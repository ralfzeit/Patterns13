#include "stdafx.h"
#include "Area.h"

Area::Area()
{
	for(int i = 0;i < 20;i++)
	{
		for(int j = 0;j < 20;j++)
		{
			type[i][j] = 0;
			
			amount[25][25] = 0;
			pic[25][25]=0;

		}
	}
}

void Area::set_type(int i,int j, int x)
{
	type[i][j]=x;
}

void Area::set_pic(int i,int j, int x)
{
	pic[i][j]=x;
}
int Area::get_pic(int i,int j)
{
	return pic[i][j];
}
int Area::get_unit(int i,int j)
{
	return unit[i][j];
}
void Area::set_unit(int i,int j, int x)
{
	unit[i][j]=x;
}
void Area::set_amount(int i,int j, int x)
{
	amount[i][j]=x;
}

int Area::dec_amount(int i,int j, int x)
{
	if(amount[i][j]-x<0) amount[i][j]=0;
	amount[i][j]-=x;
	return amount[i][j];
}


int Area::get_type(int i,int j)
{
	return type[i][j];
}
int Area::get_amount(int i,int j)
{
	return amount[i][j];
}

Area::~Area(){};