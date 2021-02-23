using AbstractSchoolBusinessLogic.BindingModels;
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
    public partial class FormCircle : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ICircleLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> circleSchoolSupplie;

        public FormCircle(ICircleLogic service)
        {
            InitializeComponent();
            dataGridViewComponents.Columns.Add("Id", "Id");
            dataGridViewComponents.Columns.Add("SchoolSupplieName", "Канц.Товар");
            dataGridViewComponents.Columns.Add("Count", "Количество");
            dataGridViewComponents.Columns[0].Visible = false;
            dataGridViewComponents.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.logic = service;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CircleViewModel view = logic.Read(new CircleBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxNameProduct.Text = view.CircleName;
                        textBoxPrice.Text = view.PricePerHour.ToString();
                        circleSchoolSupplie = view.CircleSchoolSupplies;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                circleSchoolSupplie = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (circleSchoolSupplie != null)
                {
                    dataGridViewComponents.Rows.Clear();
                    foreach (var pc in circleSchoolSupplie)
                    {
                        dataGridViewComponents.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCirclesSchoolSupplie>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (circleSchoolSupplie.ContainsKey(form.Id))
                {
                    circleSchoolSupplie[form.Id] = (form.SchoolSupplieName, form.Count);
                }
                else
                {
                    circleSchoolSupplie.Add(form.Id, (form.SchoolSupplieName, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormCirclesSchoolSupplie>();
                int id = Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = circleSchoolSupplie[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    circleSchoolSupplie[form.Id] = (form.SchoolSupplieName, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        circleSchoolSupplie.Remove(Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameProduct.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (circleSchoolSupplie == null || circleSchoolSupplie.Count == 0)
            {
                MessageBox.Show("Заполните нужную канцелярию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new CircleBindingModel
                {
                    Id = id ?? null,
                    CircleName = textBoxNameProduct.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    CircleSchoolSupplies = circleSchoolSupplie
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
