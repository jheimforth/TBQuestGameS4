﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel
    {
        #region Fields
        private Player _player;
        private List<string> _messages;

        






        #endregion

        #region Properties
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
            
        }

        #endregion

        #region Constructors
        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player, List<string> initialMessages)
        {
            _player = player;
            _messages = initialMessages;
        }

        public GameSessionViewModel(Player player)
        {
            _player = player;
        }
        #endregion


    }
}
