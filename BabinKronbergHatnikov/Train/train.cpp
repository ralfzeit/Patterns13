#include "StdAfx.h"
#include "train.h"
#include "vagon.h"
#include "stantion.h"
#include "_time.h"

train::train(void)
{
	sostoyanie=0;
	nomer=-1;
	vagons1.clear();
	vagons2.clear();
}

train::train( int nomer1, stantion otpr, stantion nazn,_time otpr1, _time prib1)
{
	vagons1.clear();
	vagons2.clear();
	nomer=nomer1;
	st_otpravlenie = otpr;
	st_naznachenie = nazn;
	time_otpravlenie = otpr1;
	time_pribitia = prib1 ;
}

void train::add_vagons(vagon_passenger vagon1)
{
	vagons1.push_back(vagon1);
}

vagon train::get_vagons(int i)
{
	return vagons1[i];
}

void train::set_st_otpravlenie(stantion x1)
{
	st_otpravlenie=x1;
}

stantion train::get_st_otpravlenie()
{
	return st_otpravlenie;
}

stantion train::get_st_naznachenie()
{
	return st_naznachenie;
}

void train::set_st_naznachenie(stantion x1)
{
	st_naznachenie=x1;
}

void train::set_time_otpravlenie(_time x1)
{
	time_otpravlenie=x1;
}

_time train::get_time_otpravlenie()
{
	return time_otpravlenie;
}

void train::set_time_pribitia(_time x1)
{
	time_pribitia=x1;
}

_time train::get_time_pribitia()
{
	return time_pribitia;
}
