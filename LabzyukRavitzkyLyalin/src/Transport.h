#pragma once
#include "Machinery.h"
class Transport :
	public Machinery
{
protected:
	int fly_speed; // Скорость по воздуху
	int spice; // Спайс
	int obtain_speed; // Скорость добычи спайса
	int spice_amout;

public:

//	Transport(const Transport &trans);
	virtual ~Transport(void);


	// Для создания объекта
	Transport(void); // Конструктор
	Transport(int dx, int dy, int arm, int spd,int m_a, int spc, int o_s, int f_s,int s_a); // Конструктор


	// Для изменения параметров объекта
	void spoil();

	

	// Для вывода информации об объекте
	int get_spc();
	int get_o_s();
	int get_s_a();
	void drop_s_a();
};


