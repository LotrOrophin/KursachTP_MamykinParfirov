﻿namespace AbstractSchoolView
{
    partial class FormCirclesSchoolSupplie
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
            this.labelComponentName = new System.Windows.Forms.Label();
            this.labelCountComponent = new System.Windows.Forms.Label();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.textBoxCountComponent = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelComponentName
            // 
            this.labelComponentName.AutoSize = true;
            this.labelComponentName.Location = new System.Drawing.Point(6, 9);
            this.labelComponentName.Name = "labelComponentName";
            this.labelComponentName.Size = new System.Drawing.Size(70, 13);
            this.labelComponentName.TabIndex = 0;
            this.labelComponentName.Text = "Канц. товар:";
            // 
            // labelCountComponent
            // 
            this.labelCountComponent.AutoSize = true;
            this.labelCountComponent.Location = new System.Drawing.Point(1, 40);
            this.labelCountComponent.Name = "labelCountComponent";
            this.labelCountComponent.Size = new System.Drawing.Size(69, 13);
            this.labelCountComponent.TabIndex = 1;
            this.labelCountComponent.Text = "Количество:";
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(76, 6);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(271, 21);
            this.comboBoxComponent.TabIndex = 2;
            // 
            // textBoxCountComponent
            // 
            this.textBoxCountComponent.Location = new System.Drawing.Point(76, 33);
            this.textBoxCountComponent.Name = "textBoxCountComponent";
            this.textBoxCountComponent.Size = new System.Drawing.Size(271, 20);
            this.textBoxCountComponent.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Crimson;
            this.buttonSave.Location = new System.Drawing.Point(9, 88);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(166, 28);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Crimson;
            this.buttonCancel.Location = new System.Drawing.Point(181, 88);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(166, 28);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormCirclesSchoolSupplie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(386, 128);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCountComponent);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.labelCountComponent);
            this.Controls.Add(this.labelComponentName);
            this.Name = "FormCirclesSchoolSupplie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Канцелярия";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComponentName;
        private System.Windows.Forms.Label labelCountComponent;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.TextBox textBoxCountComponent;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}