#ifndef MWINDOW_H
#define MWINDOW_H

//------------------------- GTKMM
#include <gtkmm/window.h>
#include <gtkmm/scrolledwindow.h>
#include <gtkmm/messagedialog.h>
#include <gtkmm/button.h>
#include <gtkmm/textbuffer.h>
#include <gtkmm/textview.h>
#include <gtkmm/entry.h>
#include <gtkmm/box.h>
#include <glibmm/ustring.h>
//------------------------- MY
#include "messageclient.h"
//------------------------- LIBC
#include <iostream>
#include <string.h>

class ClientWindow : public Gtk::Window {

	Gtk::TextView log;
	Gtk::ScrolledWindow sc;
	Gtk::Entry    message;
	Gtk::Button   sendMessage;

	Gtk::Entry  IP;
	Gtk::Entry  port;
	Gtk::Entry  nick;
	Gtk::Button connect;

	Gtk::VBox vert;
	Gtk::HBox conParams;

	MessageClient protocol;
	bool isConnected;

private:
	void connecting();
	void sendMsg();
	bool getMessages(int);

public:

	ClientWindow();

	virtual ~ClientWindow(){
	}
};


#endif
