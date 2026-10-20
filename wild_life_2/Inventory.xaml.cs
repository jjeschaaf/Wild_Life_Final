using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wild_life_2
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {

        private List<string> inventory;
        private string selectedItem;

        public Inventory(List<string> inventory)
        {
            InitializeComponent();

            this.inventory = inventory;

            RefreshInventory();
        }

        private void RefreshInventory()
        {
            InventoryList.ItemsSource = null;
            InventoryList.ItemsSource = inventory;
        }

        //Om vrucht te eten
        private void EatButton_Click(object sender, RoutedEventArgs e)
        {
            string item = InventoryList.SelectedItem as string;

            if (item == null)
                return;

            if (item == "Appel")
            {
                inventory.Remove(item);

                MessageBox.Show("Appel gegeten!");

                RefreshInventory();
            }
        }

        private void InventoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = InventoryList.SelectedItem as string;

            if (selectedItem == null)
                return;

            ItemNameText.Text = selectedItem;

            if (selectedItem == "Appel")
            {
                ItemInfoText.Text = "Een verse appel. Herstelt 10 gezondheid.";
                EatButton.IsEnabled = true;
            }
        }
    }
}
