#include "StdAfx.h"
#include "types_vagons.h"
#include "vagon.h"

vagon_passenger::vagon_passenger()
{
	nomer=-1;
	type=-1;
	oborudovanie=-1;
	cena=0;
}

vagon_passenger::vagon_passenger(int mesta1,int nomer1, int type1, int oborudovanie1, int stoim)
{
	if (mesta1>0 && mesta1<150) mesta=mesta1;
	else mesta=50;
	free_mesta=mesta;
	nomer=nomer1;
	type=type1;
	oborudovanie=oborudovanie1;
	if (type==1) cena=stoim; //плацкарт
	if (type==2) cena=int(float(stoim)*1.4);//купе
	if (oborudovanie1==1 || oborudovanie1==2) cena+=int(float(stoim)*0.4);//если в вагоне имеется телефон или телевизор
	if (oborudovanie1==3) cena+=int(float(stoim)*0.8);//если имеется и телефон и телевизор
}

void vagon_passenger::set_type(int type1)
{
	if (type1==2) type=2;
	else type=1;
}

int vagon_passenger::get_type()
{
	return type;
}

void vagon_passenger::set_oborudovanie(int oborudovanie1)
{
	if (oborudovanie1>=0 && oborudovanie1<=3) oborudovanie=oborudovanie1;
	else oborudovanie=0;
}

int vagon_passenger::get_oborudovanie()
{
	return oborudovanie;
}

void vagon_passenger::set_cena(int stoim)
{
	if (type==1) cena=stoim; //плацкарт
	if (type==2) cena=int(float(stoim)*1.4);//купе
	if (oborudovanie==1 || oborudovanie==2) cena+=int(float(stoim)*0.4);//если в вагоне имеется телефон или телевизор
	if (oborudovanie==3) cena+=int(float(stoim)*0.8);//если имеется и телефон и телевизор
}

int vagon_passenger::get_cena()
{
	return cena;
}

void vagon_passenger::minus_mesto()
{
	if (free_mesta!=0) free_mesta--;
}

int vagon_passenger::get_mesta()
{
	return mesta;
}

int vagon_passenger::get_free_mesta()
{
	return free_mesta;
}

vagon_passenger::~vagon_passenger()
{
}

vagon_slujebnii::vagon_slujebnii()
{
	nomer=-1;
	type=-1;
}

vagon_slujebnii::vagon_slujebnii(int nomer1, int type1)
{
	nomer=nomer1;
	if (type1==2 || type1==3) type=type1;
	else type=1;
}

void vagon_slujebnii::set_type(int type1)
{
	if (type1==2 || type1==3) type=type1;
	else type=1;
}

int vagon_slujebnii::get_type()
{
	return type;
}

vagon_slujebnii::~vagon_slujebnii()
{
}