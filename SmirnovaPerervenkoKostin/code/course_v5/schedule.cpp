#include "schedule.h"

Schedule::Schedule() : QObject(NULL)
{
    table = NULL;
    countRoutes = 0;
}

void Schedule::addScheduleOfOneRoute(ScheduleOfOneRoute *scheduleOfOneRoute)
{
    for (int i = 0; i < countRoutes; i++)
        if (scheduleOfOneRoute->getRoute()->getNumber() == schedule[i]->getRoute()->getNumber())
            return;
    schedule.append(scheduleOfOneRoute);
    countRoutes++;
    if (table != NULL)
        scheduleOfOneRoute->setVisibility(table);
}

void Schedule::addRoute(Route *route)
{
//    for (int i = 0; i < countRoutes; i++)
//        if (route->getNumber() == schedule[i]->getRoute()->getNumber())
//            return;
    addScheduleOfOneRoute(new ScheduleOfOneRoute(route));
}

RouteSheet *Schedule::getRouteSheet()
{
    if (countRoutes == 0)
        return new RouteSheet();
    int index = 0;
    QTime minTime = schedule[0]->getFirstFreeTime();
    for (int i = 1; i < countRoutes; i++) {
        QTime currentTime = schedule[i]->getFirstFreeTime();
        if (currentTime < minTime) {
            minTime = currentTime;
            index = i;
        }
    }
    return schedule[index]->getRouteSheet();
}

RouteSheet *Schedule::getRouteSheet(int numberRoute)
{
    for (int i = 0; i < countRoutes; i++)
        if (schedule[i]->getRoute()->getNumber() == numberRoute)
            return schedule[i]->getRouteSheet();
    return new RouteSheet();
}

void Schedule::setVisibility(QTableWidget *table)
{
    this->table = table;
    while (table->rowCount() > 0)
        table->removeRow(0);
    for (int i = 0; i < countRoutes; i++)
        schedule[i]->setVisibility(table);
}

RouteSheet *Schedule::getTempRouteSheet()
{
    if (countRoutes == 0)
        return new RouteSheet();
    int index = 0;
    QTime minTime = schedule[0]->getFirstFreeTime();
    for (int i = 1; i < countRoutes; i++) {
        QTime currentTime = schedule[i]->getFirstFreeTime();
        if (currentTime < minTime) {
            minTime = currentTime;
            index = i;
        }
    }
    return schedule[index]->getTempRouteSheet();
}

RouteSheet *Schedule::getTempRouteSheet(int numberRoute)
{
    for (int i = 0; i < countRoutes; i++)
        if (schedule[i]->getRoute()->getNumber() == numberRoute)
            return schedule[i]->getTempRouteSheet();
    return new RouteSheet();
}

RouteSheet *Schedule::setTempRouteSheet(RouteSheet *tempRouteSheet)
{
    RouteSheet *routeSheet;
    for (int i=0; i<countRoutes; i++){
        routeSheet = schedule[i]->setTempRouteSheet(tempRouteSheet);
        if (routeSheet->getCountItem() > 0)
            return routeSheet;
        else
            delete routeSheet;
    }
    return new RouteSheet();
}





















