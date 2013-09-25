

struct Area{

	int type[25][25];//0-песок,1-гора,2-спайс,9-база,10-другая база
	int amount[25][25];
	int unit[25][25];
	int pic[25][25];
	
	Area();
	virtual ~Area();

		void set_type(int i,int j, int x);
		void set_amount(int i,int j, int x);
		void set_pic(int i,int j, int x);
		int dec_amount(int i,int j, int x);
		int get_type(int i,int j);
		int get_amount(int i,int j);
		int get_unit(int i,int j);
		void set_unit(int i,int j,int x);
		int get_pic(int i,int j);
	

	
};
