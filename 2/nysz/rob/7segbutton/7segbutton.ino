const int PINOUT[] = {2, 3, 4, 5, 6, 7, 8};
const int BUTTON = 13;
const int MATRIX[][7] = {
  {1, 1, 1, 1, 1, 1, 0},
  {0, 1, 1, 0, 0, 0, 0},
  {1, 1, 0, 1, 1, 0, 1},
  {1, 1, 1, 1, 0, 0, 1},
  {0, 1, 1, 0, 0, 1, 1},
  {1, 0, 1, 1, 0, 1, 1},
  {1, 0, 1, 1, 1, 1, 1},
  {1, 1, 1, 0, 0, 0, 0},
  {1, 1, 1, 1, 1, 1, 1},
  {1, 1, 1, 0, 0, 1, 1}
};
int n = 0;
void setup() {
  for(int i = 0; i < 8; i++){
    pinMode(PINOUT[i], OUTPUT);
  }
  pinMode(BUTTON, INPUT_PULLUP);
  Count(n);
}

void loop() {
  int sensorVal = digitalRead(BUTTON);
  if(sensorVal == HIGH){
      n++;
      Count(n);
      }
    if(n > 8){
    n = 0;
    }
 }


void Count(int num){
  for(int i = 0; i < 7; i++){
    digitalWrite(PINOUT[i], MATRIX[num][i]);
  }
}
