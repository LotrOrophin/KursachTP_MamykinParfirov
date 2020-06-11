namespace AbstractSchoolView
{
    partial class FormReportCircleExcel
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
            this.dataGridViewSchoolSupplieCircle = new System.Windows.Forms.DataGridView();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchoolSupplieCircle)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSchoolSupplieCircle
            // 
            this.dataGridViewSchoolSupplieCircle.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridViewSchoolSupplieCircle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchoolSupplieCircle.Location = new System.Drawing.Point(10, 40);
            this.dataGridViewSchoolSupplieCircle.Name = "dataGridViewSchoolSupplieCircle";
            this.dataGridViewSchoolSupplieCircle.RowHeadersWidth = 51;
            this.dataGridViewSchoolSupplieCircle.Size = new System.Drawing.Size(515, 205);
            this.dataGridViewSchoolSupplieCircle.TabIndex = 0;
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.BackColor = System.Drawing.Color.Magenta;
            this.buttonSaveToExcel.Location = new System.Drawing.Point(358, 11);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(137, 23);
            this.buttonSaveToExcel.TabIndex = 1;
            this.buttonSaveToExcel.Text = "Сохранить в Excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = false;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // FormReportCircleExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(535, 255);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.dataGridViewSchoolSupplieCircle);
            this.Name = "FormReportCircleExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Потребности кружка";
            this.Load += new System.EventHandler(this.FormReportFoodsToDishes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchoolSupplieCircle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSchoolSupplieCircle;
        private System.Windows.Forms.Button buttonSaveToExcel;
    }
}