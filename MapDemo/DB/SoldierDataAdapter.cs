using MapDemo.Data;
using MapDemo.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MapDemo.DB
{
    public class SoldierDataAdapter
    {
        private ILogger logger;
        private SoldierDbContext Context { get; set; }
        public SoldierDataAdapter()
        {
            logger = LogManager.GetLogger(nameof(SoldierDataAdapter));
            Context = new SoldierDbContext();
            CreateDb();
        }

        public void CreateDb()
        {
            try
            {
                {
                    if (!Context.Database.CreateIfNotExists())
                    {
                        Context.Soldiers.RemoveRange(Context.Soldiers);
                        Context.SaveChanges();
                        logger.Info("db already exists so we do a clean start");
                    }
                    else
                    {
                        logger.Info("db created");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }


        async public void SaveDataAsync(List<SoldierCache> soldiers)
        {
            await Task.Run(() => SaveData(soldiers));
        }

        private void SaveData(List<SoldierCache> soldiers)
        {
            try
            {
                foreach (var soldier in soldiers)
                {
                    var sol = Context.GetSoldierDataByName(soldier.Name);
                    if (sol != null)
                    {
                        logger.Info($"found {sol.Name} {sol.Id}");
                        LocationData ldata = new LocationData()
                        {
                            Latitude = soldier.Location.Latitude,
                            Longitude = soldier.Location.Longitude,
                            Soldier = sol,
                            Soldier_Id = sol.Id
                        };

                        sol.Locations.Add(ldata);
                    }
                    else
                    {
                        logger.Info($"not found {soldier.Name}");
                        SoldierData data = new SoldierData()
                        {
                            Id = soldier.Id,
                            Name = soldier.Name,
                            Rank = soldier.Rank
                        };
                        data.Locations.Add(soldier.Location);

                        Context.Soldiers.Add(data);
                    }//endElse
                }//endFor
                Context.SaveChanges();
                System.Threading.Thread.Sleep(500);//give it some breathing space
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }
    }
}
