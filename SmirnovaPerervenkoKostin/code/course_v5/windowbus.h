#ifndef WINDOWBUS_H
#define WINDOWBUS_H

#include <QMainWindow>
#include <QLayout>
#include "header.h"

namespace Ui {
class WindowBus;
}

class WindowBus : public QMainWindow
{
    Q_OBJECT

    City *city;
    Bus *bus;
    RouteSheetItem *routeSheetItem;
    bool onRoute;

public:
    explicit WindowBus(City *city, Bus *bus, QWidget *parent = 0);
    ~WindowBus();
    
private:
    Ui::WindowBus *ui;

public slots:
    void timeout();
    void actionCallBus();
    void actionCallDriver();
private slots:
    void on_groupBox_4_clicked();
//    void on_groupBox_4_toggled(bool arg1);
};

#endif // WINDOWBUS_H
