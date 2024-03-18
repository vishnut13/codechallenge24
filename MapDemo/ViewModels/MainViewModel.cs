using DevExpress.Mvvm;
using MapDemo.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows.Input;

namespace MapDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region private properties
        private SoldierService service;
        private Timer updateTimer;
        private List<SoldierCache> soldierCache;
        private ILogger logger;
        #endregion

        #region commands
        public ICommand GenerateCommand => new DelegateCommand(GenerateSoldiers, CanGenerate);
        public ICommand StartServiceCommand => new DelegateCommand(StartService, CanStart);
        public ICommand StopServiceCommand => new DelegateCommand(StopService, CanStop);

        #endregion

        #region public properties
        public bool IsStarted { get; set; } = false;
        public ObservableCollection<SoldierCache> Soldiers { get; set; }

        #endregion

        public MainViewModel()
        {
            logger = LogManager.GetLogger(nameof(MainViewModel));

            service = new SoldierService();
            service.LocationUpdated += Service_LocationUpdated;
            IsStarted = false;

            // Set up timer to update soldiers periodically
            updateTimer = new Timer();
            updateTimer.Interval = 2000; // Update every 1 second
            updateTimer.Elapsed += UpdateSoldiers;
            updateTimer.Start();

        }

        private bool CanGenerate()
        {
            return IsStarted == false;
        }
        private bool CanStart()
        {
            return IsStarted == false;
        }
        private bool CanStop()
        {
            return IsStarted == true;
        }

        // generating random locations
        public void GenerateSoldiers()
        {
            Soldiers = new ObservableCollection<SoldierCache>(service.Generate(10));
            StartService();
        }


        private void Service_LocationUpdated(List<SoldierCache> soldiers)
        {
            soldierCache = soldiers;
        }

        private void StartService()
        {
            service.Start();
            IsStarted = true;
        }

        private void StopService()
        {
            service.Stop();
            IsStarted = false;
        }


        private void UpdateSoldiers(object sender, ElapsedEventArgs e)
        {
            if (soldierCache == null) { return; }

            try
            {
                // Update soldier location in batches
                App.Current.Dispatcher.Invoke(() =>
                {
                    Soldiers = new ObservableCollection<SoldierCache>(soldierCache);
                    RaisePropertiesChanged(nameof(Soldiers));
                });

            }
            catch (Exception ex)
            {
                logger.Error("unable to update " + ex.Message);
            }
        }

    }
}
