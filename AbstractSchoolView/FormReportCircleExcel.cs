using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.BusinessLogics;
using AbstractSchoolBusinessLogic.ViewModels;
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
    public partial class FormReportCircleExcel : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportCircleExcel(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            dataGridViewSchoolSupplieCircle.Columns.Add("Кружки", "Кружки");
            dataGridViewSchoolSupplieCircle.Columns.Add("Канцелярия", "Канцелярия");
            dataGridViewSchoolSupplieCircle.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void FormReportFoodsToDishes_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetCircleSchoolSupplies();
                if (dict != null)
                {
                    Dictionary<string, List<ReportCircleSchoolSupplieViewModel>> dishFoods = new Dictionary<string, List<ReportCircleSchoolSupplieViewModel>>();
                    dataGridViewSchoolSupplieCircle.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        if (!dishFoods.ContainsKey(elem.CircleName))
                            dishFoods.Add(elem.CircleName, new List<ReportCircleSchoolSupplieViewModel>() { elem });
                        else
                            dishFoods[elem.CircleName].Add(elem);
                    }
                    foreach (var order in dishFoods)
                    {
                        dataGridViewSchoolSupplieCircle.Rows.Add(order.Key, "", "");
                        foreach (var dish in order.Value)
                        {
                            dataGridViewSchoolSupplieCircle.Rows.Add("", dish.SchoolSupplieName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveOrdersToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Отчет сохранен и успешно выслан на указанный адрес", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
