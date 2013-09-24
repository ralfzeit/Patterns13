#include "city.h"

City::City() : QObject(NULL)
{
    tableSchedule = NULL;
    tableBus = NULL;
    tableDrivers = NULL;
    currentTime = NULL;
    timer = NULL;
    schedule = new Schedule();

    FILE *f = fopen("City.data", "r");
    fscanf(f, "%d\n", &countVertex);
    for (int i = 0; i < countVertex; i++) {
        char string[500];
        fgets(string, 499, f);
        if (string[strlen(string) - 1] == '\n')
            string[strlen(string) - 1] = 0;
        QStringList list = QString(string).split(",");
        double x = list[0].toDouble();
        double y = list[1].toDouble();
        QString name = list[2];
//        char ch = (char)name[name.size()-1];
        vertexes.append(new Vertex(i, name, QPointF(x, y)));
        vertexNameToIndex[name.toLower()] = i;
    }
    road.resize(countVertex);
    int countRoad;
    fscanf(f, "%d\n", &countRoad);
    for (int i = 0; i < countRoad; i++) {
        char string[500];
        fgets(string, 499, f);
        if (string[strlen(string) - 1] == '\n')
            string[strlen(string) - 1] = 0;
        QStringList list = QString(string).split(",");
        int from = vertexNameToIndex[list[0].toLower()];
        int to = vertexNameToIndex[list[1].toLower()];
        road[from].append(to);
        road[to].append(from);
    }
    fclose(f);
    f = fopen("Route.data", "r");
    fscanf(f, "%d\n", &countRoute);
    for (int i = 0; i < countRoute; i++) {
        int countVertexInRoute, number;
        QVector<Vertex *> vertexInRoute;
        QVector<QTime> timeArrival;
        char string[500];
        fscanf(f, "%d %d\n", &countVertexInRoute, &number);
        if (string[strlen(string) - 1] == '\n')
            string[strlen(string) - 1] = 0;
        for (int j = 0; j < countVertexInRoute; j++) {
            fgets(string, 499, f);
            if (string[strlen(string) - 1] == '\n')
                string[strlen(string) - 1] = 0;
            QStringList list = QString(string).split(",");
            vertexInRoute.append(vertexes[vertexNameToIndex[list[0].toLower()]]);
            list = list[1].split(":");
            int hour = list[0].toInt();
            int minute = list[1].toInt();
            int second = list[2].toInt();
            timeArrival.append(QTime(hour, minute, second));
        }
        routes.append(new Route(number, vertexInRoute, timeArrival));
    }
    for (int i = 0; i < countRoute; i++)
        schedule->addRoute(routes[i]);
    fclose(f);
    f = fopen("Driver.data", "r");
    fscanf(f, "%d\n", &countDriver);
    for (int i = 0; i < countDriver; i++) {
        char string[500];
        fgets(string, 499, f);
        if (string[strlen(string) - 1] == '\n')
            string[strlen(string) - 1] = 0;
        QStringList list = QString(string).split(",");
        drivers.append(new Driver(list[0], list[1], list[2]));
    }
    for (int i = 0; i < countDriver; i++)
        connect(this, SIGNAL(sendTimeout()), drivers[i], SLOT(timeout()));
    fclose(f);
    f = fopen("Bus.data", "r");
    fscanf(f, "%d\n", &countBus);
    for (int i = 0; i < countBus; i++) {
        char string[500];
        fgets(string, 499, f);
        if (string[strlen(string) - 1] == '\n')
            string[strlen(string) - 1] = 0;
        buses.append(new Bus(QString(string)));
    }
    fclose(f);
//    RouteSheetItem *rsi = new RouteSheetItem(QTime(6,0,0), routes[0]);
//    RouteSheet *rs = new RouteSheet();
//    rs->addItem(rsi);
//    drivers[0]->goWork(buses[0], schedule->getRouteSheet());
}

void City::setScene(QGraphicsScene *scene, double sizeVisibleElements)
{
    this->scene = scene;
    this->sizeVisibleElements = sizeVisibleElements;
    for (int i = 0; i < countVertex; i++)
        vertexes[i]->setVisibily(scene->addEllipse(0, 0, 0, 0), scene->addText(""), sizeVisibleElements);
    for (int i = 0; i < countBus; i++)
        buses[i]->setVisibility(scene->addEllipse(0, 0, 0, 0), scene->addText(""), sizeVisibleElements);
    for (int i = 0; i < countVertex; i++)
        for (int j = 0; j < road[i].size(); j++)
            if (i < road[i][j]) {
                QPointF firstPoint = vertexes[i]->getPosition();
                QPointF secondPoint = vertexes[road[i][j]]->getPosition();
                scene->addLine(firstPoint.x(), firstPoint.y(), secondPoint.x(), secondPoint.y(), QPen(QColor::fromRgb(0, 0, 0)));
            }
}

void City::setClock(QTime *time)
{
    this->currentTime = time;
    for (int i = 0; i < countDriver; i++)
        drivers[i]->setClock(time);
    for (int i = 0; i < countBus; i++)
        buses[i]->setClock(time);
}

void City::setTableDriver(QTableWidget *tableDrivers)
{
    this->tableDrivers = tableDrivers;
    while (tableDrivers->rowCount() > 0)
        tableDrivers->removeRow(0);
    for (int i = 0; i < countDriver; i++) {
        tableDrivers->insertRow(i);
        QTableWidgetItem *fio = new QTableWidgetItem();
        QTableWidgetItem *state = new QTableWidgetItem();
        tableDrivers->setItem(i, 0, fio);
        tableDrivers->setItem(i, 1, state);
        drivers[i]->setVisibility(fio, state);
    }
}

void City::setTableBus(QTableWidget *tableBus)
{
    this->tableBus = tableBus;
    while (tableBus->rowCount() > 0)
        tableBus->removeRow(0);
    for (int i = 0; i < countBus; i++) {
        tableBus->insertRow(i);
        QTableWidgetItem *numberBusItem = new QTableWidgetItem();
        QTableWidgetItem *numberRouteItem = new QTableWidgetItem();
        QTableWidgetItem *timeLeaveItem = new QTableWidgetItem();
        QTableWidgetItem *timeArrivalItem = new QTableWidgetItem();
        tableBus->setItem(i, 0, numberBusItem);
        tableBus->setItem(i, 1, numberRouteItem);
        tableBus->setItem(i, 2, timeLeaveItem);
        tableBus->setItem(i, 3, timeArrivalItem);
        buses[i]->setVisibility(numberBusItem, numberRouteItem, timeLeaveItem, timeArrivalItem);
    }
}

void City::setTableSchedule(QTableWidget *tableSchedule)
{
    this->tableSchedule = tableSchedule;
    schedule->setVisibility(tableSchedule);
}

Driver *City::getDriver(QString FLP)
{
    for (int i = 0; i < countDriver; i++)
        if (drivers[i]->getFLP() == FLP)
            return drivers[i];
    return NULL;
}

Bus *City::getBus(QString number)
{
    for (int i=0; i<countBus; i++)
        if (buses[i]->getNumber() == number)
            return buses[i];
    return NULL;
}

Schedule *City::getSchedule()
{
    return schedule;
}

void City::goWork(QString FLP)
{
    Driver *driver = getDriver(FLP);
    if (driver != NULL) {
        for (int i = 0; i < countBus; i++)
            if (buses[i]->getDriver() == NULL) {
                RouteSheet *tempRouteSheer = schedule->getTempRouteSheet();
                driver->goWork(buses[i], schedule->setTempRouteSheet(tempRouteSheer));
                return;
            }
    }
}

QVector<Bus *> City::getFreeBus()
{
    QVector<Bus *> freeBus;
    for (int i=0; i<countBus; i++)
        if (buses[i]->getDriver() == NULL)
            freeBus.append(buses[i]);
    return freeBus;
}

QVector<Route *> City::getRoutes()
{
    return routes;
}

//void City::startTime(int ms)
//{
//    if (timer != NULL) {
//        timer->stop();
//        disconnect(timer, SIGNAL(timeout()), this, SLOT(timeout()));
//        delete timer;
//    }
//    timer = new QTimer();
//    connect(timer, SIGNAL(timeout()), this, SLOT(timeout()));
//    timer->start(ms);
//}

void City::timeout()
{
//    if (currentTime != NULL)
//        currentTime = new QTime(currentTime->addSecs(1));
//    if (currentTime != NULL)
//        qDebug() << currentTime->toString();
    emit sendTimeout();
}


















