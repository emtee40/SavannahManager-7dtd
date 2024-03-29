﻿using System;
using System.Collections.ObjectModel;
using _7dtd_svmanager_fix_mvvm.LangResources;

namespace _7dtd_svmanager_fix_mvvm.Models.Setup
{
    public class FirstPageModel : PageModelBase
    {

        private readonly SettingLoader _settingLoader;
        private int _languagesSelectedIndex;

        public int LanguagesSelectedIndex
        {
            get => _languagesSelectedIndex;
            set => SetProperty(ref _languagesSelectedIndex, value);
        }
        public ObservableCollection<Tuple<string, string>> Languages { get; } = new()
        {
            new Tuple<string, string>(Resources.UI_EnglishLabel, ResourceService.English),
            new Tuple<string, string>(Resources.UI_JapaneseLabel, ResourceService.Japanese)
        };

        public FirstPageModel(InitializeData initializeData) : base(initializeData)
        {
            _settingLoader = initializeData.Setting;
            var cultureName = _settingLoader.CultureName;

            LanguagesSelectedIndex = cultureName == ResourceService.Japanese ? 1 : 0;
        }

        public void ChangeCulture()
        {
            if (LanguagesSelectedIndex < 0 || LanguagesSelectedIndex >= Languages.Count)
                return;

            _settingLoader.CultureName = Languages[LanguagesSelectedIndex].Item2;
            _settingLoader.ApplyCulture();
            
        }
    }
}
