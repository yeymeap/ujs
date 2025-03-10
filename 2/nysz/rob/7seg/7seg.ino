  const int pinout[] = {2, 3, 4, 5, 6, 7, 8};
  const int button = 13;
  const int matrix[][7] = {
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

  void setup() {
    for(int i = 0; i < 8; i++){
      pinMode(pinout[i], OUTPUT);
    }
  }

  void loop() {
    for (int i = 0; i < 10; i++) {
      Count(i);
      delay(500);
  }
  }

  void Count(int num){
    for(int i = 0; i < 7; i++){
      digitalWrite(pinout[i], matrix[num][i]);
    }
  }
