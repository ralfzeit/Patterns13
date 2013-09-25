#pragma once
class Storehouse
{
public:
	int spice;
	int transport_count;
	int combat_count;
	int fly_count;
	int destroy_count;


	Storehouse(void);
	virtual ~Storehouse(void);


	int get_spice();
	int get_tc();
	int get_cc();
	int get_fc();
	int get_dc();

	void inc_spice(int a);
	void inc_tc(int a);
	void inc_cc(int a);
	void inc_fc(int a);
	void inc_dc(int a);

	void dec_spice(int a);
	void dec_tc(int a);
	void dec_cc(int a);
	void dec_fc(int a);


};

