#pragma once
#include "Machinery.h"
#include "Transport.h"
#include "Combat.h"
#include "Area.h"
#include "Storehouse.h"
#include "Abstract.h"


#include <time.h>
#include <windows.h>
#include <vector>

#include <algorithm>
#include <ctime>
//////////////////////////////////////////////////////////////////////////
Area *build;
int myMin=0;
int mySec=1;

bool start=false;
bool win=false;


Storehouse *Bblue = new Storehouse;
Storehouse *Bred = new Storehouse;

vector<Machinery *> Red_team;
vector<Machinery *> Blue_team;

int round_x[]={-1,0,1,1,1,0,-1,-1};
int round_y[]={-1,-1,-1,0,1,1,1,0};
//////////////////////////////////////////////////////////////////////////



using namespace std;
namespace BattleForDune {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Collections::Generic;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	
	//void obtain_spice(vector<Machinery *> &team);
	 void obtain_spice(Transport *b);
	void return_base(int x,int y,int teamN,Transport* b);
	
	int blue_base=0;
	int red_base=3;
	int xB,xR,yB,yR;


	/// <summary>
	/// —водка дл€ Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
		
		
	public:
		Form1(void)
		{
			
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// ќсвободить все используемые ресурсы.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}

	

	private: System::ComponentModel::IContainer^  components;

	private: System::Windows::Forms::Timer^  timer1;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::Button^  button2;


	
	private: System::Windows::Forms::GroupBox^  groupBox1;
	private: System::Windows::Forms::Label^  kBC;
	private: System::Windows::Forms::Label^  eBC;
	private: System::Windows::Forms::Label^  fBC;
	private: System::Windows::Forms::Label^  tBC;
	private: System::Windows::Forms::Label^  mBC;
	private: System::Windows::Forms::Label^  kN;
	private: System::Windows::Forms::Label^  sBC;
	private: System::Windows::Forms::Label^  eN;
	private: System::Windows::Forms::Label^  fN;
	private: System::Windows::Forms::Label^  tN;
	private: System::Windows::Forms::Label^  mN;
	private: System::Windows::Forms::Label^  spiceN;
	private: System::Windows::Forms::GroupBox^  groupBox2;
	private: System::Windows::Forms::Label^  kRC;
	private: System::Windows::Forms::Label^  eRC;
	private: System::Windows::Forms::Label^  fRC;
	private: System::Windows::Forms::Label^  tRC;
	private: System::Windows::Forms::Label^  mRC;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::Label^  sRC;
	private: System::Windows::Forms::Label^  label8;
	private: System::Windows::Forms::Label^  label9;
	private: System::Windows::Forms::Label^  label10;
	private: System::Windows::Forms::Label^  label11;
	private: System::Windows::Forms::Label^  label12;

	private: array< Button^, 2 >^ field;
	private: List<Image^> ^sand;
	 private: List<Image^> ^rock;
			private: List<Image^> ^spice;
	private: System::Windows::Forms::ListBox^  listBox1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::RadioButton^  radioButton1;
	private: System::Windows::Forms::RadioButton^  radioButton2;
	private: System::Windows::Forms::RadioButton^  radioButton3;
	private: System::Windows::Forms::GroupBox^  groupBox3;
	private: List<Image^> ^base_pic;

	private:
		
	
		/// <summary>
		/// “ребуетс€ переменна€ конструктора.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// ќб€зательный метод дл€ поддержки конструктора - не измен€йте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->kBC = (gcnew System::Windows::Forms::Label());
			this->eBC = (gcnew System::Windows::Forms::Label());
			this->fBC = (gcnew System::Windows::Forms::Label());
			this->tBC = (gcnew System::Windows::Forms::Label());
			this->mBC = (gcnew System::Windows::Forms::Label());
			this->kN = (gcnew System::Windows::Forms::Label());
			this->sBC = (gcnew System::Windows::Forms::Label());
			this->eN = (gcnew System::Windows::Forms::Label());
			this->fN = (gcnew System::Windows::Forms::Label());
			this->tN = (gcnew System::Windows::Forms::Label());
			this->mN = (gcnew System::Windows::Forms::Label());
			this->spiceN = (gcnew System::Windows::Forms::Label());
			this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->kRC = (gcnew System::Windows::Forms::Label());
			this->eRC = (gcnew System::Windows::Forms::Label());
			this->fRC = (gcnew System::Windows::Forms::Label());
			this->tRC = (gcnew System::Windows::Forms::Label());
			this->mRC = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->sRC = (gcnew System::Windows::Forms::Label());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->label11 = (gcnew System::Windows::Forms::Label());
			this->label12 = (gcnew System::Windows::Forms::Label());
			this->listBox1 = (gcnew System::Windows::Forms::ListBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->radioButton1 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton2 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton3 = (gcnew System::Windows::Forms::RadioButton());
			this->groupBox3 = (gcnew System::Windows::Forms::GroupBox());
			this->groupBox1->SuspendLayout();
			this->groupBox2->SuspendLayout();
			this->groupBox3->SuspendLayout();
			this->SuspendLayout();
			// 
			// timer1
			// 
			this->timer1->Tick += gcnew System::EventHandler(this, &Form1::timer1_Tick);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->BackColor = System::Drawing::Color::Transparent;
			this->label1->Font = (gcnew System::Drawing::Font(L"Times New Roman", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label1->Location = System::Drawing::Point(155, 37);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(46, 19);
			this->label1->TabIndex = 0;
			this->label1->Text = L"00:00";
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(71, 64);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 1;
			this->button1->Text = L"—тарт";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(152, 64);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(75, 23);
			this->button2->TabIndex = 2;
			this->button2->Text = L"ѕауза";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &Form1::button2_Click);
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->kBC);
			this->groupBox1->Controls->Add(this->eBC);
			this->groupBox1->Controls->Add(this->fBC);
			this->groupBox1->Controls->Add(this->tBC);
			this->groupBox1->Controls->Add(this->mBC);
			this->groupBox1->Controls->Add(this->kN);
			this->groupBox1->Controls->Add(this->sBC);
			this->groupBox1->Controls->Add(this->eN);
			this->groupBox1->Controls->Add(this->fN);
			this->groupBox1->Controls->Add(this->tN);
			this->groupBox1->Controls->Add(this->mN);
			this->groupBox1->Controls->Add(this->spiceN);
			this->groupBox1->Font = (gcnew System::Drawing::Font(L"Times New Roman", 14.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->groupBox1->ForeColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->groupBox1->Location = System::Drawing::Point(26, 193);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(285, 196);
			this->groupBox1->TabIndex = 7;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"—иний";
			// 
			// kBC
			// 
			this->kBC->AutoSize = true;
			this->kBC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->kBC->Location = System::Drawing::Point(224, 123);
			this->kBC->Name = L"kBC";
			this->kBC->Size = System::Drawing::Size(14, 15);
			this->kBC->TabIndex = 7;
			this->kBC->Text = L"0";
			// 
			// eBC
			// 
			this->eBC->AutoSize = true;
			this->eBC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->eBC->Location = System::Drawing::Point(146, 86);
			this->eBC->Name = L"eBC";
			this->eBC->Size = System::Drawing::Size(14, 15);
			this->eBC->TabIndex = 8;
			this->eBC->Text = L"2";
			// 
			// fBC
			// 
			this->fBC->AutoSize = true;
			this->fBC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->fBC->Location = System::Drawing::Point(153, 104);
			this->fBC->Name = L"fBC";
			this->fBC->Size = System::Drawing::Size(14, 15);
			this->fBC->TabIndex = 10;
			this->fBC->Text = L"0";
			// 
			// tBC
			// 
			this->tBC->AutoSize = true;
			this->tBC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->tBC->Location = System::Drawing::Point(154, 68);
			this->tBC->Name = L"tBC";
			this->tBC->Size = System::Drawing::Size(14, 15);
			this->tBC->TabIndex = 9;
			this->tBC->Text = L"1";
			// 
			// mBC
			// 
			this->mBC->AutoSize = true;
			this->mBC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->mBC->Location = System::Drawing::Point(226, 51);
			this->mBC->Name = L"mBC";
			this->mBC->Size = System::Drawing::Size(14, 15);
			this->mBC->TabIndex = 8;
			this->mBC->Text = L"3";
			// 
			// kN
			// 
			this->kN->AutoSize = true;
			this->kN->Font = (gcnew System::Drawing::Font(L"Times New Roman", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->kN->Location = System::Drawing::Point(6, 120);
			this->kN->Name = L"kN";
			this->kN->Size = System::Drawing::Size(212, 19);
			this->kN->TabIndex = 5;
			this->kN->Text = L"”бито техники противника:";
			// 
			// sBC
			// 
			this->sBC->AutoSize = true;
			this->sBC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->sBC->Location = System::Drawing::Point(70, 32);
			this->sBC->Name = L"sBC";
			this->sBC->Size = System::Drawing::Size(14, 15);
			this->sBC->TabIndex = 7;
			this->sBC->Text = L"0";
			// 
			// eN
			// 
			this->eN->AutoSize = true;
			this->eN->Font = (gcnew System::Drawing::Font(L"Times New Roman", 11.25F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)), 
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->eN->Location = System::Drawing::Point(51, 84);
			this->eN->Name = L"eN";
			this->eN->Size = System::Drawing::Size(89, 18);
			this->eN->TabIndex = 4;
			this->eN->Text = L"Х Ќаземна€:";
			// 
			// fN
			// 
			this->fN->AutoSize = true;
			this->fN->Font = (gcnew System::Drawing::Font(L"Times New Roman", 11.25F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)), 
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->fN->Location = System::Drawing::Point(51, 102);
			this->fN->Name = L"fN";
			this->fN->Size = System::Drawing::Size(96, 18);
			this->fN->TabIndex = 3;
			this->fN->Text = L"Х ¬оздушна€:";
			// 
			// tN
			// 
			this->tN->AutoSize = true;
			this->tN->Font = (gcnew System::Drawing::Font(L"Times New Roman", 11.25F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)), 
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->tN->Location = System::Drawing::Point(51, 66);
			this->tN->Name = L"tN";
			this->tN->Size = System::Drawing::Size(97, 18);
			this->tN->TabIndex = 2;
			this->tN->Text = L"Х “ранспорт:";
			// 
			// mN
			// 
			this->mN->AutoSize = true;
			this->mN->Font = (gcnew System::Drawing::Font(L"Times New Roman", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->mN->Location = System::Drawing::Point(6, 47);
			this->mN->Name = L"mN";
			this->mN->Size = System::Drawing::Size(214, 19);
			this->mN->TabIndex = 1;
			this->mN->Text = L"ќбщее количество техники:";
			// 
			// spiceN
			// 
			this->spiceN->AutoSize = true;
			this->spiceN->Font = (gcnew System::Drawing::Font(L"Times New Roman", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->spiceN->Location = System::Drawing::Point(6, 28);
			this->spiceN->Name = L"spiceN";
			this->spiceN->Size = System::Drawing::Size(58, 19);
			this->spiceN->TabIndex = 0;
			this->spiceN->Text = L"—пайс:";
			// 
			// groupBox2
			// 
			this->groupBox2->Controls->Add(this->kRC);
			this->groupBox2->Controls->Add(this->eRC);
			this->groupBox2->Controls->Add(this->fRC);
			this->groupBox2->Controls->Add(this->tRC);
			this->groupBox2->Controls->Add(this->mRC);
			this->groupBox2->Controls->Add(this->label6);
			this->groupBox2->Controls->Add(this->sRC);
			this->groupBox2->Controls->Add(this->label8);
			this->groupBox2->Controls->Add(this->label9);
			this->groupBox2->Controls->Add(this->label10);
			this->groupBox2->Controls->Add(this->label11);
			this->groupBox2->Controls->Add(this->label12);
			this->groupBox2->Font = (gcnew System::Drawing::Font(L"Times New Roman", 14.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->groupBox2->ForeColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->groupBox2->Location = System::Drawing::Point(26, 395);
			this->groupBox2->Name = L"groupBox2";
			this->groupBox2->Size = System::Drawing::Size(285, 196);
			this->groupBox2->TabIndex = 8;
			this->groupBox2->TabStop = false;
			this->groupBox2->Text = L" расный";
			// 
			// kRC
			// 
			this->kRC->AutoSize = true;
			this->kRC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->kRC->Location = System::Drawing::Point(224, 123);
			this->kRC->Name = L"kRC";
			this->kRC->Size = System::Drawing::Size(14, 15);
			this->kRC->TabIndex = 7;
			this->kRC->Text = L"0";
			// 
			// eRC
			// 
			this->eRC->AutoSize = true;
			this->eRC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->eRC->Location = System::Drawing::Point(146, 86);
			this->eRC->Name = L"eRC";
			this->eRC->Size = System::Drawing::Size(14, 15);
			this->eRC->TabIndex = 8;
			this->eRC->Text = L"2";
			// 
			// fRC
			// 
			this->fRC->AutoSize = true;
			this->fRC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->fRC->Location = System::Drawing::Point(153, 104);
			this->fRC->Name = L"fRC";
			this->fRC->Size = System::Drawing::Size(14, 15);
			this->fRC->TabIndex = 10;
			this->fRC->Text = L"0";
			// 
			// tRC
			// 
			this->tRC->AutoSize = true;
			this->tRC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->tRC->Location = System::Drawing::Point(154, 68);
			this->tRC->Name = L"tRC";
			this->tRC->Size = System::Drawing::Size(14, 15);
			this->tRC->TabIndex = 9;
			this->tRC->Text = L"1";
			// 
			// mRC
			// 
			this->mRC->AutoSize = true;
			this->mRC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->mRC->Location = System::Drawing::Point(226, 51);
			this->mRC->Name = L"mRC";
			this->mRC->Size = System::Drawing::Size(14, 15);
			this->mRC->TabIndex = 8;
			this->mRC->Text = L"3";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Font = (gcnew System::Drawing::Font(L"Times New Roman", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label6->Location = System::Drawing::Point(6, 120);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(212, 19);
			this->label6->TabIndex = 5;
			this->label6->Text = L"”бито техники противника:";
			// 
			// sRC
			// 
			this->sRC->AutoSize = true;
			this->sRC->Font = (gcnew System::Drawing::Font(L"Times New Roman", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->sRC->Location = System::Drawing::Point(70, 32);
			this->sRC->Name = L"sRC";
			this->sRC->Size = System::Drawing::Size(14, 15);
			this->sRC->TabIndex = 7;
			this->sRC->Text = L"0";
			// 
			// label8
			// 
			this->label8->AutoSize = true;
			this->label8->Font = (gcnew System::Drawing::Font(L"Times New Roman", 11.25F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)), 
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->label8->Location = System::Drawing::Point(51, 84);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(89, 18);
			this->label8->TabIndex = 4;
			this->label8->Text = L"Х Ќаземна€:";
			// 
			// label9
			// 
			this->label9->AutoSize = true;
			this->label9->Font = (gcnew System::Drawing::Font(L"Times New Roman", 11.25F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)), 
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->label9->Location = System::Drawing::Point(51, 102);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(96, 18);
			this->label9->TabIndex = 3;
			this->label9->Text = L"Х ¬оздушна€:";
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->Font = (gcnew System::Drawing::Font(L"Times New Roman", 11.25F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)), 
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->label10->Location = System::Drawing::Point(51, 66);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(97, 18);
			this->label10->TabIndex = 2;
			this->label10->Text = L"Х “ранспорт:";
			// 
			// label11
			// 
			this->label11->AutoSize = true;
			this->label11->Font = (gcnew System::Drawing::Font(L"Times New Roman", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label11->Location = System::Drawing::Point(6, 47);
			this->label11->Name = L"label11";
			this->label11->Size = System::Drawing::Size(214, 19);
			this->label11->TabIndex = 1;
			this->label11->Text = L"ќбщее количество техники:";
			// 
			// label12
			// 
			this->label12->AutoSize = true;
			this->label12->Font = (gcnew System::Drawing::Font(L"Times New Roman", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label12->Location = System::Drawing::Point(6, 28);
			this->label12->Name = L"label12";
			this->label12->Size = System::Drawing::Size(58, 19);
			this->label12->TabIndex = 0;
			this->label12->Text = L"—пайс:";
			// 
			// listBox1
			// 
			this->listBox1->FormattingEnabled = true;
			this->listBox1->Location = System::Drawing::Point(1200, 50);
			this->listBox1->Name = L"listBox1";
			this->listBox1->Size = System::Drawing::Size(300, 498);
			this->listBox1->TabIndex = 9;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->BackColor = System::Drawing::Color::Transparent;
			this->label2->Font = (gcnew System::Drawing::Font(L"Times New Roman", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label2->Location = System::Drawing::Point(92, 37);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(61, 19);
			this->label2->TabIndex = 10;
			this->label2->Text = L"¬рем€:";
			// 
			// radioButton1
			// 
			this->radioButton1->AutoSize = true;
			this->radioButton1->BackColor = System::Drawing::Color::Transparent;
			this->radioButton1->Checked = true;
			this->radioButton1->Location = System::Drawing::Point(13, 17);
			this->radioButton1->Name = L"radioButton1";
			this->radioButton1->Size = System::Drawing::Size(53, 20);
			this->radioButton1->TabIndex = 11;
			this->radioButton1->TabStop = true;
			this->radioButton1->Text = L"> 1x";
			this->radioButton1->UseVisualStyleBackColor = false;
			this->radioButton1->CheckedChanged += gcnew System::EventHandler(this, &Form1::radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this->radioButton2->AutoSize = true;
			this->radioButton2->BackColor = System::Drawing::Color::Transparent;
			this->radioButton2->Location = System::Drawing::Point(14, 40);
			this->radioButton2->Name = L"radioButton2";
			this->radioButton2->Size = System::Drawing::Size(61, 20);
			this->radioButton2->TabIndex = 12;
			this->radioButton2->Text = L">> 4x";
			this->radioButton2->UseVisualStyleBackColor = false;
			this->radioButton2->CheckedChanged += gcnew System::EventHandler(this, &Form1::radioButton2_CheckedChanged);
			// 
			// radioButton3
			// 
			this->radioButton3->AutoSize = true;
			this->radioButton3->BackColor = System::Drawing::Color::Transparent;
			this->radioButton3->Location = System::Drawing::Point(14, 63);
			this->radioButton3->Name = L"radioButton3";
			this->radioButton3->Size = System::Drawing::Size(69, 20);
			this->radioButton3->TabIndex = 13;
			this->radioButton3->Text = L">>> 8x";
			this->radioButton3->UseVisualStyleBackColor = false;
			this->radioButton3->CheckedChanged += gcnew System::EventHandler(this, &Form1::radioButton3_CheckedChanged);
			// 
			// groupBox3
			// 
			this->groupBox3->BackColor = System::Drawing::SystemColors::Control;
			this->groupBox3->Controls->Add(this->radioButton3);
			this->groupBox3->Controls->Add(this->radioButton2);
			this->groupBox3->Controls->Add(this->radioButton1);
			this->groupBox3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->groupBox3->Location = System::Drawing::Point(80, 90);
			this->groupBox3->Name = L"groupBox3";
			this->groupBox3->Size = System::Drawing::Size(139, 88);
			this->groupBox3->TabIndex = 14;
			this->groupBox3->TabStop = false;
			this->groupBox3->Text = L"—корость игры";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->AutoScroll = true;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"$this.BackgroundImage")));
			this->ClientSize = System::Drawing::Size(704, 636);
			this->Controls->Add(this->groupBox3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->listBox1);
			this->Controls->Add(this->groupBox2);
			this->Controls->Add(this->groupBox1);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->label1);
			this->Name = L"Form1";
			this->Text = L"Ѕитва за ƒюну";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->groupBox2->ResumeLayout(false);
			this->groupBox2->PerformLayout();
			this->groupBox3->ResumeLayout(false);
			this->groupBox3->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
				 srand((unsigned)time( NULL ));
				 build = new Area;
				
				 //////////////////////////////////////////////////////////////////////////
				 //«агрузка изображений
				 sand= gcnew List<Image^>;	 
				 sand->Add( Image::FromFile( "pic\\sand1.png" ));
				 sand->Add( Image::FromFile( "pic\\sand2.png" ));
				 sand->Add( Image::FromFile( "pic\\sand1!.png" ));
				 sand->Add( Image::FromFile( "pic\\sand2!.png" ));
				 sand->Add( Image::FromFile( "pic\\sand1B.png" ));
				 sand->Add( Image::FromFile( "pic\\sand2B.png" ));
				 rock= gcnew List<Image^>;	 
				 rock->Add( Image::FromFile( "pic\\rock1.png" ));
				rock->Add( Image::FromFile( "pic\\rock2.png" ));
				rock->Add( Image::FromFile( "pic\\rock1!.png" ));
				rock->Add( Image::FromFile( "pic\\rock2!.png" ));
				rock->Add( Image::FromFile( "pic\\rock1B.png" ));
				rock->Add( Image::FromFile( "pic\\rock2B.png" ));
				spice= gcnew List<Image^>;	 
				  spice->Add( Image::FromFile( "pic\\spice1.png" ));
				   spice->Add( Image::FromFile( "pic\\spice2.png" ));
				   spice->Add( Image::FromFile( "pic\\spice1!.png" ));
				   spice->Add( Image::FromFile( "pic\\spice2!.png" ));
				   spice->Add( Image::FromFile( "pic\\spice1B.png" ));
				   spice->Add( Image::FromFile( "pic\\spice2B.png" ));
				   base_pic= gcnew List<Image^>;	 
				  base_pic->Add( Image::FromFile( "pic\\baseB.png" ));
				  base_pic->Add( Image::FromFile( "pic\\baseR.png" ));

				 //////////////////////////////////////////////////////////////////////////
				 this->timer1->Interval = 1000;	 
				 //√енераци€ ѕол€
				 field = gcnew array< Button^,2 >(22, 22);
				 for(int i = 0; i < 20; i++)
				 {
					 for(int j = 0;j < 20;j++)
					 {
						 field[i,j] = gcnew Button();
						 field[i,j]->Size = System::Drawing::Size(40, 40);
						 field[i,j]->Text=gcnew String("");
						 field[i,j]->Location = System::Drawing::Point(350 + 40*j, 25 + 40*i);
						 field[i,j]->Name = (i*20+j).ToString();
						 field[i,j]->Image = sand[0];
						 build->set_pic(i,j,0);
						 field[i,j]->FlatStyle = System::Windows::Forms::FlatStyle::Popup;
						 field[i,j]->Click += gcnew System::EventHandler(this, &Form1::field_Click);
						 Controls->Add(field[i,j]);
					 }
				 }

				 blue_base = rand()%3;
				 switch(blue_base)
				 {
				 case 0:
					 {
						 build->set_type(0,0,9);
						 build->set_type(1,0,9);
						 build->set_type(0,1,9);
						 field[0,0]->Image = base_pic[0];
						 field[1,0]->Image = base_pic[0];
						 field[0,1]->Image = base_pic[0];

						 build->set_type(19,19,10);
						 build->set_type(18,19,10);
						 build->set_type(19,18,10);
						 field[19,19]->Image = base_pic[1];
						 field[19,18]->Image = base_pic[1];
						 field[18,19]->Image = base_pic[1];
						 red_base=3;
						 break;
					 }

				 case 1:
					 {
						 build->set_type(0,19,9);
						 build->set_type(0,18,9);
						 build->set_type(1,19,9);
						 field[0,19]->Image = base_pic[0];
						 field[1,19]->Image = base_pic[0];
						 field[0,18]->Image = base_pic[0];

						 build->set_type(19,0,10);
						 build->set_type(18,0,10);
						 build->set_type(19,1,10);
						 field[19,0]->Image = base_pic[1];
						 field[19,1]->Image = base_pic[1];
						 field[18,0]->Image = base_pic[1];
						 red_base=2;
						 break;
					 }
				 case 2:
					 {
						 build->set_type(0,19,10);
						 build->set_type(1,19,10);
						 build->set_type(0,18,10);
						 field[0,19]->Image = base_pic[1];
						 field[1,19]->Image = base_pic[1];
						 field[0,18]->Image = base_pic[1];

						 build->set_type(19,0,9);
						 build->set_type(19,1,9);
						 build->set_type(18,0,9);
						 field[19,0]->Image = base_pic[0];
						 field[19,1]->Image = base_pic[0];
						 field[18,0]->Image = base_pic[0];
						 red_base=1;
						 break;
					 }
				 case 3:
					 {
						 build->set_type(0,0,10);
						 build->set_type(0,1,10);
						 build->set_type(1,0,10);
						 field[0,0]->Image = base_pic[1];
						 field[1,0]->Image = base_pic[1];
						 field[0,1]->Image = base_pic[1];

						 build->set_type(19,19,9);
						 build->set_type(18,19,9);
						 build->set_type(19,18,9);
						 field[19,19]->Image = base_pic[0];
						 field[19,18]->Image = base_pic[0];
						 field[18,19]->Image = base_pic[0];
						 red_base=0;
						 break;
					 }
				 }

				 for(int i = 0; i < 70; i++)
				 {
					 int x,y;
					 do{
						 x=rand()%20;
						 y=rand()%20;
					 }while(build->get_type(x,y)!=0);
					 int k=rand()%2;
					 this->field[x,y]->Image = spice[k];
					 build->set_pic(x,y,k);
					 build->set_type(x,y,2);
					 build->set_amount(x,y,rand()%500+500);

				 }

				 for(int i = 0; i < 50; i++)
				 {
					 int x;
					 int y;
					 do{
						 do{

							 x=rand()%20;
							 y=rand()%20;
						 }while(x==xR&&y==yR||x==xB&&y==yB);
					 }while(build->get_type(x,y)!=0);
					 int k=rand()%2;
					 field[x,y]->Image = rock[k];
					 build->set_pic(x,y,k);

					 build->set_type(x,y,1);

				 }

				 switch(blue_base)
				 {
				 case 0:
					 {
						 xB=1;
						 yB=1;
						 xR=18;
						 yR=18;
						 break;
					 }
				 case 1:
					 {
						 xB=1;
						 yB=18;
						 xR=18;
						 yR=1;
						 break;
					 }
				 case 2:
					 {
						 xB=18;
						 yB=1;
						 xR=1;
						 yR=18;
						 break;
					 }
				 case 3:
					 {
						 xB=18;
						 yB=18;
						 xR=1;
						 yR=1;
						 break;
					 }

				 }
				 Machinery *unit=NULL;
				 int gg;
				 gg=rand()%200+50;
				 unit=new Transport(xB,yB,gg,1,gg,500,rand()%20+100,4,0);
					Blue_team.push_back(unit);
					unit=NULL;
					 gg=rand()%200+50;
					 unit=new Transport(xR,yR,gg,2,gg,500,rand()%20+100,3,0);
					Red_team.push_back(unit);
						unit=NULL;
				 for(int i=0;i<2;i++)
				 {
					 unit=new Combat(xB,yB,gg,2,gg,3,2,rand()%10+50,0);
					 gg=rand()%20+300;
					 Blue_team.push_back(unit);
					 	unit=NULL;
					  gg=rand()%20+300;
					  unit=new Combat(xR,yR,gg,2,gg,2,3,rand()%10+50,0);
					 Red_team.push_back(unit);
					 	unit=NULL;
				 }
				 unit=NULL;
				 check_info();


				 build->set_unit(xR,yR,1);
				 build->set_unit(xB,yB,1);
				 area_rebuild_all();
			 }

//////////////////////////////////////////////////////////////////////////

	 private: System::Void field_Click(System::Object^  sender, System::EventArgs^  e) 
			  {
				   if(!start)
				   {
					   int t = Convert::ToInt32(((Button^) sender)->Name);
					   int x = t/20;
					   int y = t%20;
					   if(area_info(x,y))
					   {
						   switch(build->get_type(x,y))
						   {
							   case 0:MessageBox::Show("ѕесок!");break;
							   case 1:MessageBox::Show("√ора!");break;
							   case 2:MessageBox::Show(gcnew String("—пайс: "+build->get_amount(x,y)));break;
							   case 9:MessageBox::Show("—ин€€ база");break;
							   case 10:MessageBox::Show(" расна€ база");break;
						   }
						 }
				   }
				   else MessageBox::Show("„тобы просмотреть информацию о €чейке нажмите паузу");
			  }

//////////////////////////////////////////////////////////////////////////

			  bool check_field(int x,int y,int fly)
			  {
				  if(x<0||x>19||y<0||y>19)
					  return false;
				  if(fly==0)
				  {
					if(build->get_type(x,y)!=0&&build->get_type(x,y)!=2)
						return false;
					else 
						return true;
				  }
				  else
				  {
					if(build->get_type(x,y)==9&&build->get_type(x,y)==10)
						return false;
					else 
						return true;
				  }
				  
			  }

			  				  
//////////////////////////////////////////////////////////////////////////


			  void area_rebuild_all()
			  {
				   int x,y;
				   vector<Machinery *>::iterator cnt = Blue_team.begin();
				   while(cnt != Blue_team.end())
				   {
						x=(*cnt)->get_X();
						y=(*cnt)->get_Y();
						check_pic(x,y,0);
						cnt++;
				   }

				   vector<Machinery *>::iterator cnt1 = Red_team.begin();
				   while(cnt1 != Red_team.end())
				   {
					   x=(*cnt1)->get_X();
					   y=(*cnt1)->get_Y();
					   check_pic(x,y,1);
					   cnt1++;
				   }
			   }

//////////////////////////////////////////////////////////////////////////
void random_go(vector<Machinery *> &team,vector<Machinery *> &enemy,int xp, int yp,int teamN,int base_name)
{


	int k;
	bool f=false;
	int x,y;
	vector<Machinery *>::iterator cnt = team.begin();


	while(cnt!=team.end())
	{
		if((*cnt)->get_arm()==0)
		{
			build->set_unit((*cnt)->get_X(),(*cnt)->get_Y(),0);
			check_pic((*cnt)->get_X(),(*cnt)->get_Y(),base_name); 


			switch(base_name)
			{
			case 0:
				{
					Bred->inc_dc(1);
					Transport *test1 = dynamic_cast<Transport*>(*cnt);
					if(test1)
					{
						Bblue->dec_tc(1);
						listBox1->Items->Add(label1->Text+" | "+"—иний ’ј–¬≈—“≈– уничтожен");
					}

					Combat *test2 = dynamic_cast<Combat*>(*cnt);
					if(test2)
					{
						if(test2->get_f_m())
						{
							Bblue->dec_fc(1);
							listBox1->Items->Add(label1->Text+" | "+"—ин€€ Ќј«≈ћЌјя ≈ƒ»Ќ»÷ј уничтожена");
						}
						else
						{
							Bblue->dec_cc(1);
							listBox1->Items->Add(label1->Text+" | "+"—ин€€ ¬ќ«ƒ”ЎЌјя ≈ƒ»Ќ»÷ј уничтожена");

						}
					}


					break;
				}
			case 1:
				{
					Bblue->inc_dc(1);
					Transport *test1 = dynamic_cast<Transport*>(*cnt);
					if(test1)
					{
						Bred->dec_tc(1);
						listBox1->Items->Add(label1->Text+" | "+" расный ’ј–¬≈—“≈– уничтожен");
					}

					Combat *test2 = dynamic_cast<Combat*>(*cnt);
					if(test2)
					{
						if(test2->get_f_m())
						{
							Bred->dec_fc(1);
								listBox1->Items->Add(label1->Text+" | "+" расна€ Ќј«≈ћЌјя ≈ƒ»Ќ»÷ј уничтожена");
						}
						else
						{
							Bred->dec_cc(1);
								listBox1->Items->Add(label1->Text+" | "+" расна€ ¬ќ«ƒ”ЎЌјя ≈ƒ»Ќ»÷ј уничтожена");

						}

					}


					break;
				}
			}
			delete (*cnt);
			cnt = team.erase(cnt);
		}
		else
		{



			Transport *b = dynamic_cast<Transport*>(*cnt);
			if(b)
			{
				if(b->get_spc()==b->get_s_a())
					return_base(xp,yp,teamN,b,base_name);	
				else
				{
					if(build->get_type(b->get_X(),b->get_Y())==2)
						obtain_spice(b);
					else
					{

						do{
							k = rand()%8;
							x=b->get_X()+round_x[k];
							y=b->get_Y()+round_y[k];
							f=check_field(x,y,0);		 
						}while(f==false);
						build->set_unit(b->get_X(),b->get_Y(),0);
						check_pic(b->get_X(),b->get_Y(),base_name);
		
						b->move_at(x,y);
						build->set_unit(x,y,1);
						check_pic(x,y,base_name);

					}
				}
			}
			f=false;

			Combat *cb = dynamic_cast<Combat*>(*cnt);
			if(cb)
			{
				do{
					k = rand()%8;
					x=cb->get_X()+round_x[k];
					y=cb->get_Y()+round_y[k];
					f=check_field(x,y,cb->get_f_m());		 
				}while(f==false);
				if(cb->get_f_m()==0&&build->get_type(cb->get_X(),cb->get_Y())==2)
				{


					switch(base_name)
					{
					case 0: {
						//if(r) r->reduce();
						cb->dec_arm(1);
						break;}
					case 1: {cb->set_arm(1);break;}
					}
				}

				if(find_target(cb,enemy)==false)
				{

					build->set_unit(cb->get_X(),cb->get_Y(),0);
					check_pic(cb->get_X(),cb->get_Y(),base_name);

					
					
					cb->move_at(x,y);

					build->set_unit(x,y,1);
					check_pic(x,y,base_name);

				}
				
			
			}

			cnt++; 
		}

	}

}  


//////////////////////////////////////////////////////////////////////////
			  void area_rebuild(int x,int y,int MT)
			  {
				//  check_pic(x,y);
				// field[x,y]->Image = store[MT];
			  } 
//////////////////////////////////////////////////////////////////////////
			  bool area_info(int x,int y)
			  {
				 bool f=true;
				  int xp,yp;
				  vector<Machinery *>::iterator cnt = Blue_team.begin();
				  while(cnt != Blue_team.end())
				  {

					 xp=(*cnt)->get_X();
					 yp=(*cnt)->get_Y();
					 if(x==xp&&y==yp)
					 {
						 Transport *test=dynamic_cast<Transport*>(*cnt);
						 if(test) 
						 {
							
							 MessageBox::Show(gcnew String("»грок: —иний\n“ип: харвестер		\n’арактеристики:\n"+"   Х Ѕрон€: "+test->get_arm()+"/"+(*cnt)->get_ma()+"\n"+"   Х —корость: "+test->get_spd()+"\n"+"   Х —пайс: "+test->get_s_a()+"/"+test->get_spc())); 
							 f=false;
						 }
						 Combat *test1=dynamic_cast<Combat*>(*cnt);
						 if(test1) 
						 {
							 if(test1->get_f_m())
								MessageBox::Show(gcnew String("»грок: —иний\n“ип: воздушна€ единица		\n’арактеристики:\n"+"   Х Ѕрон€: "+test1->get_arm()+"/"+(*cnt)->get_ma()+"\n"+"   Х —корость: "+test1->get_spd()+"\n"+"   Х ”рон: "+test1->get_dmg()+"\n"+"   Х —корость атаки: "+test1->get_a_s())); 
							 else MessageBox::Show(gcnew String("»грок: —иний\n“ип: наземна€ единица		\n’арактеристики:\n"+"   Х Ѕрон€: "+test1->get_arm()+"/"+(*cnt)->get_ma()+"\n"+"   Х —корость: "+test1->get_spd()+"\n"+"   Х ”рон: "+test1->get_dmg()+"\n"+"   Х —корость атаки: "+test1->get_a_s())); 
							 f=false;
						 }
					 }
					  cnt++;
				  }

				  vector<Machinery *>::iterator cnt1 = Red_team.begin();
				  while(cnt1 != Red_team.end())
				  {

					  xp=(*cnt1)->get_X();
					  yp=(*cnt1)->get_Y();
					  if(x==xp&&y==yp)
					  {
						  Transport *test=dynamic_cast<Transport*>(*cnt1);
						  if(test) 
						  {

							  MessageBox::Show(gcnew String("»грок:  расный\n“ип: харвестер		\n’арактеристики:\n"+"   Х Ѕрон€: "+test->get_arm()+"/"+(*cnt1)->get_ma()+"\n"+"   Х —корость: "+test->get_spd()+"\n"+"   Х —пайс: "+test->get_s_a()+"/"+test->get_spc())); 
							  f=false;
						  }
						 Combat *test1=dynamic_cast<Combat*>(*cnt1);
						  if(test1) 
						  {
							  if(test1->get_f_m())
								 MessageBox::Show(gcnew String("»грок:  расный\n“ип: воздушна€ единица		\n’арактеристики:\n"+"   Х Ѕрон€: "+test1->get_arm()+"/"+(*cnt1)->get_ma()+"\n"+"   Х —корость: "+test1->get_spd()+"\n"+"   Х ”рон: "+test1->get_dmg()+"\n"+"   Х —корость атаки: "+test1->get_a_s())); 
							  else MessageBox::Show(gcnew String("»грок:  расный\n“ип: наземна€ единица		\n’арактеристики:\n"+"   Х Ѕрон€: "+test1->get_arm()+"/"+(*cnt1)->get_ma()+"\n"+"   Х —корость: "+test1->get_spd()+"\n"+"   Х ”рон: "+test1->get_dmg()+"\n"+"   Х —корость атаки: "+test1->get_a_s())); 
							  f=false;
						  }
					  }
					  cnt1++;
				  }
				 
				  return f;  
			  }
//////////////////////////////////////////////////////////////////////////
private: System::Void timer1_Tick(System::Object^  sender, System::EventArgs^  e) {

			 if(mySec==59)
				{
					myMin++;
					mySec=0;
			 
			 }
			 if(myMin<10)
			 {
				if(mySec<10)
					label1->Text="0"+myMin.ToString()+":0"+(mySec++).ToString();
				else 
					label1->Text="0"+myMin.ToString()+":"+(mySec++).ToString();
			 }
			 else
				 if(mySec<10)
					 label1->Text=myMin.ToString()+":0"+(mySec++).ToString();
				 else 
					 label1->Text=myMin.ToString()+":"+(mySec++).ToString();
			
		
			this->timer1->Stop();
			 int k=rand()%2;
			 switch(k)
			 {
			 case 0:{
				 random_go(Blue_team,Red_team,xB,yB,blue_base,0);
				 random_go(Red_team,Blue_team,xR,yR,red_base,1);
				 break;
					}
			 case 1:
				 {
					 
					 random_go(Red_team,Blue_team,xR,yR,red_base,1);
					 random_go(Blue_team,Red_team,xB,yB,blue_base,0);
					 break;
				 }
			 }
			
			victory();
			check_info();
			if(!win) this->timer1->Start();
			
		


		 }
//////////////////////////////////////////////////////////////////////////
	
//////////////////////////////////////////////////////////////////////////
private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

			 if(!win){
			start=true;
			this->timer1->Start();
			 }
		 }

private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
			 start=false;
			 this->timer1->Stop();
		 }


//////////////////////////////////////////////////////////////////////////

		 void return_base(int x,int y,int teamN,Transport *b,int base_name)
		 {
			int xp,yp;
			xp=b->get_X();
			yp=b->get_Y();
			
			
			build->set_unit(xp,yp,0);
			check_pic(xp,yp,base_name);
			if(x!=xp)
			{
				if(x>xp) 
					xp++;
				else 
					if(x<xp) 
						xp--;
			}

			if(y!=yp)
			{
				if(y>yp) 
					yp++;
				else  
					if(y<yp) 
						yp--;
			}
			
		
			b->move_at(xp,yp);
			build->set_unit(xp,yp,1);
			check_pic(xp,yp,base_name);
	
			if(x==xp&&y==yp)
			{
				b->drop_s_a();
				if(blue_base==teamN)
					Bblue->inc_spice(b->get_spc()); 
				else
					Bred->inc_spice(b->get_spc()); 
			 
			}
		 }



//////////////////////////////////////////////////////////////////////////

		bool find_target(Combat* cb,vector<Machinery *>&team)
		{
			int xp,yp;
			int rad=cb->get_rad();
			vector<Machinery *>::iterator cnt = team.begin();
			while(cnt!=team.end())
			{
				
				xp=(*cnt)->get_X();
				yp=(*cnt)->get_Y();
				//if(xp-rad==cb->get_X()||xp+rad==cb->get_X()||yp-rad==cb->get_Y()||yp+rad==cb->get_Y())
				{
					for(int i=1;i<=rad;i++)
					{
						for(int j=0;j<8;j++)
							if(cb->get_X()+round_x[j]*i==xp&&cb->get_Y()+round_y[j]*i==yp)
							{
								Machinery *target = dynamic_cast<Machinery*>(*cnt);
									if(target){ kill_combat(cb,target);
									return true;
									}
								/*Transport *target = dynamic_cast<Transport*>(*cnt);
									if(target) kill_transport(cb,target);*/
							}
								
					}
				}
				cnt++;
			}
			return false;
			
		
		}

//////////////////////////////////////////////////////////////////////////
		void kill_combat(Combat* cb,Machinery* target)
		{
			target->dec_arm(cb->get_dmg());
		}
//////////////////////////////////////////////////////////////////////////
		 void obtain_spice(Transport *b)
		 {	
			 b->spoil();
			 build->dec_amount(b->get_X(),b->get_Y(),b->get_o_s());
			 if(build->get_amount(b->get_X(),b->get_Y())<=0)
				 {
					 build->set_pic(b->get_X(),b->get_Y(),1);
					 build->set_type(b->get_X(),b->get_Y(),0);
				field[b->get_X(),b->get_Y()]->Image=sand[1];
			 }
				// check_pic(b->get_X(),b->get_Y());
		 }


//////////////////////////////////////////////////////////////////////////

void check_info()
{
	int k;
	if(Bblue->get_spice()>=2000||Bblue->get_tc()==0)
		create_unit(Bblue,Blue_team,0);
	 k=0;
	this->sBC->Text=(Bblue->get_spice()).ToString();
	k+=Bblue->get_tc();
	this->tBC->Text=(Bblue->get_tc()).ToString();
	k+=Bblue->get_cc();
	this->eBC->Text=(Bblue->get_cc()).ToString();
	k+=Bblue->get_fc();
	this->fBC->Text=(Bblue->get_fc()).ToString();
	this->mBC->Text=k.ToString();
	this->kBC->Text=(Bblue->get_dc()).ToString();

	
	if(Bred->get_spice()>=2000||Bred->get_tc()==0)
		create_unit(Bred,Red_team,1);

	k=0;
	this->sRC->Text=(Bred->get_spice()).ToString();
	k+=Bred->get_tc();
	this->tRC->Text=(Bred->get_tc()).ToString();
	k+=Bred->get_cc();
	this->eRC->Text=(Bred->get_cc()).ToString();
	k+=Bred->get_fc();
	this->fRC->Text=(Bred->get_fc()).ToString();
	this->mRC->Text=k.ToString();
	this->kRC->Text=(Bred->get_dc()).ToString();
	

}
//////////////////////////////////////////////////////////////////////////
void create_unit(Storehouse *col,vector<Machinery *>&team,int TN)
{
	int gg;
	if(col->get_tc()==0)
	{
		if(col->get_spice()>=1000)
		{
			gg=rand()%200+50;

			if(TN==0)
			{
				team.push_back(new Transport(xB,yB,gg,1,gg,500,rand()%20+100,4,0));
				listBox1->Items->Add(label1->Text+" | "+"—иний построил ’ј–¬≈…—“≈–");
				build->set_unit(xB,yB,1);
			}
			else
			{
				team.push_back(new Transport(xR,yR,gg,2,gg,500,rand()%20+100,3,0));
				listBox1->Items->Add(label1->Text+" | "+" расный построил ’ј–¬≈…—“≈–");
				build->set_unit(xR,yR,1);
			}
			col->dec_spice(1000);
			col->inc_tc(1);
		}
	}
	if(col->get_spice()>=2000)	
	{

	int k=rand()%2;
		switch(k)
		{
			case 0:
				{	gg=rand()%20+300;
					
					if(TN==0)
					{
						team.push_back(new Combat(xB,yB,gg,2,gg,2,2,rand()%10+50,0));
						listBox1->Items->Add(label1->Text+" | "+"—иний построил Ќј«≈ћЌ”ё ≈ƒ»Ќ»÷”");
						build->set_unit(xB,yB,1);
					}
					else
					{
						team.push_back(new Combat(xR,yR,gg,2,gg,2,2,rand()%10+50,0));
						listBox1->Items->Add(label1->Text+" | "+" расный построил Ќј«≈ћЌ”ё ≈ƒ»Ќ»÷”");
						build->set_unit(xR,yR,1);
					}
					col->dec_spice(1500);
					col->inc_cc(1);
					break;

				}
			case 1:
				{
					gg=rand()%10+50;
					if(TN==0)
					{
						team.push_back(new Combat(xB,yB,gg,3,gg,3,3,rand()%10+15,1));
						listBox1->Items->Add(label1->Text+" | "+"—иний построил ¬ќ«ƒ”ЎЌ”ё ≈ƒ»Ќ»÷”");
						build->set_unit(xB,yB,1);
					}

					else
					{
						team.push_back(new Combat(xR,yR,gg,3,gg,3,3,rand()%10+15,1));
						listBox1->Items->Add(label1->Text+" | "+" расный построил ¬ќ«ƒ”ЎЌ”ё ≈ƒ»Ќ»÷”");
						build->set_unit(xR,yR,1);
					
					}
					col->dec_spice(1500);
					col->inc_fc(1);
					break;

				}
		}
	}
		check_pic(xR,yR,1);
		check_pic(xB,yB,0);


}




void check_pic(int x,int y,int team)
{
	switch(build->get_type(x,y))
	{
	case 0:
		{
			switch(build->get_unit(x,y))
			{
				case 0: field[x,y]->Image=sand[build->get_pic(x,y)]; break;
				case 1: if(!team)field[x,y]->Image=sand[build->get_pic(x,y)+4]; else field[x,y]->Image=sand[build->get_pic(x,y)+2];  break;	
			}
			break;

	
		}
	case 1:
		{
			switch(build->get_unit(x,y))
			{
			case 0: field[x,y]->Image=rock[build->get_pic(x,y)]; break;
			case 1: if(!team)field[x,y]->Image=rock[build->get_pic(x,y)+4]; else field[x,y]->Image=rock[build->get_pic(x,y)+2]; break;	
			}
			break;


		}
	case 2:
		{
			switch(build->get_unit(x,y))
			{
			case 0: field[x,y]->Image=spice[build->get_pic(x,y)]; break;
			case 1: if(!team)field[x,y]->Image=spice[build->get_pic(x,y)+4]; else field[x,y]->Image=spice[build->get_pic(x,y)+2]; break;	
			}
			break;


		}
	}

}
//////////////////////////////////////////////////////////////////////////
void victory()
{
	if(win) return;
	if(Bred->get_tc()==0&&Bred->get_fc()==0&&Bred->get_cc()==0&&Bred->get_spice()<1000)
	{
		MessageBox::Show("—иний победил!!!");
		this->timer1->Stop();
		win=true;
	}
	if(Bblue->get_tc()==0&&Bblue->get_fc()==0&&Bblue->get_cc()==0&&Bblue->get_spice()<1000)
	{
		MessageBox::Show(" расный победил!!!");
		this->timer1->Stop();
		win=true;
	}

	

}
//////////////////////////////////////////////////////////////////////////
private: System::Void radioButton2_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			  this->timer1->Interval=250;
		 }
private: System::Void radioButton3_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			  this->timer1->Interval=125;
		 }
private: System::Void radioButton1_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			 this->timer1->Interval=1000;
		 }
};// ќнец всего





}///јщще јƒ

