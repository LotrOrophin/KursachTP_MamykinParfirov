using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.BusinessLogics;
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
    public partial class FormCreateRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IRequestLogic requestLogic;
        private readonly ISupplierLogic supplierLogic;
        private readonly MainLogic mainLogic;
        public int ID { set { Id = value; } }
        private int? Id;
        private Dictionary<int, (string, int, bool)> requestSchoolSupplie;

        public FormCreateRequest(MainLogic mainLogic,
            IRequestLogic requestLogic, ISupplierLogic supplierLogic)
        {
            InitializeComponent();
            this.requestLogic = requestLogic;
            this.supplierLogic = supplierLogic;
            this.mainLogic = mainLogic;
        }

        private void RequestCreationForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            if (Id.HasValue)
            {
                try
                {
                    RequestViewModel request = requestLogic.Read(new RequestBindingModel
                    {
                        Id = Id.Value
                    })?[0];
                    if (request != null)
                    {
                        comboBoxSupplier.SelectedIndex =
                            comboBoxSupplier.FindStringExact(request.SupplierFIO);
                        requestSchoolSupplie = request.SchoolSupplies;
                        LoadFoods();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Ошибка загрузки данных заявки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                requestSchoolSupplie = new Dictionary<int, (string, int, bool)>();
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                List<SupplierViewModel> suppliersList = supplierLogic.Read(null);
                if (suppliersList != null)
                {
                    comboBoxSupplier.DisplayMember = "Email";
                    comboBoxSupplier.ValueMember = "Id";
                    comboBoxSupplier.DataSource = suppliersList;
                    comboBoxSupplier.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки списка поставщиков",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadFoods()
        {
            try
            {
                if (requestSchoolSupplie != null)
                {
                    SchoolSupplieGridView.Rows.Clear();
                    foreach (var requestSchoolSupplie in requestSchoolSupplie)
                    {
                        SchoolSupplieGridView.Rows.Add(new object[] {
                            requestSchoolSupplie.Key,
                            requestSchoolSupplie.Value.Item1,
                            requestSchoolSupplie.Value.Item2
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateSchoolSupplie>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (requestSchoolSupplie.ContainsKey(form.Id))
                {
                    requestSchoolSupplie[form.Id] = (form.SchoolSupplieName, form.Count, false);
                }
                else
                {
                    requestSchoolSupplie.Add(form.Id, (form.SchoolSupplieName, form.Count, false));
                }
                LoadFoods();
            }
        }

        private void UpdateFoodButton_Click(object sender, EventArgs e)
        {
            if (SchoolSupplieGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormCreateSchoolSupplie>();
                int Id = Convert.ToInt32(SchoolSupplieGridView.SelectedRows[0].Cells[0].Value);
                form.Id = Id;
                form.Count = requestSchoolSupplie[Id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    requestSchoolSupplie[form.Id] = (form.SchoolSupplieName, form.Count, false);
                    LoadFoods();
                }
            }
        }

        private void DeleteFoodButton_Click(object sender, EventArgs e)
        {
            if (SchoolSupplieGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show(
                    "Действительно хотите удалить кружок?",
                    "Требуется подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        requestSchoolSupplie.Remove(Convert.ToInt32(SchoolSupplieGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    LoadFoods();
                }
            }
        }

        private void RefreshFoodsButton_Click(object sender, EventArgs e)
        {
            LoadFoods();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (comboBoxSupplier.SelectedValue == null)
            {
                MessageBox.Show(
                    "Поставщик не выбран",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (requestSchoolSupplie == null || requestSchoolSupplie.Count == 0)
            {
                MessageBox.Show(
                    "Не выбрано ни одного кружка",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                mainLogic.CreateOrUpdateRequest(new RequestBindingModel
                {
                    Id = Id,
                    SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue),
                    SchoolSupllies = requestSchoolSupplie
                });
                MessageBox.Show(
                    "Сохранение заявки прошло успешно",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void СancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
