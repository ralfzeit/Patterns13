#pragma once

class vagon //класс описания вагонов
{
protected:
	int nomer;
public:
	vagon(void);
	vagon(int nomer1){nomer=nomer1;}

	void set_nomer(int nom){nomer=nom;}
	int get_nomer(){return nomer;}

	vagon operator=(vagon va);
	~vagon(){};
};
