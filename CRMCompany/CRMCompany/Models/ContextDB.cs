using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{

    public class ContextDB : DbContext
    {
        public ContextDB()
            : base("DbConnection")
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<EntityModel> Enities { get; set; }
        public DbSet<ConterpartyModel> Conterparties { get; set; }
        public DbSet<WarhouseModel> Warhousies { get; set; }
        public DbSet<StoreModel> Stores { get; set; }
        public DbSet<CurrencyModel> Currency { get; set; }
        public DbSet<SellingsModel> Sellings { get; set; }
        public System.Data.Entity.DbSet<CRMCompany.Models.ShiftModel> ShiftModels { get; set; }
        public System.Data.Entity.DbSet<CRMCompany.Models.GoodModel> GoodModels { get; set; }
        public System.Data.Entity.DbSet<CRMCompany.Models.ReturnsModel> ReturnsModels { get; set; }
        public System.Data.Entity.DbSet<CRMCompany.Models.OrderInModel> OrderInModels { get; set; }
        public System.Data.Entity.DbSet<CRMCompany.Models.OrdersOutModel> OrdersOutModels { get; set; }
        public System.Data.Entity.DbSet<CRMCompany.Models.ReseiptModel> ReseiptModels { get; set; }

        public System.Data.Entity.DbSet<CRMCompany.Models.Shipment> Shipments { get; set; }

        public System.Data.Entity.DbSet<CRMCompany.Models.LossModel> LossModels { get; set; }
    }
}