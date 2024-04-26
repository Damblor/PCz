//Autorzy: Piotr Krupa && Kamil Opara
//Piny silników
#define MOTOR_FL_FORWARD 13
#define MOTOR_FL_BACKWARD 12
#define MOTOR_FL_PWM 11

#define MOTOR_BL_FORWARD 8
#define MOTOR_BL_BACKWARD 7
#define MOTOR_BL_PWM 10

#define MOTOR_FR_FORWARD 4
#define MOTOR_FR_BACKWARD 5
#define MOTOR_FR_PWM 9

#define MOTOR_BR_FORWARD 2
#define MOTOR_BR_BACKWARD 3
#define MOTOR_BR_PWM 6

//Predefiniowana prędkość
#define SPEED 150

//Piny sensora
#define TRIGGER_PIN 14
#define ECHO_PIN 15

//Klasa odpowiadająca za sterowanie silnikiem
class Motor {
private:
  //Piny silnika
  int forward;
  int backward;
  int pwm;

public:
  Motor(int forward, int backward, int pwm)
    : forward(forward), backward(backward), pwm(pwm) {}

  //Inicjalizacja pinów
  void init() {
    pinMode(forward, OUTPUT);
    pinMode(backward, OUTPUT);
    pinMode(pwm, OUTPUT);
  }

  //Ustawianie prędkości i kierunku silnika
  void setSpeed(int s) {
    if (s >= 0) {
      digitalWrite(forward, 1);
      digitalWrite(backward, 0);
      analogWrite(pwm, s);
    }
    else {
      digitalWrite(forward, 0);
      digitalWrite(backward, 1);
      analogWrite(pwm, -s);
    }
  }
};

//Klasa odpowiadająca za obsługę sensora
class Sensor{
private:
//Piny sensora
  int trigger;
  int echo;

public:
  Sensor(int trigger, int echo)
    : trigger(trigger), echo(echo) {}

  //Inicjalizacja pinów
  void init() {
    pinMode(trigger, OUTPUT);
    pinMode(echo, INPUT);
  }

  //Pobranie odległości (cm)
  int getDistance() {
    int pulseWidth = 0;

    //Wysyłanny jest impuls na pin triger o długości 10us
    digitalWrite(TRIGGER_PIN, HIGH);
    delayMicroseconds(10);
    digitalWrite(TRIGGER_PIN, LOW);

    //Odczytywana jest długość impulsu zwrotnego
    pulseWidth = pulseIn(ECHO_PIN, HIGH, 2000);

    //Zwracana jest watrość podzielona na 58 w celu konwersji na cm
    return pulseWidth / 58.0;
  }
};

//Obiekty każdego z silników
Motor motor_fl (MOTOR_FL_FORWARD, MOTOR_FL_BACKWARD, MOTOR_FL_PWM);
Motor motor_bl (MOTOR_BL_FORWARD, MOTOR_BL_BACKWARD, MOTOR_BL_PWM);
Motor motor_fr (MOTOR_FR_FORWARD, MOTOR_FR_BACKWARD, MOTOR_FR_PWM);
Motor motor_br (MOTOR_BR_FORWARD, MOTOR_BR_BACKWARD, MOTOR_BR_PWM);

//Obiekt sensora
Sensor sensor (TRIGGER_PIN, ECHO_PIN);

//Zmienna opisująca czy jedzie do przodu
int forward = 0;

void setup() {
  //inicjalizacja portów szeregowych
  Serial1.begin(9600);
  Serial.begin(9600);

  //Inicjalizacja silników
  motor_fl.init();
  motor_bl.init();
  motor_fr.init();
  motor_br.init();

  //Inicjalizacja sensora
  sensor.init();
}

void loop() {
  //Pobranie odległości z sensora
  int dist = sensor.getDistance();
  Serial.println(dist);
  delay(100);
  
  //Odebranie danych z bluetootch jeśli jest dostępny
  int incomingByte = Serial1.available() ? Serial1.read() : 0;

  //Ustawienie silników na jazdę w odpowiednim kierunku na podstawie danych odebranych z bluetooth
  if (incomingByte == 'w') {
    forward = 1;
    motor_fl.setSpeed(SPEED);
    motor_bl.setSpeed(SPEED);
    motor_fr.setSpeed(SPEED);
    motor_br.setSpeed(SPEED);
  }

  if (incomingByte == 's') {
    motor_fl.setSpeed(-SPEED);
    motor_bl.setSpeed(-SPEED);
    motor_fr.setSpeed(-SPEED);
    motor_br.setSpeed(-SPEED);
  }

  if (incomingByte == 'a') {
    motor_fl.setSpeed(-SPEED);
    motor_bl.setSpeed(-SPEED);
    motor_fr.setSpeed(SPEED);
    motor_br.setSpeed(SPEED);
  }

  if (incomingByte == 'd') {
    motor_fl.setSpeed(SPEED);
    motor_bl.setSpeed(SPEED);
    motor_fr.setSpeed(-SPEED);
    motor_br.setSpeed(-SPEED);
  }
  
  //Zatrzymanie silników jeśli presłane zostało '0' lub dystans jest mniejszy niż 10
  //'0' oznacza puszczenie przycisków
  if (incomingByte == '0' || dist < 10 && forward == 1) {
    forward = 0;
    motor_fl.setSpeed(0);
    motor_bl.setSpeed(0);
    motor_fr.setSpeed(0);
    motor_br.setSpeed(0);
  }
}
