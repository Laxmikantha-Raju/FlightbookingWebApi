using DAL.Models;
using DAL.Interface;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly FlightTicketBookingDBContext _inventoryContext;
        public InventoryRepository(FlightTicketBookingDBContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }
        public IEnumerable<TblAirLine> GetAirlines()
        {
            return _inventoryContext.TblAirLines.ToList().Where(x => x.AirlineIsActiveYn == "Y");
        }

        public void AddAirlines(TblAirLine tbl)
        {
            _inventoryContext.TblAirLines.Add(tbl);
            Save();
        }
        public IEnumerable<TblInventory> GetInventory()
        {
            return _inventoryContext.TblInventories.ToList().Where(x => x.FlightIsActiveYn == "Y");
        }

        public void AddInventory(TblInventory tbl)
        {
            _inventoryContext.TblInventories.Add(tbl);
            Save();
        }
        public void Save()
        {
            _inventoryContext.SaveChanges();
        }

        public IEnumerable<TblInventory> GetAllFlightBasedOnPlaces(string fromplace, string toplace)
        {
            return _inventoryContext.TblInventories.Where(x => x.FlightToPlace.ToLower() == toplace.ToLower() && x.FlightFromPlace.ToLower() == fromplace.ToLower()).ToList();
        }
        public void BlockAirline(TblAirLine tblAirLine)
        {
            var cols = _inventoryContext.TblAirLines.Where(w => w.AirlineNo == tblAirLine.AirlineNo);
            foreach (var item in cols)
            {
                item.AirlineIsActiveYn = "Y"; ;
            }
            Save();
        }
        public void UpdateAirline(TblAirLine tblAirLine)
        {
            _inventoryContext.Entry(tblAirLine).State = EntityState.Modified;
            Save();
        }
        public void UpdateInventory(TblInventory tblInventory)
        {
            _inventoryContext.Entry(tblInventory).State = EntityState.Modified;
            Save();
        }
    }
}
