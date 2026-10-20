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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow2 : Window
    {
        private List<string> inventory = new();

        public GameWindow2()
        {
            InitializeComponent();

            KeyDown += GameWindow2_KeyDown;
        }

        private void GameWindow2_KeyDown(object sender, KeyEventArgs e)
        {
            double x = Canvas.GetLeft(Player);
            double y = Canvas.GetTop(Player);

            if (e.Key == Key.Left)
                Canvas.SetLeft(Player, x - 10);

            if (e.Key == Key.Right)
                Canvas.SetLeft(Player, x + 10);

            if (e.Key == Key.Up)
                Canvas.SetTop(Player, y - 10);

            if (e.Key == Key.Down)
                Canvas.SetTop(Player, y + 10);
            if (e.Key == Key.I)
            {
                Inventory inventoryWindow =
                    new Inventory(inventory);

                inventoryWindow.Show();
            }

            CheckFruitPickup();
        }

        private void CheckFruitPickup()
        {
            Rect playerRect = new Rect(
                Canvas.GetLeft(Player),
                Canvas.GetTop(Player),
                Player.Width,
                Player.Height);

            Rect fruitRect = new Rect(
                Canvas.GetLeft(Vrucht),
                Canvas.GetTop(Vrucht),
                Vrucht.Width,
                Vrucht.Height);

            if (playerRect.IntersectsWith(fruitRect))
            {
                inventory.Add("Appel");

                GameCanvas.Children.Remove(Vrucht);

                MessageBox.Show("Appel opgepakt!");
            }
        }
    }
}
