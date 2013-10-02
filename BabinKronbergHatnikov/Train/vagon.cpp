#include "StdAfx.h"
#include "vagon.h"

vagon::vagon(void)
{nomer=-1;}

vagon vagon::operator =(vagon va)
{
	nomer=va.nomer;
	return *this;
}
