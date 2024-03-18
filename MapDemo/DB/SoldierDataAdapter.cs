using MapDemo.Data;
using MapDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

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

    }
}
