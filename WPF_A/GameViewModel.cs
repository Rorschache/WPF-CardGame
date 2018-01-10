using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_CardLib;
using System.Windows.Input;
using System.ComponentModel;

namespace WPF_A
{
    public class GameViewModel:INotifyPropertyChanged
    {

        private GameOptions _gameOptions;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private Player _currentPlayer;
        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged("CurrentPlayer");
                if(!Players.Any(x=>x.State==PlayerState.Winner))
                {
                    Players.ForEach(x => x.State =
                    (x == value ? PlayerState.Active : PlayerState.Inactive));
                    CurrentStatusText = $"Player{CurrentPlayer.PlayerName} ready";
                }
                else
                {
                    var winner = Players.Where(x => x.HasWon).FirstOrDefault();
                    if (winner != null)
                        CurrentStatusText = $"Player {winner.PlayerName} has WON!";
                }
            }
        }

        private List<Player> _players;
        public List<Player> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        private Card _availableCard;
        public Card CurrentAvailableCard
        {
            get { return _availableCard; }
            set
            {
                _availableCard = value;
                OnPropertyChanged(nameof(CurrentAvailableCard));
            }
        }

        private Deck _deck;
        public Deck GameDeck
        {
            get { return _deck; }
            set
            {
                _deck = value;
                OnPropertyChanged(nameof(GameDeck));
            }
        }

        private bool _gameStarted;
        public bool GameStarted
        {
            get { return _gameStarted; }
            set
            {
                _gameStarted = value;
                OnPropertyChanged(nameof(GameStarted));
            }
        }

        public string _currentStatusText = "Game is not started";
        public string CurrentStatusText
        {
            get { return _currentStatusText; }
            set
            {
                _currentStatusText = value;
                OnPropertyChanged(nameof(CurrentStatusText));
            }
        }



        //添加两个路由命令

        public static RoutedCommand StartGameCommand =
            new RoutedCommand("Start New Game", typeof(GameViewModel),
                new InputGestureCollection(new List<InputGesture>
                {new KeyGesture(Key.N,ModifierKeys.Control) }));

        public static RoutedCommand ShowAboutCommand =
            new RoutedCommand("Show About Dialog", typeof(GameViewModel));

        //添加一个新的默认构造函数
        public GameViewModel()
        {
            _players = new List<Player>();
            _gameOptions = GameOptions.Create();
        }

        //游戏开始时对玩家和牌堆进行初始化
        public void StartNewGame()
        {
            if (_gameOptions.SelectedPlayers.Count < 1 ||
                (_gameOptions.SelectedPlayers.Count == 1
                && !_gameOptions.PlayAgainstComputer))
                return;
            CreatGameDeck();
            CreatPlayers();
            InitializeGame();
            GameStarted = true;
            CurrentStatusText = string.Format("New game started. Player {0} to start",
                CurrentPlayer.PlayerName);
        }

        private void InitializeGame()
        {
            AssignCurrentPlayer(0);
            CurrentAvailableCard = GameDeck.Draw();
        }

        private void AssignCurrentPlayer(int index)
        {
            CurrentPlayer = Players[index];
            if (!Players.Any(x => x.State == PlayerState.Winner))
            {
                Players.ForEach(x => x.State = (x == Players[index] ? PlayerState.Active :
                  PlayerState.Inactive));
            }
        }

        private void InitializePlayer(Player player)
        {
            player.DrawNewHand(GameDeck);
            player.OnCardDiscarded += player_OnCardDiscarded;
            player.OnPlayerHasWon += player_OnPlayerHasWon;
            Players.Add(player);
        }

        private void CreatGameDeck()
        {
            GameDeck = new Deck();
            GameDeck.Shuffle();
        }

        private void CreatPlayers()
        {
            Players.Clear();
            for(var i = 0;i<_gameOptions.NumberOfPlayers;i++)
            {
                if (i < _gameOptions.SelectedPlayers.Count)
                    InitializePlayer(new Player
                    {
                        Index = i,
                        PlayerName =
                        _gameOptions.SelectedPlayers[i]
                    });
                else
                    InitializePlayer(new ComputerPlayer
                    {
                        Index = i,
                        Skill =
                        _gameOptions.ComputerSkill
                    });
            }
        }

        void player_OnCardDiscarded(object sender,CardEventArgs e)
        {
            CurrentAvailableCard = e.Card;
            var nextIndex = (CurrentPlayer.Index + 1 >=_gameOptions.NumberOfPlayers)
                ? 0 : CurrentPlayer.Index + 1;
            if(GameDeck.CardsInDeck ==0)
            {
                var cardsInPlay = new List<Card>();
                foreach (var player in Players)
                    cardsInPlay.AddRange(player.GetCards());
                cardsInPlay.Add(CurrentAvailableCard);
                GameDeck.ReshuffleDiscarded(cardsInPlay);
            }
            AssignCurrentPlayer(nextIndex);
        }

        void player_OnPlayerHasWon(object sender,PlayerEventArgs e)
        {
            Players.ForEach(x => x.State = (x == e.Player
            ? PlayerState.Winner : PlayerState.Loser));
        }


    }
}
