#include <Wire.h>
#include <LiquidCrystal_I2C.h>

// Set the LCD address (usually 0x27 or 0x3F), 16 columns, and 2 rows
LiquidCrystal_I2C lcd(0x27, 16, 2);

void setup() {
  lcd.init();                      // Initialize the LCD
  lcd.backlight();                 // Turn on the backlight
  lcd.setCursor(0, 0);             // Set cursor to column 0, row 0
  lcd.print("Hello World!");      // Print message
}

void loop() {
  // No need to put anything here for a static message
}
