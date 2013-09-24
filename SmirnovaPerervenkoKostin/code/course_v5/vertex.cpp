#include "vertex.h"

Vertex::Vertex(int id, QString name, QPointF position) : QObject(NULL)
{
    this->id = id;
    this->name = name;
    this->position = position;
    sizeVisibleElements = -1;
    ellipse = NULL;
    text = NULL;
}

void Vertex::setVisibily(QGraphicsEllipseItem *ellipse, QGraphicsTextItem *text, double sizeVisibleElements)
{
    this->ellipse = ellipse;
    this->text = text;
    this->sizeVisibleElements = sizeVisibleElements;
    ellipse->setRect(position.x() - sizeVisibleElements / 2, position.y() - sizeVisibleElements / 2, sizeVisibleElements, sizeVisibleElements);
    ellipse->setBrush(QColor::fromRgb(255, 255, 255));
    text->setPlainText(name);
    text->setPos(position);
    text->setDefaultTextColor(QColor().fromRgb(127, 127, 127));

}

QPointF Vertex::getPosition()
{
    return position;
}

double Vertex::getX()
{
    return position.x();
}

double Vertex::getY()
{
    return position.y();
}

QString Vertex::getName()
{
    return name;
}
