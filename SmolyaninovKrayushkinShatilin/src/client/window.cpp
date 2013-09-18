#include "window.h"
#include <fstream>

ClientWindow::ClientWindow():
	sendMessage("Send"),
	connect("Connect"),
	isConnected(false)
{
	IP.get_buffer  ()->set_text("localhost");
	port.get_buffer()->set_text("9000");
	port.set_width_chars(4);
	port.set_max_length(4);
	nick.get_buffer()->set_text("Mikhail");

	vert.pack_start( sc, Gtk::PACK_SHRINK );
	sc.add( log );
	sc.set_policy(Gtk::POLICY_AUTOMATIC, Gtk::POLICY_AUTOMATIC);
	sc.set_size_request(200, 200);

	vert.pack_start( message, Gtk::PACK_SHRINK, 5 );
	vert.pack_start( sendMessage, Gtk::PACK_SHRINK );

		conParams.pack_start( IP, Gtk::PACK_SHRINK );
		conParams.pack_start( port, Gtk::PACK_SHRINK );
		conParams.pack_start( nick, Gtk::PACK_SHRINK );

	vert.pack_start( conParams, Gtk::PACK_SHRINK, 10 );
	vert.pack_start( connect, Gtk::PACK_SHRINK );

	add( vert );

	show_all_children();



	vert.set_spacing(0);

	connect.signal_clicked().connect(sigc::mem_fun(*this,
							&ClientWindow::connecting) );
	sendMessage.signal_clicked().connect(sigc::mem_fun(*this,
							&ClientWindow::sendMsg) );

	sigc::slot<bool> mySlot = sigc::bind(sigc::mem_fun(*this,
              &ClientWindow::getMessages), 0);

	Glib::signal_timeout().connect(mySlot,
          500);

}

bool ClientWindow::getMessages(int i){
	if( !isConnected ) return true;
	//std::cout << "TEST" << endl;

	bool isAnother = false;
	string mes;

	do{
		mes = protocol.getMessage( isAnother );
		if( mes.length() == 0 ) break;
		mes += '\n';
		log.get_buffer()-> insert(log.get_buffer()->end(), mes );
	} while( isAnother );

	return true;
}

void ClientWindow::connecting(){

	Glib::ustring s = port.get_buffer()->get_text();
	if( s.length() < 4 ){
		Gtk::MessageDialog mw(*this, "Invalid port", true,
								Gtk::MESSAGE_ERROR, Gtk::BUTTONS_OK );
		mw.run();
		return;
	}
	int number = 0;
	number += ( s[0] - '0' ) * 1000;
	number += ( s[1] - '0' ) * 100;
	number += ( s[2] - '0' ) * 10;
	number += ( s[3] - '0');

	if( !protocol.connectTo( IP.get_buffer()->get_text(),
						number) ){
		Gtk::MessageDialog mw(*this, "Can't connect to server", false,
								Gtk::MESSAGE_ERROR, Gtk::BUTTONS_OK );
		mw.run();
		return;
	}

	if( nick.get_buffer()->get_text().length() == 0 ){
		Gtk::MessageDialog mw(*this, "Choose yout nickname!", false,
								Gtk::MESSAGE_ERROR, Gtk::BUTTONS_OK );
		mw.run();
		return;
	}
	protocol.setNick( nick.get_buffer()->get_text() );
	protocol.sendMessage( "Hello, from first gui client с русским языком!" );
	isConnected = true;
}

void ClientWindow::sendMsg(){
	string mes = message.get_buffer()->get_text();
	if( mes.length() == 0){
		return;
	}
	if( !protocol.sendMessage( mes ) ){
		Gtk::MessageDialog mw(*this, "Problem with sending message!", false,
								Gtk::MESSAGE_ERROR, Gtk::BUTTONS_OK );
		mw.run();
		return;
	}
}

