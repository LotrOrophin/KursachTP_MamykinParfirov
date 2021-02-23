using AbstractSchoolBusinessLogic.Interfaces;
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
    public partial class FormCreateSchoolSupplie : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxSchoolSupplie.SelectedValue); }
            set { comboBoxSchoolSupplie.SelectedValue = value; }
        }
        public string SchoolSupplieName { get { return comboBoxSchoolSupplie.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set { textBoxCount.Text = value.ToString(); }
        }

        public FormCreateSchoolSupplie(ISchoolSupplieLogic logic)
        {
            InitializeComponent();
            List<SchoolSupplieViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxSchoolSupplie.DisplayMember = "SchoolSupplieName";
                comboBoxSchoolSupplie.ValueMember = "Id";
                comboBoxSchoolSupplie.DataSource = list;
                comboBoxSchoolSupplie.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show(
                    "Поле \"Количество\" не заполнено",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSchoolSupplie.SelectedValue == null)
            {
                MessageBox.Show(
                    "Комплектующее не выбрано",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
