
/*                    THINGS TO DO
 *     DONE     - Control Pump using GUI slider
 *              - Control Electrolysis using GUI Grid 
 *              - Control Electrolysis Fire Patterns
 *              
 *              - Control analog ON/OFF Button / Electrolysis
 *              - Control analog ON/OFF Buton  / Pump 
 *              - Analog potentiometer for Pump 
 *             
 *              - Analog/Digital Overwrite Function
 *  
 *  
 *
 *    Electrolysis mode is controlled by reading Strings from
 *    the Serial Port. If "Ev7" is received, the 7th vertical 
 *    wire will be activated. 
 * 
 *        E       Electrolysis Case
 *        h/v     Horizonal or Vertical
 *        1...8   Wire Number
 * 
 * 
 * ------------DECODING SEQUENCE----------------- 
 * 
 *    1.  String "Eh4" (example) is received from Serial
 *    2.  Recieved String is stored on string data
 *    3.  String POS[0] is stored in d1 as a char 
 *    4.  Case (Operation) is determined 
 *    
 *    5.  String POS[1] is determined and stored  
 *           -  string if integer is required
 *           -  char if char is required 
 *    6.  String POS[2] is determined and stored and converted to char
 *    
 *    Chars can be used to determine a switch case.
 * 
 */

#include <BTS7960.h>

#define L_EN 8        
#define R_EN 7
#define L_PWM 5                             
#define R_PWM 6 


#define h1 26
#define h2 27
#define h3 28
#define h4 29
#define h5 30
#define h6 31
#define h7 32
#define h8 33

#define v1 40
#define v2 41
#define v3 42
#define v4 43
#define v5 44
#define v6 45
#define v7 46
#define v8 47
BTS7960 motor(L_EN, R_EN, L_PWM, R_PWM);   //object class BTS7960

//ENCODES VALUES 
//String being read from C#
String data;  
//Used for storing String pos[0], decides       
char d1;
//Used for reading Motor value from data          
String x; 



bool buttonState = false;
          
//Electrolysis Horizontal or vertical, takes cases 'h' and 'v' 
char Ex;
//Electrolysis Wire number from '1' to '8'           
char WireNumber;      
 
void setup() {
  Serial.begin(9600);
  Serial1.begin(9600);
  pinMode(10, OUTPUT);
  pinMode(4, INPUT_PULLUP); 

  motor.begin();                           //This method will set the motor driver pins as output
  motor.enable();
  
}

void loop() {

  if(Serial.available()){
    data = Serial.readString();
    d1 = data.charAt(0);        //reads first character, determines case 

//----------------------TURN MOTOR ON AND OFF------------------------
    
    switch(d1){           // select action based on first character
      case '1':           // first character is "1" = turn on       
      analogWrite(10, 255);

      
      motor.pwm = 255; 
      break;
      
      case '0':           // first character is "0" = turn off
        
      analogWrite(10, LOW);  
      break;

      case'E':
      Electro();
      break;

    }
  }  
}

//------------------ELECTROLYSIS DIGITAL CONTROL----------------------

void Electro(void) {
  char Ex = data.charAt(1);
  char WireNumber = data.charAt(2);

  switch (Ex) {
    case 'h':
      ActivateWire(true, WireNumber);
      break;
    case 'v':
      ActivateWire(false, WireNumber);
      break;
    case '1':
      setPins(HIGH);
      break;
    case '0':
      setPins(LOW);
      break;
  }
}

void ActivateWire(bool isHorizontal, char WireNumber) {
  int pin;
  if (isHorizontal) {
    pin = h1 + (WireNumber - '1');
  } else {
    pin = v1 + (WireNumber - '1');
  }
  char onoff = data.charAt(3);
  if(onoff=='0'){
    digitalWrite(pin, LOW);
    analogWrite(10, 0);
  }
  else{
    digitalWrite(pin, HIGH);
    analogWrite(10, 255);
  }

}

void setPins(bool state){
  
  digitalWrite(h1, state);
  digitalWrite(h2, state);
  digitalWrite(h3, state);
  digitalWrite(h4, state);
  digitalWrite(h5, state);
  digitalWrite(h6, state);
  digitalWrite(h7, state);
  digitalWrite(h8, state);  
  digitalWrite(v1, state);
  digitalWrite(v2, state);
  digitalWrite(v3, state);
  digitalWrite(v4, state);
  digitalWrite(v5, state);
  digitalWrite(v6, state);
  digitalWrite(v7, state);
  digitalWrite(v8, state);    
  
}
