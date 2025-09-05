using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
// ReSharper disable EntityFramework.NPlusOne.IncompleteDataQuery
// ReSharper disable EntityFramework.NPlusOne.IncompleteDataUsage

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()

namespace PriceBook_Data
{
    public class Category
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(70)]
        public string Name { get; set; }

        
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public List<Item> Items { get; set; }

        public bool Watch { get; set; }
        
        [NotMapped]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal bool IsAttached { get; set; }

        public Category()
        {

        }

        public Category(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var cat = context.Category
                    .FirstOrDefault(i => i.Id == id);
                if (cat == null) throw new ApplicationException("No Category with that Id Exists.");
                this.Id = cat.Id;
                this.Name = cat.Name;
                this.IsAttached = true;
            }
        }

        

        public void Add()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Category.Add(this);
                context.SaveChanges();
            }
        }

        public void Delete()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Category.Attach(this);
                context.Category.Remove(this);
                context.SaveChanges();
            }

        }

        public void SaveUpdate(bool modified = false)
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                context.Category.Attach(this);
                if (modified) context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        public bool Equals(Category compare)
        {
            if (this.Id != compare.Id) return false;
            if (this.Name != compare.Name) return false;
            if (this.Watch != compare.Watch) return false;
            return true;
        }

    }
}
