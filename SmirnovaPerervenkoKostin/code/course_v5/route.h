#ifndef ROUTE_H
#define ROUTE_H

#include "header.h"

class Vertex;

class Route : public QObject
{
    Q_OBJECT

    int number;
    int countVertex;
    int countPoints;
    QVector<Vertex *> vertexes;
    QVector<QTime> timeArrival;
    QVector<QPointF> points;
    QVector<Vertex *> pointToVertex;
    QVector<int> pointToIndexVertex;

public:
    explicit Route(int number, QVector<Vertex *> &vertexes, QVector<QTime> &timeArrival);
    int toSecond(const QTime &time);
    
    int getCountVertex();
    int getCountPoints();
    QPointF getPoint(int index);
    Vertex *vertexOnCurrentPoint(int index);
    int indexVertexOnCurrentPoint(int index);
    Vertex *getVertex(int index);
    QTime getTimeArrival(int index);
    QTime getTimeOnRoute();
    int getNumber();

signals:
    
public slots:
    
};

#endif // ROUTE_H
