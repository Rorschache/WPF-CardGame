using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;
using C_sharp_CardLib;

namespace WPF_A
{
    [Serializable]
    public class GameOptions
    {
        private ObservableCollection<string> _playerNames =
            new ObservableCollection<string>();

        public ObservableCollection<string> PlayerNames
        {
            get { return _playerNames; }
            set
            {
                _playerNames = value;
                OnPropertyChanged("PlayerNames");
            }
        }

        public void AddPlayer(string playerName)
        {
            if (_playerNames.Contains(playerName))
                return;
            _playerNames.Add(playerName);
            OnPropertyChanged("PlayerNames");
        }

        public List<string> SelectedPlayers { get; set; }

        //构造函数
        public GameOptions()
        {
            SelectedPlayers = new List<string>();
        }

        private bool _playAgainstComputer = true;
        private int _numberOfPlayers = 2;
        private ComputerSkillLevel _computerSkill =
            ComputerSkillLevel.Dumb;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke
                (this, new PropertyChangedEventArgs(propertyName));
        }

        public bool PlayAgainstComputer
        {
            get { return _playAgainstComputer; }
            set
            {
                _playAgainstComputer = value;
                OnPropertyChanged(nameof(PlayAgainstComputer));
            }
        }
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set
            {
                _numberOfPlayers = value;
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }
       // public int MinutesBeforeLoss { get; set; }
        public ComputerSkillLevel ComputerSkill
        {
            get { return _computerSkill; }
            set
            {
                _computerSkill = value;
                OnPropertyChanged(nameof(ComputerSkill));
            }
        }

        //命令
        public static RoutedCommand OptionsCommand = new RoutedCommand("Show Options",
            typeof(GameOptions), new InputGestureCollection(new List<InputGesture>
            { new KeyGesture(Key.O,ModifierKeys.Control)}));

        public void Save()
        {
            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, this);
            }
        }

        public static GameOptions Create()
        {
            if (File.Exists("GameOptions.xml"))
            {
                using (var stream = File.OpenRead("GameOptions.xml"))
                {
                    var serializer = new XmlSerializer(typeof(GameOptions));
                    return serializer.Deserialize(stream) as GameOptions;
                }
            }
            else
                return new GameOptions();
        }
    }
}
