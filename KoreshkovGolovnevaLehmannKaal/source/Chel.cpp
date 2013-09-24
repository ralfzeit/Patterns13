#include "StdAfx.h"
#include "Chel.h"

Chel::Chel(void):Monkey()
{
	goril = false;
	orangutan = false;
	shinpanz = false;
}

Chel::Chel(int razmer, string name, int growth, int weight, bool tail, int fight, bool goril0, bool orangutan0, bool shinpanz0):
	Monkey(razmer, name, growth, weight, tail, fight)
{
	goril = goril0;
	orangutan = orangutan0;	
	shinpanz = shinpanz0;
}

Chel::Chel(const Chel &ccc):Monkey(ccc)
{
	goril = ccc.goril;
	orangutan = ccc.orangutan;
	shinpanz = ccc.shinpanz;
};