#pragma once
#include "StdAfx.h"
using System::String;

class _time //класс описани€ времени дл€ отправлени€, прибыти€
{
protected:
	int hour;
	int minut;
public:
	_time(void);
	_time(int h,int m)
	{
		if (h>=0 && h<=23)
			hour=h;
		if (m>=0 && m<=59)
			minut=m;
	}
	String^ get_time() 
	{
		String^ s;//=hour.ToString()+":"+minut.ToString();
		if (hour<10) s="0"+hour.ToString()+":";
		else s=hour.ToString()+":";
		if (minut<10) s+="0"+minut.ToString();
		else s+=minut.ToString();
		return s;
	}
	
	int get_hour(){return hour;}
	int get_minut(){return minut;}

	void time_plus(int x)
	{
		if (minut<50) minut+=x;
		else 
		{
			if (hour<23) {hour++;}
			else {hour=0;}
			minut=0;
		}
	}
	_time operator=(_time x)
	{
		hour=x.hour;
		minut=x.minut;
		return *this;
	}
	~_time(){};
};
