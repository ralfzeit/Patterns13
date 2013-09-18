#include <iostream>
#include <string>

#include "tcpserver.h"
#include "messageserver.h"
using namespace std;


int main(){

	MessageServer server;
	int port;
	cin >> port;
	if( !server.startServer( port ) ){
		cout << "Cant start server!" << endl;
	}

	return 0;
}
