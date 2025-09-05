using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceBook_Data
{
    public class ItemCostRecord
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int StoreId { get; set; }

        public int UnitId { get; set; }

        public DateTime BuyDate { get; set; } = DateTime.Now;

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public Store Store { get; set; }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public Unit Unit { get; set; }

        public decimal Price { get; set; }

        [MaxLength(20)]
        public string Upc { get; set; }

        [MaxLength(100)]
        public string Brand { get; set; }

        [MaxLength]
        // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
        public string Notes { get; set; }

        [NotMapped]
        public bool Found { get; private set; }

        public ItemCostRecord()
        {

        }

        public ItemCostRecord(int id)
        {
            ApplicationContext context = new ApplicationContext();

            ItemCostRecord cr = context.ItemCostRecord.FirstOrDefault(i => i.Id == id);


            if (cr == null)
            {
                Found = false;
            }
            else
            {
                this.Id = cr.Id;
                this.Brand = cr.Brand;
                this.BuyDate = cr.BuyDate;
                this.ItemId = cr.ItemId;
                this.Notes = cr.Notes;
                this.Price = cr.Price;
                this.StoreId = cr.StoreId;
                this.UnitId = cr.UnitId;
                this.Upc = cr.Upc;
                Found = true;
            }

        }
        

        public void Add()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.ItemCostRecord.Add(this);
                context.SaveChanges();
            }
        }

        public void SaveUpdate()
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                context.ItemCostRecord.Attach(this);
                context.SaveChanges();
            }
            
        }

        public void Delete()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.ItemCostRecord.Attach(this);
                context.ItemCostRecord.Remove(this);
                context.SaveChanges();
            }
        }
    }
}
