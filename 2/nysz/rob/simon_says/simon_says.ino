#define LED_RED 9
#define LED_GREEN 10
#define LED_BLUE 11
#define BUTTON_RED 2
#define BUTTON_GREEN 3
#define BUTTON_BLUE 4
#define BUTTON_YELLOW 5

const int sequenceLength = 5;
int gameSequence[sequenceLength];
int currentRound = 0;
int playerStep = 0;
bool playerTurn = false;

void setup() {
  randomSeed(analogRead(0));
  pinMode(LED_RED, OUTPUT);
  pinMode(LED_GREEN, OUTPUT);
  pinMode(LED_BLUE, OUTPUT);
  pinMode(BUTTON_RED, INPUT_PULLUP);
  pinMode(BUTTON_GREEN, INPUT_PULLUP);
  pinMode(BUTTON_BLUE, INPUT_PULLUP);
  pinMode(BUTTON_YELLOW, INPUT_PULLUP);

  GenerateSequence();
  delay(500);
  PlaySequence();
}

void loop() {
  if (playerTurn) {
    ReadInput();
  }
}

void GenerateSequence() {
  for (int i = 0; i < sequenceLength; i++) {
    gameSequence[i] = random(4);
  }
}

void PlaySequence() {
  playerTurn = false;
  for (int i = 0; i <= currentRound; i++) {
    SetLEDColor(gameSequence[i]);
    delay(500);
    TurnOffLED();
    delay(500);
  }
  playerStep = 0;
  playerTurn = true;
}

void SetLEDColor(int color) {
  switch (color) {
    case 0:
      digitalWrite(LED_RED, HIGH);
      digitalWrite(LED_GREEN, LOW);
      digitalWrite(LED_BLUE, LOW);
      break;
    case 1:
      digitalWrite(LED_RED, LOW);
      digitalWrite(LED_GREEN, HIGH);
      digitalWrite(LED_BLUE, LOW);
      break;
    case 2:
      digitalWrite(LED_RED, LOW);
      digitalWrite(LED_GREEN, LOW);
      digitalWrite(LED_BLUE, HIGH);
      break;
    case 3:
      digitalWrite(LED_RED, HIGH);
      digitalWrite(LED_GREEN, HIGH);
      digitalWrite(LED_BLUE, LOW);
      break;
  }
}

void TurnOffLED() {
  digitalWrite(LED_RED, LOW);
  digitalWrite(LED_GREEN, LOW);
  digitalWrite(LED_BLUE, LOW);
}

void ReadInput() {
  if (digitalRead(BUTTON_RED) == LOW) CheckInput(0);
  if (digitalRead(BUTTON_GREEN) == LOW) CheckInput(1);
  if (digitalRead(BUTTON_BLUE) == LOW) CheckInput(2);
  if (digitalRead(BUTTON_YELLOW) == LOW) CheckInput(3);
}

void CheckInput(int color) {
  SetLEDColor(color);
  delay(500);
  TurnOffLED();

  if (color != gameSequence[playerStep]) {
    ResetGame();
  } else {
    playerStep++;
    if (playerStep > currentRound) {
      delay(1000);
      currentRound++;
      if (currentRound == sequenceLength) {
        WinGame();
      } else {
        PlaySequence();
      }
    }
  }
}

void ResetGame() {
  TurnOffLED();
  for (int i = 0; i < 10; i++) {
    digitalWrite(LED_RED, HIGH);
    delay(50);
    digitalWrite(LED_RED, LOW);
    delay(50);
  }
  delay(500);
  currentRound = 0;
  GenerateSequence();
  PlaySequence();
}

void WinGame() {
  for (int i = 0; i < 5; i++) {
    SetLEDColor(0);
    delay(200);
    SetLEDColor(1);
    delay(200);
    SetLEDColor(2);
    delay(200);
    SetLEDColor(3);
    delay(200);
    TurnOffLED();
    delay(200);
  }
  delay(500);
  ResetGame();
}
 