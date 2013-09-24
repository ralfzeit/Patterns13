#ifndef WINDOWEMPLOYEE_H
#define WINDOWEMPLOYEE_H

#include <QMainWindow>
#include "header.h"

namespace Ui {
class WindowEmployee;
}

class WindowEmployee : public QMainWindow
{
    Q_OBJECT
    
    City *city;
    Driver *driver;

public:
    explicit WindowEmployee(City *city, Driver *driver, QWidget *parent = 0);
    ~WindowEmployee();
    
private:
    Ui::WindowEmployee *ui;

public slots:
    void timeout();
    void action();
    void actionCall();
};

#endif // WINDOWEMPLOYEE_H
