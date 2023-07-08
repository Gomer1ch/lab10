namespace Семестр_2_Лаба_5
{
    partial class FormZakazEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textTName = new System.Windows.Forms.TextBox();
            this.textTSize = new System.Windows.Forms.TextBox();
            this.textTPrise = new System.Windows.Forms.TextBox();
            this.textTNumber = new System.Windows.Forms.TextBox();
            this.textTType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textTName
            // 
            this.textTName.Location = new System.Drawing.Point(12, 48);
            this.textTName.Name = "textTName";
            this.textTName.Size = new System.Drawing.Size(95, 20);
            this.textTName.TabIndex = 0;
            // 
            // textTSize
            // 
            this.textTSize.Location = new System.Drawing.Point(129, 109);
            this.textTSize.Name = "textTSize";
            this.textTSize.Size = new System.Drawing.Size(95, 20);
            this.textTSize.TabIndex = 1;
            // 
            // textTPrise
            // 
            this.textTPrise.Location = new System.Drawing.Point(252, 48);
            this.textTPrise.Name = "textTPrise";
            this.textTPrise.Size = new System.Drawing.Size(95, 20);
            this.textTPrise.TabIndex = 1;
            // 
            // textTNumber
            // 
            this.textTNumber.Location = new System.Drawing.Point(12, 109);
            this.textTNumber.Name = "textTNumber";
            this.textTNumber.Size = new System.Drawing.Size(95, 20);
            this.textTNumber.TabIndex = 1;
            // 
            // textTType
            // 
            this.textTType.AutoCompleteCustomSource.AddRange(new string[] {
            "Шутеры",
            "РПГ",
            "Гонки"});
            this.textTType.Location = new System.Drawing.Point(129, 48);
            this.textTType.Name = "textTType";
            this.textTType.Size = new System.Drawing.Size(95, 20);
            this.textTType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название товара";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Цена";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Номер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Размер";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Дата";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(388, 48);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(207, 165);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(140, 45);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormZakazEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 241);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textTType);
            this.Controls.Add(this.textTNumber);
            this.Controls.Add(this.textTPrise);
            this.Controls.Add(this.textTSize);
            this.Controls.Add(this.textTName);
            this.Name = "FormZakazEdit";
            this.Text = "FormZakazEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTName;
        private System.Windows.Forms.TextBox textTSize;
        private System.Windows.Forms.TextBox textTPrise;
        private System.Windows.Forms.TextBox textTNumber;
        private System.Windows.Forms.TextBox textTType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonUpdate;
    }
}