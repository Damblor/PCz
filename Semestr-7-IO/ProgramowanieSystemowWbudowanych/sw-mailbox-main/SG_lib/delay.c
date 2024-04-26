#include "delay.h"

/*******************************************************************************
* Function Name  : delay_ms
* Description    : Delay Time
* Input          : - cnt: Delay Time
* Output         : None
* Return         : None
* Return         : None
* Attention		 : None
*******************************************************************************/
void delay_ms(uint16_t ms)
{
	uint16_t i,j;
	for( i = 0; i < ms; i++ )
	{
		for( j = 0; j < 1141; j++ );
	}
}
