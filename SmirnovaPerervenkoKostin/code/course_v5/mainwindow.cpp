#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QApplication *a, QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    application = a;
//    QGraphicsScene *scene = new QGraphicsScene();
//    ui->graphicsView->setScene(scene);
//    City *city = new City(scene);
    ui->table->setSelectionBehavior(QAbstractItemView::SelectRows);
    ui->table->setColumnWidth(0, 150);
    ui->table->setColumnWidth(1, 100);
    ui->table->setColumnWidth(2, (ui->table->width() - 250) / 2 - 1);
    ui->table->setColumnWidth(3, (ui->table->width() - 250) / 2 - 1);
//    ui->schedule->setSelectionBehavior(QAbstractItemView::SelectRows);
//    ui->schedule->setColumnWidth(0, 200);
//    ui->schedule->setColumnWidth(1, ui->schedule->width() - 200 - 10);
//    connect(ui->drivers, SIGNAL(), this, SLOT(on_drivers_doubleClicked(QModelIndex)));
    ui->drivers->setSelectionBehavior(QAbstractItemView::SelectRows);
    ui->drivers->setColumnWidth(0, ui->drivers->width() / 2 - 1);
    ui->drivers->setColumnWidth(1, ui->drivers->width() / 2 - 1);

//    ui->schedule->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
//    connect(ui->schedule->horizontalScrollBar(), SIGNAL(valueChanged(int)), ui->schedule->horizontalScrollBar(), SLOT(setValue(0)));
//    connect(ui->schedule->horizontalScrollBar(), SIGNAL(actionTriggered(int)), ui->schedule->horizontalScrollBar(), SLOT(setValue(0)));
//    QStringList list = QString("asdf1,asdf2,asdf3").split(",");
//    for (int i=0; i<list.size(); i++)
//        qDebug() << list.at(i);

    Scene *scene = new Scene();
    city = new City();
    city->setScene(scene, 10);
    ui->map->setScene(scene);
    time.setHMS(5, 59, 0);
    connect(this, SIGNAL(sendTimeout()), city, SLOT(timeout()));
    timer = new QTimer();
    city->setClock(&time);
    connect(timer, SIGNAL(timeout()), this, SLOT(timeout()));
    city->setTableDriver(ui->drivers);
    city->setTableBus(ui->table);
//    city->setTableSchedule(ui->schedule);
    timer->start(1000);
    ui->lineEdit_2->setFocus();
//    ui->tab_4->setVisible(false);
//    ui->tab_4->setHidden(true);
//    ui->tab->

//    ui->tab_4->
//    connect(scene, SIGNAL())

//    QGraphicsScene *scene = new QGraphicsScene();
//    Vertex *vertex1 = new Vertex(0,"ad", QPointF(0,0));
//    Vertex *vertex2 = new Vertex(0,"ad", QPointF(100,100));
//    vertex1->setVisibily(scene->addEllipse(0,0,0,0), scene->addText(""), 10);
//    vertex2->setVisibily(scene->addEllipse(0,0,0,0), scene->addText(""), 10);
//    QVector<Vertex *> vertexes;
//    vertexes.append(vertex1);
//    vertexes.append(vertex2);
//    QVector<QTime> times;
//    times.append(QTime(0,0,0));
//    times.append(QTime(0,1,0));
//    Route *route = new Route(1, vertexes, times);
//    RouteSheetItem *item = new RouteSheetItem(QTime(6,0,0), route);
//    RouteSheet *sheet = new RouteSheet();
//    sheet->addItem(item);
//    Bus *bus = new Bus("asd");
//    bus->setVisibily(scene->addEllipse(0,0,0,0), scene->addText(""), 10);
//    Driver *driver = new Driver("asdf","asdf","asdf");
//    driver->goWork(bus, sheet);
//    driver->setClock(new QTime(7,0,0));
//    bus->setClock(new QTime(7,0,0));
//    QTimer *timer = new QTimer();
//    connect(timer, SIGNAL(timeout()), driver, SLOT(timeout()));
//    timer->start(1000);
//    ui->map->setScene(scene);
}

MainWindow::~MainWindow()
{
    delete ui;
}

//void MainWindow::on_tableWidget_doubleClicked(const QModelIndex &index)
//{
//    //    ui->tableWidget->setItem(index.row(),0,new QTableWidgetItem("asdf"));
//}

void MainWindow::timeout()
{
    time = time.addSecs(1);
    ui->labelTime->setText(time.toString());
    emit sendTimeout();
}

void MainWindow::on_drivers_doubleClicked(const QModelIndex &index)
{
//    city->goWork(ui->drivers->item(index.row(), 0)->text());
    Driver *driver = city->getDriver(ui->drivers->item(index.row(), 0)->text());
    if (driver != NULL) {
        if (driver->getRouteSheet() == NULL) {
            WindowRouteSheet *windowRouteSheet = new WindowRouteSheet(city, driver);
            windowRouteSheet->showNormal();
        } else {
            WindowEmployee *windowEmployee = new WindowEmployee(city, driver);
            windowEmployee->show();
            connect(this, SIGNAL(sendTimeout()), windowEmployee, SLOT(timeout()));
        }
    }
//    Driver *driver = city->getDriver(ui->drivers->item(index.row(), 0)->text());
//    int i;
//    i=0;
}

void MainWindow::on_table_doubleClicked(const QModelIndex &index)
{
    Bus *bus = city->getBus(ui->table->item(index.row(), 0)->text());
    if (bus != NULL) {
        WindowBus *windowBus = new WindowBus(city, bus);
        windowBus->show();
        connect(this, SIGNAL(sendTimeout()), windowBus, SLOT(timeout()));
    }
}

void MainWindow::on_pushButton_clicked()
{
    application->exit();
}

void MainWindow::on_pushButton_2_clicked()
{
    WindowCall *windowCall = new WindowCall("Аварийная служба");
    windowCall->showNormal();
}

void MainWindow::on_lineEdit_2_textChanged(const QString &arg1)
{
    if (arg1 == "") {
        for (int i = 0; i < ui->drivers->rowCount(); i++)
            ui->drivers->setRowHidden(i, false);
    } else {
        for (int i = 0; i < ui->drivers->rowCount(); i++)
            ui->drivers->setRowHidden(i, !(ui->drivers->item(i, 0)->text().contains(arg1, Qt::CaseInsensitive)));
    }
}

void MainWindow::on_lineEdit_textChanged(const QString &arg1)
{
    if (arg1 == "") {
        for (int i = 0; i < ui->table->rowCount(); i++)
            ui->table->setRowHidden(i, false);
    } else  {
        int index = ui->comboBox_2->currentIndex();
        for (int i = 0; i < ui->table->rowCount(); i++)
            ui->table->setRowHidden(i, !(ui->table->item(i, index)->text().contains(arg1, Qt::CaseInsensitive)));
    }
}










