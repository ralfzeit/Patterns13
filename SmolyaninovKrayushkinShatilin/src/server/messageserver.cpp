#include "messageserver.h"
#include <fstream>
bool MessageServer::startServer( int _port ){
	port = _port;

	Poco::Thread messageHandler;
	Poco::Thread *netThread = netServer.startServer( port );

	if( !netThread ){
		return false;
	}

	messageHandler.start( *this );

	string s;
	while(true){
		cin >> s;
		if( s.compare("quit") == 0 ){
			break;
		}
	}

	return true;
}

void MessageServer::run(){

	while( true ){
		// TODO:проверить, что не ноль пользователей
		bool isMore = false;
		pair<int, string> newMes;
		do{
			newMes = netServer.getMessage( isMore );

			if( newMes.first != -1 ){
				processMessage( newMes );
			}
		}while( isMore );

		Poco::Thread::sleep(100);
	}


}


void MessageServer::processMessage( pair<int, string > mes ){
	cout << mes.first << " " << mes.second << endl;
	string command;
	string text;

	Poco::StringTokenizer tokenizer(mes.second, "~");
	bool invalid = false;
	int tokCnt = tokenizer.count();
	if( tokCnt < 1 && tokCnt > 2){
		invalid = true;
	} else {
		command = tokenizer[0];
		if(tokCnt > 1 ) text = tokenizer[1];
		if( command.length() == 0 ){
			invalid = true;
		}
	}
	if( invalid ){
		sendToUser( mes.first, "~ERR_INVMSGFRMT");
		return;
	}

	// VALID format

	if( command.compare("SETNICK") == 0 ){
		if( text.length() == 0 ){
			sendToUser( mes.first, "~ERR_EMPTYNICK");
			return;
		}
		users.insert( pair<int, string>(mes.first, text ) );
		sendToUser( mes.first, "~SUCCESS");
	} else if( command.compare("MSG") == 0 ){
		if( text.length() == 0){
			sendToUser( mes.first, "~ERR_EMPTYMSG");
			return;
		}
		string nick;
		stringstream allMessage;
		bool found = false;
		if( users.find(mes.first) != users.end() ){
			nick = users[ mes.first ];
			found = true;
		}
		if( found ){
			string mes(nick);

			mes += ": ";
			mes += text;

			sendToAll( mes );
		} else {
			sendToUser( mes.first, "~ERR_NOTREG");
		}
	} else if( command.compare("QUIT") == 0 ) {
		map<int, string>::iterator qu = users.find(mes.first);
		if( qu != users.end() ){
			string name = (*qu).second;
			users.erase( qu );
			stringstream allMessage;
			allMessage << "User " << name << " leaving chat" << endl;
			sendToAll( allMessage.str() );
		}

	}


}

void MessageServer::sendToUser( int n, string mes ){
	if( !netServer.send( n, mes ) ){
		//users.erase( users.find(n) );
	}
}

void MessageServer::sendToAll( string mes ){
	map<int, string>::iterator it = users.begin();
	while( it != users.end() ){
		sendToUser( (*it).first, mes );
		++it;
	}
}
