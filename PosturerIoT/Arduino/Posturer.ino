#include <ESP8266HTTPClient.h>
#include <ESP8266WiFi.h>
#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
 
void setup() {
  Serial.begin(115200);                                
  WiFi.begin("nure", "");
 
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.println("Waiting for connection");
  }
  
  setIO();
}
 
void loop() {
  if (WiFi.status() == WL_CONNECTED) {  
    lcd.setCursor(0, 1);
    lcd.print(getLevel()); 
	
    sendPostRequest();
  } else {
      Serial.println("Error in WiFi connection");   
  }
 
   delay(30000);
}

void setIO() {
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  pinMode(A2, INPUT);
  
  lcd.begin(16, 2);
  lcd.print("Posture Level:");
}

void sendPostRequest() {
  HTTPClient http;
 
  http.begin("http://posturer.azurewebsites.net/api/posturelevel"); 
  http.addHeader("Content-Type", "application/json");
 
  int httpCode = http.POST("{ \"UserId\": \"74b43350-8275-42ae-91b3-152ae1944328\" \"Level\": \"" + 
								(String) getLevel() + "\"}");
 
  Serial.println(httpCode);	
  http.end();
}

float getLevel() {
 float ranger = 204.6;
 int controllersCount = 3;
 
 int controller1Value = analogRead(A0);
 int controller2Value = analogRead(A1);
 int controller3Value = analogRead(A2);
  
 return (controller1Value + controller2Value + controller3Value) / 
			(controllersCount * ranger);
}


 

