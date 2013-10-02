#pragma once 
#include "_date.h"
#include "stantion.h"

//����� �������� ����������

class passengers
{
protected:
	int nomer_poezda;//����� ������ �� ������� ����� ������ �������� (0-��� �������)
	_date date_otpravlenie;//���� ����� ������� ��������
	stantion stantion_otpravlenie;// ������� � ������� ������� ��������
	stantion stantion_naznachenie;//������� ���� ���� ��������
	int type_predpochtenie;//������������ ���� ������ ���������� (0-��� ������� 1-�������� 2-����)
	int oborudovanie_predpochtenie;//������������ � ������������ ������ 
	//(-1 - ��� ������� 0-��� ����� 1-� ����������� 2-� ��������� 3-� � ����������� � � ���������)
public:
	passengers(void);
	passengers(int nom_poezd1,_date date_otpr1,stantion st_otpr1,stantion st_nazn1,int type_pred1,int obor_predp1);

	int get_nomer_poezda(){return nomer_poezda;}
	_date get_date_otpravlenie(){return date_otpravlenie;}
	stantion get_stantion_otpravlenie(){return stantion_otpravlenie;}
	stantion get_stantion_naznachenie(){return stantion_naznachenie;}
	int get_type_predpochtenie(){return type_predpochtenie;}
	int get_oborudovanie_predpochtenie(){return oborudovanie_predpochtenie;}

	void set_nomer_poezda(int nom1){nomer_poezda=nom1;}
	void set_date_otpravlenie(_date date_otpr1){date_otpravlenie=date_otpr1;}
	void set_stantion_otpravlenie(stantion st_otpr){stantion_otpravlenie=st_otpr;}
	void set_stantion_naznachenie(stantion st_nazn){stantion_naznachenie=st_nazn;}
	void set_type_predpochtenie(int type_predp1){type_predpochtenie=type_predp1;}	
	void set_oborudovanie_predpochtenie(int obor_predp1){oborudovanie_predpochtenie=obor_predp1;}
};
