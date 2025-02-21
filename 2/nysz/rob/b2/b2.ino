  int red = 3;
  int yellow = 4;
  int green = 5;
  int del = 500;
  int pullup = 2;
  bool state = false;
  
void setup() {
  
  pinMode(red, OUTPUT);
  pinMode(yellow, OUTPUT);
  pinMode(green, OUTPUT);
  pinMode(pullup, INPUT_PULLUP);
  digitalWrite(red, HIGH);
}
void loop() {
  static bool lastState = HIGH;
  int sensorVal = digitalRead(pullup);
  if(sensorVal == LOW && lastState == HIGH){
    state = !state;
    if(state){
      toGreen();
    }
    else{
      toRed();
      }
    }
}

void toGreen(){
  delay(1000);
  digitalWrite(yellow, HIGH);
  delay(1000);
  digitalWrite(red, LOW);
  digitalWrite(yellow, LOW);
  digitalWrite(green, HIGH);
  }

void toRed(){
  for(int i = 0; i <= 3; i++){
    greenBlink();
    if(i == 3){
      digitalWrite(green, LOW);
    }
  }
  digitalWrite(yellow, HIGH);
  delay(1000);
  digitalWrite(yellow, LOW);
  digitalWrite(red, HIGH);
  }

void greenBlink(){
  delay(del);
  digitalWrite(green, LOW);
  delay(del);
  digitalWrite(green, HIGH);
}