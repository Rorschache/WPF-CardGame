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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_A
{
    /// <summary>
    /// CardControl.xaml 的交互逻辑
    /// </summary>
    public partial class CardControl : UserControl
    {
        public CardControl()
        {
            InitializeComponent();
        }

        public CardControl(C_sharp_CardLib.Card card)
        {
            InitializeComponent();
            Card = card;
        }


        //
        public static DependencyProperty SuitProperty = DependencyProperty.Register
            (
           "Suit",
           typeof(C_sharp_CardLib.Suit),
           typeof(CardControl),
           new PropertyMetadata(C_sharp_CardLib.Suit.Club,
    new PropertyChangedCallback(OnSuitChanged))
            );
        public static void OnSuitChanged(DependencyObject source,
       DependencyPropertyChangedEventArgs args)
        {
            var control = source as CardControl;
            control.SetTextColor();
        }


        public static DependencyProperty RankProperty = DependencyProperty.Register
            (
           "Rank",
           typeof(C_sharp_CardLib.Rank),
           typeof(CardControl),
           new PropertyMetadata(C_sharp_CardLib.Rank.Ace)
            );


        //
        public static DependencyProperty IsFaceUpProperty = DependencyProperty.Register
            (
       "IsFaceUp",
       typeof(bool),
       typeof(CardControl),
       new PropertyMetadata(true, new PropertyChangedCallback(OnIsFaceUpChanged))
            );

        private static void OnIsFaceUpChanged(DependencyObject source,
                  DependencyPropertyChangedEventArgs args)
        {
            var control = source as CardControl;
            control.RankLabel.Visibility =
            control.SuitLabel.Visibility =
            control.RankLabelInverted.Visibility =
            control.TopRightImage.Visibility =
            control.BottomLeftImage.Visibility = control.IsFaceUp ?
                 Visibility.Visible : Visibility.Hidden;
        }



        public bool IsFaceUp
        {
            get { return (bool)GetValue(IsFaceUpProperty); }
            set { SetValue(IsFaceUpProperty, value); }
        }
        public C_sharp_CardLib.Suit Suit
        {
            get { return (C_sharp_CardLib.Suit)GetValue(SuitProperty); }
            set { SetValue(SuitProperty, value); }
        }
        public C_sharp_CardLib.Rank Rank
        {
            get { return (C_sharp_CardLib.Rank)GetValue(RankProperty); }
            set { SetValue(RankProperty, value); }
        }


        private C_sharp_CardLib.Card _card;
        public C_sharp_CardLib.Card Card
        {
            get { return _card; }
            private set { _card = value; Suit = _card.suit; Rank = _card.rank; }
        }

        private void SetTextColor()
        {
            var color = (Suit == C_sharp_CardLib.Suit.Club || Suit == C_sharp_CardLib.Suit.Spade) ?
              new SolidColorBrush(Color.FromRgb(0, 0, 0)) :
              new SolidColorBrush(Color.FromRgb(255, 0, 0));
            RankLabel.Foreground = SuitLabel.Foreground = RankLabelInverted.Foreground =
                                  color;

        }
    }
}
