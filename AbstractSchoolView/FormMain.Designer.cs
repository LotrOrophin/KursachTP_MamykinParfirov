namespace AbstractSchoolView
{
    partial class FormMain
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.канцелярияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кружкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кружкиWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кружкиExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.канцелярияPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказатьКанцТоварыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посмотретьДоступныеПродуктыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coздатьBackUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateKurs = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.ButtonPayKurs = new System.Windows.Forms.Button();
            this.ButtonKursReady = new System.Windows.Forms.Button();
            this.ButtonTakeKursInWork = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(239, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(934, 336);
            this.dataGridView.TabIndex = 0;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.AliceBlue;
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.заказыToolStripMenuItem,
            this.coздатьBackUPToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(1185, 24);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.BackColor = System.Drawing.Color.Orchid;
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.канцелярияToolStripMenuItem,
            this.кружкиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // канцелярияToolStripMenuItem
            // 
            this.канцелярияToolStripMenuItem.Name = "канцелярияToolStripMenuItem";
            this.канцелярияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.канцелярияToolStripMenuItem.Text = "Канцелярия";
            this.канцелярияToolStripMenuItem.Click += new System.EventHandler(this.SchoolSuppliesToolStripMenuItem_Click);
            // 
            // кружкиToolStripMenuItem
            // 
            this.кружкиToolStripMenuItem.Name = "кружкиToolStripMenuItem";
            this.кружкиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.кружкиToolStripMenuItem.Text = "Кружки";
            this.кружкиToolStripMenuItem.Click += new System.EventHandler(this.CircleToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.BackColor = System.Drawing.Color.DeepPink;
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кружкиWordToolStripMenuItem,
            this.кружкиExcelToolStripMenuItem,
            this.канцелярияPDFToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // кружкиWordToolStripMenuItem
            // 
            this.кружкиWordToolStripMenuItem.Name = "кружкиWordToolStripMenuItem";
            this.кружкиWordToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.кружкиWordToolStripMenuItem.Text = "Кружки - Word";
            this.кружкиWordToolStripMenuItem.Click += new System.EventHandler(this.кружкиWordToolStripMenuItem_Click);
            // 
            // кружкиExcelToolStripMenuItem
            // 
            this.кружкиExcelToolStripMenuItem.Name = "кружкиExcelToolStripMenuItem";
            this.кружкиExcelToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.кружкиExcelToolStripMenuItem.Text = "Кружки - Excel";
            this.кружкиExcelToolStripMenuItem.Click += new System.EventHandler(this.кружкиExcelToolStripMenuItem_Click);
            // 
            // канцелярияPDFToolStripMenuItem
            // 
            this.канцелярияPDFToolStripMenuItem.Name = "канцелярияPDFToolStripMenuItem";
            this.канцелярияPDFToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.канцелярияPDFToolStripMenuItem.Text = "По движению кацелярии - PDF";
            this.канцелярияPDFToolStripMenuItem.Click += new System.EventHandler(this.канцеляриPDFToolStripMenuItem_Click);
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.BackColor = System.Drawing.Color.DarkViolet;
            this.заказыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заказатьКанцТоварыToolStripMenuItem,
            this.посмотретьДоступныеПродуктыToolStripMenuItem});
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.заказыToolStripMenuItem.Text = "Заказы";
            // 
            // заказатьКанцТоварыToolStripMenuItem
            // 
            this.заказатьКанцТоварыToolStripMenuItem.Name = "заказатьКанцТоварыToolStripMenuItem";
            this.заказатьКанцТоварыToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.заказатьКанцТоварыToolStripMenuItem.Text = "Заказать канц.товар";
            this.заказатьКанцТоварыToolStripMenuItem.Click += new System.EventHandler(this.заказатьКанцеляриюToolStripMenuItem_Click);
            // 
            // посмотретьДоступныеПродуктыToolStripMenuItem
            // 
            this.посмотретьДоступныеПродуктыToolStripMenuItem.Name = "посмотретьДоступныеПродуктыToolStripMenuItem";
            this.посмотретьДоступныеПродуктыToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.посмотретьДоступныеПродуктыToolStripMenuItem.Text = "Заказы";
            this.посмотретьДоступныеПродуктыToolStripMenuItem.Click += new System.EventHandler(this.выводВсейКанцелярииToolStripMenuItem_Click);
            // 
            // coздатьBackUPToolStripMenuItem
            // 
            this.coздатьBackUPToolStripMenuItem.BackColor = System.Drawing.Color.Purple;
            this.coздатьBackUPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLToolStripMenuItem,
            this.jSONToolStripMenuItem});
            this.coздатьBackUPToolStripMenuItem.Name = "coздатьBackUPToolStripMenuItem";
            this.coздатьBackUPToolStripMenuItem.Size = new System.Drawing.Size(165, 20);
            this.coздатьBackUPToolStripMenuItem.Text = "Coздать резервную копию";
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.jSONToolStripMenuItem.Text = "JSON";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.jSONToolStripMenuItem_Click);
            // 
            // buttonCreateKurs
            // 
            this.buttonCreateKurs.BackColor = System.Drawing.Color.Magenta;
            this.buttonCreateKurs.Location = new System.Drawing.Point(12, 27);
            this.buttonCreateKurs.Name = "buttonCreateKurs";
            this.buttonCreateKurs.Size = new System.Drawing.Size(221, 55);
            this.buttonCreateKurs.TabIndex = 2;
            this.buttonCreateKurs.Text = "Новый курс";
            this.buttonCreateKurs.UseVisualStyleBackColor = false;
            this.buttonCreateKurs.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Crimson;
            this.buttonRefresh.Location = new System.Drawing.Point(12, 374);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(215, 36);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Обновить статусы направлений";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // ButtonPayKurs
            // 
            this.ButtonPayKurs.BackColor = System.Drawing.Color.Magenta;
            this.ButtonPayKurs.Location = new System.Drawing.Point(12, 166);
            this.ButtonPayKurs.Name = "ButtonPayKurs";
            this.ButtonPayKurs.Size = new System.Drawing.Size(221, 33);
            this.ButtonPayKurs.TabIndex = 7;
            this.ButtonPayKurs.Text = "Занятия оплачены";
            this.ButtonPayKurs.UseVisualStyleBackColor = false;
            this.ButtonPayKurs.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // ButtonKursReady
            // 
            this.ButtonKursReady.BackColor = System.Drawing.Color.Magenta;
            this.ButtonKursReady.Location = new System.Drawing.Point(12, 125);
            this.ButtonKursReady.Name = "ButtonKursReady";
            this.ButtonKursReady.Size = new System.Drawing.Size(221, 35);
            this.ButtonKursReady.TabIndex = 8;
            this.ButtonKursReady.Text = "Курс завершился";
            this.ButtonKursReady.UseVisualStyleBackColor = false;
            this.ButtonKursReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // ButtonTakeKursInWork
            // 
            this.ButtonTakeKursInWork.BackColor = System.Drawing.Color.Magenta;
            this.ButtonTakeKursInWork.Location = new System.Drawing.Point(12, 88);
            this.ButtonTakeKursInWork.Name = "ButtonTakeKursInWork";
            this.ButtonTakeKursInWork.Size = new System.Drawing.Size(221, 31);
            this.ButtonTakeKursInWork.TabIndex = 9;
            this.ButtonTakeKursInWork.Text = "Начать занятия";
            this.ButtonTakeKursInWork.UseVisualStyleBackColor = false;
            this.ButtonTakeKursInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1185, 423);
            this.Controls.Add(this.ButtonTakeKursInWork);
            this.Controls.Add(this.ButtonKursReady);
            this.Controls.Add(this.ButtonPayKurs);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonCreateKurs);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Детская школа искусств";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private new System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem канцелярияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кружкиToolStripMenuItem;
        private System.Windows.Forms.Button buttonCreateKurs;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кружкиWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кружкиExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem канцелярияPDFToolStripMenuItem;
        private System.Windows.Forms.Button ButtonPayKurs;
        private System.Windows.Forms.Button ButtonKursReady;
        private System.Windows.Forms.Button ButtonTakeKursInWork;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказатьКанцТоварыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посмотретьДоступныеПродуктыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coздатьBackUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
    }
}