#ifndef MESCLIENT_H
#define MESCLETNT_H

#include <string>
#include <queue>
#include <iostream>

#include <Poco/Runnable.h>
#include <Poco/Thread.h>
#include <Poco/Mutex.h>

#include "tcpcplient.h"

using namespace std;

class MessagePool{
	queue < string > strings;
	Poco::FastMutex mutex;

public:
	void addMessage( string s );
	string getMessage();
	bool isEmpty(){
		return strings.empty();
	}
};

class MessageClient {
	Poco::Thread t;

	TCPClient network;

	MessagePool incomingMessages;

private:
	void run();

public:

	bool connectTo(string address, int port);

	string getMessage(bool &isAnother);

	bool setNick(string nick );
	bool sendMessage(string message);
	~MessageClient(){
		network.sendMessage("QUIT~");
	}
};

#endif
