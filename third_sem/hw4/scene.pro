
#-------------------------------------------------
#
# Project created by QtCreator 2016-03-09T12:06:27
#
#-------------------------------------------------

QT       += core gui

CONFIG += c++11

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = scene
TEMPLATE = app

SOURCES += main.cpp\
		mainWidget.cpp \
    graphicsscene.cpp \
    addcommand.cpp \
    deletecommand.cpp

HEADERS  += mainWidget.h \
    graphicsscene.h \
    command.h \
    addcommand.h \
    deletecommand.h
