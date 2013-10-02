#pragma once
using System::String;

class stantion //класс описания станции
{
protected:
	int nom;//номер станции (для удобства отображения)
	int x;
	int y;
public:
	stantion(void){x=-1;y=-1;}
	stantion(int x1,int y1){x=x1;y=y1;}
	
	void set_stantion(int x1,int y1){x=x1;y=y1;}
	
	void set_nom(int x){nom=x;}
	int get_nom(){return nom;}

	int get_x(void){return x;}
	int get_y(void){return y;}

stantion operator=(stantion st)
{
	nom=st.nom;
	x=st.x;
	y=st.y;
	return *this;
}
	~stantion(){};
};
