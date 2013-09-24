#pragma once
#include "Monkey.h"

class Uzk : public Monkey
{
protected:
	bool martishk;	//мартышки
	bool makak;		//макаки
	bool swimpool;	//требование бассейна

public:
	Uzk(void);
	Uzk(int, string, int, int, bool, int, bool, bool, bool );
	Uzk(const Uzk&);
	virtual ~Uzk(void) {};
	
	virtual void set_swimpool(bool swimpool1) {swimpool1 = swimpool;}
	virtual void set_makak(bool makak1) {makak1 = makak;}
	virtual void set_martishk(bool martishk1) {martishk1 = martishk;}

	bool get_swimpool(void) const {return swimpool;}
	bool get_makak(void) const {return makak;}	
	bool get_martishk(void) const {return martishk;}	

};
