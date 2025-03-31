#include <Wire.h> 
#include <Servo.h>
#include <LiquidCrystal_I2C.h>

// Constants
const int LIGHT_SENSOR_PIN = A0;  // Light sensor pin
const int SERVO_PIN = 9;          // Servo motor pin
const int POTENTIOMETER_PIN = A1; // Potentiometer pin

int threshold = 600;  // Initial threshold value

LiquidCrystal_I2C lcd(0x27,16,2);
Servo servo;  

void setup() {
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();

  // LCD labels
  lcd.setCursor(0, 0);
  lcd.print("Light Level:");
  lcd.setCursor(0, 1);
  lcd.print("Threshold:");

  pinMode(LIGHT_SENSOR_PIN, INPUT);
  pinMode(POTENTIOMETER_PIN, INPUT);

  servo.attach(SERVO_PIN);  
  servo.write(0);
}

void loop() {
  int analogValue = analogRead(LIGHT_SENSOR_PIN);  // Read light sensor
  int potValue = analogRead(POTENTIOMETER_PIN);   // Read potentiometer

  threshold = map(potValue, 0, 1023, 100, 900); // Map pot value to threshold range

  // Update threshold display
  lcd.setCursor(10, 1);
  lcd.print(threshold);

  // Update light sensor value on LCD
  lcd.setCursor(12, 0);
  lcd.print(analogValue);

  // Print values for debugging
  Serial.print("Light Sensor: "); Serial.print(analogValue);
  Serial.print(" | Potentiometer: "); Serial.print(potValue);
  Serial.print(" | Threshold: "); Serial.println(threshold);

  // Control the servo based on the light sensor reading
  if (analogValue > threshold)
    servo.write(180);  
  else
    servo.write(0);  

  delay(100); // Stability delay
}
