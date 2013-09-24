#ifndef WINDOWCALL_H
#define WINDOWCALL_H

#include <QMainWindow>

namespace Ui {
class WindowCall;
}

class WindowCall : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit WindowCall(QString name, QWidget *parent = 0);
    ~WindowCall();
    
private slots:
    void on_pushButton_clicked();

    void on_pushButton_2_clicked();

private:
    Ui::WindowCall *ui;
};

#endif // WINDOWCALL_H
