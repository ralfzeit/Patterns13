#pragma once
#include "Monkey.h"

class Chel : public Monkey
{
protected:
	bool goril;		//гориллы
	bool orangutan;	//орангутаны
	bool shinpanz;	//шимпанзе

public:
	Chel(void);
	Chel(int, string, int, int, bool, int, bool, bool, bool );
	Chel(const Chel& );
	virtual ~Chel(void) {};
		
	virtual void set_goril(bool goril1) {goril1 = goril;}
	virtual void set_orangutan(bool orangutan1) {orangutan1 = orangutan;}
	virtual void set_shinpanz(bool shinpanz1) {shinpanz1 = shinpanz;}

	bool get_goril(void) const {return goril;}	
	bool get_orangutan(void) const {return orangutan;}	
	bool get_shinpanz(void) const {return shinpanz;}	

};
