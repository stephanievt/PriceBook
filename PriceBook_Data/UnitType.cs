using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PriceBook_Data
{
    public class UnitType
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        // Getters and setter definitions need't be covered by dotcover
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
        public List<Unit> Units { get; set; }

        [NotMapped]
        public bool IsAttached { get; internal set; }

        public UnitType()
        {
        }

        public UnitType(string name)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                UnitType ut = context.UnitType.FirstOrDefault(t => t.Name == name);
                if (ut == null) return;
                this.Name = ut.Name;
                this.Id = ut.Id;
                this.IsAttached = true;

            }
        }

        public UnitType(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                UnitType ut = context.UnitType.FirstOrDefault(t => t.Id == id);
                if (ut == null) return;
                this.Name = ut.Name;
                this.Id = ut.Id;
                this.IsAttached = true;

            }
        }

        public void Add()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.UnitType.Add(this);
                context.SaveChanges();
            }
        }

        public void SaveUpdate()
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                context.UnitType.Attach(this);
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void Delete()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.UnitType.Attach(this);
                context.UnitType.Remove(this);
                context.SaveChanges();
            }
        }

        public bool Equals(UnitType compare)
        {
            if (this.Id != compare.Id) return false;
            if (this.Name != compare.Name) return false;
            return true;
        }

        public override string ToString()
        {
            
            return Name + " " + IsAttached.ToString();
        }
    }
}
