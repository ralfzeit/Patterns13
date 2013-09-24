#include "StdAfx.h"
#include "Shirok.h"

Shirok::Shirok(void):Monkey()
{
	igrunk = false;	
	revun = false;		
}

Shirok::Shirok(int razmer, string name, int growth, int weight, bool tail, int fight, bool igrunk0, bool revun0):
	Monkey(razmer, name, growth, weight, tail, fight)
{
	igrunk = igrunk0;
	revun = revun0;	
}

Shirok::Shirok(const Shirok &sss):Monkey(sss)
{
	igrunk = sss.igrunk;
	revun = sss.revun;
};

