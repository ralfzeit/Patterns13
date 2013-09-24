#include "routesheet.h"

RouteSheet::RouteSheet() : QObject(NULL)
{
    driver = NULL;
    countItem = 0;
}

void RouteSheet::addItem(RouteSheetItem *item)
{
    countItem++;
    items.append(item);
    for (int i = countItem - 1; i >= 1; i--)
        if (items[i - 1]->getTimeLeave() > items[i]->getTimeLeave()) {
            RouteSheetItem *temp = items[i];
            items[i] = items[i - 1];
            items[i] = temp;
        }
    item->setRouteSheet(this); // Visualize
    for (int i = 0; i < tables.size(); i++) {
        tables[i]->insertRow(countItem - 1);
        tables[i]->setItem(countItem - 1, 0, new QTableWidgetItem(QString::number(items[countItem - 1]->getRoute()->getNumber())));
        tables[i]->setItem(countItem - 1, 1, new QTableWidgetItem(items[countItem - 1]->getTimeLeave().toString()));
        tables[i]->setItem(countItem - 1, 2, new QTableWidgetItem(items[countItem - 1]->getTimeArrival(items[countItem - 1]->getCountVertex() - 1).toString()));
    }
}

RouteSheetItem *RouteSheet::getRouteSheetItem(int index)
{
    if (index < 0 || index >= countItem)
        return NULL;
    return items[index];
}

int RouteSheet::getCountItem()
{
    return countItem;
}

void RouteSheet::setDriver(Driver *driver)
{
    this->driver = driver;
    for (int i = 0; i < countItem; i++)
        items[i]->setRouteSheet(this); // To visualize
}

Driver *RouteSheet::getDriver()
{
    return driver;
}

void RouteSheet::setVisibility(QTableWidget *table)
{
    tables.append(table);
    while (table->rowCount() > 0)
        table->removeRow(0);
    for (int i = 0; i < countItem; i++) {
        table->insertRow(i);
        table->setItem(i, 0, new QTableWidgetItem(QString::number(items[i]->getRoute()->getNumber())));
        table->setItem(i, 1, new QTableWidgetItem(items[i]->getTimeLeave().toString()));
        table->setItem(i, 2, new QTableWidgetItem(items[i]->getTimeArrival(items[i]->getCountVertex() - 1).toString()));
    }
}

void RouteSheet::delVisibility(QTableWidget *table)
{
    for (int i = 0; i < tables.size(); i++)
        if (tables[i] == table){
            tables.remove(i);
            return;
        }
}

















