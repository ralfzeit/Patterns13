#include "stdafx.h"
#include "Transport.h"


Transport::Transport(void):Machinery()
{
	fly_speed = 0;
	spice = 0;
	obtain_speed = 10;
}



Transport::Transport(int dx, int dy, int arm, int spd,int m_a, int spc, int o_s,int f_s,int s_a):Machinery(dx, dy, arm, spd,m_a)
{
	spice = spc;
	obtain_speed = o_s;
	fly_speed = f_s;
	spice_amout = s_a;
}


void Transport::spoil()
{
	if((spice_amout+obtain_speed)>spice) spice_amout=spice; 
	else spice_amout+=obtain_speed;

}

int Transport::get_spc()
{
	return spice;
}

int Transport::get_o_s()
{
	return obtain_speed;
}

void Transport::drop_s_a()
{
	spice_amout=0;
}

int Transport::get_s_a()
{
	return spice_amout;
}

Transport::~Transport(void)
{
}
