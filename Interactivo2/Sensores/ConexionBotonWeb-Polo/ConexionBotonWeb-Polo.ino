#include <ESP8266WiFi.h>

int buttonState = 0;    
int lastButtonState = 0;
int buttonPushCounter = 0;

//POLO
const char* ssid1 = "INFINITUMFD9C_2.4";
const char* password1 = "8q8ydR28gY";

//CASA
const char* ssid2 = "JustInternet";
const char* password2 = "thePassword";

//CASA
const char* ssid3 = "Sotres";
const char* password3 = "12345678";

const char* host = "uruguay25.mx";

int led = D1;     // LED pin D1
int button = D5; // push button is connected D0

void setup() {
  // put your setup code here, to run once:
  pinMode( button, INPUT);
  pinMode(led , OUTPUT );
  pinMode(LED_BUILTIN , OUTPUT );
 
  Serial.begin(115200);

  // Connect to WiFi network
  Serial.println();
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid1);

  WiFi.begin(ssid1, password1);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print("Not connected");
    digitalWrite(led, HIGH);
    delay(500);
    digitalWrite(led, LOW);
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

void loop() 
{ 
  buttonState = digitalRead(button);

  if (buttonState != lastButtonState) {
    // if the state has changed, increment the counter
    if (buttonState == HIGH) {
      digitalWrite(led, HIGH);
      // if the current state is HIGH then the button went from off to on:
      buttonPushCounter++;
      Serial.print("number of button pushes: ");
      Serial.println(buttonPushCounter);
    }
    // Delay a little bit to avoid bouncing
    WiFiClient client;
    const int httpPort = 80;
    if (!client.connect(host, httpPort)) {
      Serial.println("connection failed");
      digitalWrite(led, HIGH);
      delay(1000);
      digitalWrite(led, LOW);
      delay(1000);
      digitalWrite(led, HIGH);
      delay(1000);
      digitalWrite(led, LOW);
      return;
    }

    String url = "/apiUruguay/sensor4/insert.php?info1=" + String(buttonPushCounter);
    //Serial.print("Requesting URL: ");
    //Serial.println(url);

    client.print(String("GET ") + url + " HTTP/1.1\r\n" +
                 "Host: " + host + "\r\n" +
                 "Connection: close\r\n\r\n");

    while (client.available()) {
      String line = client.readStringUntil('\r');
      //Serial.print(line);
    }

    //Serial.println();
    Serial.println("PUBLICADO");
    lastButtonState = buttonState;
    digitalWrite(led, LOW);
    delay(250);
    digitalWrite(led, HIGH);
    delay(250);
    digitalWrite(led, LOW);
    
    
  }
  else{
    digitalWrite(led, LOW);}
}
