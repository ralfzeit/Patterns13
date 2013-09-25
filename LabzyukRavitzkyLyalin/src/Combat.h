#pragma once
#include "Machinery.h"
class Combat :
	public Machinery
{
protected:
	int radius; //Радиус атаки
	int attack_speed; // Скорость атаки
	int damage; // Урон
	int fly_mode;
public:
	
	
	//Combat(const Combat &cm);

	

	// Для создания объекта
	Combat(void); // Конструктор
	Combat(int dx, int dy, int arm, int spd, int m_a, int rad, int a_s, int dmg, int f_m); // Конструктор


	// Для изменения параметров объекта
	



	// Для вывода информации об объекте
	int get_rad();
	int get_a_s();
	int get_dmg();
	int get_f_m();

	virtual ~Combat(void);
protected:
	static const int DMG = 10;
	static const int A_S = 15;
	static const int RAD = 5;
	static const int LVL = 1;



};

