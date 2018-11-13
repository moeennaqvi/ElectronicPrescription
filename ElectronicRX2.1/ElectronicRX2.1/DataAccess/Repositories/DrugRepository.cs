using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class DrugRepository : Repository<Drug>
    {
        PrescriptionsDbContext _context;
        public DrugRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Drug> GetAllUsingDrugName(string drugName)
        {
            return _context.Drugs.Where(p => p.DrugName.Contains(drugName)).ToList<Drug>();
        }

        public List<Drug> GetAllUsingManufacturerName(string companyName)
        {
            return _context.Drugs.Where(p => p.PharmaceuticalFirm.PharmaceuticalFirmName == companyName).ToList<Drug>();
        }

        public List<Drug> GetAllUsingIngredient(string name)
        {
            return _context.Drugs.Where(p => p.ActiveIngredient.Contains(name)).ToList<Drug>();
        }

        public int GetNumofDrugs()
        {
            return _context.Set<Drug>().Count();
        }
    }
}