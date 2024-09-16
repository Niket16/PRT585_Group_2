using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class UnitDal : IUnitDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public UnitDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<UnitModel> GetAll()
        {
            var result = _db.Unit.ToList();

            var returnObject = new List<UnitModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToUnitModel());
            }

            return returnObject;
        }

        public UnitModel? GetById(int UnitId)
        {
            var result = _db.Unit.SingleOrDefault(x => x.UnitId == UnitId);
            return result?.ToUnitModel();
        }

        public UnitModel? GetByUnitCode(string UnitCode)
        {
            var result = _db.Unit.SingleOrDefault(x => x.UnitCode == UnitCode);
            return result?.ToUnitModel();
        }


        public int CreateUnit(UnitModel Unit)
        {
            var newUnit = Unit.ToUnit();
            _db.Unit.Add(newUnit);
            _db.SaveChanges();
            return newUnit.UnitId;
        }


        public void UpdateUnit(UnitModel Unit)
        {
            var existingUnit = _db.Unit
                .SingleOrDefault(x => x.UnitId == Unit.UnitId);

            if (existingUnit == null)
            {
                throw new ApplicationException($"Unit {Unit.UnitId} does not exist.");
            }
            Unit.ToUnit(existingUnit);

            _db.Update(existingUnit);
            _db.SaveChanges();
        }

        public void DeleteUnit(int UnitId)
        {
            var efModel = _db.Unit.Find(UnitId);
            _db.Unit.Remove(efModel);
            _db.SaveChanges();


        }

    }

}
