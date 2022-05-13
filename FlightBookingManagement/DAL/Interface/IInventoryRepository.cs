using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IInventoryRepository
    {
        public void AddInventory(TblInventory tbl);
        public void AddAirlines(TblAirLine tbl);
        public IEnumerable<TblInventory> GetInventory();
        public IEnumerable<TblAirLine> GetAirlines();
        public IEnumerable<TblInventory> GetAllFlightBasedOnPlaces(string fromplace, string toplace);
        public void BlockAirline(TblAirLine tbl);
        public void UpdateAirline(TblAirLine tbl);
        public void UpdateInventory(TblInventory tbl);
    }
}
