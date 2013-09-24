#ifndef BUS_H
#define BUS_H

#include "header.h"

class Route;
class Driver;
class RouteSheetItem;

class Bus : public QObject
{
    Q_OBJECT

    QTime *currentTime;

    QString number;
    Driver *driver;
    Route *route;
    RouteSheetItem *routeSheetItem;
    QPointF position;
    int indexPositionOnRoute;

    QGraphicsEllipseItem *ellipse;
    QGraphicsTextItem *text;
    double sizeVisibleElements;
    QTableWidgetItem *numberBusItem;
    QTableWidgetItem *numberRouteItem;
    QTableWidgetItem *leaveItem;
    QTableWidgetItem *arrivalItem;

private:
    void redraw();

public:
    explicit Bus(QString number);
    void setVisibility(QGraphicsEllipseItem *ellipse, QGraphicsTextItem *text, double sizeVisibleElements);
    void setVisibility(QTableWidgetItem *numberBusItem, QTableWidgetItem *numberRouteItem, QTableWidgetItem *leaveItem, QTableWidgetItem *arrivalItem);
    void sendToRoute(Driver *driver, RouteSheetItem *routeSheetItem);
    bool go();
    void setClock(QTime *time);
    Driver *getDriver();
    QString getNumber();
    Route *getRoute();
    void setDriver(Driver *driver);
    RouteSheetItem *getRouteSheetItem();

signals:

public slots:

};

#endif // BUS_H
