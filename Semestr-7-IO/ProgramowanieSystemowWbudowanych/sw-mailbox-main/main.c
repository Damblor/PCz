#include "stm32f10x.h"
#include "stm32f10x_gpio.h"
#include "stm32f10x_rcc.h"
#include "misc.h"
#include "stm32f10x_usart.h"
#include <CoOs.h>
#include "GLCD_SG.h"

#define TRUE 1
#define FALSE 0

#define STACK_SIZE (256 * 4)

OS_STK circle_task_stack[STACK_SIZE];
OS_STK led1_task_stack[STACK_SIZE];
OS_STK led2_task_stack[STACK_SIZE];
OS_STK led3_task_stack[STACK_SIZE];
OS_STK usart_receive_task_stack[STACK_SIZE];

OS_FlagID circle_flag;
OS_EventID mailbox;
OS_EventID mailbox2;

void USART1_Configuration(void) {
  GPIO_InitTypeDef GPIO_InitStructure;
  USART_InitTypeDef USART_InitStructure;

  RCC_APB2PeriphClockCmd( RCC_APB2Periph_GPIOA | RCC_APB2Periph_USART1,ENABLE);
  /* USART1_RX -> PA10 */

  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_Init(GPIOA, &GPIO_InitStructure);

  USART_InitStructure.USART_BaudRate = 115200;
  USART_InitStructure.USART_WordLength = USART_WordLength_8b;
  USART_InitStructure.USART_StopBits = USART_StopBits_1;
  USART_InitStructure.USART_Parity = USART_Parity_No;
  USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
  USART_InitStructure.USART_Mode = USART_Mode_Rx;

  USART_Init(USART1, &USART_InitStructure);
  USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);
  USART_ITConfig(USART1, USART_IT_TXE, DISABLE);
  USART_ClearFlag(USART1,USART_FLAG_TC);
  USART_Cmd(USART1, ENABLE);
}

void NVIC_Configuration(void) {
	NVIC_InitTypeDef NVIC_InitStructure;

	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_0);
	NVIC_InitStructure.NVIC_IRQChannel = USART1_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
}

void initializeBoard(){
	GPIO_InitTypeDef  GPIO_InitStructure;
	/* Initialize LEDS connected to PF6...9, Enable the Clock*/
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOF,ENABLE);
	/* Configure the GPIO_LED pins */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_4;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
	GPIO_Init(GPIOF, &GPIO_InitStructure);

	/* Initialize LEDS connected to PF6...9, Enable the Clock*/
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOF, ENABLE);
	/* Configure the GPIO_LED pins */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_6|GPIO_Pin_7|GPIO_Pin_8|GPIO_Pin_9;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
	GPIO_Init(GPIOF, &GPIO_InitStructure);

	/* Configure the Joystick pins, i.e. port G 7(press), 8(down), 11(up), 13(left), 14(right) */
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOG, ENABLE);
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_7|GPIO_Pin_8|GPIO_Pin_11|GPIO_Pin_13|GPIO_Pin_14;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
	GPIO_Init(GPIOG, &GPIO_InitStructure);

	LCD_Initialization();
	LCD_Clear(Black);
	LCD_SetBacklight(255);
	USART1_Configuration();
	NVIC_Configuration();
}

void USART1_IRQHandler(void) {
	CoEnterISR();
	static uint8_t p1;
	if ((USART1->SR & USART_FLAG_RXNE) != (u16)RESET) {
		uint8_t data = (uint8_t) USART_ReceiveData(USART1);
		CoPostMail(mailbox2, data);
		if(data == 'S' || data == 's') {
			CoSetFlag(circle_flag);
			CoPostMail(mailbox, "Circle drawing ON ");
		}
		else if(data == 'E' || data == 'e') {
			CoClearFlag(circle_flag);
			CoPostMail(mailbox, "Circle drawing OFF");
		}
    }
	CoExitISR();
}

void circle_task(void* data) {
	while(1) {
		for(int i = 1; i < 60; ++i) {
			CoWaitForSingleFlag(circle_flag, 0);
			LCD_DrawCircle(60, 180, i, Green);
		}
		for(int i = 59; i != 0; --i) {
			CoWaitForSingleFlag(circle_flag, 0);
			LCD_DrawCircle(60, 180, i, Red);
		}
	}
}

void led1_task(void* data) {
	while(1) {
		GPIO_SetBits(GPIOF, (1 << 6));
		CoTickDelay(100);
		GPIO_ResetBits(GPIOF, (1 << 6));
		CoTickDelay(100);
	}
}

void led2_task(void* data) {
	while(1) {
		GPIO_SetBits(GPIOF, (1 << 7));
		CoTickDelay(10);
		GPIO_ResetBits(GPIOF, (1 << 7));
		CoTickDelay(10);
	}
}

void led3_task(void* data) {
	while(1) {
		StatusType err;
		char* msg = CoPendMail(mailbox, 1, &err);
		if(err == E_OK) {
			GUI_Text(10, 10, msg, White, Black);
		}
		GPIO_SetBits(GPIOF, (1 << 8));
		CoTickDelay(1);
		GPIO_ResetBits(GPIOF, (1 << 8));
		CoTickDelay(1);
	}
}

char buffer[31];
uint32_t buffer_pos = 0;
void usart_receive_task(void* data) {
	while(1) {
		StatusType err;
		char msg = CoPendMail(mailbox2, 1, &err);
		if(err == E_OK) {
			buffer[buffer_pos++] = msg;
			buffer_pos %= 30;
			GUI_Text(10, 30, buffer, Black, White);
		}
	}
}

int main(void) {
	initializeBoard();
	GUI_Text(10, 10, "Circle drawing ON", White, Black);
	CoInitOS ();
	circle_flag = CoCreateFlag(FALSE, TRUE);
	mailbox = CoCreateMbox(0);
	mailbox2 = CoCreateMbox(0);
	CoCreateTask(circle_task, 0, 3, &circle_task_stack[STACK_SIZE - 1], STACK_SIZE);
	CoCreateTask(led1_task, 0, 2, &led1_task_stack[STACK_SIZE - 1], STACK_SIZE);
	CoCreateTask(led2_task, 0, 2, &led2_task_stack[STACK_SIZE - 1], STACK_SIZE);
	CoCreateTask(led3_task, 0, 2, &led3_task_stack[STACK_SIZE - 1], STACK_SIZE);
	CoCreateTask(usart_receive_task, 0, 2, &usart_receive_task_stack[STACK_SIZE - 1], STACK_SIZE);

	CoStartOS();

	while(1);
}
