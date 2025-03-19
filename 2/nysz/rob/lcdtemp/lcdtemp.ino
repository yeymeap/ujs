#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27,16,2);  // set the LCD address to 0x27 for a 16 chars and 2 line display

void setup()
{
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
  lcd.setCursor(0,0);
  lcd.print("Temperature: ");
}


void loop()
{
  int receivedNum;
  if (Serial.available() > 0){
    receivedNum = Serial.parseInt();
  }
  lcd.setCursor(0,1);
  lcd.print(receivedNum);
  Serial.print("Received: ");
  Serial.println(receivedNum);
  delay(1000);
}
