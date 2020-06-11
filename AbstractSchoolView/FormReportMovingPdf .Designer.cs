using Microsoft.Reporting.WinForms;
namespace AbstractSchoolView

{
    partial class FormReportMovingPdf
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
            this.components = new System.ComponentModel.Container();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCreateToPdf = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportFoodViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportFoodViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonCreate.Location = new System.Drawing.Point(494, 11);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(100, 28);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // buttonCreateToPdf
            // 
            this.buttonCreateToPdf.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonCreateToPdf.Location = new System.Drawing.Point(599, 11);
            this.buttonCreateToPdf.Name = "buttonCreateToPdf";
            this.buttonCreateToPdf.Size = new System.Drawing.Size(91, 28);
            this.buttonCreateToPdf.TabIndex = 3;
            this.buttonCreateToPdf.Text = "В PDF";
            this.buttonCreateToPdf.UseVisualStyleBackColor = false;
            this.buttonCreateToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(366, 19);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(122, 20);
            this.dateTimePickerTo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "С";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(215, 16);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(122, 20);
            this.dateTimePickerFrom.TabIndex = 11;
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractSchoolView.ReportM.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(20, 40);
            this.reportViewer.Name = "ReportViewer";
            this.reportViewer.Size = new System.Drawing.Size(650, 320);
            this.reportViewer.TabIndex = 0;
            // 
            // ReportOrdersViewModelBindingSource
            // 
            this.ReportOrdersViewModelBindingSource.DataSource = typeof(AbstractSchoolBusinessLogic.ViewModels.ReportOrdersViewModel);
            // 
            // ReportFoodViewModelBindingSource
            // 
            this.ReportFoodViewModelBindingSource.DataSource = typeof(AbstractSchoolBusinessLogic.ViewModels.ReportSchoolSupplieViewModel);
            // 
            // FormReportMovingPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(698, 359);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.buttonCreateToPdf);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormReportMovingPdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчеты по поставкам канц. товаров";
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportFoodViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCreateToPdf;
        private System.Windows.Forms.BindingSource ReportOrdersViewModelBindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.BindingSource ReportFoodViewModelBindingSource;
        private ReportViewer reportViewer;
    }
}