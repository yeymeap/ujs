const int PINOUT[] = {6, 7, 8, 9, 10, 11, 12};
const int RED_PIN = 2;
const int GREEN_PIN = 3;
const int BLUE_PIN = 4;
const int BUTTON_PIN = 5;

const byte MATRIX[6][7] = {
  {0, 1, 1, 0, 0, 0, 0}, // 1
  {1, 1, 0, 1, 1, 0, 1}, // 2
  {1, 1, 1, 1, 0, 0, 1}, // 3
  {0, 1, 1, 0, 0, 1, 1}, // 4
  {1, 0, 1, 1, 0, 1, 1}, // 5
  {1, 0, 1, 1, 1, 1, 1}, // 6
};

void setup() {
  randomSeed(analogRead(A0));
  pinMode(RED_PIN, OUTPUT);
  pinMode(GREEN_PIN, OUTPUT);
  pinMode(BLUE_PIN, OUTPUT);
  pinMode(BUTTON_PIN, INPUT_PULLUP);
  for(int i = 0; i < 7; i++){
    pinMode(PINOUT[i], OUTPUT);
  }
}

void loop() {
  if(digitalRead(BUTTON_PIN) == LOW){
    clearDisplay();
    clearColor();
    int randomNum = random(1, 7);
    writeToDisplay(randomNum);
    setColor(randomNum);
    delay(250);
  }
}

void writeToDisplay(int num){
  for(int i = 0; i < 7; i++){
    digitalWrite(PINOUT[i], MATRIX[num-1][i]);
  }
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
