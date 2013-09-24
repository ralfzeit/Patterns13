#ifndef SCHEDULEOFONEROUTE_H
#define SCHEDULEOFONEROUTE_H

#include "header.h"

class ScheduleOfOneRoute : public QObject
{
    Q_OBJECT

    int countLeave;
    QVector<QTime> timeLeave;
    QVector<RouteSheetItem *> routeSheetItems;
    Route *route;

    QVector<QTableWidgetItem *> driverItem;
    QVector<QTableWidgetItem *> timeItem;

private:
    int toSecond(const QTime &time);
    void addTimeLeave(QTime begin, QTime end, QTime interval);
    void sort();

public:
    explicit ScheduleOfOneRoute(Route *route, QVector<QPair<QTime, QTime> > intervalsTime, QVector<QTime> intervalBetweenDriving);
    ScheduleOfOneRoute(Route *route);
    QTime getFirstFreeTime();
    RouteSheet *getRouteSheet();
    Route *getRoute();
    RouteSheet *getTempRouteSheet();
    RouteSheet *setTempRouteSheet(RouteSheet *routeSheet);
    void setVisibility(QTableWidget *table);

signals:

public slots:

};

#endif // SCHEDULEOFONEROUTE_H
