#include "bus.h"

Bus::Bus(QString number) : QObject(NULL)
{
    numberBusItem = NULL;
    numberRouteItem = NULL;
    leaveItem = NULL;
    arrivalItem  = NULL;
    ellipse = NULL;
    text = NULL;
    route = NULL;
    driver = NULL;
    currentTime = NULL;
    routeSheetItem = NULL;
    this->number = number;
}

void Bus::setVisibility(QGraphicsEllipseItem *ellipse, QGraphicsTextItem *text, double sizeVisibleElements)
{
    this->ellipse = ellipse;
    this->text = text;
    this->sizeVisibleElements = sizeVisibleElements;
    redraw();
    ellipse->setBrush(QColor::fromRgb(255, 0, 0));
}

void Bus::setVisibility(QTableWidgetItem *numberBusItem, QTableWidgetItem *numberRouteItem, QTableWidgetItem *leaveItem, QTableWidgetItem *arrivalItem)
{
    this->numberBusItem = numberBusItem;
    this->numberRouteItem = numberRouteItem;
    this->leaveItem = leaveItem;
    this->arrivalItem = arrivalItem;
    numberBusItem->setText(number);
    if (route != NULL) {
        numberRouteItem->setText(QString::number(route->getNumber()));
        if (routeSheetItem->getRealTimeLeave() != QTime(0, 0, 0))
            leaveItem->setText(routeSheetItem->getTimeLeave().toString() + " / " + routeSheetItem->getRealTimeLeave().toString());
        else
            leaveItem->setText(routeSheetItem->getTimeLeave().toString());
        if (routeSheetItem->getRealTimeArrival(routeSheetItem->getCountVertex() - 1) != QTime(0, 0, 0))
            arrivalItem->setText(routeSheetItem->getTimeArrival(routeSheetItem->getCountVertex() - 1).toString() + " / " +
                                 routeSheetItem->getRealTimeArrival(routeSheetItem->getCountVertex() - 1).toString());
        else
            arrivalItem->setText(routeSheetItem->getTimeArrival(routeSheetItem->getCountVertex() - 1).toString());
    } else {
        numberRouteItem->setText(" - ");
        leaveItem->setText("");
        arrivalItem->setText("");
    }
}

void Bus::sendToRoute(Driver *driver, RouteSheetItem *routeSheetItem)
{
    if (currentTime == NULL)
        return;
    this->driver = driver;
    this->route = routeSheetItem->getRoute();
    this->routeSheetItem = routeSheetItem;
    position = route->getPoint(0);
    indexPositionOnRoute = 0;
    routeSheetItem->setRealTimeArrival(0, *currentTime);
    redraw();
    if (numberRouteItem != NULL) {
        numberRouteItem->setText(QString::number(route->getNumber()));
        leaveItem->setText(routeSheetItem->getTimeLeave().toString() + " / " + routeSheetItem->getRealTimeLeave().toString());
        arrivalItem->setText(routeSheetItem->getTimeArrival(routeSheetItem->getCountVertex() - 1).toString());
    }
}

bool Bus::go()
{
    if (route == NULL || currentTime == NULL)
        return false;
    indexPositionOnRoute++;
    if (indexPositionOnRoute >= route->getCountPoints()) {
        route = NULL;
//        driver = NULL;
        routeSheetItem->delVisibility();
        routeSheetItem = NULL;
        redraw();
        return false;
    }
    if (route->indexVertexOnCurrentPoint(indexPositionOnRoute) != -1) {
        routeSheetItem->setRealTimeArrival(route->indexVertexOnCurrentPoint(indexPositionOnRoute), *currentTime);
        if (route->indexVertexOnCurrentPoint(indexPositionOnRoute) == route->getCountVertex() - 1)
            arrivalItem->setText(routeSheetItem->getTimeArrival(routeSheetItem->getCountVertex() - 1).toString() + " / " +
                                 routeSheetItem->getRealTimeArrival(routeSheetItem->getCountVertex() - 1).toString());
    }
    position = route->getPoint(indexPositionOnRoute);
    redraw();
    return true;
}

void Bus::setClock(QTime *time)
{
    this->currentTime = time;
}

Driver *Bus::getDriver()
{
    return driver;
}

QString Bus::getNumber()
{
    return number;
}

Route *Bus::getRoute()
{
    return route;
}

void Bus::setDriver(Driver *driver)
{
    this->driver = driver;
}

RouteSheetItem *Bus::getRouteSheetItem()
{
    return routeSheetItem;
}

void Bus::redraw()
{
    if (ellipse != NULL && text != NULL) {
        if (route == NULL) {
            ellipse->setVisible(false);
            text->setVisible(false);
            return;
        }
        ellipse->setVisible(true);
        text->setVisible(true);
        if (route != NULL){
            text->setPlainText(QString::number(route->getNumber()));
            text->setFont(QFont("Arial", 16));
        }
        ellipse->setRect(position.x() - sizeVisibleElements / 2, position.y() - sizeVisibleElements / 2, sizeVisibleElements, sizeVisibleElements);
        text->setPos(position);
    }
}
