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
    /// GameClient.xaml 的交互逻辑
    /// </summary>
    public partial class GameClient : Window
    {
        public GameClient()
        {
            InitializeComponent();
            /*
            var position = new Point(15, 15);
            for(var i = 0;i<4; i++)
            {
                var suit = (C_sharp_CardLib.Suit)i;
                position.Y = 15;
                for(int rank =1;rank<14;rank++)
                {
                    position.Y += 30;
                    var card = new CardControl
                        (new C_sharp_CardLib.Card(suit, (C_sharp_CardLib.Rank)rank));
                    card.VerticalAlignment = VerticalAlignment.Top;
                    card.HorizontalAlignment = HorizontalAlignment.Left;
                    card.Margin = new Thickness(position.X, position.Y, 0, 0);
                    contentGrid.Children.Add(card);
                }
                position.X += 112;
            }*/
        }
        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Close)
                e.CanExecute = true;
            if (e.Command == ApplicationCommands.Save)
                e.CanExecute = false;
            
            if (e.Command == GameViewModel.StartGameCommand)
                e.CanExecute = true;
            if (e.Command == GameOptions.OptionsCommand)
                e.CanExecute = true;
            if (e.Command == GameViewModel.ShowAboutCommand)
                e.CanExecute = true;
            e.Handled = true;
        }

        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Close)
                this.Close();
            
            if (e.Command == GameViewModel.StartGameCommand)
            {
                var model = new GameViewModel();
                StartGame startGameDialog = new StartGame();
                var options = GameOptions.Create();
                startGameDialog.DataContext = options;
                var result = startGameDialog.ShowDialog();
                if (result.HasValue && result.Value == true)
                {
                    options.Save();
                    model.StartNewGame();
                    DataContext = model;
                }
            }
            if (e.Command == GameOptions.OptionsCommand)
            {
                var dialog = new Options();
                var result = dialog.ShowDialog();
                if (result.HasValue && result.Value == true)
                    DataContext = new GameViewModel(); // Clear current game
            }
            if (e.Command == GameViewModel.ShowAboutCommand)
            {
                var dialog = new About();
                dialog.ShowDialog();
            }
            e.Handled = true;
        }
    }
}
