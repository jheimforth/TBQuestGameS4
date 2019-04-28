﻿using System;
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

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                _gameSessionViewModel.AddItemToInventory();
          
        }

        private void PutDown_Button_Click(object sender, RoutedEventArgs e)
        {
         
                _gameSessionViewModel.RemoveItemFromInventory();
        }

        private void Item_Use_Button_Click(object sender, RoutedEventArgs e)
        {
               _gameSessionViewModel.OnUseGameItem();
            
        }

        private void Speak_Button_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNPCsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnPlayerTalkTo();
            }
        }
    }
}
