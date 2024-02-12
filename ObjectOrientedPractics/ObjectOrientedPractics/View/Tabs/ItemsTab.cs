using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class ItemsTab : UserControl
    {
        List<Item> _items = new List<Item>();

        public ItemsTab()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Item newItem = new Item();
            _items.Add(newItem);
            ItemsListBox.Items.Add($"New item{newItem.Id}");
            ItemsListBox.SelectedItem = $"New item{newItem.Id}";
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = ItemsListBox.SelectedIndex;
            if (removeIndex != -1)
            {
                ItemsListBox.Items.RemoveAt(removeIndex);
                _items.RemoveAt(removeIndex);
                if (ItemsListBox.Items.Count > 0)
                {
                    if (removeIndex < ItemsListBox.Items.Count)
                    {
                        ItemsListBox.SelectedIndex = removeIndex;
                    }
                    else
                    {
                        ItemsListBox.SelectedIndex = removeIndex - 1;
                    }
                }
            }
        }
    }
}
