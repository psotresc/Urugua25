#include <ESP8266WiFi.h>

const int sensorVentana = 5;

//ANTONIO 
const char* ssid1 = "INFINITUM5C89";
const char* password1 = "4660010816";

//CASA
const char* ssid2 = "JustInternet";
const char* password2 = "thePassword";

const char* host = "uruguay25.mx";

int count = 0;
bool activo = false;

// Create an instance of the server
// specify the port to listen on as an argument

void setup() {
  Serial.begin(115200);
  delay(100);

  pinMode(LED_BUILTIN, OUTPUT);     // Initialize the LED_BUILTIN pin as an output
  //pinMode(sensorVentana, INPUT_PULLUP);

  // Connect to WiFi network
  Serial.println();
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid1);

  WiFi.begin(ssid1, password1);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print("Not connected");
    pinMode(LED_BUILTIN, HIGH);
    delay(500);
    pinMode(LED_BUILTIN, LOW);
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

  int sensorState = digitalRead(sensorVentana);
  //Serial.println(sensorState);
  delay(1);

  if (sensorState == 0 && activo == false) {
    digitalWrite(LED_BUILTIN, HIGH);
    Serial.println("Activado");
    count ++;
    Serial.println(count);
    activo = true;
    delay(1000);

    //Serial.print("connecting to ");
    //Serial.println(host);

    WiFiClient client;
    const int httpPort = 80;
    if (!client.connect(host, httpPort)) {
      Serial.println("connection failed");
      digitalWrite(LED_BUILTIN, HIGH);
      delay(1000);
      digitalWrite(LED_BUILTIN, LOW);
      delay(1000);
      digitalWrite(LED_BUILTIN, HIGH);
      delay(1000);
      digitalWrite(LED_BUILTIN, LOW);
      return;
    }

    String url = "/apiUruguay/sensor2/insert.php?info1=" + String(count);
    //Serial.print("Requesting URL: ");
    //Serial.println(url);

    client.print(String("GET ") + url + " HTTP/1.1\r\n" +
                 "Host: " + host + "\r\n" +
                 "Connection: close\r\n\r\n");
    delay(500);

    while (client.available()) {
      String line = client.readStringUntil('\r');
      //Serial.print(line);
    }

    //Serial.println();
    Serial.println("PUBLICADO");
  }
  else if (sensorState == 0 && activo == true) {
    //Serial.println("se quedo abierto");
  }


  else {
    digitalWrite(LED_BUILTIN, LOW);
    activo = false;
    //Serial.println("esta cerrado");
  }
}
