﻿using DevExpress.Mvvm;
using MapDemo.Models;
using System.Collections.ObjectModel;

namespace MapDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private SoldierService service;

        public ObservableCollection<SoldierCache> Soldiers { get; set; }
        public MainViewModel()
        {
            service = new SoldierService();

            GenerateSoldiers();
        }

        // generating random positions
        private void GenerateSoldiers()
        {
            Soldiers = new ObservableCollection<SoldierCache>(service.Generate());
        }


    }
}