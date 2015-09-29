﻿using System.Collections.Generic;
using System.Windows.Controls;
using Pulsar4X.ECSLib;
using Pulsar4X.WPFUI.ViewModels;

namespace Pulsar4X.WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for AbilitySelectionList.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class AbilitySelectionList : UserControl
    {
        private List<TechSD> _techList; 
        public event ValueChangedEventHandler ValueChanged; 

        public AbilitySelectionList()
        {
            InitializeComponent();
        }

        public void GuiListSetup(ComponentAbilityDesignVM designAbility)
        {
            //AbilitySelectionList abilitySelection = new AbilitySelectionList();
            _techList = designAbility.TechList;

            NameLabel.Content = designAbility.Name;
            SelectionComboBox.ItemsSource = _techList;
            SelectionComboBox.DisplayMemberPath = "Name";

            SelectionComboBox.SelectedIndex = 0;
            
        }

        private void SelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged.Invoke(ECSLib.GuiHint.GuiTechSelectionList, SelectionComboBox.SelectedIndex);
            }
        }
    }
}
