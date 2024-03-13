using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.View.Tabs;
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
            ItemsTab.Items = Store.Items;
            CustomersTab.Customers = Store.Customers;
            CartsTab.Items = Store.Items;
            CartsTab.Customers = Store.Customers;
            OrdersTab.Customers = Store.Customers;
        }

        /// <summary>
        /// Событие при закрытии проекта.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Serializer.SetStore(Store);
        }

        /// <summary>
        /// Событие при переходе на другую вкладку элемента <see cref="MainTabControl"/>.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void MainTabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (MainTabControl.SelectedIndex)
            {
                case 1:
                    CustomersTab.UpdateDiscountsListBox();
                    break;
                case 2:
                    CartsTab.RefreshData();
                    break;
                case 3:
                    OrdersTab.RefreshData();
                    break;
            }
        }

        /// <summary>
        /// Событие при загрузки главного окна.
        /// </summary>
        /// <param name="sender">Элемент управления, вызвавший событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            CartsTab.UpdateCustomerCarts();
        }
    }
}
