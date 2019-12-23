#include <ESP8266WiFi.h>

#define sensor D2

#define LED D1 // Led in NodeMCU at pin GPIO16 (D0).

//PIBE
const char* ssid1 = "INFINITUM6038_2.4";
const char* password1 = "1942842573";

//CASA
const char* ssid2 = "JustInternet";
const char* password2 = "thePassword";

//CASA
const char* ssid3 = "Sotres";
const char* password3 = "12345678";
const char* host = "uruguay25.mx";

int count = 0;
int state = LOW; 

// Create an instance of the server
// specify the port to listen on as an argument

void setup() {
    Serial.begin(115200);
    delay(100);
    
    pinMode(LED, OUTPUT);     // Initialize the LED_BUILTIN pin as an output
    pinMode(sensor, INPUT);
    
    // Connect to WiFi network
    Serial.println();
    Serial.println();
    Serial.print("Connecting to ");
    Serial.println(ssid1);
    
    WiFi.begin(ssid1, password1);
    
    while (WiFi.status() != WL_CONNECTED) {
      delay(500);
      Serial.print(".");
      Serial.print("Not connected");
      
      digitalWrite(LED, HIGH);
      delay(500);
      digitalWrite(LED, LOW);
    }
    Serial.println("");
    Serial.println("WiFi connected");  
    
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());
    
    Serial.print("Netmask: ");
    Serial.println(WiFi.subnetMask());
    
    Serial.print("Gateway: ");
    Serial.println(WiFi.gatewayIP());
}

void loop() {
  long vibracion = pulseIn(sensor, HIGH);
  if (vibracion > 2000) 
  {
  //int sensorValue = digitalRead(sensor);   
    digitalWrite(LED, HIGH);   // turn LED ON
    delay(100); 
    // delay 100 milliseconds 
    count ++;
    Serial.println(count);
    //delay(1000);

    Serial.print("connecting to ");
    Serial.println(host);

    WiFiClient client;
    const int httpPort = 80;
    if (!client.connect(host, httpPort)) {
      Serial.println("connection failed");
      return;
    }
  
    String url = "/apiUruguay/sensor1/insert.php?info1=" + String(count);
    //Serial.print("Requesting URL: ");
    //Serial.println(url);
    
    client.print(String("GET ") + url + " HTTP/1.1\r\n" +
                "Host: " + host + "\r\n" + 
                "Connection: close\r\n\r\n");

    digitalWrite(LED, HIGH);
    delay(250);
    digitalWrite(LED, LOW); 
    delay(250);
    digitalWrite(LED, HIGH);
    delay(250);
    digitalWrite(LED, LOW);

    
    while(client.available()){
      String line = client.readStringUntil('\r');
      //Serial.print(line);
    }

    
    Serial.println();
    Serial.println("PUBLICADO");
  }   
  else{
    digitalWrite(LED, LOW); // turn LED OFF
    delay(200);             // delay 200 milliseconds 
          
   
  } 
}
