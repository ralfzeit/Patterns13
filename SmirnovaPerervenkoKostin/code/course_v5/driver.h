#ifndef DRIVER_H
#define DRIVER_H

#include "header.h"

class Route;
class RouteSheet;
class Bus;

class Driver : public QObject
{
    Q_OBJECT

    QTime *currentTime;

    QString firstName;
    QString lastName;
    QString patronymic;
    QString telephone;
    QString address;
    Bus *bus;
    int indexCurrentRoute;
    RouteSheet *routeSheet;
    Route *route;

    QTableWidgetItem *fio;
    QTableWidgetItem *state;

public:
    explicit Driver(QString firstName, QString lastName, QString patronymic);
    void goWork(Bus *bus, RouteSheet *routeSheet);
    void setClock(QTime *time);
    void setTelephone(QString telephone);
    void setAddress(QString address);
    QString getFirstName();
    QString getLastName();
    QString getPatronymic();
    QString getTelephone();
    QString getAddress();
    Route *getRoute();
    Bus *getBus();
    void setVisibility(QTableWidgetItem *fio, QTableWidgetItem *state);
    void redraw();
    QString getFLP();
    RouteSheet *getRouteSheet();

signals:

public slots:
    void timeout();

};

#endif // DRIVER_H
