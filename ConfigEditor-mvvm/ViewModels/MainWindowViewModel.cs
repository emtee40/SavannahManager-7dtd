﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommonLib.Models;
using CommonLib.ViewModels;
using System.Windows.Input;
using Reactive.Bindings;
using System.Collections.ObjectModel;
using ConfigEditor_mvvm.Models;
using Reactive.Bindings.Extensions;
using Prism.Commands;

namespace ConfigEditor_mvvm.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private MainWindowModel model;
        public MainWindowViewModel(Window view, MainWindowModel model) : base(view, model)
        {
            this.model = model;

            #region Event Initialize
            Loaded = new DelegateCommand(MainWindow_Loaded);
            NewFileBtClicked = new DelegateCommand(NewFileBt_Clicked);
            OpenBtClicked = new DelegateCommand(OpenBt_Clicked);
            SaveAsBtClicked = new DelegateCommand(SaveAsBt_Clicked);
            SaveBtClicked = new DelegateCommand(SaveBt_Clicked);

            VersionsListSelectionChanged = new DelegateCommand(VersionsList_SelectionChanged);
            ConfigListSelectionChanged = new DelegateCommand(ConfigList_SelectionChanged);
            ValueListSelectionChanged = new DelegateCommand(ValueList_SelectionChanged);
            ValueTextTextChanged = new DelegateCommand(ValueTextText_Changed);
            #endregion

            VersionList = model.VersionList.ToReadOnlyReactiveCollection(x => x);
            ConfigList = model.ConfigList.ToReadOnlyReactiveCollection(x => x);
            ValueList = model.ToReactivePropertyAsSynchronized(m => m.ValueList);
            VersionListSelectedIndex = model.ToReactivePropertyAsSynchronized(m => m.VersionListSelectedIndex);
            ConfigListSelectedIndex = model.ToReactivePropertyAsSynchronized(m => m.ConfigListSelectedIndex);
            ValueListSelectedItem = model.ToReactivePropertyAsSynchronized(m => m.ValueListSelectedItem);
            ValueListSelectedIndex = model.ToReactivePropertyAsSynchronized(m => m.ValueListSelectedIndex);

            NameLabel = model.ToReactivePropertyAsSynchronized(m => m.NameLabel);
            DescriptionLabel = model.ToReactivePropertyAsSynchronized(m => m.DescriptionLabel);
            ValueText = model.ToReactivePropertyAsSynchronized(m => m.ValueText);
            ValueListVisibility = model.ToReactivePropertyAsSynchronized(m => m.ValueListVisibility);
            ValueTextBoxVisibility = model.ToReactivePropertyAsSynchronized(m => m.ValueTextBoxVisibility);

            if (Loaded != null && Loaded.CanExecute(null))
            {
                Loaded?.Execute(null);
            }
        }

        #region Properties
        public ReadOnlyCollection<string> VersionList { get; }
        public ReactiveProperty<int> VersionListSelectedIndex { get; set; }

        public ReadOnlyCollection<ConfigListInfo> ConfigList { get; }
        public ReactiveProperty<int> ConfigListSelectedIndex { get; set; }
        
        public ReactiveProperty<string> NameLabel { get; set; }
        public ReactiveProperty<string> DescriptionLabel { get; set; }

        public ReactiveProperty<ObservableCollection<string>> ValueList { get; set; }
        public ReactiveProperty<string> ValueListSelectedItem { get; set; }
        public ReactiveProperty<int> ValueListSelectedIndex { get; set; }

        public ReactiveProperty<string> ValueText { get; set; }
        public ReactiveProperty<Visibility> ValueListVisibility { get; set; }
        public ReactiveProperty<Visibility> ValueTextBoxVisibility { get; set; }

        #endregion

        #region Event Properties
        public ICommand Loaded { get; set; }

        public ICommand NewFileBtClicked { get; }
        public ICommand OpenBtClicked { get; }
        public ICommand SaveAsBtClicked { get; }
        public ICommand SaveBtClicked { get; }

        public ICommand VersionsListSelectionChanged { get; }
        public ICommand ConfigListSelectionChanged { get; }
        public ICommand ValueListSelectionChanged { get; }

        public ICommand ValueTextTextChanged { get; }
        #endregion

        #region Event Methods
        public void MainWindow_Loaded()
        {
            model.Initialize();
        }

        public void NewFileBt_Clicked()
        {

        }
        public void OpenBt_Clicked()
        {

        }
        public void SaveAsBt_Clicked()
        {

        }
        public void SaveBt_Clicked()
        {

        }

        public void VersionsList_SelectionChanged()
        {
            model.Load();
        }
        public void ConfigList_SelectionChanged()
        {
            model.SetConfigProperty();
        }
        public void ValueList_SelectionChanged()
        {
        }
        public void ValueTextText_Changed()
        {
            Console.WriteLine("ValueTextText_Changed");
        }
        #endregion
    }
}