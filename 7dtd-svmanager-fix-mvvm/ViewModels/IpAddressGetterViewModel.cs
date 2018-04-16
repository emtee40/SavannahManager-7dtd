﻿using _7dtd_svmanager_fix_mvvm.Models;
using CommonLib.Models;
using CommonLib.ViewModels;
using Prism.Commands;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _7dtd_svmanager_fix_mvvm.ViewModels
{
    public class IpAddressGetterViewModel : ViewModelBase
    {
        public IpAddressGetterViewModel(Window view, IpAddressGetterModel model) : base(view, model)
        {
            this.model = model;

            #region EventInitialize
            GetIpClicked = new DelegateCommand(GetIp_Clicked);
            CopyClicked = new DelegateCommand<string>(Copy_Clicked);
            #endregion

            #region PropertyInitialize
            ExternalIpAddress = model.ToReactivePropertyAsSynchronized(m => m.ExternalIpAddress);
            LocalIpAddress = model.ToReactivePropertyAsSynchronized(m => m.LocalIpAddress);
            StatusLabel = model.ToReactivePropertyAsSynchronized(m => m.StatusLabel);
            #endregion
        }

        #region Fields
        private IpAddressGetterModel model;
        #endregion

        #region Properties
        public ReactiveProperty<string> ExternalIpAddress { get; set; }
        public ReactiveProperty<string> LocalIpAddress { get; set; }
        public ReactiveProperty<string> StatusLabel { get; set; }
        #endregion

        #region EventProperties
        public ICommand GetIpClicked { get; set; }
        public ICommand CopyClicked { get; set; }
        #endregion

        #region EventMethods
        private void GetIp_Clicked()
        {
            model.SetIpAddress();
        }

        private void Copy_Clicked(string text)
        {
            model.CopyClipboard(text);
        }
        #endregion
    }
}