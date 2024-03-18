using MapDemo.DB;
using MapDemo.Events;
using MapDemo.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Timers;

namespace MapDemo.Models
{
    public class SoldierService
    {
        private Timer dataTimer;
        private ILogger logger;
        private SoldierDataAdapter soldierDataAdapter;


        public event LocationUpdateEvent LocationUpdated;
        public List<SoldierCache> SoldierCache;

        public SoldierService()
        {
            logger = LogManager.GetLogger(nameof(SoldierService));

            // Initialize cache
            SoldierCache = new List<SoldierCache>();
            //init adapter
            soldierDataAdapter = new SoldierDataAdapter();

            // Set up timer to update location periodically
            dataTimer = new Timer();
            dataTimer.Interval = 1000; // Update every 1 second
            dataTimer.Elapsed += UpdateLocation;
            
        }

        public List<SoldierCache> Generate(int count)
        {
            try{
                // Simulate soldier data by generating random locations
                Random rand = new Random();
                for (int i = 0; i < count; i++)
                {
                    double latitude = 46.950249 + (rand.NextDouble() - 0.4) * 0.01;
                    double longitude = 7.415634 + (rand.NextDouble() - 0.4) * 0.01;
                    SoldierCache.Add
                        (new SoldierCache(latitude, longitude) { Id = i, Name = "Name" + i, Rank = "Rank" + i });
                }
                logger.Info($"generated {count} soldiers");
            }catch(Exception ex)
            {
                logger.Error($"error while generating {count} soldiers" + ex.Message);
            }

            return SoldierCache;
        }


        #region DataTimer
        public void Start()
        {
            dataTimer.Start();
        }

        public void Stop()
        {
            dataTimer.Stop();
        }

        private void UpdateLocation(object sender, ElapsedEventArgs e)
        {
            //TODO: Optimize this by randomizing only few checking what has changed and only update the changed items
            RandomLocation();

            LocationUpdated?.Invoke(SoldierCache);
        }

        private void RandomLocation()
        {
            try
            {
                if(SoldierCache.Count == 0)
                {
                    //since we're emulating
                    Generate(10);
                }

                Random rand = new Random();
                foreach (var soldier in SoldierCache)
                {
                    soldier.Location.Latitude = soldier.Location.Latitude + (rand.NextDouble() - 0.5) * 0.01;
                    soldier.Location.Longitude = soldier.Location.Longitude + (rand.NextDouble() - 0.5) * 0.01;
                }
            }catch(Exception ex) {
                logger.Error("error while update location " + ex.Message);
            }
        }
        #endregion

    }
}
