#ifndef VERTEX_H
#define VERTEX_H

#include "header.h"

class Vertex : public QObject
{
    Q_OBJECT

    int id;
    QString name;
    QPointF position;

    QGraphicsEllipseItem *ellipse;
    QGraphicsTextItem *text;
    double sizeVisibleElements;

public:
    explicit Vertex(int id, QString name, QPointF position);
    void setVisibily(QGraphicsEllipseItem *ellipse, QGraphicsTextItem *text, double sizeVisibleElements);
    QPointF getPosition();
    double getX();
    double getY();
    QString getName();

signals:

public slots:

};

#endif // VERTEX_H
