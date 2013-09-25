#include "StdAfx.h"
#include "Machinery.h"


Machinery::Machinery(void)
{
	x = y = 0;
	armor = ARM;
	speed = SPD;
	
}

Machinery::Machinery(const Machinery &mach)
{
	x = mach.x;
	y = mach.y;
	armor = mach.armor;
	speed = mach.speed;
}

Machinery::Machinery(int dx, int dy)
{
		x = dx;
		y = dy;
		armor = ARM;
		speed = SPD;
}

Machinery::Machinery(int dx, int dy, int arm, int spd,int m_a)
{
	x = dx;
	y = dy;
	armor = arm;
	speed = spd;
	max_arm=m_a;
}

void Machinery::move_at(int nx, int ny)
{
	
	x = nx;
	y = ny;
}
void Machinery::get_pos(int &rx, int &ry)
{
	rx = x;
	ry = y;
}
void Machinery::set_arm(int x)
{
	armor+=x;
	if(armor>max_arm) armor=max_arm;
}


void Machinery::dec_arm(int d)
{
	armor -= d;
	if(armor < 0) armor = 0;


}

int Machinery::get_arm(){
	return armor;
}

int Machinery::get_spd(){
	return speed;
}

int Machinery::get_X(){
	return x;
}

int Machinery::get_Y(){
	return y;
}
int Machinery::get_ma(){
	return max_arm;
}



Machinery::~Machinery(void)
{
}
