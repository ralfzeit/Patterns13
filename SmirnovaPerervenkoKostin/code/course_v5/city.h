#ifndef CITY_H
#define CITY_H

#include "header.h"

class Vertex;
class Driver;
class Bus;
class Route;
class Schedule;

class City : public QObject
{
    Q_OBJECT

    QTime *currentTime;
    QTimer *timer;

    int countVertex;
    QVector<Vertex *> vertexes;
    int countDriver;
    QVector<Driver *> drivers;
    int countBus;
    QVector<Bus *> buses;
    int countRoute;
    QVector<Route *> routes;
    QMap<QString, int> vertexNameToIndex;
    QVector< QVector<int> > road;
    Schedule *schedule;

    QTableWidget *tableSchedule;
    QTableWidget *tableDrivers;
    QTableWidget *tableBus;
    QGraphicsScene *scene;
    double sizeVisibleElements;

public:
    explicit City();
    void setScene(QGraphicsScene *scene, double sizeVisibleElements);
    void setClock(QTime *time);
    void setTableDriver(QTableWidget *tableDrivers);
    void setTableBus(QTableWidget *tableBus);
    void setTableSchedule(QTableWidget *tableSchedule);
    Driver *getDriver(QString FLP);
    Bus *getBus(QString number);
    Schedule *getSchedule();
    void goWork(QString FLP);
    QVector<Bus *> getFreeBus();
    QVector<Route *> getRoutes();
//    void startTime(int ms);

signals:
    void sendTimeout();
    
public slots:
    void timeout();
};

#endif // CITY_H
