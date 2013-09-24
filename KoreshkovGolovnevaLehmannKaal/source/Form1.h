#pragma once
#include "Monkey.h"
#include "Uzk.h"
#include "Shirok.h"
#include "Chel.h"
#include "Vector.h"

#include "New_vector.h"
#include "New_Object.h"
#include "Voler.h"

namespace Monkey_cur {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  button_New_Vector;
	protected: 
	private: System::Windows::Forms::Button^  button_New_Object;
	private: System::Windows::Forms::PictureBox^  pictureBox;



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
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->button_New_Vector = (gcnew System::Windows::Forms::Button());
			this->button_New_Object = (gcnew System::Windows::Forms::Button());
			this->pictureBox = (gcnew System::Windows::Forms::PictureBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox))->BeginInit();
			this->SuspendLayout();
			// 
			// button_New_Vector
			// 
			this->button_New_Vector->Location = System::Drawing::Point(12, 12);
			this->button_New_Vector->Name = L"button_New_Vector";
			this->button_New_Vector->Size = System::Drawing::Size(150, 48);
			this->button_New_Vector->TabIndex = 0;
			this->button_New_Vector->Text = L"Новый вольер";
			this->button_New_Vector->UseVisualStyleBackColor = true;
			this->button_New_Vector->Click += gcnew System::EventHandler(this, &Form1::button_New_Vector_Click);
			// 
			// button_New_Object
			// 
			this->button_New_Object->Location = System::Drawing::Point(374, 12);
			this->button_New_Object->Name = L"button_New_Object";
			this->button_New_Object->Size = System::Drawing::Size(150, 48);
			this->button_New_Object->TabIndex = 1;
			this->button_New_Object->Text = L"Новая обезъянка";
			this->button_New_Object->UseVisualStyleBackColor = true;
			this->button_New_Object->Click += gcnew System::EventHandler(this, &Form1::button_New_Object_Click);
			// 
			// pictureBox
			// 
			this->pictureBox->InitialImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox.InitialImage")));
			this->pictureBox->Location = System::Drawing::Point(12, 66);
			this->pictureBox->Name = L"pictureBox";
			this->pictureBox->Size = System::Drawing::Size(512, 302);
			this->pictureBox->TabIndex = 3;
			this->pictureBox->TabStop = false;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(536, 380);	
			this->Controls->Add(this->pictureBox);
			this->Controls->Add(this->button_New_Object);
			this->Controls->Add(this->button_New_Vector);
			this->Name = L"Form1";
			this->Text = L"Главное меню";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion

	private: vector<Voler*> *MAIN_vector;
	
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
				 MAIN_vector = new vector<Voler*>;
			 }

	private: System::Void button_New_Vector_Click(System::Object^  sender, System::EventArgs^  e) {
				 New_vector ^p1 = gcnew New_vector(MAIN_vector);
				 p1->ShowDialog();
			 }

	private: System::Void button_New_Object_Click(System::Object^  sender, System::EventArgs^  e) {
				 New_Object ^p2 = gcnew New_Object(MAIN_vector);
				 p2->ShowDialog();		 
			 }
};
}