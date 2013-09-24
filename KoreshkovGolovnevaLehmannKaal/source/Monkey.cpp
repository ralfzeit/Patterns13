#include "StdAfx.h"
#include "Monkey.h"

Monkey::Monkey(void)
{
	razmer = 0;
	growth = 0;
	weight = 0;
	tail = false;
	fight = 0;
};

Monkey::Monkey(int razmer0, string name0, int growth0, int weight0, bool tail0, int fight0)
{
	razmer = razmer0;
	name = name0;
	growth = growth0;
	weight = weight0;
	tail = tail0;
	fight = fight0;
};

Monkey::Monkey(const Monkey &zzz)
{
	razmer = zzz.razmer;
	name = zzz.name;
	growth = zzz.growth;
	weight = zzz.weight;
	tail = zzz.tail;
	fight = zzz.fight;
};