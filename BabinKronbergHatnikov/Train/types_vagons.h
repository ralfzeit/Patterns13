#pragma once
#include "vagon.h"
// ���� � ���������� ����� ������� (������������, ���������)

class vagon_passenger : public vagon
{
protected:
	int mesta;//���������� ���� � ������
	int free_mesta;//���������� ��������� ����
	int type;//��� ������������� ������ (1-�������� 2-����)
	int oborudovanie;//������������ � ������ (0-��� 1-��������� 2-������� 3-���������+�������)
	int cena;//���� ������� �� 1�� ����
public:
	vagon_passenger();
	vagon_passenger(int mesta1,int nomer1,int type1,int oborudovanie1,int stoim1/*��������� 1�� ����*/);

	void set_type(int type1);
	int get_type();
	void set_oborudovanie(int oborudovanie1);
	int get_oborudovanie();
	void set_cena(int stoim1);
	int get_cena();

	void minus_mesto();
	void all_free_mesto(){free_mesta=mesta;}

	int get_mesta();
	int get_free_mesta();

	~vagon_passenger();
};

class vagon_slujebnii : public vagon
{
protected:
	int type;//��� ���������� ������(1-�������� 2-�������� 3-�����)
public:
	vagon_slujebnii();
	vagon_slujebnii(int nomer1,int type1);

	void set_type(int type1);
	int get_type();

	~vagon_slujebnii();
};