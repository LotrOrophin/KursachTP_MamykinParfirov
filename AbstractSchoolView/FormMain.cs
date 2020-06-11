using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.BusinessLogics;
using AbstractSchoolBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractSchoolView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        private readonly IRequestLogic requestLogic;
        private readonly ICircleLogic circleLogic;
        private readonly ISchoolSupplieLogic schoolSupplieLogic;
        private readonly ReportLogic report;

        public FormMain(MainLogic logic, IOrderLogic orderLogic, ReportLogic report,
            ISchoolSupplieLogic schoolSupplieLogic, IRequestLogic requestLogic, ICircleLogic circleLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.report = report;
            this.circleLogic = circleLogic;
            this.requestLogic = requestLogic;
            this.schoolSupplieLogic = schoolSupplieLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var listOrders = orderLogic.Read(null);
            if (listOrders != null)
            {
                dataGridView.DataSource = listOrders;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView.Columns[6].Visible = false;
            }
            dataGridView.Update();
        }

        private void SchoolSuppliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSchoolSupplies>();
            form.ShowDialog();
        }

        private void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCircles>();
            form.ShowDialog();
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.FinishOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void канцеляриPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportMovingPdf>();
            form.ShowDialog();
        }

        private void кружкиWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        report.SaveOrdersToWordFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Отчет выслан", "Успешно", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void кружкиExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportCircleExcel>();
            form.ShowDialog();
        }

        private void заказатьКанцеляриюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateRequest>();
            form.ShowDialog();
        }

        private void выводВсейКанцелярииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequest>();
            form.ShowDialog();
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    requestLogic.SaveXmlRequest(fbd.SelectedPath);
                    requestLogic.SaveXmlRequestSchoolSupplie(fbd.SelectedPath);
                    circleLogic.SaveXmlCircle(fbd.SelectedPath);
                    circleLogic.SaveXmlCircleSchoolSupplie(fbd.SelectedPath);
                    orderLogic.SaveXmlOrder(fbd.SelectedPath);
                    schoolSupplieLogic.SaveXmlSchoolSupplie(fbd.SelectedPath);
                    report.SendMailReport("mamykinvladimir00@gmail.com", fbd.SelectedPath, "XML копия", "xml");
                    MessageBox.Show("Резерваная копия выслана", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    requestLogic.SaveJsonRequest(fbd.SelectedPath);
                    requestLogic.SaveJsonRequestSchoolSupplie(fbd.SelectedPath);
                    circleLogic.SaveJsonCircle(fbd.SelectedPath);
                   circleLogic.SaveJsonCircleSchoolSupplie(fbd.SelectedPath);
                    orderLogic.SaveJsonOrder(fbd.SelectedPath);
                    schoolSupplieLogic.SaveJsonSchoolSupplie(fbd.SelectedPath);
                    report.SendMailReport("mamykinvladimir00gmail.com", fbd.SelectedPath, "JSON копия", "json");
                    MessageBox.Show("Резервная копия выслана", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
