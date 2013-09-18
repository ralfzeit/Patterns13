#include "messageclient.h"

void MessagePool::addMessage( string s){
	mutex.lock();
	strings.push( s );
	mutex.unlock();
}

string MessagePool::getMessage(){

	mutex.lock();
		string ans = strings.front();
		strings.pop();
	mutex.unlock();

	return ans;
}


bool MessageClient::connectTo(string a, int p){
	bool isStarted = (network.establishConnection(a, p) );
	return isStarted;
}

bool MessageClient::setNick(string s){

	string mes("SETNICK~");
	mes += s;

	network.sendMessage( mes );
	string ans;

	bool isAnother = false;
	bool answerRecieved = false;
	do{
		do{
			ans = network.getMessage( isAnother );
			if( ans.length() ){
				if( ans[0] != '~'){
					incomingMessages.addMessage(ans);
				} else {
					answerRecieved = true;
				}
			}
		}while(isAnother && !answerRecieved);
	}while( !answerRecieved );
	if( ans.compare("~SUCCESS") == 0 ){
		return true;
	} else {
		return false;
	}
}

string MessageClient::getMessage( bool &ia){
	string mes;
	bool an = false;
	if( incomingMessages.isEmpty() ){
		do{
			mes = network.getMessage( an );
			if( mes.length() != 0 ){
				incomingMessages.addMessage(mes);
			}
		} while ( an );
	}

	if( incomingMessages.isEmpty() ){
		ia = false;
		return "";
	} else {
		mes = incomingMessages.getMessage();
		//cout << "FROM TCP:: " << mes << endl;
		if(!incomingMessages.isEmpty()){
			ia = true;
		} else {
			ia = false;
		}
		return mes;
	}

}

bool MessageClient::sendMessage(string s){
	string mes("MSG~");
	mes += s;
	return network.sendMessage( mes );
}

void MessageClient::run(){
	while(true){
		Poco::Thread::sleep(5000);
	}
}
