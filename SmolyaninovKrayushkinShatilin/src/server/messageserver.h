#include "tcpserver.h"

//---------------------
#include <Poco/Thread.h>
#include <Poco/Runnable.h>
#include <Poco/StringTokenizer.h>

#ifndef MESSAGESERVER_H
#define MESSAGESERVER_H

#include <iostream>
#include <string>
#include <sstream>
#include <map>

using namespace std;

struct Message{
public:
	int from;
	string text;

	Message( int _from, string _text ):
		from(_from),
		text(_text)
	{
	}
};


class MessageServer : Poco::Runnable{

	TCPServer netServer;
	int port;

	vector< Message > log;
	map< int, string > users;

private:

	void processMessage( pair<int, string > mes );

	void sendToUser( int number, string message);
	void sendToAll( string message );
public:
	MessageServer(){
	}

	~MessageServer(){
	}

	bool startServer( int _port );

	void run();

};


#endif
