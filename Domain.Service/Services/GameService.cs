﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Layer.DataAccessLayer;
using Data.Layer.Models;
using Data.Layer.Interfaces;
using TrackerEnabledDbContext.Common.Models;

namespace Domain.Layer.Services
{
    public class GameService : IService<Event>
    {
        GameDayContext db = new GameDayContext();
        
        public List<Event> GetRecords()
        {

            return db.Events.ToList();
        }

        public Event FindRecord(int? id)
        {
            return db.Events.Find(id);
        }

        public void AddRecord(Event e)
        {
            db.Events.Add(e);
            SaveChanges();
        }

        public void EditRecord(Event e)
        {
            db.Entry(e).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteRecord(Event e)
        {
            db.Events.Remove(e);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IQueryable<AuditLog> GetAuditLogs(int id)
        {
            return db.GetLogs<Event>(id);
        }
    }
}