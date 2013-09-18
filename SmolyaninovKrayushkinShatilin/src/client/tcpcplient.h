#ifndef TCPCLIENT_H
#define TCPCLIENT_H


#include <Poco/Net/StreamSocket.h>
#include <Poco/Net/SocketStream.h>
#include <Poco/Net/NetException.h>

using namespace std;

const int MAXMSGLEN = 200;

class TCPClient{

	Poco::Net::StreamSocket socket;
	Poco::Net::SocketStream stream;
public:

	TCPClient():
	stream(socket)
	{
	}
	~TCPClient(){
	}

	bool establishConnection( string ip, int port);

	bool sendMessage( string message );
	string getMessage( bool &isAnother );
	bool checkConnection();

};

#endif
