#include <Keypad.h>
#include <Servo.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>

// Keypad setup
const byte ROWS = 4;
const byte COLS = 4;
char keys[ROWS][COLS] = {
  {'1','2','3','A'},
  {'4','5','6','B'},
  {'7','8','9','C'},
  {'*','0','#','D'}
};
byte rowPins[ROWS] = {A0, A1, A2, A3};
byte colPins[COLS] = {5, 4, 3, 2};
Keypad keypad = Keypad(makeKeymap(keys), rowPins, colPins, ROWS, COLS);

// LCD
LiquidCrystal_I2C lcd(0x27, 16, 2);

// Servo
Servo servo;
const int ServoPin = 11;

// RGB LED pins (common cathode)
int redPin = 6;
int greenPin = 9;
int bluePin = 10;

// Buzzer pin
int buzzer = 8;

// Multiple valid PINs
String validPINs[] = {"1234", "4321", "2468"};
const int numberOfPINs = sizeof(validPINs) / sizeof(validPINs[0]);

// Tries
const int maxTries = 3;
int triesLeft = maxTries;

void setup() {
  Serial.begin(9600);

  lcd.init();
  lcd.backlight();
  lcd.setCursor(0, 0);
  lcd.print("Enter PIN:");

  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);
  pinMode(buzzer, OUTPUT);

  servo.attach(ServoPin);
  servo.write(0); // Locked

  setColor(0, 0, 0); // LED off
}

void loop() {
  String enteredPIN = "";
  lcd.setCursor(0, 1);
  lcd.print("PIN: ");
  
  while (true) {
    char key = keypad.getKey();
    if (key) {
      if (isDigit(key)) {
        enteredPIN += key;
        lcd.print("*");
      } 
      else if (key == '#') { // Clear
        enteredPIN = "";
        lcd.setCursor(5, 1);
        lcd.print("        "); // Clear PIN display area
        lcd.setCursor(5, 1);
      } 
      else if (key == '*') { // Submit
        break;
      }
    }
  }

  delay(500);

  if (isValidPIN(enteredPIN)) {
    signalSuccess();
    triesLeft = maxTries; // Reset tries after success
  } else {
    triesLeft--;
    signalFailure(enteredPIN, triesLeft);

    if (triesLeft <= 0) {
      alarmMode();
      cooldownMode(10); // 10 seconds cooldown
      triesLeft = maxTries; // Reset after cooldown
    }
  }

  delay(2000);
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Enter PIN:");
}

bool isValidPIN(String pin) {
  for (int i = 0; i < numberOfPINs; i++) {
    if (pin == validPINs[i]) {
      return true;
    }
  }
  return false;
}

void signalSuccess() {
  setColor(0, 255, 0); // Green
  tone(buzzer, 1000, 200);
  delay(200); // Let the tone finish
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Access Granted");
  servo.write(90); // Open
  delay(3000);
  servo.write(0);  // Close
  setColor(0, 0, 0); // LED off
}

void signalFailure(String wrongPIN, int triesLeft) {
  setColor(255, 0, 0); // Red
  tone(buzzer, 200, 500);
  delay(500); // Let the tone finish
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Wrong PIN:");
  lcd.setCursor(0, 1);
  lcd.print(wrongPIN);
  lcd.print(" T:");
  lcd.print(triesLeft);
  //delay(1000);
  setColor(0, 0, 0); // LED off
}

void alarmMode() {
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("LOCKED OUT!");
  lcd.setCursor(0, 1);
  lcd.print("Security Alert!");

  for (int i = 0; i < 5; i++) { // 20 x 500ms = 10 seconds
    setColor(255, 0, 0);
    tone(buzzer, 400, 250); // Beep 250ms
    delay(250);             // Wait 500ms
    setColor(0, 0, 0);
    delay(250);
  }

  noTone(buzzer);
  setColor(0, 0, 0);
}

void cooldownMode(int seconds) {
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Cooldown active");

  for (int i = seconds; i > 0; i--) {
    lcd.setCursor(0, 1);
    lcd.print("Wait: ");
    lcd.print(i);
    lcd.print("s   "); // Extra spaces to clear leftover chars

    tone(buzzer, 500, 100); // Small beep every second
    setColor(255, 0, 0);
    delay(500);
    setColor(0, 0, 0);
    delay(500);
  }

  noTone(buzzer);
  setColor(0, 0, 0);
}

void setColor(int redVal, int greenVal, int blueVal) {
  analogWrite(redPin, redVal);
  analogWrite(greenPin, greenVal);
  analogWrite(bluePin, blueVal);
}
