#pragma once
#include "Monkey.h"
#include "Voler.h"

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;
using namespace std;

namespace Monkey_cur {
	static int naz; 
	static int kol; 
	static bool swp;

	/// <summary>
	/// Summary for New_vector
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class New_vector : public System::Windows::Forms::Form
	{
	private:  vector<Voler*> *MAIN_vector;
	public:
		New_vector(vector<Voler*> *AMAIN_vector)
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
		~New_vector()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  label_num;
	protected: 

	private: System::Windows::Forms::Label^  label_kol;
	private: System::Windows::Forms::Button^  button_OK;
	private: System::Windows::Forms::Button^  button_Cancel;
	private: System::Windows::Forms::NumericUpDown^  numericUpDown_num;

	private: System::Windows::Forms::NumericUpDown^  numericUpDown_kol;
	private: System::Windows::Forms::Label^  label_swpool;


	private: System::Windows::Forms::RadioButton^  radioButton_Yes;
	private: System::Windows::Forms::RadioButton^  radioButton_No;
	private: System::Windows::Forms::Panel^  panel_swpool;







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
			this->label_num = (gcnew System::Windows::Forms::Label());
			this->label_kol = (gcnew System::Windows::Forms::Label());
			this->button_OK = (gcnew System::Windows::Forms::Button());
			this->button_Cancel = (gcnew System::Windows::Forms::Button());
			this->numericUpDown_num = (gcnew System::Windows::Forms::NumericUpDown());
			this->numericUpDown_kol = (gcnew System::Windows::Forms::NumericUpDown());
			this->label_swpool = (gcnew System::Windows::Forms::Label());
			this->radioButton_Yes = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton_No = (gcnew System::Windows::Forms::RadioButton());
			this->panel_swpool = (gcnew System::Windows::Forms::Panel());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_num))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_kol))->BeginInit();
			this->panel_swpool->SuspendLayout();
			this->SuspendLayout();
			// 
			// label_num
			// 
			this->label_num->AutoSize = true;
			this->label_num->Location = System::Drawing::Point(12, 22);
			this->label_num->Name = L"label_num";
			this->label_num->Size = System::Drawing::Size(86, 13);
			this->label_num->TabIndex = 0;
			this->label_num->Text = L"Номер вольера";
			// 
			// label_kol
			// 
			this->label_kol->AutoSize = true;
			this->label_kol->Location = System::Drawing::Point(12, 58);
			this->label_kol->Name = L"label_kol";
			this->label_kol->Size = System::Drawing::Size(80, 13);
			this->label_kol->TabIndex = 1;
			this->label_kol->Text = L"Вмещаемость";
			// 
			// button_OK
			// 
			this->button_OK->Location = System::Drawing::Point(12, 155);
			this->button_OK->Name = L"button_OK";
			this->button_OK->Size = System::Drawing::Size(103, 32);
			this->button_OK->TabIndex = 4;
			this->button_OK->Text = L"Создать вольер";
			this->button_OK->UseVisualStyleBackColor = true;
			this->button_OK->Click += gcnew System::EventHandler(this, &New_vector::button_OK_Click);
			// 
			// button_Cancel
			// 
			this->button_Cancel->Location = System::Drawing::Point(144, 155);
			this->button_Cancel->Name = L"button_Cancel";
			this->button_Cancel->Size = System::Drawing::Size(128, 32);
			this->button_Cancel->TabIndex = 5;
			this->button_Cancel->Text = L"Отменить созданиие";
			this->button_Cancel->UseVisualStyleBackColor = true;
			this->button_Cancel->Click += gcnew System::EventHandler(this, &New_vector::button_Cancel_Click);
			// 
			// numericUpDown_num
			// 
			this->numericUpDown_num->Location = System::Drawing::Point(144, 15);
			this->numericUpDown_num->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {1, 0, 0, 0});
			this->numericUpDown_num->Name = L"numericUpDown_num";
			this->numericUpDown_num->Size = System::Drawing::Size(120, 20);
			this->numericUpDown_num->TabIndex = 6;
			this->numericUpDown_num->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {1, 0, 0, 0});
			this->numericUpDown_num->ValueChanged += gcnew System::EventHandler(this, &New_vector::numericUpDown_num_ValueChanged);
			// 
			// numericUpDown_kol
			// 
			this->numericUpDown_kol->Location = System::Drawing::Point(144, 51);
			this->numericUpDown_kol->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) {200, 0, 0, 0});
			this->numericUpDown_kol->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {10, 0, 0, 0});
			this->numericUpDown_kol->Name = L"numericUpDown_kol";
			this->numericUpDown_kol->Size = System::Drawing::Size(120, 20);
			this->numericUpDown_kol->TabIndex = 7;
			this->numericUpDown_kol->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {10, 0, 0, 0});
			this->numericUpDown_kol->ValueChanged += gcnew System::EventHandler(this, &New_vector::numericUpDown_kol_ValueChanged);
			// 
			// label_swpool
			// 
			this->label_swpool->AutoSize = true;
			this->label_swpool->Location = System::Drawing::Point(12, 106);
			this->label_swpool->Name = L"label_swpool";
			this->label_swpool->Size = System::Drawing::Size(114, 13);
			this->label_swpool->TabIndex = 8;
			this->label_swpool->Text = L"Включения бассейна";
			// 
			// radioButton_Yes
			// 
			this->radioButton_Yes->AutoSize = true;
			this->radioButton_Yes->Checked = true;
			this->radioButton_Yes->Location = System::Drawing::Point(4, 4);
			this->radioButton_Yes->Name = L"radioButton_Yes";
			this->radioButton_Yes->Size = System::Drawing::Size(37, 17);
			this->radioButton_Yes->TabIndex = 0;
			this->radioButton_Yes->TabStop = true;
			this->radioButton_Yes->Text = L"да";
			this->radioButton_Yes->UseVisualStyleBackColor = true;
			this->radioButton_Yes->CheckedChanged += gcnew System::EventHandler(this, &New_vector::radioButton_Yes_CheckedChanged);
			// 
			// radioButton_No
			// 
			this->radioButton_No->AutoSize = true;
			this->radioButton_No->Location = System::Drawing::Point(4, 28);
			this->radioButton_No->Name = L"radioButton_No";
			this->radioButton_No->Size = System::Drawing::Size(42, 17);
			this->radioButton_No->TabIndex = 1;
			this->radioButton_No->Text = L"нет";
			this->radioButton_No->UseVisualStyleBackColor = true;
			// 
			// panel_swpool
			// 
			this->panel_swpool->Controls->Add(this->radioButton_No);
			this->panel_swpool->Controls->Add(this->radioButton_Yes);
			this->panel_swpool->Location = System::Drawing::Point(144, 88);
			this->panel_swpool->Name = L"panel_swpool";
			this->panel_swpool->Size = System::Drawing::Size(120, 51);
			this->panel_swpool->TabIndex = 9;
			// 
			// New_vector
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(296, 208);
			this->Controls->Add(this->panel_swpool);
			this->Controls->Add(this->label_swpool);
			this->Controls->Add(this->numericUpDown_kol);
			this->Controls->Add(this->numericUpDown_num);
			this->Controls->Add(this->button_Cancel);
			this->Controls->Add(this->button_OK);
			this->Controls->Add(this->label_kol);
			this->Controls->Add(this->label_num);
			this->Name = L"New_vector";
			this->Text = L"Создание нового вольера";
			this->Load += gcnew System::EventHandler(this, &New_vector::New_vector_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_num))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->numericUpDown_kol))->EndInit();
			this->panel_swpool->ResumeLayout(false);
			this->panel_swpool->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	private: System::Void New_vector_Load(System::Object^  sender, System::EventArgs^  e) {	
				 naz = Decimal::ToInt32(this->numericUpDown_num->Value);
				 kol = Decimal::ToInt32(this->numericUpDown_kol->Value);
 				 if(this->radioButton_Yes->Checked) swp = true;
				 if(this->radioButton_No->Checked) swp = false;
			 }

	private: System::Void numericUpDown_num_ValueChanged(System::Object^  sender, System::EventArgs^  e) {
				  naz = Decimal::ToInt32(this->numericUpDown_num->Value);
			 }
	private: System::Void numericUpDown_kol_ValueChanged(System::Object^  sender, System::EventArgs^  e) {
				  kol = Decimal::ToInt32(this->numericUpDown_kol->Value);
			 }

	private: System::Void radioButton_Yes_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
				 if(this->radioButton_Yes->Checked) swp = true;
				 if(this->radioButton_No->Checked) swp = false;
			 }	

	private: System::Void button_OK_Click(System::Object^  sender, System::EventArgs^  e) {
			int abc = 1;

			for(vector<Voler*>::iterator i = MAIN_vector->begin(); i != MAIN_vector->end() && abc; i++)
				if( ( (*i)->get_number() ) == naz) abc = 0;

			if(abc)
			{
				Voler* p1 = new Voler(naz,kol,swp);
				MAIN_vector->push_back(p1);	

				this->Close();
			}
			else
			{
				 System::Windows::Forms::MessageBox::Show
						("Вольер с таким же номером существует! Измените номер!", "Внимание!", 
						System::Windows::Forms::MessageBoxButtons::OK, 
						System::Windows::Forms::MessageBoxIcon::Warning);
			}
			 }

	private: System::Void button_Cancel_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->Close();
			 }
};
}