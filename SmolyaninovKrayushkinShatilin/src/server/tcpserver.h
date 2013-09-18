#ifndef TCPSERVER_H
#define TCPSERVER_H
//Poco
#include <Poco/Net/SocketAddress.h>
#include <Poco/Net/StreamSocket.h>
#include <Poco/Net/SocketStream.h>
#include <Poco/Net/ServerSocket.h>

#include <Poco/Runnable.h>
#include <Poco/Mutex.h>
#include <Poco/Thread.h>
//-------------------------
#include <vector>
#include <map>
#include <queue>
#include <string>
#include <iostream>

const int MAXMSGLEN = 200;

using namespace std;

// class contains vector of strings
// thread-safe
class MessagePool{
	queue < pair< int, string > > strings;
	Poco::FastMutex mutex;

public:
	void addMessage( int from, string s );
	pair<int, string> getMessage();
	bool isEmpty(){
		return strings.empty();
	}
};

// class implements thread for each client
class ClientThread : public Poco::Runnable{
	int number;

	Poco::Net::StreamSocket socket;
	Poco::Net::SocketStream stream;
	MessagePool *pool;

public:
	ClientThread(int numb, Poco::Net::StreamSocket str, MessagePool *p);

	void run();
	bool send( string s);
	~ClientThread();
};

// TCP server. Accepts connections and create
// separate thread for each
class TCPServer : public Poco::Runnable {
	int numberOfClients;

	Poco::Net::SocketAddress address;
	Poco::Net::ServerSocket server;
	MessagePool stringPool;

	//vector< ClientThread * > clients;
	map<int, ClientThread * > clients;
	//vector< Poco::Thread * > threads;
	map<int, Poco::Thread *> threads;
	Poco::Mutex clientsMutex;

	Poco::Thread t;

private:

public:
	TCPServer(){
		numberOfClients = 0;
	}

	void run();

//DEBUG/ LATER WILL SIMPLY RETURN BOOL
	Poco::Thread *startServer( int port );

// return last message in s and true
// return empty string and false if
// queue is empty
	pair<int, string> getMessage( bool &b );

	bool send(int client, string message);
	bool sendToAllClients( string message );

	~TCPServer();
};

#endif
