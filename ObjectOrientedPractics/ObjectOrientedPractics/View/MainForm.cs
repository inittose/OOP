using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.View.Tabs;
using System;
using System.Windows.Forms;

namespace ObjectOrientedPractics
{
    /// <summary>
    /// Управляет главным окном программы.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Возвращает и задает объект класса <see cref="Model.Store"/>,
        /// который хранит данные о товарах и покупателях.
        /// </summary>
        public Store Store {  get; } = Serializer.GetStore();

        /// <summary>
        /// Инициализирует компонент,
        /// создает экзепляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            CustomersTab.Customers = Store.Customers;
            CartsTab.Items = Store.Items;
            CartsTab.Customers = Store.Customers;
            OrdersTab.Customers = Store.Customers;
            CustomersTab.CustomersChanged += DataChanged;
            ItemsTab.ItemsChanged += DataChanged;
            CartsTab.OrderCreated += DataChanged;
            ItemsTab.Items = Store.Items;
        }

        /// <summary>
        /// Событие при обновлении данных о товарах или покупателях.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="args">Данные о событии.</param>
        private void DataChanged(object sender, EventArgs e)
        {
            CartsTab.RefreshData();
            OrdersTab.RefreshData();
        }

        /// <summary>
        /// Событие при закрытии программы.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Serializer.SetStore(Store);
        }

        /// <summary>
        /// Событие при загрузки главного окна.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            CartsTab.UpdateCustomerCarts();
        }
    }
}
