﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Layer.DataAccessLayer;
using Data.Layer.Models;
using Data.Layer.Interfaces;
using TrackerEnabledDbContext.Common.Models;

namespace Domain.Layer.Services
{
    public class AddressService : IService<Address>
    {
        GameDayContext db = new GameDayContext();

        public List<Address> GetRecords()
        {
            return db.Locations.ToList();
        }

        public Dictionary<string, string> GetAddressDropDown()
        {
            var addressDictionary = db.Locations.ToDictionary(x => x.ID.ToString(), x => x.Name);
            return addressDictionary;
        }  

        public Address FindRecord(int? id)
        {
            return db.Locations.Find(id);
        }

        public void AddRecord(Address a)
        {
            db.Locations.Add(a);
            SaveChanges();
        }

        public void EditRecord(Address a)
        {
            db.Entry(a).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteRecord(Address a)
        {
            db.Locations.Remove(a);
            SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IQueryable<AuditLog> GetAuditLogs(int id)
        {
            return db.GetLogs<Address>(id);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        //Gather the name of all address in string form
        public List<string> GetAddressNames()
        {
            return db.Locations.ToList().Select(x => x.Name).ToList();
        }

    }
}