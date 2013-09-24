#include "driver.h"

Driver::Driver(QString firstName, QString lastName, QString patronymic) : QObject(NULL)
{
    indexCurrentRoute = -1;
    this->firstName = firstName;
    this->lastName = lastName;
    this->patronymic = patronymic;
    bus = NULL;
    routeSheet = NULL;
    route = NULL;
    currentTime = NULL;
    fio = NULL;
    state = NULL;
}

void Driver::goWork(Bus *bus, RouteSheet *routeSheet)
{
    bus->setDriver(this);
    indexCurrentRoute = 0;
    this->routeSheet = routeSheet;
    routeSheet->setDriver(this);
    this->bus = bus;
    redraw();
}

void Driver::setClock(QTime *time)
{
    this->currentTime = time;
}

void Driver::setTelephone(QString telephone)
{
    this->telephone = telephone;
}

void Driver::setAddress(QString address)
{
    this->address = address;
}

QString Driver::getFirstName()
{
    return firstName;
}

QString Driver::getLastName()
{
    return lastName;
}

QString Driver::getPatronymic()
{
    return patronymic;
}

QString Driver::getTelephone()
{
    return address;
}

QString Driver::getAddress()
{
    return telephone;
}

Route *Driver::getRoute()
{
    return route;
}

Bus *Driver::getBus()
{
    return bus;
}

void Driver::setVisibility(QTableWidgetItem *fio, QTableWidgetItem *state)
{
    this->fio = fio;
    this->state = state;
    fio->setText(firstName + " " + lastName + " " + patronymic);
    redraw();
}

void Driver::redraw()
{
    if (state != NULL) {
        if (routeSheet == NULL || bus == NULL)
            state->setText("Не на работе");
        else if (route == NULL)
            state->setText("Перерыв между маршрутами");
        else
            state->setText("Находится на маршруте " + QString::number(route->getNumber()));
    }
}

QString Driver::getFLP()
{
    return firstName + " " + lastName + " " + patronymic;
}

RouteSheet *Driver::getRouteSheet()
{
    return routeSheet;
}

void Driver::timeout()
{
    if (routeSheet == NULL || bus == NULL || currentTime == NULL)
        return;
    routeSheet->setDriver(this); // to Visualize
    if (route == NULL) {
        if (routeSheet->getRouteSheetItem(indexCurrentRoute)->getTimeLeave() <= (*currentTime)) {
            route = routeSheet->getRouteSheetItem(indexCurrentRoute)->getRoute();
            bus->sendToRoute(this, routeSheet->getRouteSheetItem(indexCurrentRoute));
            redraw();
        }
    } else if (!bus->go()) {
        route = NULL;
        indexCurrentRoute++;
        if (indexCurrentRoute == routeSheet->getCountItem()) {
            bus = NULL;
            routeSheet = NULL;
        }
        redraw();
    }
}
