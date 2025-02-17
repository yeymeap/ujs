const int ledPin = 5; // PWM output pin
const int ledPin1 = 3;
cons int ledPin2 = 6;
int brightness = 127;   // Initial brightness
int delayms = 150;

void setup() {
  pinMode(ledPin, OUTPUT);
  pinMode(ledPin1, OUTPUT);
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  digitalWrite(LED_BUILTIN, HIGH);  // turn the LED on (HIGH is the voltage level)
  analogWrite(ledPin, brightness);
  delay(delayms); // Adjust speed of fading
  analogWrite(ledPin, 0);
  delay(delayms);
  analogWrite(ledPin, brightness);
  delay(delayms);
  analogWrite(ledPin, 0);
  digitalWrite(LED_BUILTIN, LOW);  // turn the LED on (HIGH is the voltage level)
  analogWrite(ledPin1, brightness);
  delay(delayms); // Adjust speed of fading
  analogWrite(ledPin1, 0);
  delay(delayms);
  analogWrite(ledPin1, brightness);
  delay(delayms);
  analogWrite(ledPin1, 0);
}
