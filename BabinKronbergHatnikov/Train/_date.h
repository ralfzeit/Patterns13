#pragma once //вспомагательный класс для описания даты
using System::String;

class _date
{
protected:
	int day; //день
	int mounth; //месяц
	int year; //год
public:
	_date(void);
	_date(int day1,int mounth1,int year1);
	
	int get_day(){return day;};
	int get_mounth(){return mounth;};
	int get_year(){return year;};
	String^ get_date(){String^ s;return (s=day.ToString()+"."+mounth.ToString()+"."+year.ToString());}
	void date_plus()
	{
		
	if (day<=28) day++;
	else
	{
		if (mounth==2 && day==29) 
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
			else day++;
		}
		else if (mounth==4 || mounth==6 || mounth==9 || mounth==7 || mounth==11)
		{
			if (day==30) {mounth++;day=1;}
			else day++;
		}
		//else day++;
	}
	}
	void set_date(int day1,int mounth1,int year1)
	{
		day=day1;mounth=mounth1;year=year1;
	}

	_date operator++(); //увеличение даты на день
	_date operator=(_date x);
	~_date(){};
};
