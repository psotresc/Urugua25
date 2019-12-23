
// constants won't change. They're used here to set pin numbers:
const int buttonPin1 = 5;    // the number of the pushbutton pin
const int buttonPin2 = 6;
const int buttonPin3 = 7;

// Variables will change:
int buttonState1;             // the current reading from the input pin
int buttonState2;             // the current reading from the input pin
int buttonState3;             // the current reading from the input pin

int lastButtonState1 = HIGH;   // the previous reading from the input pin
int lastButtonState2 = LOW;   // the previous reading from the input pin
int lastButtonState3 = HIGH;   // the previous reading from the input pin

int count1 = 0;
int count2 = 0;
int count3 = 0;

int presionado = LOW;

// the following variables are unsigned longs because the time, measured in
// milliseconds, will quickly become a bigger number than can be stored in an int.
unsigned long lastDebounceTime1 = 0;  // the last time the output pin was toggled
unsigned long debounceDelay1 = 50;    // the debounce time; increase if the output flickers

unsigned long lastDebounceTime2 = 0;  // the last time the output pin was toggled
unsigned long debounceDelay2 = 50;    // the debounce time; increase if the output flickers

unsigned long lastDebounceTime3 = 0;  // the last time the output pin was toggled
unsigned long debounceDelay3 = 10;    // the debounce time; increase if the output flickers

void setup() {
  pinMode(buttonPin1, INPUT);
  pinMode(buttonPin2, INPUT);
  pinMode(buttonPin3, INPUT);
  
  Serial.begin(9600);
}

void loop() {
  // read the state of the switch into a local variable:
  int reading1 = digitalRead(buttonPin1);
  int reading2 = digitalRead(buttonPin2);
  int reading3 = digitalRead(buttonPin3);

  //Serial.println(reading3);
  // check to see if you just pressed the button
  // (i.e. the input went from LOW to HIGH), and you've waited long enough
  // since the last press to ignore any noise:

  //////////////////////////////////////////////////////////////////////////////////////////////
  // If the switch changed, due to noise or pressing:
  if (reading1 != lastButtonState1) {\
    // reset the debouncing timer
    lastDebounceTime1 = millis();
  }

  if (reading2 != lastButtonState2) {\
    // reset the debouncing timer
    lastDebounceTime2 = millis();
  }

  if (reading3 != lastButtonState3) {
    //Aqui es cero
    // reset the debouncing timer
    lastDebounceTime3 = millis();
  }

//  //UNO   ////////////////////////////////////////////////////////////////////////////////////////////
  
  ////
  if ((millis() - lastDebounceTime1) > debounceDelay1) {
    // whatever the reading is at, it's been there for longer than the debounce
    // delay, so take it as the actual current state:
    
    // if the button state has changed:
    if (buttonState1 != reading1 ) {
      
      
    
    //
      if (buttonState1 == HIGH) {
        // if the current state is HIGH then the button went from off to on:
        //Serial.println("Arriba//////////////////////////////////");
        Serial.write(1);
        Serial.flush();
        presionado = LOW;

    } else {
        // if the current state is LOW then the button went from on to off:
        //Serial.println("Abajo////////////////////////////////////");
        Serial.write(3);
        Serial.flush();
    }
    
   }
   if (reading1 ==HIGH ){
    //Serial.println("Activo");
    Serial.write(2);
    Serial.flush();
    delay(110);
    //presionado = HIGH;
    } 
    buttonState1 = reading1;
    //
  }
  

  //DOS   ////////////////////////////////////////////////////////////////////////////////////////////
  if ((millis() - lastDebounceTime2) > debounceDelay2) {
    // whatever the reading is at, it's been there for longer than the debounce
    // delay, so take it as the actual current state:
    
    // if the button state has changed:
    if (reading2 != buttonState2) {
      buttonState2 = reading2;
      //Serial.println(buttonState2);
      
      
      // only toggle the LED if the new button state is HIGH
      if (buttonState2 == HIGH) {
        //Serial.println("LEFT");
        Serial.write(5);
        Serial.flush();
        //delay(100);
      }
    }
  }
  
  //TRES   ////////////////////////////////////////////////////////////////////////////////////////////
  if ((millis() - lastDebounceTime3) > debounceDelay3) {
    // whatever the reading is at, it's been there for longer than the debounce
    // delay, so take it as the actual current state:

    // Aqui es 0 
    // if the button state has changed:
    if (reading3 != buttonState3) {
      buttonState3 = reading3;

      //Serial.println(buttonState3);
      // only toggle the LED if the new button state is HIGH
      if (buttonState3 == HIGH) {
        //count3++;
        //Serial.println(count3);
        //Serial.println("RIGHT");
        Serial.write(4);
        Serial.flush();
        //delay(100);
      }
    }
  }
  
  // save the reading. Next time through the loop, it'll be the lastButtonState:
  lastButtonState1 = reading1;
  lastButtonState2 = reading2;
  lastButtonState3 = reading3;
  //Serial.flush();
  //delay(200);
  //////////////////////////////////////////////////////////////////////////////////
}
