void setup() {
  Serial.begin(9600);
}

void loop() {
  int receivedNum;
  if (Serial.available() > 0){
    receivedNum = Serial.parseInt();
  }
    Serial.print("Received: ");
    Serial.println(receivedNum);
}
