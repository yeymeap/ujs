#include <DHT11.h>

DHT11 dht11(7);

void setup() {
    Serial.begin(9600);
    Serial1.begin(9600);

}

void loop() {
    int temperature = 0;
    int humidity = 0;

    int result = dht11.readTemperatureHumidity(temperature, humidity);

    if (result == 0) {
        Serial.print("Temperature: ");
        Serial.print(temperature);
        Serial.print(" °C\tHumidity: ");
        Serial.print(humidity);
        Serial.println(" %");
        Serial1.println(temperature);
    } else {
        Serial.println(DHT11::getErrorString(result));
    }
}
