#include "routesheetitem.h"

RouteSheetItem::RouteSheetItem(QTime timeLeave, Route *route) : QObject(NULL)
{
//    table = NULL;
    routeSheet = NULL;
    driverItem = NULL;
    timeItem = NULL;
    this->timeLeave = timeLeave;
    this->route = route;
    countVertex = route->getCountVertex();
    realTimeArrival.resize(countVertex);
    realTimeArrival.fill(QTime(0, 0, 0));
    timeArrival.append(timeLeave);
    int secondInTimeLeave = toSecond(timeLeave);
    for (int i = 1; i < countVertex; i++)
        timeArrival.append(QTime(0, 0, 0).addSecs(secondInTimeLeave + toSecond(route->getTimeArrival(i))));
}

QTime RouteSheetItem::getTimeLeave()
{
    return timeLeave;
}

QTime RouteSheetItem::getRealTimeLeave()
{
    return realTimeArrival[0];
}

QTime RouteSheetItem::getTimeArrival(int index)
{
    if (index < 0 || index >= countVertex)
        return QTime(0, 0, 0);
    return timeArrival[index];
}

QTime RouteSheetItem::getRealTimeArrival(int index)
{
    if (index < 0 || index >= countVertex)
        return QTime(0, 0, 0);
    return realTimeArrival[index];
}

Route *RouteSheetItem::getRoute()
{
    return route;
}

int RouteSheetItem::getCountVertex()
{
    return countVertex;
}

void RouteSheetItem::setRouteSheet(RouteSheet *routeSheet)
{
    this->routeSheet = routeSheet;
    if (driverItem != NULL)
        if (routeSheet->getDriver() != NULL)
            driverItem->setText(routeSheet->getDriver()->getFLP());
}

void RouteSheetItem::setRealTimeArrival(int index, QTime timeAriival)
{
    if (index < 0 || index >= countVertex)
        return;
    realTimeArrival[index] = timeAriival;
    for (int i = 0; i < tables.size(); i++)
        if (tables[i]->columnCount() == 3)
            tables[i]->item(index, 2)->setText(realTimeArrival[index].toString());
//    qDebug() << route->getVertex(index)->getName();
//    qDebug() << timeAriival.toString();
}

void RouteSheetItem::setVisibility(QTableWidgetItem *driverItem, QTableWidgetItem *timeItem)
{
    this->driverItem = driverItem;
    this->timeItem = timeItem;
    if (routeSheet != NULL)
        if (routeSheet->getDriver() != NULL)
            driverItem->setText(routeSheet->getDriver()->getFLP());
    timeItem->setText(timeLeave.toString());
}

void RouteSheetItem::setVisibility(QTableWidget *table)
{
    tables.append(table);
    while (table->rowCount() > 0)
        table->removeRow(0);
    for (int i = 0; i < countVertex; i++) {
        table->insertRow(i);
        table->setItem(i, 0, new QTableWidgetItem(route->getVertex(i)->getName()));
        table->setItem(i, 1, new QTableWidgetItem(timeArrival[i].toString()));
        if (table->columnCount() == 3)
            if (realTimeArrival[i] != QTime(0, 0, 0))
                table->setItem(i, 2, new QTableWidgetItem(realTimeArrival[i].toString()));
            else
                table->setItem(i, 2, new QTableWidgetItem());
    }
}

void RouteSheetItem::delVisibility(QTableWidget *table)
{
    for (int i = 0; i < tables.size(); i++)
        if (tables[i] == table) {
            tables.remove(i);
            return;
        }
}

void RouteSheetItem::delVisibility()
{
    tables.clear();
}

int RouteSheetItem::toSecond(const QTime &time)
{
    return time.hour() * 60 * 60 + time.minute() * 60 + time.second();
}



















