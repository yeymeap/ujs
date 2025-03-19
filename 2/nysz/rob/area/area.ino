#include <LiquidCrystal_I2C.h>
#include <Wire.h>

LiquidCrystal_I2C lcd(0x27, 16, 2); 
const int trigPin = 6;
const int echoPin = 5;
const int buttonPin = 13;

float duration, distance;
float A = 0, B = 0;
bool measuringA = true;

void setup() {
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  pinMode(buttonPin, INPUT_PULLUP);
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
  lcd.setCursor(0, 0);
  lcd.print("Area Calculator");
  lcd.setCursor(0, 1);
  lcd.print("Press to Measure");
}

void loop() {
  // Trigger ultrasonic sensor
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  // Read echo time and calculate distance
  duration = pulseIn(echoPin, HIGH);
  distance = (duration * 0.0343) / 2;

  Serial.print("Distance: ");
  Serial.println(distance);

  lcd.setCursor(0, 1);
  lcd.print("Measuring ");
  lcd.print(measuringA ? "A: " : "B: ");
  lcd.print(distance);
  lcd.print(" cm   "); // Clear trailing characters

  // Button press detection (debounce)
  if (digitalRead(buttonPin) == LOW) {
    delay(200); // Debounce delay
    while (digitalRead(buttonPin) == LOW); // Wait for release
    
    if (measuringA) {
      A = distance;
      measuringA = false;
    } else {
      B = distance;
      measuringA = true;
      float area = A * B;

      lcd.clear();
      lcd.setCursor(0, 0);
      lcd.print("A: ");
      lcd.print(A);
      lcd.print(" cm");

      lcd.setCursor(0, 1);
      lcd.print("B: ");
      lcd.print(B);
      lcd.print(" cm");
      delay(2000);

      lcd.clear();
      lcd.setCursor(0, 0);
      lcd.print("Area: ");
      lcd.print(area);
      lcd.print(" cm2");
      delay(3000);
      lcd.clear();
      lcd.setCursor(0, 0);
      lcd.print("Press to Measure");
    }
  }

  delay(100);
}
