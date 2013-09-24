#include "route.h"

Route::Route(int number, QVector<Vertex *> &vertexes, QVector<QTime> &timeArrival) : QObject(NULL)
{
    this->number = number;
    this->vertexes = vertexes;
    this->timeArrival = timeArrival;
    countVertex = vertexes.size();
    points.append(vertexes[0]->getPosition());
    pointToVertex.append(vertexes[0]);
    pointToIndexVertex.append(0);
    for (int i = 1; i < countVertex; i++) {
        int countSecond = toSecond(timeArrival[i]) - toSecond(timeArrival[i - 1]);
        double x = vertexes[i - 1]->getX();
        double y = vertexes[i - 1]->getY();
        double dx = (vertexes[i]->getX() - x) / countSecond;
        double dy = (vertexes[i]->getY() - y) / countSecond;
        for (int j = 1; j < countSecond; j++) {
            points.append(QPointF(x + j * dx, y + j * dy));
            pointToVertex.append(NULL);
            pointToIndexVertex.append(-1);
        }
        points.append(vertexes[i]->getPosition());
        pointToVertex.append(vertexes[i]);
        pointToIndexVertex.append(i);
    }
    countPoints = points.size();
}

int Route::toSecond(const QTime &time)
{
    return time.hour() * 60 * 60 + time.minute() * 60 + time.second();
}

int Route::getCountVertex()
{
    return countVertex;
}

int Route::getCountPoints()
{
    return countPoints;
}

QPointF Route::getPoint(int index)
{
    if (index < 0 || index >= countPoints)
        return QPointF(INT_MAX, INT_MAX);
    return points[index];
}

Vertex *Route::vertexOnCurrentPoint(int index)
{
    if (index < 0 || index >= countPoints)
        return NULL;
    return pointToVertex[index];
}

int Route::indexVertexOnCurrentPoint(int index)
{
    if (index < 0 || index >= countPoints)
        return -1;
    return pointToIndexVertex[index];
}

Vertex *Route::getVertex(int index)
{
    if (index < 0 || index >= countVertex)
        return NULL;
    return vertexes[index];
}

QTime Route::getTimeArrival(int index)
{
    if (index < 0 || index >= countVertex)
        return QTime(0, 0, 0);
    return timeArrival[index];
}

QTime Route::getTimeOnRoute()
{
    return timeArrival[countVertex - 1];
}

int Route::getNumber()
{
    return number;
}

