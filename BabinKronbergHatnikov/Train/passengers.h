#pragma once 
#include "_date.h"
#include "stantion.h"

//класс описания пассажиров

class passengers
{
protected:
	int nomer_poezda;//номер поезда на котором хочет уехать пассажир (0-без разницы)
	_date date_otpravlenie;//дата когда уезжает пассажир
	stantion stantion_otpravlenie;// станция с которой уезжает пассажир
	stantion stantion_naznachenie;//станция куда едет пассажир
	int type_predpochtenie;//предпочтение типа вагона пассажиром (0-без разницы 1-плацкарт 2-купе)
	int oborudovanie_predpochtenie;//предпостение в оборудовании вагона 
	//(-1 - без разницы 0-без всего 1-с телевизором 2-с телефоном 3-и с телевизором и с телефоном)
public:
	passengers(void);
	passengers(int nom_poezd1,_date date_otpr1,stantion st_otpr1,stantion st_nazn1,int type_pred1,int obor_predp1);

	int get_nomer_poezda(){return nomer_poezda;}
	_date get_date_otpravlenie(){return date_otpravlenie;}
	stantion get_stantion_otpravlenie(){return stantion_otpravlenie;}
	stantion get_stantion_naznachenie(){return stantion_naznachenie;}
	int get_type_predpochtenie(){return type_predpochtenie;}
	int get_oborudovanie_predpochtenie(){return oborudovanie_predpochtenie;}

	void set_nomer_poezda(int nom1){nomer_poezda=nom1;}
	void set_date_otpravlenie(_date date_otpr1){date_otpravlenie=date_otpr1;}
	void set_stantion_otpravlenie(stantion st_otpr){stantion_otpravlenie=st_otpr;}
	void set_stantion_naznachenie(stantion st_nazn){stantion_naznachenie=st_nazn;}
	void set_type_predpochtenie(int type_predp1){type_predpochtenie=type_predp1;}	
	void set_oborudovanie_predpochtenie(int obor_predp1){oborudovanie_predpochtenie=obor_predp1;}
};
