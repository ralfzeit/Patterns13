//#include "mainwindow.h"
//#include "windowbus.h"
//#include "windowcall.h"
//#include "windowemployee.h"
//#include "windowroutesheet.h"
#include <QApplication>

#include "header.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
//    currentTime = new QTime(6,0,0);
    MainWindow w(&a);
    w.show();
//    WindowBus wb;
//    wb.show();
//    WindowCall wc;
//    wc.show();
//    WindowEmployee we;
//    we.show();
//    WindowRouteSheet wrs;
//    wrs.show();

    return a.exec();
}
