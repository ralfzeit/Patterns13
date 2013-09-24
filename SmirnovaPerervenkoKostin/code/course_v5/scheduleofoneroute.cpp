#include "scheduleofoneroute.h"

ScheduleOfOneRoute::ScheduleOfOneRoute(Route *route, QVector< QPair<QTime, QTime> > intervalsTime, QVector<QTime> intervalBetweenDriving) : QObject(NULL)
{
    this->route = route;
    for (int i = 0; i < intervalsTime.size(); i++)
        addTimeLeave(intervalsTime[i].first, intervalsTime[i].second, intervalBetweenDriving[i]);
    countLeave = routeSheetItems.size();
    for (int i = 0; i < countLeave; i++) {
        timeItem.append(NULL);
        driverItem.append(NULL);
    }
    sort();
}

ScheduleOfOneRoute::ScheduleOfOneRoute(Route *route)
{
    this->route = route;
    addTimeLeave(QTime(6, 0, 0), QTime(9, 0, 0), QTime(0, 4, 0));
    addTimeLeave(QTime(9, 0, 0), QTime(15, 0, 0), QTime(0, 7, 0));
    addTimeLeave(QTime(15, 0, 0), QTime(19, 0, 0), QTime(0, 4, 0));
    addTimeLeave(QTime(19, 0, 0), QTime(23, 0, 0), QTime(0, 7, 0));
    countLeave = routeSheetItems.size();
    for (int i = 0; i < countLeave; i++) {
        timeItem.append(NULL);
        driverItem.append(NULL);
    }
    sort();
}

QTime ScheduleOfOneRoute::getFirstFreeTime()
{
    for (int i = 0; i < countLeave; i++)
        if (routeSheetItems[i] == NULL)
            return timeLeave[i];
    return QTime(23, 59, 59);
}

RouteSheet *ScheduleOfOneRoute::getRouteSheet()
{
    QTime currentTimeArrival(0, 0, 0);
    RouteSheet *routeSheet = new RouteSheet();
    for (int i = 0; i < countLeave; i++)
        if (routeSheetItems[i] == NULL)
            if (currentTimeArrival < timeLeave[i]) {
                routeSheetItems[i] = new RouteSheetItem(timeLeave[i], route);
                routeSheet->addItem(routeSheetItems[i]);
                currentTimeArrival = timeLeave[i].addSecs(toSecond(route->getTimeOnRoute()));
                if (driverItem[i] != NULL && timeItem[i] != NULL)
                    routeSheetItems[i]->setVisibility(driverItem[i], timeItem[i]);
            }
    return routeSheet;
}

Route *ScheduleOfOneRoute::getRoute()
{
    return route;
}

RouteSheet *ScheduleOfOneRoute::getTempRouteSheet()
{
    QTime currentTimeArrival(0, 0, 0);
    RouteSheet *routeSheet = new RouteSheet();
    for (int i = 0; i < countLeave; i++)
        if (routeSheetItems[i] == NULL)
            if (currentTimeArrival < timeLeave[i]) {
                routeSheet->addItem(new RouteSheetItem(timeLeave[i], route));
                currentTimeArrival = timeLeave[i].addSecs(toSecond(route->getTimeOnRoute()));
            }
    return routeSheet;
}

RouteSheet *ScheduleOfOneRoute::setTempRouteSheet(RouteSheet *tempRouteSheet)
{
    RouteSheet *routeSheet = new RouteSheet();
    for (int i = 0; i < countLeave; i++)
        if (routeSheetItems[i] == NULL)
            for (int j = 0; j < tempRouteSheet->getCountItem(); j++)
                if (timeLeave[i] == tempRouteSheet->getRouteSheetItem(j)->getTimeLeave() &&
                    route->getNumber() == tempRouteSheet->getRouteSheetItem(j)->getRoute()->getNumber()) {

                    routeSheet->addItem(tempRouteSheet->getRouteSheetItem(j));
                    routeSheetItems[i] = tempRouteSheet->getRouteSheetItem(j);
                    if (driverItem[i] != NULL && timeItem[i] != NULL)
                        routeSheetItems[i]->setVisibility(driverItem[i], timeItem[i]);
                }
    return routeSheet;
}

void ScheduleOfOneRoute::setVisibility(QTableWidget *table)
{
    for (int i = 0; i < countLeave; i++) {
        table->insertRow(table->rowCount());
        driverItem[i] = new QTableWidgetItem();
        timeItem[i] = new QTableWidgetItem();
        table->setItem(table->rowCount() - 1, 0, timeItem[i]);
        table->setItem(table->rowCount() - 1, 1, driverItem[i]);
        if (routeSheetItems[i] != NULL)
            routeSheetItems[i]->setVisibility(driverItem[i], timeItem[i]);
        else
            timeItem[i]->setText(timeLeave[i].toString());
    }
}

int ScheduleOfOneRoute::toSecond(const QTime &time)
{
    return time.hour() * 60 * 60 + time.minute() * 60 + time.second();
}

void ScheduleOfOneRoute::addTimeLeave(QTime begin, QTime end, QTime interval)
{
    int countSecond = toSecond(interval);
    QTime time = begin;
    while (time < end) {
        timeLeave.append(time);
        routeSheetItems.append(NULL);
        time = time.addSecs(countSecond);
    }
}

void ScheduleOfOneRoute::sort()
{
    for (int i = 0; i < countLeave; i++)
        for (int j = 0; j < countLeave - 1; j++)
            if (timeLeave[j] >= timeLeave[j + 1]) {
                std::swap(timeLeave[j], timeLeave[j + 1]);
                std::swap(routeSheetItems[j], routeSheetItems[j + 1]);
            }
}
