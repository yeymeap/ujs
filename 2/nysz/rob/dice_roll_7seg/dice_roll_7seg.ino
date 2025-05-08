const int PINOUT[] = {6, 7, 8, 9, 10, 11, 12};
const int RED_PIN = 2;
const int GREEN_PIN = 3;
const int BLUE_PIN = 4;
const int BUTTON_PIN = 5;
const int BUZZER_PIN = 44;

const byte MATRIX[6][7] = {
// A  B  C  D  E  F  G
  {0, 1, 1, 0, 0, 0, 0}, // 1
  {1, 1, 0, 1, 1, 0, 1}, // 2
  {1, 1, 1, 1, 0, 0, 1}, // 3
  {0, 1, 1, 0, 0, 1, 1}, // 4
  {1, 0, 1, 1, 0, 1, 1}, // 5
  {1, 0, 1, 1, 1, 1, 1}, // 6
};

// move prevNum here

void setup() {
  Serial.begin(9600);
  randomSeed(analogRead(A0));
  pinMode(RED_PIN, OUTPUT);
  pinMode(GREEN_PIN, OUTPUT);
  pinMode(BLUE_PIN, OUTPUT);
  pinMode(BUTTON_PIN, INPUT_PULLUP);
  pinMode(BUZZER_PIN, OUTPUT);
  for(int i = 0; i < 7; i++){
    pinMode(PINOUT[i], OUTPUT);
  }
  clearDisplay();
}

void loop() {
  if(digitalRead(BUTTON_PIN) == LOW){
    //throwAnimationSeries();
    int animationRandomNum = throwAnimationRandomized(); // obsolete if prevNum is made global
    clearDisplay();
    //clearColor();
    int randomNum;
    do{
      randomNum = random(1, 7);
    }
    while(randomNum == animationRandomNum);
    writeToDisplay(randomNum);
    setColor(randomNum);
    delay(250);
  }
}

void writeToDisplay(int num){
  for(int i = 0; i < 7; i++){
    digitalWrite(PINOUT[i], MATRIX[num-1][i]);
  }
  //Serial.println("writeToDisplay i = " + String(num - 1));
}

void clearDisplay(){
  for(int i = 0; i < 7; i++){
    digitalWrite(PINOUT[i], LOW);
  }
}

void setColor(int num) {
  switch(num) {
    case 1: // Red
      analogWrite(RED_PIN, 255);  
      analogWrite(GREEN_PIN, 0);
      analogWrite(BLUE_PIN, 0);
      break;
    case 2: // Green
      analogWrite(RED_PIN, 0);
      analogWrite(GREEN_PIN, 255);  
      analogWrite(BLUE_PIN, 0);
      break;
    case 3: // Blue
      analogWrite(RED_PIN, 0);
      analogWrite(GREEN_PIN, 0);
      analogWrite(BLUE_PIN, 255);
      break;
    case 4: // Yellow
      analogWrite(RED_PIN, 255);
      analogWrite(GREEN_PIN, 255);
      analogWrite(BLUE_PIN, 0);
      break;
    case 5: // Pink
      analogWrite(RED_PIN, 255);
      analogWrite(GREEN_PIN, 0);
      analogWrite(BLUE_PIN, 255);
      break;
    case 6: // Cyan
      analogWrite(RED_PIN, 0);
      analogWrite(GREEN_PIN, 255);
      analogWrite(BLUE_PIN, 255);
      break;
  }
}


void clearColor(){
  analogWrite(RED_PIN, 0);
  analogWrite(GREEN_PIN, 0);
  analogWrite(BLUE_PIN, 0);
  }

void throwAnimationSeries(){
  for(int i = 0; i < 6; i++){
    //Serial.println("throwAnimation i = " + String(i));
    clearDisplay();
    writeToDisplay(i+1);
    setColor(i+1);
    delay(250);
  }
}

int throwAnimationRandomized(){ // refactor
  int prevNum = 0;
  int lastNum;
  for(int i = 0; i < 6; i++){
    int randomNum;
    do{
      randomNum = random(1, 7);
    }
    while(randomNum == prevNum);
    prevNum = randomNum;
    tickTone();
    if(i == 5){
      lastNum = randomNum;
    }
    Serial.println("random int = " + String(randomNum));
    clearDisplay();
    writeToDisplay(randomNum);
    setColor(randomNum);
    delay(250);
  }
  finalTone();
  return lastNum;
}

void tickTone(){
  tone(BUZZER_PIN, 250, 50);
  //delay(50);
}

void finalTone() {
    tone(BUZZER_PIN, 500, 200);
}
