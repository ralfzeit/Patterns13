#include "tcpcplient.h"

bool TCPClient::establishConnection( string ip, int port){
	try{
		socket.connect( Poco::Net::SocketAddress( ip, port) );
	} catch( ... ){
		return false;
	}

	return true;
}


bool TCPClient::sendMessage( string s ){

	Poco::Timespan span(500);
	try{
		if( !socket.poll( span, Poco::Net::Socket::SELECT_WRITE) ) {
			return false;
		}

		stream << s << endl;
		stream.flush();
	} catch( ... ){
	}

	return true;
}

string TCPClient::getMessage( bool &isAnother ){

	Poco::Timespan span500(500);
	Poco::Timespan span10(10);

	if( !socket.poll( span500, Poco::Net::Socket::SELECT_READ) ) {
		isAnother = false;
		return "";
	}

	char buf[MAXMSGLEN + 1];
	buf[0] = '\0';

	try{
		stream.getline(buf, MAXMSGLEN);
	}catch(...){
		return "";
	}
	string message(buf, stream.gcount() - 1);
	isAnother = socket.poll( span10, Poco::Net::Socket::SELECT_READ);
	return message;
}

bool TCPClient::checkConnection(){
		char buf[2];
		int ret;
		try{
			ret = socket.receiveBytes((void *)(""), 1);
		} catch ( Poco::Net::NetException ne ) {
			return false;
		}
		if( ret == 0 ){
			return false;
		}

	return true;
}
