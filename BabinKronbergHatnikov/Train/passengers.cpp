#include "StdAfx.h"
#include "passengers.h"

passengers::passengers(void)
{
	nomer_poezda=0;
	type_predpochtenie=0;
	oborudovanie_predpochtenie=-1;
}

passengers::passengers(int nom_poezd1, _date date_otpr1, \
					   stantion st_otpr1, stantion st_nazn1, int type_pred1, int obor_predp1)
{
	nomer_poezda=nom_poezd1;
	date_otpravlenie=date_otpr1;
	stantion_otpravlenie=st_otpr1;
	stantion_naznachenie=st_nazn1;
	type_predpochtenie=type_pred1;
	oborudovanie_predpochtenie=obor_predp1;
}
