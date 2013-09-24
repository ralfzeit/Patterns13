#include "windowcall.h"
#include "ui_windowcall.h"

WindowCall::WindowCall(QString name, QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowCall)
{
    ui->setupUi(this);
    ui->labelName->setText(name);
}

WindowCall::~WindowCall()
{
    delete ui;
}

void WindowCall::on_pushButton_clicked()
{
    if (ui->pushButton->text() == "Вызвать")
        ui->pushButton->setText("Отменить");
    else
        ui->pushButton->setText("Вызвать");
}

void WindowCall::on_pushButton_2_clicked()
{
    this->close();
    delete this;
}
