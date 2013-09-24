#include "windowbus.h"
#include "ui_windowbus.h"

WindowBus::WindowBus(City *city, Bus *bus, QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowBus)
{
    ui->setupUi(this);
    ui->table->setSelectionBehavior(QAbstractItemView::SelectRows);
    ui->table->setColumnWidth(0, 200);
    ui->table->setColumnWidth(1, (ui->table->width() - 200) / 2 - 1);
    ui->table->setColumnWidth(2, (ui->table->width() - 200) / 2 - 1);

    this->city = city;
    this->bus = bus;
    if (bus->getDriver())
        ui->labelDriverFLP->setText(bus->getDriver()->getFLP());
    else
        ui->labelDriverFLP->setText("Без водителя");
    ui->labelNumberBus->setText(bus->getNumber());
    if (bus->getRoute() != NULL)
        ui->labelNumberRoute->setText(QString::number(bus->getRoute()->getNumber()));
    else
        ui->labelNumberRoute->setText("Не на маршруте");
    routeSheetItem = bus->getRouteSheetItem();
    if (routeSheetItem != NULL) {
        routeSheetItem->setVisibility(ui->table);
        onRoute = true;
    } else
        onRoute = false;
    connect(ui->actionCallBus, SIGNAL(triggered()), this, SLOT(actionCallBus()));
    connect(ui->actionCallDriver, SIGNAL(triggered()), this, SLOT(actionCallDriver()));
}

WindowBus::~WindowBus()
{
    if (routeSheetItem != NULL)
        routeSheetItem->delVisibility(ui->table);
//    if (bus->getRouteSheetItem() != NULL)
//        bus->getRouteSheetItem()->setVisibility(ui->table);
    delete ui;
}

void WindowBus::timeout()
{
    if (onRoute && bus->getRouteSheetItem() == NULL) {
        onRoute = false;
        routeSheetItem->delVisibility(ui->table);
        routeSheetItem = NULL;
        ui->labelDriverFLP->setText("Без водителя");
        ui->labelNumberRoute->setText("Не на маршруте");
    } else if (!onRoute && bus->getRouteSheetItem() != NULL) {
        onRoute = true;
        routeSheetItem = bus->getRouteSheetItem();
        routeSheetItem->setVisibility(ui->table);
        ui->labelDriverFLP->setText(bus->getDriver()->getFLP());
        ui->labelNumberRoute->setText(QString::number(bus->getRoute()->getNumber()));
    }
}

void WindowBus::actionCallBus()
{
    WindowCall *windowCall = new WindowCall("Автобус: " + bus->getNumber());
    windowCall->showNormal();
}

void WindowBus::actionCallDriver()
{
    WindowCall *windowCall;
    if (bus->getDriver() == NULL)
        windowCall = new WindowCall("В данный момент нет водителя");
    else
        windowCall = new WindowCall(bus->getDriver()->getFLP());
    windowCall->showNormal();
}

void WindowBus::on_groupBox_4_clicked()
{
    if (bus->getDriver() != NULL){
        WindowEmployee *windowEmployee = new WindowEmployee(city, bus->getDriver());
        windowEmployee->show();
        connect(this, SIGNAL(sendTimeout()), windowEmployee, SLOT(timeout()));
    }
}

//void WindowBus::on_groupBox_4_toggled(bool arg1)
//{
//    if (bus->getDriver() != NULL){
//        WindowEmployee *windowEmployee = new WindowEmployee(city, bus->getDriver());
//        windowEmployee->show();
//        connect(this, SIGNAL(sendTimeout()), windowEmployee, SLOT(timeout()));
//    }
//}
