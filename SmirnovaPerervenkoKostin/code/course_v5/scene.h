#ifndef SCENE_H
#define SCENE_H

#include "header.h"


class Scene : public QGraphicsScene
{
    Q_OBJECT
public:
    explicit Scene(QObject *parent = 0);
    
signals:
    
public slots:

protected:
    void mousePressEvent(QGraphicsSceneMouseEvent *event);
    
};

#endif // SCENE_H
