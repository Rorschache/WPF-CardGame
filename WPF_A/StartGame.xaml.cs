using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;

namespace WPF_A
{
    /// <summary>
    /// </summary>
    public partial class StartGame : Window
    {
        private GameOptions _gameOptions;
        public StartGame()
        {
            InitializeComponent();
            DataContextChanged += StartGame_DataContextChanged;
        }

        void StartGame_DataContextChanged(object sender,DependencyPropertyChangedEventArgs e)
        {
            _gameOptions = DataContext as GameOptions;
            ChangeListBoxOptions();
        }

        private void ChangeListBoxOptions()
        {
            if (_gameOptions.PlayAgainstComputer)
                playerNamesListBox.SelectionMode
                    = SelectionMode.Single;
            else
                playerNamesListBox.SelectionMode
                    = SelectionMode.Extended;
        }

        public void playerNamesListBox_SelectionChanged
            (object sender,SelectionChangedEventArgs e)
        {
            if (_gameOptions.PlayAgainstComputer)
                okButton.IsEnabled = (playerNamesListBox.
                    SelectedItems.Count == 1);
            else
                okButton.IsEnabled = (playerNamesListBox.
                    SelectedItems.Count == _gameOptions.
                    NumberOfPlayers);
        }

        private void addNewPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newPlayerTextBox.Text))
                _gameOptions.AddPlayer(newPlayerTextBox.Text);
            newPlayerTextBox.Text = string.Empty;
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            var gameOptions = DataContext as GameOptions;
            gameOptions.SelectedPlayers = new List<string>();

            foreach(string item in playerNamesListBox.SelectedItems)
            {
                _gameOptions.SelectedPlayers.Add(item);
            }

            this.DialogResult = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameOptions = null;
            Close();
        }
    }
}
