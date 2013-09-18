#include <iostream>
#include "window.h"
#include <Poco/Thread.h>

#include <gtkmm/main.h>
using namespace std;

int main( int argn, char **args ){

//	MessageClient client;
//	client.connectTo("localhost", 9000);
//
//	client.setNick( "Fucker" );
//	bool ex = false;
//	do{
//		client.sendMessage("Test test test");
//		string ans;
//		bool ia = false;
//
//		do{
//			ans = client.getMessage(ia);
//			//if(ans.length() > 0 ) cout << ans << endl;
//		}while(ia);
//
//		Poco::Thread::sleep(500);
//
//	} while(!ex);
	Gtk::Main kit(argn, args);

	ClientWindow window;

	Gtk::Main::run(window);


	return 0;
}
