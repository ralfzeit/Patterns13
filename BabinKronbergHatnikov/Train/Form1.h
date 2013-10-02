#pragma once
#include "_date.h"
#include "_time.h"
#include "passengers.h"
#include "stantion.h"
#include "vagon.h"
#include "types_vagons.h"
#include "train.h"
#include <conio.h>
#include <time.h>
#include <iostream>
#include <math.h>
//#include "header.h"

using namespace std;
using System::String;
namespace course_project_train {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для Form1
	///
	/// Внимание! При изменении имени этого класса необходимо также изменить
	///          свойство имени файла ресурсов ("Resource File Name") для средства компиляции управляемого ресурса,
	///          связанного со всеми файлами с расширением .resx, от которых зависит данный класс. В противном случае,
	///          конструкторы не смогут правильно работать с локализованными
	///          ресурсами, сопоставленными данной форме.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			int second=0; //счетчик секунд
			int speed=3; //скорость работы, 6-медленно, 3-нормально, 1-быстро

			_time now_time;
			_date now_date;

			train trains[30];
			stantion stantions[10];
			int passengers_oborudovanie[10];//количества пассажиров у которых имеются предпочтения 
			//в оборудовании вагона (индекс - станция (соответствует номеру станции в векторе станций)
			//, значение - количество)
			
			int cena_train[100];
			int cena_stant[10];//цены по категориям
			int cena_type_vag[2];

			int zagruz_vagonov[2];//0-kupe,1-plackart
			int **zagruz_marshrut;//загруженность маршрутов, где индекс-пункт отправления, 
			//0-ой элемент - пункт назначения, 1-й элемент сама загруженность 

			vector <int> viruchka_train; //выручка поездов
			vector <int> viruchka_stantion; //выручка каждой станции
			int viruchka_vagon[2];//0-kupe,1-plackart
			
			int ne_uehali[4];//
			//0-й элемент : 
			//
			//1-нет нужного поезда
			//2-нет оборудованного вагона
			//3-нет желаемого типа вагона
			//4-нет мест
			//
			//1-й элемент количество

			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}

	protected: 



	private:int second; //счетчик секунд
	private:int speed; //скорость работы, 6-медленно, 3-нормально, 1-быстро

	private:passengers **passenger;
	private:_time *now_time;
	private:_date *now_date;

	private:	int *cena_train;
	private:	int *cena_stant;//цены по категориям
	private:	int *cena_type_vag;

	private:train *trains;//=new train[30];
	private:stantion *stantions;
	private:int *passengers_oborudovanie;//количества пассажиров у которых имеются предпочтения 
			//в оборудовании вагона (индекс - станция (соответствует номеру станции в векторе станций)
			//, значение - количество)

	private:int *zagruz_vagonov;//0-kupe,1-plackart
	private:int **zagruz_marshrut;//загруженность маршрутов, где индекс-пункт отправления, 
			//0-ой элемент - пункт назначения, 1-й элемент сама загруженность 

	private:vector <int> *viruchka_train; //выручка поездов
	private:vector <int> *viruchka_stantion; //выручка каждой станции
	private:int *viruchka_vagon;//0-kupe,1-plackart
	private: int *ne_uehali;//
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::Button^  button3;
	private: System::Windows::Forms::ListBox^  listBox3;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::ListBox^  listBox2;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::ListBox^  listBox1;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::ListBox^  listBox4;
	private: System::Windows::Forms::ListBox^  listBox5;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::ListBox^  listBox6;
	private: System::Windows::Forms::Label^  label6;




	private: System::Windows::Forms::Label^  label7;






	private: System::Windows::Forms::Label^  label8;
	private: System::Windows::Forms::ListBox^  listBox10;
	private: System::Windows::Forms::Panel^  panel2;
	private: System::Windows::Forms::RadioButton^  radioButton5;
	private: System::Windows::Forms::RadioButton^  radioButton4;
	private: System::Windows::Forms::RadioButton^  radioButton3;
	private: System::Windows::Forms::Label^  label9;
	private: System::Windows::Forms::Panel^  panel3;
	private: System::Windows::Forms::Label^  label10;
	private: System::Windows::Forms::Label^  label12;
	private: System::Windows::Forms::Label^  label13;
	private: System::Windows::Forms::Label^  label11;
	private: System::Windows::Forms::ToolStrip^  toolStrip1;
	private: System::Windows::Forms::ToolStripSplitButton^  процесс;
	private: System::Windows::Forms::ToolStripMenuItem^  стартToolStripMenuItem;



	private: System::Windows::Forms::ToolStripMenuItem^  стопToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  выходToolStripMenuItem;
	private: System::Windows::Forms::Timer^  timer1;
private: System::Windows::Forms::ListBox^  listBox11;
private: System::Windows::Forms::Label^  label14;
private: System::Windows::Forms::TabPage^  tabPage2;
private: System::Windows::Forms::ListBox^  listBox8;
private: System::Windows::Forms::TabPage^  tabPage1;
private: System::Windows::Forms::ListBox^  listBox7;
private: System::Windows::Forms::TabControl^  tabControl1;
	private: System::ComponentModel::IContainer^  components;






	private:
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->listBox3 = (gcnew System::Windows::Forms::ListBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->listBox2 = (gcnew System::Windows::Forms::ListBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->listBox1 = (gcnew System::Windows::Forms::ListBox());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->listBox4 = (gcnew System::Windows::Forms::ListBox());
			this->listBox5 = (gcnew System::Windows::Forms::ListBox());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->listBox6 = (gcnew System::Windows::Forms::ListBox());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->listBox10 = (gcnew System::Windows::Forms::ListBox());
			this->panel2 = (gcnew System::Windows::Forms::Panel());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->radioButton5 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton4 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton3 = (gcnew System::Windows::Forms::RadioButton());
			this->panel3 = (gcnew System::Windows::Forms::Panel());
			this->label12 = (gcnew System::Windows::Forms::Label());
			this->label13 = (gcnew System::Windows::Forms::Label());
			this->label11 = (gcnew System::Windows::Forms::Label());
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->toolStrip1 = (gcnew System::Windows::Forms::ToolStrip());
			this->процесс = (gcnew System::Windows::Forms::ToolStripSplitButton());
			this->стартToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->стопToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->выходToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->listBox11 = (gcnew System::Windows::Forms::ListBox());
			this->label14 = (gcnew System::Windows::Forms::Label());
			this->tabPage2 = (gcnew System::Windows::Forms::TabPage());
			this->listBox8 = (gcnew System::Windows::Forms::ListBox());
			this->tabPage1 = (gcnew System::Windows::Forms::TabPage());
			this->listBox7 = (gcnew System::Windows::Forms::ListBox());
			this->tabControl1 = (gcnew System::Windows::Forms::TabControl());
			this->panel2->SuspendLayout();
			this->panel3->SuspendLayout();
			this->toolStrip1->SuspendLayout();
			this->tabPage2->SuspendLayout();
			this->tabPage1->SuspendLayout();
			this->tabControl1->SuspendLayout();
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F));
			this->button1->Location = System::Drawing::Point(63, 53);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 1;
			this->button1->Text = L"start";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(63, 82);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(75, 23);
			this->button2->TabIndex = 2;
			this->button2->Text = L"stop";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &Form1::Form1_Load);
			// 
			// button3
			// 
			this->button3->Location = System::Drawing::Point(63, 110);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(75, 23);
			this->button3->TabIndex = 3;
			this->button3->Text = L"exit";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &Form1::button3_Click);
			// 
			// listBox3
			// 
			this->listBox3->FormattingEnabled = true;
			this->listBox3->Location = System::Drawing::Point(239, 40);
			this->listBox3->Name = L"listBox3";
			this->listBox3->Size = System::Drawing::Size(203, 134);
			this->listBox3->TabIndex = 11;
			this->listBox3->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox3_SelectedIndexChanged);
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(236, 24);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(44, 13);
			this->label3->TabIndex = 10;
			this->label3->Text = L"вагоны";
			// 
			// listBox2
			// 
			this->listBox2->FormattingEnabled = true;
			this->listBox2->Location = System::Drawing::Point(118, 40);
			this->listBox2->Name = L"listBox2";
			this->listBox2->Size = System::Drawing::Size(115, 134);
			this->listBox2->TabIndex = 9;
			this->listBox2->Click += gcnew System::EventHandler(this, &Form1::listBox2_Click);
			this->listBox2->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox2_SelectedIndexChanged);
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(115, 24);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(43, 13);
			this->label2->TabIndex = 8;
			this->label2->Text = L"поезда";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 24);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(48, 13);
			this->label1->TabIndex = 7;
			this->label1->Text = L"станции";
			// 
			// listBox1
			// 
			this->listBox1->FormattingEnabled = true;
			this->listBox1->Location = System::Drawing::Point(12, 40);
			this->listBox1->Name = L"listBox1";
			this->listBox1->Size = System::Drawing::Size(100, 134);
			this->listBox1->TabIndex = 6;
			this->listBox1->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox1_SelectedIndexChanged);
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(12, 179);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(158, 39);
			this->label4->TabIndex = 12;
			this->label4->Text = L"Количество пассажиров, \r\nтребующих дополнительное \r\nоборудование вагонов";
			// 
			// listBox4
			// 
			this->listBox4->FormattingEnabled = true;
			this->listBox4->Location = System::Drawing::Point(15, 221);
			this->listBox4->Name = L"listBox4";
			this->listBox4->Size = System::Drawing::Size(120, 147);
			this->listBox4->TabIndex = 13;
			this->listBox4->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox4_SelectedIndexChanged);
			// 
			// listBox5
			// 
			this->listBox5->FormattingEnabled = true;
			this->listBox5->Location = System::Drawing::Point(155, 221);
			this->listBox5->Name = L"listBox5";
			this->listBox5->Size = System::Drawing::Size(126, 147);
			this->listBox5->TabIndex = 15;
			this->listBox5->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox5_SelectedIndexChanged);
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(162, 205);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(129, 13);
			this->label5->TabIndex = 14;
			this->label5->Text = L"Загруженность вагонов";
			this->label5->Click += gcnew System::EventHandler(this, &Form1::label5_Click);
			// 
			// listBox6
			// 
			this->listBox6->FormattingEnabled = true;
			this->listBox6->Location = System::Drawing::Point(304, 221);
			this->listBox6->Name = L"listBox6";
			this->listBox6->Size = System::Drawing::Size(120, 147);
			this->listBox6->TabIndex = 17;
			this->listBox6->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox6_SelectedIndexChanged);
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(301, 192);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(88, 26);
			this->label6->TabIndex = 16;
			this->label6->Text = L"Загруженность \r\nмаршрутов";
			// 
			// label7
			// 
			this->label7->AutoSize = true;
			this->label7->Location = System::Drawing::Point(544, 26);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(51, 13);
			this->label7->TabIndex = 19;
			this->label7->Text = L"выручка";
			// 
			// label8
			// 
			this->label8->AutoSize = true;
			this->label8->Location = System::Drawing::Point(718, 29);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(72, 26);
			this->label8->TabIndex = 20;
			this->label8->Text = L"неуехавшие \r\nпассажиры";
			// 
			// listBox10
			// 
			this->listBox10->FormattingEnabled = true;
			this->listBox10->Location = System::Drawing::Point(721, 58);
			this->listBox10->Name = L"listBox10";
			this->listBox10->Size = System::Drawing::Size(142, 160);
			this->listBox10->TabIndex = 21;
			this->listBox10->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox10_SelectedIndexChanged);
			// 
			// panel2
			// 
			this->panel2->Controls->Add(this->label9);
			this->panel2->Controls->Add(this->radioButton5);
			this->panel2->Controls->Add(this->radioButton4);
			this->panel2->Controls->Add(this->radioButton3);
			this->panel2->Controls->Add(this->button3);
			this->panel2->Controls->Add(this->button1);
			this->panel2->Controls->Add(this->button2);
			this->panel2->Location = System::Drawing::Point(714, 223);
			this->panel2->Name = L"panel2";
			this->panel2->Size = System::Drawing::Size(148, 142);
			this->panel2->TabIndex = 22;
			this->panel2->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::panel2_Paint);
			// 
			// label9
			// 
			this->label9->AutoSize = true;
			this->label9->Location = System::Drawing::Point(41, 14);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(53, 13);
			this->label9->TabIndex = 23;
			this->label9->Text = L"скорость";
			// 
			// radioButton5
			// 
			this->radioButton5->AutoSize = true;
			this->radioButton5->Location = System::Drawing::Point(97, 30);
			this->radioButton5->Name = L"radioButton5";
			this->radioButton5->Size = System::Drawing::Size(49, 17);
			this->radioButton5->TabIndex = 6;
			this->radioButton5->TabStop = true;
			this->radioButton5->Text = L"hight";
			this->radioButton5->UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this->radioButton4->AutoSize = true;
			this->radioButton4->Location = System::Drawing::Point(44, 30);
			this->radioButton4->Name = L"radioButton4";
			this->radioButton4->Size = System::Drawing::Size(57, 17);
			this->radioButton4->TabIndex = 5;
			this->radioButton4->TabStop = true;
			this->radioButton4->Text = L"normal";
			this->radioButton4->UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this->radioButton3->AutoSize = true;
			this->radioButton3->Location = System::Drawing::Point(6, 30);
			this->radioButton3->Name = L"radioButton3";
			this->radioButton3->Size = System::Drawing::Size(41, 17);
			this->radioButton3->TabIndex = 4;
			this->radioButton3->TabStop = true;
			this->radioButton3->Text = L"low";
			this->radioButton3->UseVisualStyleBackColor = true;
			this->radioButton3->CheckedChanged += gcnew System::EventHandler(this, &Form1::radioButton3_CheckedChanged);
			// 
			// panel3
			// 
			this->panel3->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
			this->panel3->Controls->Add(this->label12);
			this->panel3->Controls->Add(this->label13);
			this->panel3->Controls->Add(this->label11);
			this->panel3->Location = System::Drawing::Point(430, 259);
			this->panel3->Name = L"panel3";
			this->panel3->Size = System::Drawing::Size(110, 101);
			this->panel3->TabIndex = 23;
			this->panel3->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::panel3_Paint);
			// 
			// label12
			// 
			this->label12->AutoSize = true;
			this->label12->Font = (gcnew System::Drawing::Font(L"Segoe Print", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label12->Location = System::Drawing::Point(3, 21);
			this->label12->Name = L"label12";
			this->label12->RightToLeft = System::Windows::Forms::RightToLeft::No;
			this->label12->Size = System::Drawing::Size(48, 28);
			this->label12->TabIndex = 28;
			this->label12->Text = L"data";
			this->label12->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// label13
			// 
			this->label13->AutoSize = true;
			this->label13->Font = (gcnew System::Drawing::Font(L"Segoe Print", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label13->Location = System::Drawing::Point(3, 69);
			this->label13->Name = L"label13";
			this->label13->RightToLeft = System::Windows::Forms::RightToLeft::No;
			this->label13->Size = System::Drawing::Size(48, 28);
			this->label13->TabIndex = 27;
			this->label13->Text = L"data";
			this->label13->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// label11
			// 
			this->label11->AutoSize = true;
			this->label11->Location = System::Drawing::Point(3, 49);
			this->label11->Name = L"label11";
			this->label11->Size = System::Drawing::Size(32, 13);
			this->label11->TabIndex = 25;
			this->label11->Text = L"дата";
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->Location = System::Drawing::Point(427, 243);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(37, 13);
			this->label10->TabIndex = 24;
			this->label10->Text = L"время";
			// 
			// toolStrip1
			// 
			this->toolStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) {this->процесс});
			this->toolStrip1->Location = System::Drawing::Point(0, 0);
			this->toolStrip1->Name = L"toolStrip1";
			this->toolStrip1->Size = System::Drawing::Size(875, 25);
			this->toolStrip1->TabIndex = 24;
			this->toolStrip1->Text = L"toolStrip1";
			this->toolStrip1->ItemClicked += gcnew System::Windows::Forms::ToolStripItemClickedEventHandler(this, &Form1::toolStrip1_ItemClicked);
			// 
			// процесс
			// 
			this->процесс->DisplayStyle = System::Windows::Forms::ToolStripItemDisplayStyle::Text;
			this->процесс->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(3) {this->стартToolStripMenuItem, 
				this->стопToolStripMenuItem, this->выходToolStripMenuItem});
			this->процесс->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"процесс.Image")));
			this->процесс->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->процесс->Name = L"процесс";
			this->процесс->Size = System::Drawing::Size(69, 22);
			this->процесс->Text = L"процесс";
			// 
			// стартToolStripMenuItem
			// 
			this->стартToolStripMenuItem->Name = L"стартToolStripMenuItem";
			this->стартToolStripMenuItem->Size = System::Drawing::Size(107, 22);
			this->стартToolStripMenuItem->Text = L"старт";
			this->стартToolStripMenuItem->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// стопToolStripMenuItem
			// 
			this->стопToolStripMenuItem->Name = L"стопToolStripMenuItem";
			this->стопToolStripMenuItem->Size = System::Drawing::Size(107, 22);
			this->стопToolStripMenuItem->Text = L"стоп";
			this->стопToolStripMenuItem->Click += gcnew System::EventHandler(this, &Form1::Form1_Load);
			// 
			// выходToolStripMenuItem
			// 
			this->выходToolStripMenuItem->Name = L"выходToolStripMenuItem";
			this->выходToolStripMenuItem->Size = System::Drawing::Size(107, 22);
			this->выходToolStripMenuItem->Text = L"выход";
			this->выходToolStripMenuItem->Click += gcnew System::EventHandler(this, &Form1::button3_Click);
			// 
			// timer1
			// 
			this->timer1->Tick += gcnew System::EventHandler(this, &Form1::timer1_Tick);
			// 
			// listBox11
			// 
			this->listBox11->FormattingEnabled = true;
			this->listBox11->Location = System::Drawing::Point(444, 40);
			this->listBox11->Name = L"listBox11";
			this->listBox11->Size = System::Drawing::Size(97, 134);
			this->listBox11->TabIndex = 25;
			this->listBox11->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox11_SelectedIndexChanged);
			// 
			// label14
			// 
			this->label14->AutoSize = true;
			this->label14->Location = System::Drawing::Point(441, 23);
			this->label14->Name = L"label14";
			this->label14->Size = System::Drawing::Size(98, 13);
			this->label14->TabIndex = 26;
			this->label14->Text = L"состояние поезда";
			// 
			// tabPage2
			// 
			this->tabPage2->Controls->Add(this->listBox8);
			this->tabPage2->Location = System::Drawing::Point(4, 22);
			this->tabPage2->Name = L"tabPage2";
			this->tabPage2->Padding = System::Windows::Forms::Padding(3);
			this->tabPage2->Size = System::Drawing::Size(159, 302);
			this->tabPage2->TabIndex = 1;
			this->tabPage2->Text = L"поезда";
			this->tabPage2->UseVisualStyleBackColor = true;
			// 
			// listBox8
			// 
			this->listBox8->FormattingEnabled = true;
			this->listBox8->Location = System::Drawing::Point(6, 0);
			this->listBox8->Name = L"listBox8";
			this->listBox8->Size = System::Drawing::Size(142, 290);
			this->listBox8->TabIndex = 21;
			this->listBox8->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox8_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this->tabPage1->Controls->Add(this->listBox7);
			this->tabPage1->Location = System::Drawing::Point(4, 22);
			this->tabPage1->Name = L"tabPage1";
			this->tabPage1->Padding = System::Windows::Forms::Padding(3);
			this->tabPage1->Size = System::Drawing::Size(159, 302);
			this->tabPage1->TabIndex = 0;
			this->tabPage1->Text = L"станции";
			this->tabPage1->UseVisualStyleBackColor = true;
			// 
			// listBox7
			// 
			this->listBox7->FormattingEnabled = true;
			this->listBox7->Location = System::Drawing::Point(10, 9);
			this->listBox7->Name = L"listBox7";
			this->listBox7->Size = System::Drawing::Size(143, 290);
			this->listBox7->TabIndex = 20;
			this->listBox7->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::listBox7_SelectedIndexChanged);
			// 
			// tabControl1
			// 
			this->tabControl1->Controls->Add(this->tabPage1);
			this->tabControl1->Controls->Add(this->tabPage2);
			this->tabControl1->Location = System::Drawing::Point(547, 39);
			this->tabControl1->Name = L"tabControl1";
			this->tabControl1->SelectedIndex = 0;
			this->tabControl1->Size = System::Drawing::Size(167, 328);
			this->tabControl1->TabIndex = 18;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(875, 375);
			this->Controls->Add(this->label14);
			this->Controls->Add(this->listBox11);
			this->Controls->Add(this->toolStrip1);
			this->Controls->Add(this->label10);
			this->Controls->Add(this->panel2);
			this->Controls->Add(this->listBox10);
			this->Controls->Add(this->label8);
			this->Controls->Add(this->label7);
			this->Controls->Add(this->tabControl1);
			this->Controls->Add(this->listBox6);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->listBox5);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->listBox4);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->listBox3);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->listBox2);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->listBox1);
			this->Controls->Add(this->panel3);
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->panel2->ResumeLayout(false);
			this->panel2->PerformLayout();
			this->panel3->ResumeLayout(false);
			this->panel3->PerformLayout();
			this->toolStrip1->ResumeLayout(false);
			this->toolStrip1->PerformLayout();
			this->tabPage2->ResumeLayout(false);
			this->tabPage1->ResumeLayout(false);
			this->tabControl1->ResumeLayout(false);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
		private: System::Void listBox2_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 }
	private: System::Void listBox5_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 }
private: System::Void label5_Click(System::Object^  sender, System::EventArgs^  e) {
			 }
private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Close();
		 }
private: System::Void listBox2_Click(System::Object^  sender, System::EventArgs^  e) {
			 int number=listBox2->SelectedIndex;
			 this->listBox3->Items->Clear();
			 this->listBox3->Items->Add("пассажирские");
			 for (int i=0;i<trains[number].vagons1.size();i++)
			 {
				 this->listBox3->Items->Add(trains[number].vagons1[i].get_nomer()+" тип "+\
					 trains[number].vagons1[i].get_type()+"оборудован "+trains[number].vagons1[i].get_oborudovanie()+" св.м. "+\
					 trains[number].vagons1[i].get_free_mesta());
			 }
			 this->listBox3->Items->Add("служебные");
			 for (int i=0;i<trains[number].vagons2.size();i++)
			 {
				 this->listBox3->Items->Add(trains[number].vagons2[i].get_nomer()+" тип "+\
					 trains[number].vagons2[i].get_type());
			 }
			 this->listBox11->Items->Clear();
			 this->listBox11->Items->Add("вр.отпр. "+trains[number].get_time_otpravlenie().get_time());
			 this->listBox11->Items->Add("вр.приб. "+trains[number].get_time_pribitia().get_time());

			 if (trains[number].get_sostoyanie()==0)this->listBox11->Items->Add("поезд стоит");
			 else this->listBox11->Items->Add("поезд в пути");
		 }
private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
			 this->listBox2->Items->Clear();

			 cena_train = new int[100];
			 cena_stant = new int[10];//цены по категориям
			 cena_type_vag = new int[2];
			 ne_uehali=new int[4];
			 for (int i=0;i<2;i++)
			 {
				 cena_type_vag[i]=0;
			 }
			 for (int i=0;i<4;i++)
			 {
				 ne_uehali[i]=0;
			 }
			 srand((unsigned)time(NULL));
			 trains = new train[30];
			 stantions = new stantion[10];

			 int kol_stantions;//количество станций 
			 do{
				 kol_stantions=rand()%7;
			 }while(kol_stantions<3);

			 passengers_oborudovanie=new int[kol_stantions];
			 for(int i=0;i<kol_stantions;i++)
			 {
				 passengers_oborudovanie[i]=0;
				 cena_stant[i]=0;
			 }
			this->listBox1->Items->Clear();

			 vector <stantion> st;
			 st.clear();
			 stantion *new_stantion;
			 for (int i=0;i<kol_stantions;i++)
			 {
				 new_stantion = new stantion(rand()%100,rand()%100);//.set_stantion(x1,y1);
				 new_stantion->set_nom(i+1);
				 st.push_back( *new_stantion );
				 this->listBox1->Items->Add((i+1).ToString()+" ("+new_stantion->get_x().ToString()+";"+new_stantion->get_y().ToString()+")");
				// this->listBox1->Items->Add(" ("+x1.ToString()+";"+y1.ToString()+")");
				 delete new_stantion;
			 }
			 int nn=st.size();
			 int kol_trains=0;
			 {
				 for (int i=1;i<nn;i++) kol_trains+=i; //подсчет необходимого минимального колиества поездов  
			 }

			 vector <train> tr;
			 tr.clear();
			 int st_pr=1,st_ot=0;
			 train *new_train;
			 vagon *new_vagon;
			 for (int i=0;i<kol_trains;i++) //создание поездов
			 {
				 cena_train[i]=0;
				 int kol_vag;
				 do{kol_vag=rand()%8;}while(kol_vag<3);//генерирование количества вагонов
				 int kol_sluj_vag;
				 do{kol_sluj_vag=rand()%kol_vag;}while(kol_sluj_vag>2);//генерирование количества служебных вагоннов
				 int kol_pas_vag=kol_vag-kol_sluj_vag;

				 int hour1=rand()%24;
				 int minut1=rand()%60;
				 _time ti_ot(hour1,minut1);

				 hour1=rand()%24;
				 minut1=rand()%60;
				 _time ti_pr(hour1,minut1);
				 new_train = new train(rand()%1000,st[st_ot],st[st_pr],ti_ot,ti_pr);
				 this->listBox2->Items->Add("№ "+new_train->get_nomer()+"  (ot "+(st_ot+1).ToString()+" do "+\
					 (st_pr+1).ToString()+")");
				 
				 vagon_slujebnii *new_vagon_slujebnii;
				 tr.push_back(*new_train); st_pr++;

				 if (kol_sluj_vag>0)
				 for (int ii=0;ii<kol_sluj_vag;ii++)  //создание служебных вагонов
				 {
					 int nom1=ii+1;
					 int type1=rand()%3+1;

					 new_vagon_slujebnii = new vagon_slujebnii(nom1,type1);
					 tr[i].add_vagons(*new_vagon_slujebnii);
					 delete new_vagon_slujebnii;
				 }

				 vagon_passenger *new_vagon_passenger;
				 for (int ii=0;ii<kol_pas_vag;ii++)  //создание пассажирских вагонов
				 {
					 int mesta;
					 int nom1=ii+1+kol_sluj_vag;
					 int type1=rand()%2+1; //генерирование типа (купе плацкарт)
					 
					 if (type1==1) mesta=60;//60 //количество мест в вагоне
					 else mesta=40;

					 int oborudovanie1=rand()%9; //генерирование оборудования в вагоне
					 if (oborudovanie1>3) oborudovanie1=0; //необорудованных вагонов больше

					 new_vagon_passenger = new vagon_passenger(mesta,nom1,type1,oborudovanie1,2);
					 tr[i].add_vagons(*new_vagon_passenger);
					 delete new_vagon_passenger;
				 }


				 if (st_pr==kol_stantions) {st_pr=st_ot+2;st_ot++;}
				
				 delete new_train;
			 }

			 speed=15;//3 4 5
			 this->timer1->Stop();
			 if (this->radioButton3->Checked==true) speed=15;
			 if (this->radioButton4->Checked==true) speed=30;
			 if (this->radioButton5->Checked==true) speed=60;
			 now_time = new _time();
			 now_date = new _date();
			 this->button2->Enabled=false;
			 

			 for (int i=0;i<tr.size();i++)
				 trains[i]=tr[i];
			 for (int i=0;i<st.size();i++)
				 stantions[i]=st[i];
			 //trains =*tr;
//			 stantions=*st;
		 }
private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
			 if (this->button1->Text=="start") 
			 {
				 this->button1->Text="pause";
				 this->button2->Enabled=true;
				timer1->Start();
			 }

			 else 
			 {
				 this->button1->Text="start";
				 timer1->Stop();

				 int kol_trains=0;
				 for (int i=0;i<INT_MAX;i++)
				 {
					 if (trains[i].get_nomer()!=-1) kol_trains++; //подсчет количества поездов
					 else break;
				 }
				 int zagr_kupe=0;
				 int svob_kupe=0;
				 int zagr_plac=0;
				 int svob_plac=0;
				 int zagr_line=0;
				 int svob_line=0;
				 this->listBox6->Items->Clear();
				 for (int i=0;i<kol_trains;i++) //подсчет загруженности линий
				 {
					 for(int ii=0;ii<trains[i].vagons1.size();ii++) //1-plac 2-kupe
					 {
						 if (trains[i].vagons1[ii].get_type()==1)
						 {
							 svob_line+=svob_plac+=trains[i].vagons1[ii].get_mesta();
							 zagr_line+=zagr_plac+=trains[i].vagons1[ii].get_mesta()-trains[i].vagons1[ii].get_free_mesta();
						 }
						 if (trains[i].vagons1[ii].get_type()==2)
						 {
							 svob_line+=svob_kupe+=trains[i].vagons1[ii].get_mesta();
							 zagr_line+=zagr_kupe+=trains[i].vagons1[ii].get_mesta()-trains[i].vagons1[ii].get_free_mesta();
						 }
					 }
					 this->listBox6->Items->Add("Линия "+trains[i].get_st_otpravlenie().get_nom()+"-"\
						 +trains[i].get_st_naznachenie().get_nom()+" загр. "+int(float(zagr_line)/float(svob_line)*(100))+" % ");
				 }
				 this->listBox5->Items->Clear();
				 this->listBox5->Items->Add("плацк. "+int(float(zagr_plac)/float(svob_plac)*100)+" % ");
				 this->listBox5->Items->Add("купе "+int(float(zagr_kupe)/float(svob_kupe)*100)+" % ");
			 }
		 }
private: System::Void timer1_Tick(System::Object^  sender, System::EventArgs^  e) {
			 if (this->radioButton3->Checked==true) speed=10;
			 if (this->radioButton4->Checked==true) speed=30;
			 if (this->radioButton5->Checked==true) speed=60;
				 now_time->time_plus(speed);
				 if (now_time->get_hour()==0 && now_time->get_minut()==0) now_date->date_plus();
				 this->label12->Text = now_time->get_time();
				 this->label13->Text = now_date->get_date();

				 ///////////
				 /////////// проверка времени для отправления/прибытия поезда
				 ///////////
				 int kol_trains=0;
				 for (int i=0;i<INT_MAX;i++)
				 {
					 if (trains[i].get_nomer()!=-1) kol_trains++; //подсчет количества поездов
					 else break;
				 }
				 for (int i=0;i<kol_trains;i++)
				 {
					 if (trains[i].get_sostoyanie()==0)
					 {
						 if (now_time->get_hour()==trains[i].get_time_otpravlenie().get_hour())
						 {
							 if (now_time->get_minut()>=trains[i].get_time_otpravlenie().get_minut())
								 trains[i].set_sostoyanie(1);
						 }
					 }
					 else 
					 {
						 if (now_time->get_hour()==trains[i].get_time_pribitia().get_hour())
						 {
							 if (now_time->get_minut()>=trains[i].get_time_pribitia().get_minut())
							 {
								 for (int ii=0;ii<trains[i].vagons1.size();ii++)
								 {
									 trains[i].vagons1[ii].all_free_mesto(); //освобождение мест
								 }
								 trains[i].set_sostoyanie(0);
								 stantion t=trains[i].get_st_naznachenie();
								 trains[i].set_st_naznachenie(trains[i].get_st_otpravlenie());
								 trains[i].set_st_otpravlenie(t);
							 }
						 }
					 }
				 }

				 ///////////
				 /////////// генерирование пассажиров
				 ///////////
				 vector <stantion> st;
				 for (int i=0;i<10;i++)
				 {
					 if (stantions[i].get_x()!=-1) st.push_back(stantions[i]);
					 else break;
				 }

				 passengers **pas; //генерирование пассажиров
				 pas = new passengers*[st.size()];
				 for (int i=0;i<st.size();i++)
				 {
					 int kol_pas;
					 do{kol_pas=rand()%5*speed/15;}while(kol_pas<1);
					 pas[i] = new passengers [kol_pas];
					 for (int j=0;j<kol_pas;j++)
					 {
						 pas[i][j].set_stantion_otpravlenie(st[i]);//станция отправления

						 int st_naz;
						 do{st_naz=rand()%st.size();}while(st_naz==i);
						 pas[i][j].set_stantion_naznachenie(st[st_naz]);//станция назначения

						 _date *new_date1;	
						 new_date1 = new _date(now_date->get_day()+rand()%2,now_date->get_mounth(),now_date->get_year());
						 //дата отъезда пассажира
						 delete new_date1;
						 int type_predp1=rand()%5; 
						 if (type_predp1>2) type_predp1=0; //предпостение импа()купе плацкарт
						 pas[i][j].set_type_predpochtenie(type_predp1);
					 
						 int obor_predp1=rand()%6; 
						 if (obor_predp1>3) obor_predp1=0; //предпочтение оборудования
						 pas[i][j].set_oborudovanie_predpochtenie(obor_predp1);

						 int nom_poezd1=rand()%40;	
						 if (nom_poezd1==1) nom_poezd1=rand()%1000; // предпочтение в номере поезда 
						 else nom_poezd1=0;
						 pas[i][j].set_nomer_poezda(nom_poezd1);

						 ///////////////////////////////
						 /////////////////////////////// проверка купил ли пассажир билет или нет
						 ///////////////////////////////
						 int kupil=0;
						 
						 if (pas[i][j].get_oborudovanie_predpochtenie()!=0) passengers_oborudovanie[i]++;
						 if (pas[i][j].get_nomer_poezda()==0) //если пассажиру без разницы номер поезда
						 {
							 kupil=1;
						 }
						 else
						 {
							 int kupil=0;
							 for (int ii=0;ii<kol_trains;ii++)
							 {
								 if (trains[ii].get_nomer()==pas[i][j].get_nomer_poezda())
								 {
									 if (trains[ii].get_st_otpravlenie().get_nom()==\
										 pas[i][j].get_stantion_otpravlenie().get_nom() &&\
										 trains[ii].get_st_naznachenie().get_nom()==\
										 pas[i][j].get_stantion_naznachenie().get_nom())
									 {
										 kupil=1;break;
									 }
								 }
							 }
						 }
						 if (kupil==0) ne_uehali[0]++;
						 else if (kupil==1)
						 {
							 for (int ii=0;ii<kol_trains;ii++)
							 {
								 if (pas[i][j].get_stantion_otpravlenie().get_nom()==\
									 trains[ii].get_st_otpravlenie().get_nom() &&\
									 pas[i][j].get_stantion_naznachenie().get_nom()==\
									 trains[ii].get_st_naznachenie().get_nom()) 
									 //если совпадают станции отправления и назначения
								 {
									 int kup1=0;
									 if (pas[i][j].get_type_predpochtenie()==0)//если без разницы тип вагона(купе плацкарт)
									 {
										 kup1=1;
									 }
									 else
									 {
										/// if (pas[i][j].get_type_predpochtenie()==1)//плацкарт
										 {
											 int ob=0,ty=0,me=0;
											 for (int jj=0;jj<trains[ii].vagons1.size();jj++)
											 {
												 if (trains[ii].vagons1[jj].get_type()==pas[i][j].get_type_predpochtenie()) ty=1;
												 if (pas[i][j].get_oborudovanie_predpochtenie()==0 ||\
													 pas[i][j].get_oborudovanie_predpochtenie()==\
													 trains[ii].vagons1[jj].get_oborudovanie()) ob=1;
												 if (trains[ii].vagons1[jj].get_free_mesta()==0) me=1;

												 if (trains[ii].vagons1[jj].get_type()==pas[i][j].get_type_predpochtenie() &&\
													 (pas[i][j].get_oborudovanie_predpochtenie()==0 ||\
													 pas[i][j].get_oborudovanie_predpochtenie()==\
													 trains[ii].vagons1[jj].get_oborudovanie()) &&\
													 trains[ii].vagons1[jj].get_free_mesta()>0)
													 //купил билет
												 {

													 trains[ii].vagons1[jj].minus_mesto();
													 
													 ///вычислени цены билета
													 int xx=trains[ii].get_st_otpravlenie().get_x() - trains[ii].get_st_naznachenie().get_x();
													 int yy=trains[ii].get_st_otpravlenie().get_y() - trains[ii].get_st_naznachenie().get_y();
													 int cen=trains[ii].vagons1[jj].get_cena()*sqrt(pow(xx,2.0)+pow(yy,2.0));
													
													 cena_train[ii]+=cen;
													 cena_stant[i]+=cen;
													 cena_type_vag[trains[ii].vagons1[jj].get_type()-1]+=cen;
												 }
											 }

											 if (ob==0) ne_uehali[1]++;
											 if (ty==0) ne_uehali[2]++;
											 if (me==1) ne_uehali[3]++;
										 }
									 }
								 }
							 }
						 }
					 }

				}
			 passenger=pas;
			 delete pas;
			 //////////
			 //////////
			 //////////
			 this->listBox4->Items->Clear();
			 int sum=0;
			 for (int i=0;i<st.size();i++)
			 {
				 this->listBox4->Items->Add(" "+st[i].get_nom()+" = "+passengers_oborudovanie[i]);
				 sum+=passengers_oborudovanie[i];
			 }
			 this->listBox4->Items->Add("Всего = "+sum);

			 this->listBox7->Items->Clear();
			 for (int i=0;i<st.size();i++)
			 {
				 this->listBox7->Items->Add("Станция "+st[i].get_nom().ToString()+" "+cena_stant[i].ToString());
			 }
			 this->listBox8->Items->Clear();
			 for (int i=0;i<kol_trains;i++)
			 {
				 this->listBox8->Items->Add("Поезд № "+trains[i].get_nomer()+" "+cena_train[i]);
			 }
			 
			//1-нет нужного поезда
			//2-нет оборудованного вагона
			//3-нет желаемого типа вагона
			//4-нет мест
			 this->listBox10->Items->Clear();
			 this->listBox10->Items->Add("Нет нужн.поезда "+ne_uehali[0]);
			 this->listBox10->Items->Add("Нет оборуд.вагона "+ne_uehali[1]);
			 this->listBox10->Items->Add("Нет желаемого типа "+ne_uehali[2]);
			 this->listBox10->Items->Add("Нет мест "+ne_uehali[3]);

		 }
private: System::Void listBox1_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
private: System::Void listBox3_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
private: System::Void listBox11_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
private: System::Void listBox7_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
private: System::Void listBox10_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
private: System::Void listBox4_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
		 }

private: System::Void toolStrip1_ItemClicked(System::Object^  sender, System::Windows::Forms::ToolStripItemClickedEventArgs^  e) {
		 }
private: System::Void listBox8_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
private: System::Void listBox6_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
private: System::Void panel3_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
		 }
private: System::Void panel2_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
		 }
private: System::Void radioButton3_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
};
}

