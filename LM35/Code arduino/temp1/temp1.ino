#include <Wire.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27, 20, 4);
int ledNhiet1 = A0;
int ledNhiet2 = A1;
int Humility;
int Ed, Ew;
int led1 = 5;
int led3 = 6;
int ndcd = 30;
int nhan = 0;
int dacd = 80;
int manhinh = 1;
const int btnextpin = 7;
const int btbackpin = 8;
const int bttangpin = 9;
const int btgiampin = 10;

void setup() {
  // put your setup code here, to run once:
  pinMode(led1, OUTPUT);
  pinMode(led3, OUTPUT);
  pinMode(btnextpin, INPUT_PULLUP);
  pinMode(btbackpin, INPUT_PULLUP);
  pinMode(bttangpin, INPUT_PULLUP);
  pinMode(btgiampin, INPUT_PULLUP);
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
}

void loop()
{
  // put your main code here, to run repeatedly:
  if (manhinh == 1)
  {
    Serial.print("Nguyen");
    Serial.print(" Minh");
    Serial.print("Tan");
    Serial.println();
    lcd.setCursor(0, 0);
    lcd.print("Do nhiet do va do am");
    lcd.setCursor(0, 1);
    lcd.print("Nguyen Minh Tan");
    lcd.setCursor(0, 2);
    lcd.print("18118125");
    lcd.setCursor(0, 3);
    lcd.print("BACK");
    lcd.setCursor(16, 3);
    lcd.print("NEXT");
    ////////////////////////////////////
    if (digitalRead(btnextpin) == LOW)
    {
      delay(200);
      manhinh = 2; lcd.clear();
    }
    /////////////////////////////
  }
  if (manhinh == 2)
  {
    lcd.setCursor(0, 0);
    lcd.print("Do nhiet do va do am");
    lcd.setCursor(0, 1);
    lcd.print("Nhiet do cai dat:");
    lcd.setCursor(8, 2);
    lcd.print(ndcd);
    lcd.setCursor(0, 3);
    lcd.print("BACK");
    lcd.setCursor(16, 3);
    lcd.print("NEXT");
    if (digitalRead(bttangpin) == LOW)
    {
      ndcd++;
    }
    if (digitalRead(btgiampin) == LOW)
    {
      ndcd--;
    }
    ////////////////////////////////////////////
        if (digitalRead(btnextpin) == LOW)
        {
          delay(200);
          manhinh = 3; lcd.clear();
    
        }
        if (digitalRead(btbackpin) == LOW)
        {
          delay(200);
          manhinh = 1;lcd.clear();
        }
   //////////////////////////////////////////
  }
  if (manhinh == 3)
  {
    lcd.setCursor(0, 0);
    lcd.print("Do nhiet do va do am");
    lcd.setCursor(0, 1);
    lcd.print("Do Am Cai Dat:");
    lcd.setCursor(8, 2);
    lcd.print(dacd);
    lcd.setCursor(0, 3);
    lcd.print("BACK");
    lcd.setCursor(16, 3);
    lcd.print("NEXT");
    if (digitalRead(bttangpin) == LOW)
    {
      dacd++;
    }
    if (digitalRead(btgiampin) == LOW)
    {
      dacd--;
    }
    ///////////////////////////////////////////
        if (digitalRead(btnextpin) == LOW)
        {
          delay(200);
          manhinh = 4; lcd.clear();
    
        }
        if (digitalRead(btbackpin) == LOW)
        {
          delay(200);
          manhinh = 2;lcd.clear();
    /////////////////////////////////////////////////////
        }
  }
  if (manhinh == 4)
  {

    lcd.setCursor(0, 0);
    lcd.print("temp1: ");
    lcd.setCursor(0, 1);
    lcd.print("temp2:");
    lcd.setCursor(0, 2);
    lcd.print("Do am");
    lcd.setCursor(0, 3);
    lcd.print("BACK");
    doccambien();
    //////////////////////////////////////////
    if (digitalRead(btbackpin) == LOW)
    {
      delay(200);
      manhinh = 3;lcd.clear();
    }
    ///////////////////////////////////////
  }
}
void doccambien()
{
  int doc_cam_bien1 = analogRead(ledNhiet1);
  int doc_cam_bien2 = analogRead(ledNhiet2);
  float temp1 = doc_cam_bien1 * 5.0 / 1024.0;
  float temp2 = doc_cam_bien2 * 5.0 / 1024.0;
  int nhiet_do1 = temp1 * 100.0;
  int nhiet_do2 = temp2 * 100.0;
  float  Ed = 6.112 * pow(2.71828, (17.502 * nhiet_do1) / (240.97 + nhiet_do1));
  float Ew = 6.112 * pow(2.71828, (17.502 * nhiet_do2) / (240.97 + nhiet_do2));
  float Humidity = ((Ew - 0.66875 * (1 + 0.00115 * nhiet_do2) * (nhiet_do1 - nhiet_do2)) / Ed) * 100;
  lcd.setCursor(8, 0);
  lcd.print(nhiet_do1);
  lcd.setCursor(12, 0);
  lcd.print("do C");
  lcd.setCursor(8, 1);
  lcd.print(nhiet_do2);
  lcd.setCursor(12, 1);
  lcd.print("do C");
  lcd.setCursor(8, 2);
  lcd.print(Humidity);
  lcd.setCursor(14, 2);
  lcd.print("%");
  // delay(500);
//  Serial.println(nhiet_do1);
//  Serial.println(nhiet_do2);
//  Serial.println(Humidity);
  Serial.print("Nguyen Minh Tan ");
  Serial.println("23 tuoi");

  if (nhiet_do1 > ndcd)
  {
    digitalWrite(led1, HIGH);
  }
  else
  {
    digitalWrite(led1, LOW);
  }

  if (Humility > dacd)
  {
    digitalWrite(led3, HIGH);
  }
  else
  {
    digitalWrite(led3, LOW);
  }
  delay(500);

}
