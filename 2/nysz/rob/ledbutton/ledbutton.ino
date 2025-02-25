#define LED 3
#define BUTTON 2

void setup() {
  Serial.begin(9600);
  pinMode(LED, OUTPUT);
  pinMode(BUTTON, INPUT_PULLUP); 
}

void loop() {
  bool sensorValue = digitalRead(BUTTON);
  delay(1);
  if(!sensorValue){
    for(int i = 0; i < 3; i++){
    delay(50);
    digitalWrite(LED, HIGH);
    delay(250);
    digitalWrite(LED, LOW);
    delay(250);
    }
  }
  else{
    digitalWrite(LED, LOW);
  }
}
