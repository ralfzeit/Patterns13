#pragma once
using namespace std;


class Machinery
{
protected:

	int x,y; // Координаты
	int armor; // Броня
	int speed; // Скорость
	int max_arm;
	
	public:
	Machinery(const Machinery &mach); // Конструктор копирования
	virtual ~Machinery(void); // Дестркутор

	// Для создания объекта
	Machinery(void); // Конструктор
	Machinery(int dx, int dy); // Конструктор
	Machinery(int dx, int dy, int arm, int spd,int m_a); // Конструктор

	// Для изменения параметров объекта
	void move_at(int, int);
	void get_pos(int &, int &);
	void dec_arm(int);

	// Для вывода информации об объекте
	int get_arm();
	int get_spd();
	int get_X();
	int get_Y();
	int get_ma();

	void set_arm(int x);


protected:
	static const int ARM = 100;
	static const int SPD = 5;

};

