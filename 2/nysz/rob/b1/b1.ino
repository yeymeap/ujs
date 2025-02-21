#define RED_PIN 8
#define GREEN_PIN 9
#define BLUE_PIN 10

void setup() {
  pinMode(RED_PIN, OUTPUT);
  pinMode(GREEN_PIN, OUTPUT);
  pinMode(BLUE_PIN, OUTPUT);
}

void loop() {
  rainbowCycle(5);
}

void rainbowCycle(int delayTime) {
  int r, g, b;
  
  for (int i = 0; i < 256; i++) {
    r = wheel((i + 85) % 255);
    g = wheel((i + 170) % 255);
    b = wheel(i);
    analogWrite(RED_PIN, r);
    analogWrite(GREEN_PIN, g);
    analogWrite(BLUE_PIN, b);
    delay(delayTime);
  }
}

int wheel(byte pos) {
  if (pos < 85) {
    return pos * 3;
  } else if (pos < 170) {
    pos -= 85;
    return 255 - pos * 3;
  } else {
    pos -= 170;
    return 0;
  }
}
