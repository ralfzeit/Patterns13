#include "windowemployee.h"
#include "ui_windowemployee.h"

WindowEmployee::WindowEmployee(City *city, Driver *driver, QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowEmployee)
{
    ui->setupUi(this);

    this->city = city;
    this->driver = driver;
    ui->labelFirstName->setText(driver->getFirstName());
    ui->labelLastName->setText(driver->getLastName());
    ui->labelPatronymic->setText(driver->getPatronymic());
    if (driver->getAddress() != QString(""))
        ui->labelAddress->setText(driver->getAddress());
    else
        ui->labelAddress->setVisible(false);
    if (driver->getTelephone() != QString(""))
        ui->labelTelephone->setText(driver->getTelephone());
    else
        ui->labelTelephone->setVisible(false);
    connect(ui->action, SIGNAL(triggered()), this, SLOT(action()));
    connect(ui->actionCall, SIGNAL(triggered()), this, SLOT(actionCall()));
}

WindowEmployee::~WindowEmployee()
{
    delete ui;
}

void WindowEmployee::timeout()
{
    if (driver->getRoute() != NULL) {
        ui->groupBox->setVisible(true);
        ui->labelNumberRoute->setText(QString::number(driver->getRoute()->getNumber()));
        ui->labelNumberBus->setText(driver->getBus()->getNumber());
    } else
        ui->groupBox->setVisible(false);
}

void WindowEmployee::action()
{
    WindowRouteSheet *windowRouteSheet = new WindowRouteSheet(city, driver);
    windowRouteSheet->showNormal(); // Magic
    //    windowRouteSheet->show();
}

void WindowEmployee::actionCall()
{
    WindowCall *windowCall = new WindowCall(driver->getFLP());
    windowCall->showNormal();
}
