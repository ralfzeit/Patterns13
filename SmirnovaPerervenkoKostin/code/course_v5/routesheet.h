#ifndef ROUTESHEET_H
#define ROUTESHEET_H

#include "header.h"

class RouteSheetItem;

class RouteSheet : public QObject
{
    Q_OBJECT

    Driver *driver;
    int countItem;
    QVector<RouteSheetItem *> items;

    QVector<QTableWidget *> tables;

public:
    explicit RouteSheet();
    void addItem(RouteSheetItem *item);
    RouteSheetItem *getRouteSheetItem(int index);
    int getCountItem();
    void setDriver(Driver *driver);
    Driver *getDriver();
    void setVisibility(QTableWidget *table);
    void delVisibility(QTableWidget *table);

signals:
    
public slots:
    
};

#endif // ROUTESHEET_H
