#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const int levelsCount = 3;
const float rangeValue = 204.6;
const int delayTime = 500;

int buttonState;
int switchState;

int level1Pin = A0;
int level2Pin = A1;
int level3Pin = A2;

int buttonPin = 6;
int switchPin = 10;
int ledPin = 13;

String ssid     = "Simulator Wifi"; 
String password = "";

String host     = "posturer.azurewebsites.net";
const int httpPort   = 80;
String uri		 = "/api/posturelevel/";

void setup() {
    Serial.begin(9600);

    setupPins();
    setupLCD(); 
 	setupWiFi();
}

void setupPins() {
    pinMode(level1Pin, INPUT);
    pinMode(level2Pin, INPUT);
    pinMode(level3Pin, INPUT);

    pinMode(buttonPin, INPUT);
    pinMode(switchPin, INPUT);

    pinMode(ledPin, OUTPUT); 
}

void setupLCD() {
    lcd.begin(16, 2);
    lcd.print("Posture Level:"); 
}

void setupWiFi() {
 	Serial.begin(115200);		
    Serial.println("AT");		
    delay(10);				
    Serial.println("AT+CWJAP=\"" + ssid + "\",\"" + password + "\"");
    delay(10);				

    Serial.println("AT+CIPSTART=\"TCP\",\"" + host + "\"," + httpPort);
    delay(50); 
}

void loop() {  
    switchState = digitalRead(switchPin);

    if (switchState) {
        printLevel();
        delay(delayTime);
    } else {
		sendPostureLevel();
    } 
}

void sendPostureLevel() {
	buttonState = digitalRead(buttonPin);
  
    if (buttonState == HIGH) {
        printLevel();
      	sendRequest();
        digitalWrite(ledPin, HIGH);
      
        delay(delayTime);
    } else {
        digitalWrite(ledPin, LOW);
    }  
        delay(10);
}

void sendRequest() {
    String httpPacket = getPacket();
    int length = httpPacket.length();  

    Serial.print("AT+CIPSEND=");
    Serial.println(length);
    delay(10);

    Serial.print(httpPacket);
    delay(3000); 
}

String getPacket() {
 	return "GET " + uri + getPostureLevel() + " HTTP/1.1\r\nHost: " + host + "\r\n\r\n"; 
}

void printLevel() {
    lcd.setCursor(0, 1);
  	lcd.print(getPostureLevel()); 
}

int getPostureLevel() {
   int level1Value = analogRead(level1Pin);
   int level2Value = analogRead(level2Pin);
   int level3Value = analogRead(level3Pin);

   return (level1Value + level2Value + level3Value) / 
			(levelsCount * rangeValue);
}