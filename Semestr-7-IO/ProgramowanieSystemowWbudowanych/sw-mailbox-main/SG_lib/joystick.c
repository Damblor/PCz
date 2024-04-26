#include "joystick.h"

void joy_init(void)
{
    /* Configure the Joystick pins, i.e. port G 7(press), 8(down), 11(up), 13(left), 14(right) */
	GPIO_InitTypeDef  GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOG, ENABLE);
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_7|GPIO_Pin_8|GPIO_Pin_11|GPIO_Pin_13|GPIO_Pin_14;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_Init(GPIOG, &GPIO_InitStructure);
}

int joy_scan(void)
{
	// All keys of joy are tested and double keys case is also reported//
	/* Joystick pins, port G 7(press), 8(down), 11(up), 13(left), 14(right)
	   cods returned by function
	   01h - up,  	   02h - down, 	    03h - left,      04h - right,      10h - fire
	   11h - up+fire, 12h - down+fire, 13h - left+fire, 14h - right+fire
	 */
	int key_state,key_code;
	key_code=0;
	key_state=~GPIO_ReadInputDataBit(GPIOG, GPIO_Pin_11);
	if (key_state==-1) key_code=0x01;
	key_state=~GPIO_ReadInputDataBit(GPIOG, GPIO_Pin_8);
	if (key_state==-1) key_code=0x02;
	key_state=~GPIO_ReadInputDataBit(GPIOG, GPIO_Pin_13);
	if (key_state==-1) key_code=0x03;
	key_state=~GPIO_ReadInputDataBit(GPIOG, GPIO_Pin_14);
	if (key_state==-1) key_code=0x04;
	key_state=~GPIO_ReadInputDataBit(GPIOG, GPIO_Pin_7);
	if (key_state==-1) key_state=0x10; else key_state=0;
	key_code=key_code+key_state;
	return key_code;
   	}
