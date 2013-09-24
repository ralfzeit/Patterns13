#include "windowroutesheet.h"
#include "ui_windowroutesheet.h"

WindowRouteSheet::WindowRouteSheet(City *city, Driver *driver, QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowRouteSheet)
{
    ui->setupUi(this);
    ui->tableRoute->setSelectionBehavior(QAbstractItemView::SelectRows);
    ui->tableRoute->setColumnWidth(0, ui->tableRoute->width()/3);
    ui->tableRoute->setColumnWidth(1, ui->tableRoute->width()/3);
    ui->tableRoute->setColumnWidth(2, ui->tableRoute->width()/3);
    ui->tableRouteDetail->setSelectionBehavior(QAbstractItemView::SelectRows);
    ui->tableRouteDetail->setColumnWidth(0, ui->tableRouteDetail->width()/2-1);
    ui->tableRouteDetail->setColumnWidth(1, ui->tableRouteDetail->width()/2-1);

    ui->tableRoute->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    connect(ui->tableRoute->horizontalScrollBar(), SIGNAL(valueChanged(int)), this, SLOT(setAnimated(bool)));

    setTabOrder(ui->tableRoute, ui->comboBoxRouteNumber);

    this->driver = driver;
    this->city = city;
    ui->labelFLP->setText(driver->getFLP());
    schedule = city->getSchedule();
    tempRouteSheet = NULL;
    currentVisibleRouteItem = NULL;
    freeBus = city->getFreeBus();
    routes = city->getRoutes();
    for (int i=0; i<freeBus.size(); i++)
        ui->comboBoxBusNumber->addItem(freeBus[i]->getNumber());
    for (int i=0; i<routes.size(); i++)
        ui->comboBoxRouteNumber->addItem(QString::number(routes[i]->getNumber()));
    ui->comboBoxRouteNumber->addItem("Любой");
    ui->comboBoxRouteNumber->setCurrentIndex(ui->comboBoxRouteNumber->count() - 1);
    if (driver->getRouteSheet() != NULL){
        tempRouteSheet = driver->getRouteSheet();
        tempRouteSheet->setVisibility(ui->tableRoute);
        ui->pushButton->setEnabled(false);
        ui->pushButton_2->setEnabled(false);
        ui->comboBoxBusNumber->setEnabled(false);
        ui->comboBoxRouteNumber->setEnabled(false);
    }
}

WindowRouteSheet::~WindowRouteSheet()
{
    if (tempRouteSheet != NULL)
        tempRouteSheet->delVisibility(ui->tableRoute);
    if (currentVisibleRouteItem != NULL)
        currentVisibleRouteItem->delVisibility(ui->tableRouteDetail);
    delete ui;
}

void WindowRouteSheet::on_pushButton_2_clicked()
{
    while (ui->tableRouteDetail->rowCount() > 0)
        ui->tableRouteDetail->removeRow(0);
    if (tempRouteSheet != NULL)
        tempRouteSheet->delVisibility(ui->tableRoute);
    if (ui->comboBoxRouteNumber->currentText() == "Любой")
        tempRouteSheet = schedule->getTempRouteSheet();
    else
        tempRouteSheet = schedule->getTempRouteSheet(routes[ui->comboBoxRouteNumber->currentIndex()]->getNumber());
    tempRouteSheet->setVisibility(ui->tableRoute);
}

void WindowRouteSheet::on_tableRoute_clicked(const QModelIndex &index)
{
    if (currentVisibleRouteItem != NULL)
        currentVisibleRouteItem->delVisibility(ui->tableRouteDetail);
    if (tempRouteSheet != NULL){
        currentVisibleRouteItem = tempRouteSheet->getRouteSheetItem(index.row());
        currentVisibleRouteItem->setVisibility(ui->tableRouteDetail);
    }
}

void WindowRouteSheet::on_pushButton_clicked()
{
    if (tempRouteSheet != NULL){
        driver->goWork(freeBus[ui->comboBoxBusNumber->currentIndex()], schedule->setTempRouteSheet(tempRouteSheet));
        ui->pushButton->setEnabled(false);
        ui->pushButton_2->setEnabled(false);
        ui->comboBoxBusNumber->setEnabled(false);
        ui->comboBoxRouteNumber->setEnabled(false);
    }
}

void WindowRouteSheet::scrollBoxChanged()
{
    ui->tableRoute->horizontalScrollBar()->setValue(0);
}

void WindowRouteSheet::on_pushButton_4_clicked()
{
    this->close();
}

void WindowRouteSheet::on_pushButton_3_clicked()
{
    WindowEmployee *windowEmployee = new WindowEmployee(city, driver);
    windowEmployee->show();
    windowEmployee->setAttribute(Qt::WA_DeleteOnClose);
}
