#include "StdAfx.h"
#include "_date.h"

_date::_date(void)
{
	day=1;
	mounth=1;
	year=2012;
}

_date::_date(int day1, int mounth1, int year1)
{
	if (mounth1>=1 && mounth1<=12)
	{
		mounth=mounth1;

		if (mounth1==1 || mounth1==3 || mounth1==5 || mounth1==7 || mounth1==8 || mounth1==10 || mounth1==12)
		{
			if (day1>=1 && day1<=31) day=day1;
		}
		else if (mounth1!=2)
		{
			if (day1>=1 && day1<=30) day=day1;
		}
		else 
			if (day1>=1 && day1<=28) day=day1;
	}
	if (year1>=1980 && year1<=2350) year=year1;
}

_date _date::operator ++()
{
	if (day<=27) day++;
	else
	{
		if (mounth==2 && day==28) 
		{
			mounth=3; day=1;
		}
		else if (mounth==1 || mounth==3 || mounth==5 || mounth==7 || mounth==8 || mounth==10 || mounth==12)
		{
			if (day==31)
			{
				if (mounth==12) {mounth=1;year++;}
				else mounth++;
				day=1;
			}
		}
		else if (mounth==4 || mounth==6 || mounth==9 || mounth==7 || mounth==11)
		{
			if (day==30) {mounth++;day=1;}
		}
		else day++;
	}
	return *this;
}

_date _date::operator =(_date x)
{
	day=x.day;
	mounth=x.mounth;
	year=x.year;
	return *this;
}