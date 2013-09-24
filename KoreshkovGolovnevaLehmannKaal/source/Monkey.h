#pragma once
using namespace std;

class Monkey
{
protected:
	string name;		//кличка
	int growth;			//рост
	int weight;			//вес	
	bool tail;			//наличие хвоста
	int fight;			//драчливость
	int razmer;			//занимаемый объём
	int number_voler;	//номер вольера

public:
	Monkey(void);	
	Monkey(int, string , int , int , bool , int );	
	Monkey(const Monkey &zzz);	
	virtual ~Monkey() {};	

	virtual void set_number_voler(int number_voler1) {number_voler = number_voler1;}	
	virtual void set_razmer(int razmer1) {razmer = razmer1;}	
	virtual void set_name(string name1) {name = name1;}	
	virtual void set_growth(int growth1) {growth = growth1;}
	virtual void set_weight(int weight1) {weight = weight1;}
	virtual void set_tail(bool tail1) {tail = tail1;}
	virtual void set_fight(int fight1) {fight = fight1;}

	int get_number_voler(void) const {return number_voler;}
	int get_razmer(void) const {return razmer;}
	string get_name(void) const {return name;}	
	int get_growth(void) const {return growth;}
	int get_weight(void) const {return weight;}
	bool get_tail(void) const {return tail;}
	int get_fight(void) const {return fight;}
};	
