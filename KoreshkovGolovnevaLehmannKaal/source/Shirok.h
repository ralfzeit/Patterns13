#pragma once
#include "Monkey.h"

class Shirok : public Monkey
{
protected:
	bool igrunk;	//игрунки
	bool revun;		//ревуны
public:
	Shirok(void);
	Shirok(int, string, int, int, bool, int, bool, bool );
	Shirok(const Shirok&);
	virtual ~Shirok(void) {};

	virtual void set_igrunk(bool igrunk1) {igrunk1 = igrunk;}
	virtual void set_revun(bool revun1) {revun1 = revun;}
	
	bool get_igrunk(void) const {return igrunk;}	
	bool get_revun(void) const {return revun;}	

};
