#pragma once
#include "StdAfx.h"
#include "vagon.h"
#include "types_vagons.h"
#include "stantion.h"
#include "_time.h"

class train
{
protected:
	int kol_vagons;//���������� �������
	int nomer; //����� ������
	stantion st_otpravlenie; //������� �����������
	stantion st_naznachenie; //������� ����������
	_time time_otpravlenie; //����� �����������
	_time time_pribitia;  //����� ��������

	int sostoyanie;//��������� ������(0-����� 1-��������)

public:
	train(void);
	train(int nomer1,stantion otpr,stantion nazn,_time otpr1,_time prib1);
	vector <vagon_passenger> vagons1;//������ � ������� ������
	vector <vagon_slujebnii> vagons2;//������ � ������� ������

	void add_vagons(vagon_passenger vagon1);//{vagons.push_back(vagon1);}
	void add_vagons(vagon_slujebnii vagon1){vagons2.push_back(vagon1);}
	vagon get_vagons(int i);//return vagons;
	
	void set_sostoyanie(int x){sostoyanie=x;}
	int get_sostoyanie(){return sostoyanie;}

	void set_kol_vagons(int kol){kol_vagons=kol;}
	int get_kol_vagons(){return kol_vagons;}
	int get_nomer(){return nomer;}

	void set_st_otpravlenie(stantion x1);//
	stantion get_st_otpravlenie();//
	void set_st_naznachenie(stantion x1);//
	stantion get_st_naznachenie();//

	void set_time_otpravlenie(_time x1);
	_time get_time_otpravlenie();
	void set_time_pribitia(_time x1);
	_time get_time_pribitia();

	train operator=(train x)
	{
		kol_vagons=x.kol_vagons;//���������� �������
		for (int i=0;i<x.vagons1.size();i++)
			vagons1.push_back(x.vagons1[i]);	
		for (int i=0;i<x.vagons2.size();i++)
			vagons2.push_back(x.vagons2[i]);
		nomer=x.nomer; //����� ������
		st_otpravlenie=x.st_otpravlenie; //������� �����������
		st_naznachenie=x.st_naznachenie; //������� ����������
		time_otpravlenie=x.time_otpravlenie; //����� �����������
		time_pribitia=x.time_pribitia;  //����� ��������
		return *this;
	}
};
