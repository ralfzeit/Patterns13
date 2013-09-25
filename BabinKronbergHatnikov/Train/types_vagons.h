#pragma once
#include "vagon.h"
// файл с описаниями типов вагонов (пассажирские, служебные)

class vagon_passenger : public vagon
{
protected:
	int mesta;//количество мест в вагоне
	int free_mesta;//количество свободных мест
	int type;//тип пассажирского вагона (1-плацкарт 2-купе)
	int oborudovanie;//оборудование в вагоне (0-нет 1-телевизор 2-телефон 3-телевизор+телефон)
	int cena;//цена проезда на 1км пути
public:
	vagon_passenger();
	vagon_passenger(int mesta1,int nomer1,int type1,int oborudovanie1,int stoim1/*стоимость 1км пути*/);

	void set_type(int type1);
	int get_type();
	void set_oborudovanie(int oborudovanie1);
	int get_oborudovanie();
	void set_cena(int stoim1);
	int get_cena();

	void minus_mesto();
	void all_free_mesto(){free_mesta=mesta;}

	int get_mesta();
	int get_free_mesta();

	~vagon_passenger();
};

class vagon_slujebnii : public vagon
{
protected:
	int type;//тип служебного вагона(1-почтовый 2-ресторан 3-буфет)
public:
	vagon_slujebnii();
	vagon_slujebnii(int nomer1,int type1);

	void set_type(int type1);
	int get_type();

	~vagon_slujebnii();
};