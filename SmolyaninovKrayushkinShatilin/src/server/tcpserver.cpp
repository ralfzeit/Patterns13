#include "tcpserver.h"

using namespace Poco;

void MessagePool::addMessage(int from, string s){
	mutex.lock();
	pair< int, string > n(from, s);

	strings.push( n );

	mutex.unlock();
}

pair< int, string > MessagePool::getMessage(){

	mutex.lock();

	pair<int, string > ans = strings.front();
	strings.pop();

	mutex.unlock();

	return ans;
}

//---------------
ClientThread::ClientThread(int numb, Net::StreamSocket str, MessagePool *p ):
	number(numb),
	socket(str),
	stream(str),
	pool( p )
{
}

void ClientThread::run(){
	stream << "Hello, client number " << number << endl; //DEB
	stream.flush();

	Poco::Timespan span(1000 * 10);

	char buffer[MAXMSGLEN + 1];

	while( true ){
		if( socket.poll( span, Net::Socket::SELECT_READ) ){
			buffer[0] = '\0';
			int receivedBytes = 0;
			try{
					stream.getline( buffer, MAXMSGLEN);
			} catch( ... ) {
				break;
			}
			if( buffer[0] == '\0' ){
				break;
			}
			pool->addMessage( number, string(buffer, stream.gcount() -1) );
		}
	}

	cout << "Client number " << number << " gone" << endl; //DEB

}

ClientThread::~ClientThread(){
	socket.close();
}

bool ClientThread::send( string s ){
	Poco::Timespan span(100);
	if( !socket.poll( span, Net::Socket::SELECT_WRITE) ){
		return false;
	}

	stream << s << endl;
	stream.flush();
	//socket.sendBytes( (void *)s.c_str(), s.length());
	//socket.sendBytes( (void *)"\n", 1);

	return true;
}

//---------------

Thread* TCPServer::startServer( int port ){
	try{
		server.bind( port );
		server.listen();
	} catch ( ... ){
		return NULL;
	}

	t.start( *this );

	return &t;
}

void TCPServer::run(){

	while( true ){
		Net::StreamSocket s = server.acceptConnection();
		ClientThread *cl = new ClientThread( numberOfClients++, s, &stringPool);
		Thread *t = new Thread();
		t->start( *cl );

		clientsMutex.lock();

			clients.insert(
				pair<int, ClientThread *>( numberOfClients - 1, cl)
			);

			threads.insert(
				pair<int, Poco::Thread *>( numberOfClients - 1, t)
			);
		clientsMutex.unlock();

		cout << "New Client" << endl;
	}

}

pair< int, string > TCPServer::getMessage( bool &b ){
	pair< int, string > ans(-1, "");
	if( stringPool.isEmpty() ){
		b = false;
		return ans;
	}
	b = true;
	ans = stringPool.getMessage();
	return ans;
}

bool TCPServer::send( int client, string message){
	bool result = false;
	int i = 0;
	do{
		result = clients[ client ]->send( message );
		if( result ) break;
		++i;
		if( i != 3 ) Poco::Thread::sleep(100);
	} while(i < 3 );

	return result;
}

bool TCPServer::sendToAllClients( string message ){
	return true;
}


TCPServer::~TCPServer(){
	server.close();
	map<int, ClientThread*>::iterator itC = clients.begin();
	map<int, Poco::Thread*>::iterator itT = threads.begin();
	while( itC != clients.end() ){ // maps are the same size
		delete (*itC).second;
		delete (*itT).second;
		++itC;
		++itT;
	}
}

