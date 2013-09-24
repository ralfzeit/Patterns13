#pragma once
#include "Monkey.h"
using namespace std;

class Voler
{
protected:	
	int number;		//название
	int razmer;		//вмещаемость
	bool swimpool;	//бассейн

public:
	vector <Monkey*> a;
	Voler(int, int, bool);
	Voler(void);
	Voler(const Voler &);
	virtual ~Voler(void) {};
/////////////////////////////////////
	virtual void set_razmer(int razmer1) {razmer = razmer1;}	
	virtual void set_swimpool(bool swimpool1) {swimpool = swimpool1;}
	virtual void set_number(int number1) {number = number1;}

	int get_razmer(void)  const {return razmer;}
	bool get_swimpool(void) const {return swimpool;}
	int get_number(void) const {return number;}
	
};
