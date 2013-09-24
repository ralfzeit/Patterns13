#-------------------------------------------------
#
# Project created by QtCreator 2013-06-06T20:02:14
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = course_v5
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    windowroutesheet.cpp \
    windowemployee.cpp \
    windowcall.cpp \
    windowbus.cpp \
    vertex.cpp \
    route.cpp \
    bus.cpp \
    routesheetitem.cpp \
    routesheet.cpp \
    driver.cpp \
    global.cpp \
    city.cpp \
    schedule.cpp \
    scheduleofoneroute.cpp \
    scene.cpp

HEADERS  += mainwindow.h \
    windowroutesheet.h \
    windowemployee.h \
    windowcall.h \
    windowbus.h \
    vertex.h \
    header.h \
    route.h \
    bus.h \
    routesheetitem.h \
    routesheet.h \
    driver.h \
    global.h \
    city.h \
    schedule.h \
    scheduleofoneroute.h \
    scene.h

FORMS    += mainwindow.ui \
    windowroutesheet.ui \
    windowemployee.ui \
    windowcall.ui \
    windowbus.ui
