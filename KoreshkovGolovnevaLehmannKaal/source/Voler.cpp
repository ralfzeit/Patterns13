#include "StdAfx.h"
#include "Voler.h"

Voler::Voler(void)
{
	razmer = 0;
	number = 0;
	swimpool = 0;
}
Voler::Voler(int number0, int razmer0, bool swimpool0)
{
	razmer = razmer0;
	number = number0;
	swimpool = swimpool0;
}
Voler::Voler(const Voler &vvv)
{
	razmer = vvv.razmer;
	number = vvv.number;
	swimpool = vvv.swimpool;
};
