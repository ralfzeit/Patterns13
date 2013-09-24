#pragma once
#include "Monkey.h"
#include "Uzk.h"
#include "Shirok.h"
#include "Chel.h"

#include "Voler.h"

using namespace std;
using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace Monkey_cur {

	static string name_ob;
	static int growth_ob;		
	static int weight_ob;		
	static bool tail_ob;		
	static int fight_ob;		
	static int razmer_ob;

	/// <summary>
	/// Summary for New_Object
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class New_Object : public System::Windows::Forms::Form
	{
	private:  vector<Voler*> *MAIN_vector;
	public:
		New_Object(vector<Voler*> *AMAIN_vector)
		{
			MAIN_vector =  AMAIN_vector;
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}
	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~New_Object()
		{
			if (components)
			{
				delete components;		
			}
		}
	private: System::Windows::Forms::GroupBox^  groupBox_name;
	private: System::Windows::Forms::TextBox^  textBox_name;
	private: System::Windows::Forms::GroupBox^  groupBox_growth;
	private: System::Windows::Forms::GroupBox^  groupBox_weight;
	private: System::Windows::Forms::NumericUpDown^  numericUpDown_growth;
	private: System::Windows::Forms::NumericUpDown^  numericUpDown_weight;
	private: System::Windows::Forms::GroupBox^  groupBox_tail;
	private: System::Windows::Forms::RadioButton^  radioButton_tail_false;
	private: System::Windows::Forms::RadioButton^  radioButton_tail_true;
	private: System::Windows::Forms::GroupBox^  groupBox_fight;
	private: System::Windows::Forms::NumericUpDown^  numericUpDown_fight;
	private: System::Windows::Forms::GroupBox^  groupBox_family;
	private: System::Windows::Forms::RadioButton^  radioButton_chel;
	private: System::Windows::Forms::RadioButton^  radioButton_uzk;
	private: System::Windows::Forms::RadioButton^  radioButton_shirok;
	private: System::Windows::Forms::GroupBox^  groupBox_sh;
	private: System::Windows::Forms::RadioButton^  radioButton_sh_rev;
	private: System::Windows::Forms::RadioButton^  radioButton_sh_igr;
	private: System::Windows::Forms::GroupBox^  groupBox_uz;
	private: System::Windows::Forms::RadioButton^  radioButton_uz_mak;
	private: System::Windows::Forms::RadioButton^  radioButton_uz_mar;
	private: System::Windows::Forms::GroupBox^  groupBox_ch;
	private: System::Windows::Forms::RadioButton^  radioButton_ch_shim;
	private: System::Windows::Forms::RadioButton^  radioButton_ch_or;
	private: System::Windows::Forms::RadioButton^  radioButton_ch_gor;
	private: System::Windows::Forms::GroupBox^  groupBox_swp;
	private: System::Windows::Forms::RadioButton^  radioButton_swp_false;
	private: System::Windows::Forms::RadioButton^  radioButton_swp_true;
	private: System::Windows::Forms::Button^  button_Ok;
	private: System::Windows::Forms::Button^  button_Cancel;
	private: System::Windows::Forms::GroupBox^  groupBox_razmer;
	private: System::Windows::Forms::NumericUpDown^  numericUpDown_razmer;
	private: System::Windows::Forms::GroupBox^  groupBox_info;
	private: System::Windows::Forms::ListBox^  listBox_Voler;
	private: System::Windows::Forms::Label^  label_Info;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->groupBox_name = (gcnew System::Windows::Forms::GroupBox());
			this->textBox_name = (gcnew System::Windows::Forms::TextBox());
			this->groupBox_growth = (gcnew System::Windows::Forms::GroupBox());
			this->numericUpDown_growth = (gcnew System::Windows::Forms::NumericUpDown());
			this->groupBox_weight = (gcnew System::Windows::Forms::GroupBox());
			this->numericUpDown_weight = (gcnew System::Windows::Forms::NumericUpDown());
			this->groupBox_tail = (gcnew System::Windows::Forms::GroupBox());
			this->radioButton_tail_false = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_tail_true = (gcnew System::Windows::Forms::RadioButton());
			this->groupBox_fight = (gcnew System::Windows::Forms::GroupBox());
			this->numericUpDown_fight = (gcnew System::Windows::Forms::NumericUpDown());
			this->groupBox_family = (gcnew System::Windows::Forms::GroupBox());
			this->radioButton_chel = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_uzk = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_shirok = (gcnew System::Windows::Forms::RadioButton());
			this->groupBox_sh = (gcnew System::Windows::Forms::GroupBox());
			this->radioButton_sh_rev = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_sh_igr = (gcnew System::Windows::Forms::RadioButton());
			this->groupBox_uz = (gcnew System::Windows::Forms::GroupBox());
			this->groupBox_swp = (gcnew System::Windows::Forms::GroupBox());
			this->radioButton_swp_false = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_swp_true = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_uz_mak = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_uz_mar = (gcnew System::Windows::Forms::RadioButton());
			this->groupBox_ch = (gcnew System::Windows::Forms::GroupBox());
			this->radioButton_ch_shim = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_ch_or = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_ch_gor = (gcnew System::Windows::Forms::RadioButton());
			this->button_Ok = (gcnew System::Windows::Forms::Button());
			this->button_Cancel = (gcnew System::Windows::Forms::Button());
			this->groupBox_razmer = (gcnew System::Windows::Forms::GroupBox());
			this->numericUpDown_razmer = (gcnew System::Windows::Forms::NumericUpDown());
			this->groupBox_info = (gcnew System::Windows::Forms::GroupBox());
			this->listBox_Voler = (gcnew System::Windows::Forms::ListBox());
			this->label_Info = (gcnew System::Windows::Forms::Label());
			this->groupBox_name->SuspendLayout();
			this->groupBox_growth->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_growth))->BeginInit();
			this->groupBox_weight->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_weight))->BeginInit();
			this->groupBox_tail->SuspendLayout();
			this->groupBox_fight->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_fight))->BeginInit();
			this->groupBox_family->SuspendLayout();
			this->groupBox_sh->SuspendLayout();
			this->groupBox_uz->SuspendLayout();
			this->groupBox_swp->SuspendLayout();
			this->groupBox_ch->SuspendLayout();
			this->groupBox_razmer->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_razmer))->BeginInit();
			this->groupBox_info->SuspendLayout();
			this->SuspendLayout();
			// 
			// groupBox_name
			// 
			this->groupBox_name->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_name->Controls->Add(this->textBox_name);
			this->groupBox_name->Location = System::Drawing::Point(12, 12);
			this->groupBox_name->Name = L"groupBox_name";
			this->groupBox_name->Size = System::Drawing::Size(133, 56);
			this->groupBox_name->TabIndex = 0;
			this->groupBox_name->TabStop = false;
			this->groupBox_name->Text = L"Кличка";
			// 
			// textBox_name
			// 
			this->textBox_name->Location = System::Drawing::Point(8, 22);
			this->textBox_name->Name = L"textBox_name";
			this->textBox_name->Size = System::Drawing::Size(119, 20);
			this->textBox_name->TabIndex = 0;
			this->textBox_name->TextChanged += gcnew System::EventHandler(this, &New_Object::textBox_name_TextChanged);
			// 
			// groupBox_growth
			// 
			this->groupBox_growth->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_growth->Controls->Add(this->numericUpDown_growth);
			this->groupBox_growth->Location = System::Drawing::Point(151, 12);
			this->groupBox_growth->Name = L"groupBox_growth";
			this->groupBox_growth->Size = System::Drawing::Size(103, 56);
			this->groupBox_growth->TabIndex = 1;
			this->groupBox_growth->TabStop = false;
			this->groupBox_growth->Text = L"Рост";
			// 
			// numericUpDown_growth
			// 
			this->numericUpDown_growth->Location = System::Drawing::Point(15, 20);
			this->numericUpDown_growth->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) {150, 0, 0, 0});
			this->numericUpDown_growth->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {10, 0, 0, 0});
			this->numericUpDown_growth->Name = L"numericUpDown_growth";
			this->numericUpDown_growth->Size = System::Drawing::Size(71, 20);
			this->numericUpDown_growth->TabIndex = 0;
			this->numericUpDown_growth->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {10, 0, 0, 0});
			this->numericUpDown_growth->ValueChanged += gcnew System::EventHandler(this, &New_Object::numericUpDown_growth_ValueChanged);
			// 
			// groupBox_weight
			// 
			this->groupBox_weight->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_weight->Controls->Add(this->numericUpDown_weight);
			this->groupBox_weight->Location = System::Drawing::Point(260, 15);
			this->groupBox_weight->Name = L"groupBox_weight";
			this->groupBox_weight->Size = System::Drawing::Size(114, 53);
			this->groupBox_weight->TabIndex = 2;
			this->groupBox_weight->TabStop = false;
			this->groupBox_weight->Text = L"Вес";
			// 
			// numericUpDown_weight
			// 
			this->numericUpDown_weight->Location = System::Drawing::Point(20, 18);
			this->numericUpDown_weight->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) {500, 0, 0, 0});
			this->numericUpDown_weight->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {5, 0, 0, 0});
			this->numericUpDown_weight->Name = L"numericUpDown_weight";
			this->numericUpDown_weight->Size = System::Drawing::Size(71, 20);
			this->numericUpDown_weight->TabIndex = 0;
			this->numericUpDown_weight->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {6, 0, 0, 0});
			this->numericUpDown_weight->ValueChanged += gcnew System::EventHandler(this, &New_Object::numericUpDown_weight_ValueChanged);
			// 
			// groupBox_tail
			// 
			this->groupBox_tail->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_tail->Controls->Add(this->radioButton_tail_false);
			this->groupBox_tail->Controls->Add(this->radioButton_tail_true);
			this->groupBox_tail->Location = System::Drawing::Point(653, 15);
			this->groupBox_tail->Name = L"groupBox_tail";
			this->groupBox_tail->Size = System::Drawing::Size(142, 63);
			this->groupBox_tail->TabIndex = 3;
			this->groupBox_tail->TabStop = false;
			this->groupBox_tail->Text = L"Наличие хвоста";
			// 
			// radioButton_tail_false
			// 
			this->radioButton_tail_false->AutoSize = true;
			this->radioButton_tail_false->Location = System::Drawing::Point(7, 35);
			this->radioButton_tail_false->Name = L"radioButton_tail_false";
			this->radioButton_tail_false->Size = System::Drawing::Size(81, 17);
			this->radioButton_tail_false->TabIndex = 1;
			this->radioButton_tail_false->TabStop = true;
			this->radioButton_tail_false->Text = L"отсутствие";
			this->radioButton_tail_false->UseVisualStyleBackColor = true;
			// 
			// radioButton_tail_true
			// 
			this->radioButton_tail_true->AutoSize = true;
			this->radioButton_tail_true->Checked = true;
			this->radioButton_tail_true->Location = System::Drawing::Point(7, 17);
			this->radioButton_tail_true->Name = L"radioButton_tail_true";
			this->radioButton_tail_true->Size = System::Drawing::Size(68, 17);
			this->radioButton_tail_true->TabIndex = 0;
			this->radioButton_tail_true->TabStop = true;
			this->radioButton_tail_true->Text = L"имеется";
			this->radioButton_tail_true->UseVisualStyleBackColor = true;
			this->radioButton_tail_true->CheckedChanged += gcnew System::EventHandler(this, &New_Object::radioButton_tail_true_CheckedChanged);
			// 
			// groupBox_fight
			// 
			this->groupBox_fight->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_fight->Controls->Add(this->numericUpDown_fight);
			this->groupBox_fight->Location = System::Drawing::Point(515, 15);
			this->groupBox_fight->Name = L"groupBox_fight";
			this->groupBox_fight->Size = System::Drawing::Size(132, 53);
			this->groupBox_fight->TabIndex = 4;
			this->groupBox_fight->TabStop = false;
			this->groupBox_fight->Text = L"Уровень драчливость";
			// 
			// numericUpDown_fight
			// 
			this->numericUpDown_fight->Location = System::Drawing::Point(31, 19);
			this->numericUpDown_fight->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) {5, 0, 0, 0});
			this->numericUpDown_fight->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {1, 0, 0, 0});
			this->numericUpDown_fight->Name = L"numericUpDown_fight";
			this->numericUpDown_fight->Size = System::Drawing::Size(68, 20);
			this->numericUpDown_fight->TabIndex = 0;
			this->numericUpDown_fight->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {1, 0, 0, 0});
			this->numericUpDown_fight->ValueChanged += gcnew System::EventHandler(this, &New_Object::numericUpDown_fight_ValueChanged);
			// 
			// groupBox_family
			// 
			this->groupBox_family->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_family->Controls->Add(this->radioButton_chel);
			this->groupBox_family->Controls->Add(this->radioButton_uzk);
			this->groupBox_family->Controls->Add(this->radioButton_shirok);
			this->groupBox_family->Location = System::Drawing::Point(12, 91);
			this->groupBox_family->Name = L"groupBox_family";
			this->groupBox_family->Size = System::Drawing::Size(149, 101);
			this->groupBox_family->TabIndex = 5;
			this->groupBox_family->TabStop = false;
			this->groupBox_family->Text = L"Семейство";
			// 
			// radioButton_chel
			// 
			this->radioButton_chel->AutoSize = true;
			this->radioButton_chel->Location = System::Drawing::Point(6, 43);
			this->radioButton_chel->Name = L"radioButton_chel";
			this->radioButton_chel->Size = System::Drawing::Size(124, 17);
			this->radioButton_chel->TabIndex = 2;
			this->radioButton_chel->Text = L"Человекообразных";
			this->radioButton_chel->UseVisualStyleBackColor = true;
			this->radioButton_chel->CheckedChanged += gcnew System::EventHandler(this, &New_Object::radioButton_chel_CheckedChanged);
			// 
			// radioButton_uzk
			// 
			this->radioButton_uzk->AutoSize = true;
			this->radioButton_uzk->Location = System::Drawing::Point(6, 68);
			this->radioButton_uzk->Name = L"radioButton_uzk";
			this->radioButton_uzk->Size = System::Drawing::Size(82, 17);
			this->radioButton_uzk->TabIndex = 1;
			this->radioButton_uzk->Text = L"Узконосых";
			this->radioButton_uzk->UseVisualStyleBackColor = true;
			this->radioButton_uzk->CheckedChanged += gcnew System::EventHandler(this, &New_Object::radioButton_uzk_CheckedChanged);
			// 
			// radioButton_shirok
			// 
			this->radioButton_shirok->AutoSize = true;
			this->radioButton_shirok->Location = System::Drawing::Point(7, 20);
			this->radioButton_shirok->Name = L"radioButton_shirok";
			this->radioButton_shirok->Size = System::Drawing::Size(95, 17);
			this->radioButton_shirok->TabIndex = 0;
			this->radioButton_shirok->Text = L"Широконосых";
			this->radioButton_shirok->UseVisualStyleBackColor = true;
			this->radioButton_shirok->CheckedChanged += gcnew System::EventHandler(this, &New_Object::radioButton_shirok_CheckedChanged);
			// 
			// groupBox_sh
			// 
			this->groupBox_sh->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_sh->Controls->Add(this->radioButton_sh_rev);
			this->groupBox_sh->Controls->Add(this->radioButton_sh_igr);
			this->groupBox_sh->Location = System::Drawing::Point(358, 91);
			this->groupBox_sh->Name = L"groupBox_sh";
			this->groupBox_sh->Size = System::Drawing::Size(125, 74);
			this->groupBox_sh->TabIndex = 6;
			this->groupBox_sh->TabStop = false;
			this->groupBox_sh->Text = L"Широконосые";
			// 
			// radioButton_sh_rev
			// 
			this->radioButton_sh_rev->AutoSize = true;
			this->radioButton_sh_rev->Location = System::Drawing::Point(6, 44);
			this->radioButton_sh_rev->Name = L"radioButton_sh_rev";
			this->radioButton_sh_rev->Size = System::Drawing::Size(55, 17);
			this->radioButton_sh_rev->TabIndex = 1;
			this->radioButton_sh_rev->TabStop = true;
			this->radioButton_sh_rev->Text = L"Ревун";
			this->radioButton_sh_rev->UseVisualStyleBackColor = true;
			// 
			// radioButton_sh_igr
			// 
			this->radioButton_sh_igr->AutoSize = true;
			this->radioButton_sh_igr->Location = System::Drawing::Point(6, 20);
			this->radioButton_sh_igr->Name = L"radioButton_sh_igr";
			this->radioButton_sh_igr->Size = System::Drawing::Size(67, 17);
			this->radioButton_sh_igr->TabIndex = 0;
			this->radioButton_sh_igr->TabStop = true;
			this->radioButton_sh_igr->Text = L"Игрунок";
			this->radioButton_sh_igr->UseVisualStyleBackColor = true;
			// 
			// groupBox_uz
			// 
			this->groupBox_uz->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_uz->Controls->Add(this->groupBox_swp);
			this->groupBox_uz->Controls->Add(this->radioButton_uz_mak);
			this->groupBox_uz->Controls->Add(this->radioButton_uz_mar);
			this->groupBox_uz->Location = System::Drawing::Point(630, 91);
			this->groupBox_uz->Name = L"groupBox_uz";
			this->groupBox_uz->Size = System::Drawing::Size(165, 146);
			this->groupBox_uz->TabIndex = 7;
			this->groupBox_uz->TabStop = false;
			this->groupBox_uz->Text = L"Узконосые";
			// 
			// groupBox_swp
			// 
			this->groupBox_swp->Controls->Add(this->radioButton_swp_false);
			this->groupBox_swp->Controls->Add(this->radioButton_swp_true);
			this->groupBox_swp->Location = System::Drawing::Point(6, 68);
			this->groupBox_swp->Name = L"groupBox_swp";
			this->groupBox_swp->Size = System::Drawing::Size(153, 69);
			this->groupBox_swp->TabIndex = 2;
			this->groupBox_swp->TabStop = false;
			this->groupBox_swp->Text = L"Потребность в бассейне";
			// 
			// radioButton_swp_false
			// 
			this->radioButton_swp_false->AutoSize = true;
			this->radioButton_swp_false->Location = System::Drawing::Point(7, 44);
			this->radioButton_swp_false->Name = L"radioButton_swp_false";
			this->radioButton_swp_false->Size = System::Drawing::Size(85, 17);
			this->radioButton_swp_false->TabIndex = 1;
			this->radioButton_swp_false->TabStop = true;
			this->radioButton_swp_false->Text = L"отсутствует";
			this->radioButton_swp_false->UseVisualStyleBackColor = true;
			// 
			// radioButton_swp_true
			// 
			this->radioButton_swp_true->AutoSize = true;
			this->radioButton_swp_true->Location = System::Drawing::Point(7, 20);
			this->radioButton_swp_true->Name = L"radioButton_swp_true";
			this->radioButton_swp_true->Size = System::Drawing::Size(68, 17);
			this->radioButton_swp_true->TabIndex = 0;
			this->radioButton_swp_true->TabStop = true;
			this->radioButton_swp_true->Text = L"имеется";
			this->radioButton_swp_true->UseVisualStyleBackColor = true;
			// 
			// radioButton_uz_mak
			// 
			this->radioButton_uz_mak->AutoSize = true;
			this->radioButton_uz_mak->Location = System::Drawing::Point(6, 44);
			this->radioButton_uz_mak->Name = L"radioButton_uz_mak";
			this->radioButton_uz_mak->Size = System::Drawing::Size(64, 17);
			this->radioButton_uz_mak->TabIndex = 1;
			this->radioButton_uz_mak->TabStop = true;
			this->radioButton_uz_mak->Text = L"Макака";
			this->radioButton_uz_mak->UseVisualStyleBackColor = true;
			// 
			// radioButton_uz_mar
			// 
			this->radioButton_uz_mar->AutoSize = true;
			this->radioButton_uz_mar->Location = System::Drawing::Point(6, 20);
			this->radioButton_uz_mar->Name = L"radioButton_uz_mar";
			this->radioButton_uz_mar->Size = System::Drawing::Size(79, 17);
			this->radioButton_uz_mar->TabIndex = 0;
			this->radioButton_uz_mar->TabStop = true;
			this->radioButton_uz_mar->Text = L"Мартышка";
			this->radioButton_uz_mar->UseVisualStyleBackColor = true;
			// 
			// groupBox_ch
			// 
			this->groupBox_ch->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_ch->Controls->Add(this->radioButton_ch_shim);
			this->groupBox_ch->Controls->Add(this->radioButton_ch_or);
			this->groupBox_ch->Controls->Add(this->radioButton_ch_gor);
			this->groupBox_ch->Location = System::Drawing::Point(489, 91);
			this->groupBox_ch->Name = L"groupBox_ch";
			this->groupBox_ch->Size = System::Drawing::Size(135, 100);
			this->groupBox_ch->TabIndex = 8;
			this->groupBox_ch->TabStop = false;
			this->groupBox_ch->Text = L"Человекообразные";
			// 
			// radioButton_ch_shim
			// 
			this->radioButton_ch_shim->AutoSize = true;
			this->radioButton_ch_shim->Location = System::Drawing::Point(7, 68);
			this->radioButton_ch_shim->Name = L"radioButton_ch_shim";
			this->radioButton_ch_shim->Size = System::Drawing::Size(78, 17);
			this->radioButton_ch_shim->TabIndex = 2;
			this->radioButton_ch_shim->TabStop = true;
			this->radioButton_ch_shim->Text = L"Шимпанзе";
			this->radioButton_ch_shim->UseVisualStyleBackColor = true;
			// 
			// radioButton_ch_or
			// 
			this->radioButton_ch_or->AutoSize = true;
			this->radioButton_ch_or->Location = System::Drawing::Point(7, 44);
			this->radioButton_ch_or->Name = L"radioButton_ch_or";
			this->radioButton_ch_or->Size = System::Drawing::Size(78, 17);
			this->radioButton_ch_or->TabIndex = 1;
			this->radioButton_ch_or->TabStop = true;
			this->radioButton_ch_or->Text = L"Орангутан";
			this->radioButton_ch_or->UseVisualStyleBackColor = true;
			// 
			// radioButton_ch_gor
			// 
			this->radioButton_ch_gor->AutoSize = true;
			this->radioButton_ch_gor->Location = System::Drawing::Point(7, 20);
			this->radioButton_ch_gor->Name = L"radioButton_ch_gor";
			this->radioButton_ch_gor->Size = System::Drawing::Size(67, 17);
			this->radioButton_ch_gor->TabIndex = 0;
			this->radioButton_ch_gor->TabStop = true;
			this->radioButton_ch_gor->Text = L"Горилла";
			this->radioButton_ch_gor->UseVisualStyleBackColor = true;
			// 
			// button_Ok
			// 
			this->button_Ok->Location = System::Drawing::Point(12, 213);
			this->button_Ok->Name = L"button_Ok";
			this->button_Ok->Size = System::Drawing::Size(88, 24);
			this->button_Ok->TabIndex = 9;
			this->button_Ok->Text = L"Создать";
			this->button_Ok->UseVisualStyleBackColor = true;
			this->button_Ok->Click += gcnew System::EventHandler(this, &New_Object::button_Ok_Click);
			// 
			// button_Cancel
			// 
			this->button_Cancel->Location = System::Drawing::Point(142, 213);
			this->button_Cancel->Name = L"button_Cancel";
			this->button_Cancel->Size = System::Drawing::Size(112, 24);
			this->button_Cancel->TabIndex = 10;
			this->button_Cancel->Text = L"Отменить содание";
			this->button_Cancel->UseVisualStyleBackColor = true;
			this->button_Cancel->Click += gcnew System::EventHandler(this, &New_Object::button_Cancel_Click);
			// 
			// groupBox_razmer
			// 
			this->groupBox_razmer->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_razmer->Controls->Add(this->numericUpDown_razmer);
			this->groupBox_razmer->Location = System::Drawing::Point(380, 15);
			this->groupBox_razmer->Name = L"groupBox_razmer";
			this->groupBox_razmer->Size = System::Drawing::Size(129, 53);
			this->groupBox_razmer->TabIndex = 11;
			this->groupBox_razmer->TabStop = false;
			this->groupBox_razmer->Text = L"Занимаемый объем";
			// 
			// numericUpDown_razmer
			// 
			this->numericUpDown_razmer->Location = System::Drawing::Point(29, 20);
			this->numericUpDown_razmer->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {5, 0, 0, 0});
			this->numericUpDown_razmer->Name = L"numericUpDown_razmer";
			this->numericUpDown_razmer->Size = System::Drawing::Size(72, 20);
			this->numericUpDown_razmer->TabIndex = 0;
			this->numericUpDown_razmer->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {5, 0, 0, 0});
			this->numericUpDown_razmer->ValueChanged += gcnew System::EventHandler(this, &New_Object::numericUpDown_razmer_ValueChanged);
			// 
			// groupBox_info
			// 
			this->groupBox_info->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->groupBox_info->Controls->Add(this->listBox_Voler);
			this->groupBox_info->Location = System::Drawing::Point(801, 15);
			this->groupBox_info->Name = L"groupBox_info";
			this->groupBox_info->Size = System::Drawing::Size(147, 222);
			this->groupBox_info->TabIndex = 12;
			this->groupBox_info->TabStop = false;
			this->groupBox_info->Text = L"Вольеры (номер объём бассейн)";
			// 
			// listBox_Voler
			// 
			this->listBox_Voler->FormattingEnabled = true;
			this->listBox_Voler->Location = System::Drawing::Point(12, 34);
			this->listBox_Voler->Name = L"listBox_Voler";
			this->listBox_Voler->Size = System::Drawing::Size(120, 173);
			this->listBox_Voler->TabIndex = 0;
			// 
			// label_Info
			// 
			this->label_Info->AutoSize = true;
			this->label_Info->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label_Info->ForeColor = System::Drawing::Color::DarkRed;
			this->label_Info->Location = System::Drawing::Point(163, 113);
			this->label_Info->Name = L"label_Info";
			this->label_Info->Size = System::Drawing::Size(191, 39);
			this->label_Info->TabIndex = 13;
			this->label_Info->Text = L"Внимание! \r\nВ Зоопарке отсутствуют вольеры!\r\nСоздайте их, выйдя в главное меню";
			this->label_Info->Visible = false;
			// 
			// New_Object
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::ScrollBar;
			this->ClientSize = System::Drawing::Size(960, 247);
			this->Controls->Add(this->label_Info);
			this->Controls->Add(this->groupBox_info);
			this->Controls->Add(this->groupBox_razmer);
			this->Controls->Add(this->button_Cancel);
			this->Controls->Add(this->button_Ok);
			this->Controls->Add(this->groupBox_ch);
			this->Controls->Add(this->groupBox_uz);
			this->Controls->Add(this->groupBox_sh);
			this->Controls->Add(this->groupBox_family);
			this->Controls->Add(this->groupBox_fight);
			this->Controls->Add(this->groupBox_tail);
			this->Controls->Add(this->groupBox_weight);
			this->Controls->Add(this->groupBox_growth);
			this->Controls->Add(this->groupBox_name);
			this->Name = L"New_Object";
			this->Text = L"Создание обезъянки";
			this->Load += gcnew System::EventHandler(this, &New_Object::New_Object_Load);
			this->groupBox_name->ResumeLayout(false);
			this->groupBox_name->PerformLayout();
			this->groupBox_growth->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_growth))->EndInit();
			this->groupBox_weight->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_weight))->EndInit();
			this->groupBox_tail->ResumeLayout(false);
			this->groupBox_tail->PerformLayout();
			this->groupBox_fight->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_fight))->EndInit();
			this->groupBox_family->ResumeLayout(false);
			this->groupBox_family->PerformLayout();
			this->groupBox_sh->ResumeLayout(false);
			this->groupBox_sh->PerformLayout();
			this->groupBox_uz->ResumeLayout(false);
			this->groupBox_uz->PerformLayout();
			this->groupBox_swp->ResumeLayout(false);
			this->groupBox_swp->PerformLayout();
			this->groupBox_ch->ResumeLayout(false);
			this->groupBox_ch->PerformLayout();
			this->groupBox_razmer->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_razmer))->EndInit();
			this->groupBox_info->ResumeLayout(false);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	private: System::Void New_Object_Load(System::Object^  sender, System::EventArgs^  e) {
			this->groupBox_sh->Enabled = false;
			this->groupBox_ch->Enabled = false;
			this->groupBox_uz->Enabled = false;	 

			if (this->radioButton_tail_true->Checked) tail_ob = true;
				else tail_ob = false;

			for (int i=0, n = this->textBox_name->Text->Length; i<n; i++)
				name_ob.push_back((char)this->textBox_name->Text[i]);
			growth_ob = Decimal::ToInt32(this->numericUpDown_growth->Value);
			weight_ob = Decimal::ToInt32(this->numericUpDown_weight->Value);
			razmer_ob = Decimal::ToInt32(this->numericUpDown_razmer->Value);
			fight_ob = Decimal::ToInt32(this->numericUpDown_fight->Value);
			//////////////////////////////////////////////////////////////
			for (vector<Voler*>::iterator i = MAIN_vector->begin(); i!=MAIN_vector->end(); i++)
			{
				char a[50];
				int rzmr = (**i).get_razmer();

					for(vector<Monkey*>::iterator j = (**i).a.begin(); j != (**i).a.end(); j++)
						rzmr -= (**j).get_razmer();

					if((*i)->get_swimpool()) sprintf(a,"%d %d есть",(*i)->get_number(), rzmr);
					else sprintf(a,"%d %d нет",(*i)->get_number(), rzmr);

				this->listBox_Voler->Items->Add(gcnew String(a));
			}

			if(this->listBox_Voler->Items->Count == 0)
			{
				this->label_Info->Visible = true;
				RegroupBox(this);
			}
		 }
////////////////////////////////////////////////////////////////////////////////////////////////////
private: void RegroupBox(Control^ c) 
		 {
			if (dynamic_cast<GroupBox^>(c))
				c->Enabled = false;
			 
			 for each (Control^ w in c->Controls) 
			 {
				 RegroupBox(w);
			 }
		}
/////////////////////////////////////////////////////////////////////////////////////////////////////////

private: System::Void textBox_name_TextChanged(System::Object^  sender, System::EventArgs^  e) {
			 name_ob.clear();
			 for (int i=0, n = this->textBox_name->Text->Length; i<n; i++)
				name_ob.push_back((char)this->textBox_name->Text[i]);
		}

private: System::Void numericUpDown_growth_ValueChanged(System::Object^  sender, System::EventArgs^  e) {
			 growth_ob = Decimal::ToInt32(this->numericUpDown_growth->Value);
		 }

private: System::Void numericUpDown_weight_ValueChanged(System::Object^  sender, System::EventArgs^  e) {
			 weight_ob = Decimal::ToInt32(this->numericUpDown_weight->Value);
		 }

private: System::Void numericUpDown_razmer_ValueChanged(System::Object^  sender, System::EventArgs^  e) {
			 razmer_ob = Decimal::ToInt32(this->numericUpDown_razmer->Value);
		 }

private: System::Void numericUpDown_fight_ValueChanged(System::Object^  sender, System::EventArgs^  e) {
			 fight_ob = Decimal::ToInt32(this->numericUpDown_fight->Value);
		 }

private: System::Void radioButton_tail_true_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			 if (this->radioButton_tail_true->Checked) tail_ob = true;
			 else tail_ob = false;
		 }

///////////////////////////////////////////////////////////////////////////////////////////////////////////
private: System::Void radioButton_shirok_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			 if(this->radioButton_shirok->Checked)
			 {
				 this->groupBox_sh->Enabled = true;
				 this->groupBox_ch->Enabled = false;
				 this->groupBox_uz->Enabled = false;
			}
		 }
private: System::Void radioButton_chel_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			 if(this->radioButton_chel->Checked)
			 {
				 this->groupBox_sh->Enabled = false;
				 this->groupBox_ch->Enabled = true;
				 this->groupBox_uz->Enabled = false;
			 }
		 }
private: System::Void radioButton_uzk_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			 if(this->radioButton_uzk->Checked)
			 {
				this->groupBox_sh->Enabled = false;
				this->groupBox_ch->Enabled = false;
				this->groupBox_uz->Enabled = true;
			 }
		 }


///////////////////////////////////////////////////////////////////////////////////////////////////////////


private: System::Void button_Ok_Click(System::Object^  sender, System::EventArgs^  e) {

 		Monkey *p=NULL;

///////////////////////////////////////////////////////////////////////////////////////////////////////////
			 if (name_ob.empty()) 
			 {
				 System::Windows::Forms::MessageBox::Show
					 ("Кличка обезъяны не введена", "Внимание!", 
					 System::Windows::Forms::MessageBoxButtons::OK, 
					 System::Windows::Forms::MessageBoxIcon::Warning);

			 }
			 else
				 {
//	p = new Monkey(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob);
				 if( !this->radioButton_shirok->Checked && 
					 !this->radioButton_chel->Checked && 
					 !this->radioButton_uzk->Checked )
				 {
					 System::Windows::Forms::MessageBox::Show
						("Не выбрано семейство обезъяны", "Внимание!", 
						System::Windows::Forms::MessageBoxButtons::OK, 
						System::Windows::Forms::MessageBoxIcon::Warning);
				 }
				 else
				 {
	//				 Shirok(bool igrunk0, bool revun0)
 						if(this->radioButton_shirok->Checked)
						{
							if( !this->radioButton_sh_igr->Checked &&
								!this->radioButton_sh_rev->Checked )
							{ 
								 System::Windows::Forms::MessageBox::Show
									("Не выбран вид обезъяны", "Внимание!", 
									System::Windows::Forms::MessageBoxButtons::OK, 
									System::Windows::Forms::MessageBoxIcon::Warning);
							}
							else
							{
								p = dynamic_cast<Shirok*>(p);

								if(this->radioButton_sh_igr->Checked) 
									p = new Shirok(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 1, 0); 
								
								if(this->radioButton_sh_rev->Checked)
									p = new Shirok(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 0, 1); 
							}
						}

	//				 Chel(bool goril0, bool orangutan0, bool shinpanz0 )
						if(this->radioButton_chel->Checked)
						{
							if( !this->radioButton_ch_gor->Checked &&
								!this->radioButton_ch_or->Checked &&
								!this->radioButton_ch_shim->Checked )
							{ 
								 System::Windows::Forms::MessageBox::Show
									("Не выбран вид обезъяны", "Внимание!", 
									System::Windows::Forms::MessageBoxButtons::OK, 
									System::Windows::Forms::MessageBoxIcon::Warning);
							}
							else	
							{
								p = dynamic_cast<Chel*>(p);

								if(this->radioButton_ch_gor->Checked)
									p = new Chel(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 1, 0, 0); 

								if(this->radioButton_ch_or->Checked)
									p = new Chel(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 0, 1, 0); 

								if(this->radioButton_ch_shim->Checked)
									p = new Chel(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 0, 0, 1);
							}
						}

	//				 Uzk(bool martishk0, bool makak0, bool swimpool0 )
						if(this->radioButton_uzk->Checked) 
						{
							if(!this->radioButton_uz_mar->Checked && !this->radioButton_uz_mak->Checked)
							{
								 System::Windows::Forms::MessageBox::Show
									("Не выбран вид обезъяны", "Внимание!", 
									System::Windows::Forms::MessageBoxButtons::OK, 
									System::Windows::Forms::MessageBoxIcon::Warning);
							}
							else
								if(!this->radioButton_swp_true->Checked && !this->radioButton_swp_false->Checked)
								{
									System::Windows::Forms::MessageBox::Show
										("Не выбран вид обезъяны", "Внимание!", 
										System::Windows::Forms::MessageBoxButtons::OK, 
										System::Windows::Forms::MessageBoxIcon::Warning);
								}
								else
									{
										p = dynamic_cast<Uzk*>(p);

										if(this->radioButton_uz_mar->Checked)
										{
											if(this->radioButton_swp_true->Checked) p = new Uzk(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 1, 0, 1); 
											else 
												if(this->radioButton_swp_false->Checked) p = new Uzk(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 1, 0, 0); 
										}

										if(this->radioButton_uz_mak->Checked)
										{
											if(this->radioButton_swp_true->Checked) p = new Uzk(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 0, 1, 1); 
											else 
												if(this->radioButton_swp_false->Checked) p = new Uzk(razmer_ob, name_ob, growth_ob, weight_ob, tail_ob, fight_ob, 0, 1, 0); 
										}
									}
						}
					}
	
				 }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		if(p) 
		{	
			int zzz = 1;
			
			if(this->listBox_Voler->SelectedIndex == -1)
			{
				System::Windows::Forms::MessageBox::Show
					("Не выбран вольер", "Внимание!", 
					System::Windows::Forms::MessageBoxButtons::OK, 
					System::Windows::Forms::MessageBoxIcon::Warning);
				zzz = 0;
			}
			////////////////////////////////////////////////////////////////////////////////////////
			if(zzz)
			{
				int kkk = 1;

				for(vector<Voler*>::iterator i = MAIN_vector->begin(); i != MAIN_vector->end() && kkk; i++)
					for( vector<Monkey*>::iterator j = (**i).a.begin(); j != (**i).a.end() && kkk; j++)
						if( (**j).get_name() == name_ob ) kkk = 0;

				if(!kkk)
				{
					System::Windows::Forms::MessageBox::Show
						("Обезъяна с такой кличкой существует! Измените кличку!", "Внимание!", 
						System::Windows::Forms::MessageBoxButtons::OK, 
						System::Windows::Forms::MessageBoxIcon::Warning);
					zzz = 0;
					
				}
			}
			////////////////////////////////////////////////////////////////////////////////////////
			if(zzz)
			{
				Uzk *Oq = dynamic_cast<Uzk*>(p);
				Voler *Vq = MAIN_vector->at(this->listBox_Voler->SelectedIndex);
				
				if( Oq )
				{
					if( !(Vq->get_swimpool()) && this->radioButton_swp_true->Checked)
					{
						System::Windows::Forms::MessageBox::Show
							("В выбранном вольере нет бассейна!", "Внимание!", 
							System::Windows::Forms::MessageBoxButtons::OK, 
							System::Windows::Forms::MessageBoxIcon::Warning);
						zzz = 0;
					}

				}
			}
			////////////////////////////////////////////////////////////////////////////////////////
			if(zzz)
			{
				int raz = MAIN_vector->at(this->listBox_Voler->SelectedIndex)->get_razmer();
				
				for( vector<Monkey*>::iterator j = (MAIN_vector->at(this->listBox_Voler->SelectedIndex))->a.begin(); 
					 j != (MAIN_vector->at(this->listBox_Voler->SelectedIndex))->a.end(); j++ )
				{
					raz = raz - (**j).get_razmer();
				}

				if(raz < razmer_ob)	
				{
					System::Windows::Forms::MessageBox::Show
						("Для данной обезъяны недостаточно места в данном вольере", "Внимание!", 
						System::Windows::Forms::MessageBoxButtons::OK, 
						System::Windows::Forms::MessageBoxIcon::Warning);
					zzz = 0;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////
			if(zzz)
			{
					MAIN_vector->at(this->listBox_Voler->SelectedIndex)->a.push_back(p);
					this->Close();
			}
		}
		
		}

private: System::Void button_Cancel_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Close();
		 }

};
}
