#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "header.h"

namespace Ui {
class MainWindow;
}

class City;
class Driver;

class MainWindow : public QMainWindow
{
    Q_OBJECT

    QApplication *application;
    City *city;
    QTime time;
    QTimer *timer;

public:
    explicit MainWindow(QApplication *a, QWidget *parent = 0);
    ~MainWindow();
    
public slots:
//    void on_tableWidget_doubleClicked(const QModelIndex &index);
    void timeout();

private:
    Ui::MainWindow *ui;

signals:
    void sendTimeout();
private slots:
    void on_drivers_doubleClicked(const QModelIndex &index);
    void on_table_doubleClicked(const QModelIndex &index);
    void on_pushButton_clicked();
    void on_pushButton_2_clicked();
    void on_lineEdit_2_textChanged(const QString &arg1);
    void on_lineEdit_textChanged(const QString &arg1);
};

#endif // MAINWINDOW_H
