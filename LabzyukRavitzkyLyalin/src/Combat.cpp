#include "stdafx.h"
#include "Combat.h"


Combat::Combat(void):Machinery()
{
	damage = DMG;
	attack_speed = A_S;
	radius = RAD;
	fly_mode = 0;
}

Combat::Combat(int dx, int dy, int arm, int spd, int m_a, int rad, int a_s, int dmg, int f_m):Machinery(dx, dy, arm, spd, m_a)
{
	radius = rad;
	attack_speed = a_s;
	damage = dmg;
	fly_mode = f_m;

}




int Combat::get_a_s()
{
	return attack_speed;
}

int Combat::get_rad()
{
	return radius;
}

int Combat::get_dmg()
{
	return damage;
}

int Combat::get_f_m()
{
	return fly_mode;
}

Combat::~Combat(void)
{
}
