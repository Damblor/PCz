#include "stm32f10x.h"
#include "stm32f10x_gpio.h"
#include "stm32f10x_rcc.h"
//#include "systick.h"
#include "Glcd_lib_SG/GLCD_SG.h"

#include "stdlib.h"
#include "stdio.h"

#define JOY_PORT GPIOG

#define JOY_UP_PIN    GPIO_Pin_11
#define JOY_DOWN_PIN  GPIO_Pin_8
#define JOY_LEFT_PIN  GPIO_Pin_13
#define JOY_RIGHT_PIN GPIO_Pin_14
#define JOY_SEL_PIN   GPIO_Pin_7

#define LEFT_PORT   GPIOA
#define LEFT        GPIO_Pin_0
#define MIDDLE_PORT GPIOA
#define MIDDLE      GPIO_Pin_8
#define RIGHT_PORT  GPIOC
#define RIGHT       GPIO_Pin_13

#define TILE_SIZE  20
#define TILE_NUM_X 16
#define TILE_NUM_Y 12

void InitButtons() {
	GPIO_InitTypeDef  GPIO_InitStructure;

	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC, ENABLE);

	GPIO_InitStructure.GPIO_Pin = LEFT | MIDDLE;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	GPIO_InitStructure.GPIO_Pin = RIGHT;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
	GPIO_Init(GPIOC, &GPIO_InitStructure);
}

void InitLcd() {
    LCD_Initialization();
    LCD_Clear(Black);
    LCD_SetBacklight(255);
}

void Init() {
	delay_init();
	InitButtons();
	InitLcd();
}

int leftStatePrev = 0;
int leftState = 0;

int middleStatePrev = 0;
int middleState = 0;

int rightStatePrev = 0;
int rightState = 0;

void UpdateButtonsState() {
	leftStatePrev = leftState;
	leftState = GPIO_ReadInputDataBit(LEFT_PORT, LEFT);

	rightStatePrev = rightState;
	rightState = !GPIO_ReadInputDataBit(RIGHT_PORT, RIGHT);

	middleStatePrev = middleState;
	middleState = !GPIO_ReadInputDataBit(MIDDLE_PORT, MIDDLE);
}

int IsLeftDown() {
	return leftState == 1 && leftStatePrev == 0;
}

int IsRightDown() {
	return rightState == 1 && rightStatePrev == 0;
}

int IsMiddleDown() {
	return middleState == 1 && middleStatePrev == 0;
}

void DrawTile(int x, int y, int color) {
	LCD_FillArea(
		x * TILE_SIZE + 1,
		y * TILE_SIZE + 1,
		x * TILE_SIZE + (TILE_SIZE - 2),
		y * TILE_SIZE + (TILE_SIZE - 2),
		color);
}

typedef struct {
	signed char x;
	signed char y;
} SnakeSegment_t;

int segmentsCount = 0;
SnakeSegment_t segments[TILE_NUM_X * TILE_NUM_Y];

enum {
	Up,
	Right,
	Down,
	Left
} snakeDir = Up;

SnakeSegment_t apple;
SnakeSegment_t toBeCleared;

enum {
	Start,
	Playing,
	GameOver
} gameState = Start;

int dirChange = 0;

int score = 0;
int gameTick = 0;
int tick = 0;
int updateTime = 0;

#define SNAKE_HEAD_COLOR 0x23fc
#define SNAKE_TAIL_COLOR 0x6f08
#define APPLE_COLOR      0xeaa5

int IsCollidingWithSnake(const SnakeSegment_t* segment) {
	for(int i = 0; i < segmentsCount; ++i) {
		if(segments[i].x == segment->x && segments[i].y == segment->y) {
			return 1;
		}
	}
	return 0;
}

int IsCollidingWithSnakesTail(const SnakeSegment_t* segment) {
	for(int i = 1; i < segmentsCount; ++i) {
		if(segments[i].x == segment->x && segments[i].y == segment->y) {
			return 1;
		}
	}
	return 0;
}

int IsAppleCollidingWithHead() {
	return apple.x == segments[0].x && apple.y == segments[0].y;
}

SnakeSegment_t RandomizeApple() {
	srand(tick);
	SnakeSegment_t randLoc;
	do {
		randLoc.x = rand() % TILE_NUM_X;
		randLoc.y = rand() % TILE_NUM_Y;
	}while(IsCollidingWithSnake(&randLoc));
	return randLoc;
}

void UpdateSnake() {
	snakeDir = (snakeDir + dirChange + 4) % 4;
	toBeCleared = segments[segmentsCount - 1];
	for(int i = segmentsCount - 1; i != 0; --i) {
		segments[i] = segments[i - 1];
	}
	switch(snakeDir) {
	case Up:
		segments[0].y--;
		break;
	case Right:
		segments[0].x++;
		break;
	case Down:
		segments[0].y++;
		break;
	case Left:
		segments[0].x--;
		break;
	}

	segments[0].x = (segments[0].x + TILE_NUM_X) % TILE_NUM_X;
	segments[0].y = (segments[0].y + TILE_NUM_Y) % TILE_NUM_Y;

	if(IsCollidingWithSnakesTail(&segments[0])) {
		gameState = GameOver;
	}

	if(IsAppleCollidingWithHead()) {
		segments[segmentsCount] = toBeCleared;
		segmentsCount++;
		toBeCleared.x = -1;
		apple = RandomizeApple();
		score++;
		updateTime = 800 / (score + 40) + 1;
	}
}

void DrawGame() {
	if(toBeCleared.x >= 0) {
		DrawTile(toBeCleared.x, toBeCleared.y, Black);
	}

	for(int i = 1; i < segmentsCount; ++i) {
		DrawTile(segments[i].x, segments[i].y, SNAKE_TAIL_COLOR);
	}
	DrawTile(segments[0].x, segments[0].y, SNAKE_HEAD_COLOR);

	DrawTile(apple.x, apple.y, APPLE_COLOR);
}

void InitGame() {
	snakeDir = Up;
	segmentsCount = 4;
	segments[0].x = TILE_NUM_X / 2;
	segments[0].y = TILE_NUM_Y / 2;

	segments[1].x = TILE_NUM_X / 2;
	segments[1].y = TILE_NUM_Y / 2 + 1;

	segments[2].x = TILE_NUM_X / 2;
	segments[2].y = TILE_NUM_Y / 2 + 2;

	segments[3].x = TILE_NUM_X / 3;
	segments[3].y = TILE_NUM_Y / 2 + 3;

	toBeCleared.x = -1;

	apple = RandomizeApple();
	gameTick = 0;
	score = 0;
	updateTime = 20;
}

int main(void)
{
    Init();
    InitGame();

    while(1)
    {
    	UpdateButtonsState();

    	switch(gameState) {
    	case Start:
    		GUI_Text(20, 20, "Projekt wstepny", White, Black);
    		GUI_Text(20, 40, "Kamil Opara", White, Black);
    		GUI_Text(20, 60, "Piotr Krupa", White, Black);
    		GUI_Text(20, 100, "Press Middle to Start!", White, Black);
    		if(IsMiddleDown()) {
				gameState = Playing;
				LCD_Clear(Black);
			}
    		break;
    	case Playing:
    		if(IsLeftDown()) {
    			dirChange = -1;
			}
			if(IsRightDown()) {
				dirChange = 1;
			}

			if(gameTick++ % updateTime == 0) {
				UpdateSnake();
				DrawGame();
				dirChange = 0;
			}

    		break;
    	case GameOver:
    		GUI_Text(20, 20, "GameOver!", White, Black);
    		char buffer[64];
    		int n = sprintf(buffer, "Your score: %d", score);
    		GUI_Text(20, 50, buffer, White, Black);
    		GUI_Text(20, 80, "Press Middle to Try Again!", White, Black);
    		if(IsMiddleDown()) {
    			gameState = Playing;
    			LCD_Clear(Black);
    			InitGame();
    		}
    		break;
    	}

    	delay_ms(10);
    	tick++;
    }
}
