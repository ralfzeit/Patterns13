#ifndef WINDOWROUTESHEET_H
#define WINDOWROUTESHEET_H

#include <QMainWindow>
#include "header.h"

namespace Ui {
class WindowRouteSheet;
}

class WindowRouteSheet : public QMainWindow
{
    Q_OBJECT
    
    City *city;
    Driver *driver;
    Schedule *schedule;
    RouteSheet *tempRouteSheet;
    RouteSheetItem *currentVisibleRouteItem;
    QVector<Bus *> freeBus;
    QVector<Route *> routes;

public:
    explicit WindowRouteSheet(City *city, Driver *driver, QWidget *parent = 0);
    ~WindowRouteSheet();
    
private slots:
    void on_pushButton_2_clicked();
    void on_tableRoute_clicked(const QModelIndex &index);
    void on_pushButton_clicked();
    void scrollBoxChanged();

    void on_pushButton_3_clicked();

    void on_pushButton_4_clicked();

private:
    Ui::WindowRouteSheet *ui;

};

#endif // WINDOWROUTESHEET_H


