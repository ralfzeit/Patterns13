#ifndef SCHEDULE_H
#define SCHEDULE_H

#include "header.h"

class ScheduleOfOneRoute;

class Schedule : public QObject
{
    Q_OBJECT

    int countRoutes;
    QVector<ScheduleOfOneRoute *> schedule;

    QTableWidget *table;

public:
    explicit Schedule();
    void addScheduleOfOneRoute(ScheduleOfOneRoute *scheduleOfOneRoute);
    void addRoute(Route *route);
    RouteSheet *getRouteSheet();
    RouteSheet *getRouteSheet(int numberRoute);
    void setVisibility(QTableWidget *table);
    RouteSheet *getTempRouteSheet();
    RouteSheet *getTempRouteSheet(int numberRoute);
    RouteSheet *setTempRouteSheet(RouteSheet *tempRouteSheet);

signals:
    
public slots:
    
};

#endif // SCHEDULE_H
