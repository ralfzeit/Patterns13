#include "StdAfx.h"
#include "Storehouse.h"


Storehouse::Storehouse(void)
{
	spice=0;
	transport_count=1;
	combat_count=2;
	fly_count=0;
	destroy_count=0;
}


int Storehouse::get_cc()
{
	return combat_count;
}

int Storehouse::get_dc()
{
	return destroy_count;
}

int Storehouse::get_fc()
{
	return fly_count;
}

int Storehouse::get_tc()
{
	return transport_count;
}

int Storehouse::get_spice()
{
	return spice;
}

void Storehouse::inc_spice(int a)
{
	spice+=a;
}

void Storehouse::inc_fc(int a)
{
	fly_count+=a;
}

void Storehouse::inc_dc(int a)
{
	destroy_count+=a;
}

void Storehouse::inc_cc(int a)
{
	combat_count+=a;
}

void Storehouse::inc_tc(int a)
{
	transport_count+=a;
}

//dec
void Storehouse::dec_spice(int a)
{
	spice-=a;
	if(spice<0) spice=0;
}

void Storehouse::dec_fc(int a)
{
	fly_count-=a;
	if(fly_count<0) fly_count=0;
}

void Storehouse::dec_cc(int a)
{
	combat_count-=a;
	if(combat_count<0) combat_count=0;
}

void Storehouse::dec_tc(int a)
{
	transport_count-=a;
	if(transport_count<0) transport_count=0;
}




Storehouse::~Storehouse(void)
{
}
