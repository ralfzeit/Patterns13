#ifndef ROUTESHEETITEM_H
#define ROUTESHEETITEM_H

#include "header.h"

class Route;
class RouteSheet;

class RouteSheetItem : public QObject
{
    Q_OBJECT

    int countVertex;
    QTime timeLeave;
    QVector<QTime> timeArrival;
    QVector<QTime> realTimeArrival;
    Route *route;
    RouteSheet *routeSheet;
//    Driver *driver;

    QTableWidgetItem *driverItem;
    QTableWidgetItem *timeItem;
    QVector<QTableWidget *> tables;

private:
    int toSecond(const QTime &time);

public:
    explicit RouteSheetItem(QTime timeLeave, Route *route);
    QTime getTimeLeave();
    QTime getRealTimeLeave();
    QTime getTimeArrival(int index);
    QTime getRealTimeArrival(int index);
    Route *getRoute();
    int getCountVertex();
    void setRouteSheet(RouteSheet *routeSheet);
    void setRealTimeArrival(int index, QTime timeAriival);
    void setVisibility(QTableWidgetItem *driverItem, QTableWidgetItem *timeItem);
    void setVisibility(QTableWidget *table);
    void delVisibility(QTableWidget *table);
    void delVisibility();

signals:
    
public slots:
    
};

#endif // ROUTESHEETITEM_H
