#include "StdAfx.h"
#include "Uzk.h"

Uzk::Uzk(void):Monkey()
{
	martishk = false;
	makak = false;	
	swimpool = false;
}

Uzk::Uzk(int razmer, string name, int growth, int weight, bool tail, int fight, bool martishk0, bool makak0, bool swimpool0):
	Monkey(razmer, name, growth, weight, tail, fight)
{
	martishk = martishk0;
	makak = makak0;	
	swimpool = swimpool0;
}

Uzk::Uzk(const Uzk &uuu):Monkey(uuu)
{
	martishk = uuu.martishk;
	makak = uuu.makak;
	swimpool = uuu.swimpool;
};