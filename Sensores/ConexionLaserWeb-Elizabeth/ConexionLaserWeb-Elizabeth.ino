// Conexion laser Elizabeth

#include <ESP8266WiFi.h>
#define LED D1 // Led in NodeMCU at pin GPIO16 (D0).

#define resistencia A0

//ELIZABETH
const char* ssid1 = "INFINITUMBCA4"; 
const char* password1 = "1g589018077";

//CASA
const char* ssid2 = "JustInternet";
const char* password2 = "thePassword";

const char* host = "uruguay25.mx";

int count = 0;

// Create an instance of the server
// specify the port to listen on as an argument

void setup() {
    Serial.begin(115200);
    delay(100);
    
    pinMode(LED, OUTPUT);     // Initialize the LED_BUILTIN pin as an output    
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

  int sensorValue = analogRead(resistencia);   // read the input on analog pin 0
  float voltage = sensorValue * (5.0 / 1023.0);   // Convert the analog reading (which goes from 0 - 1023) to a voltage (0 - 5V)

  //Serial.println(voltage);
  if(voltage > .50){
    digitalWrite(LED_BUILTIN, LOW);
    Serial.println("HIGH");
    count ++;
    Serial.println(count);
    delay(1000);

    Serial.print("connecting to ");
    Serial.println(host);

    WiFiClient client;
    const int httpPort = 80;
    if (!client.connect(host, httpPort)) {
      Serial.println("connection failed");
      return;
    }
  
    String url = "/apiUruguay/sensor3/insert.php?info1=" + String(count);
    Serial.print("Requesting URL: ");
    Serial.println(url);
    
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
      Serial.print(line);
    }
    
    Serial.println();
    Serial.println("closing connection");
    }
  else{
    digitalWrite(LED, HIGH);
  } 
}
