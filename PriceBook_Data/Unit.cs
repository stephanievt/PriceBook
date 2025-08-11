using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PriceBook_Data
{
    public class Unit
    {

        public int Id { get; set; }

        
        public int UnitTypeId { get; set; }


        public UnitType UnitType { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }


        public bool DefaultForType { get; set; }

        public Unit()
        {

        }

        public Unit(string name)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Unit unit = context.Unit.FirstOrDefault(n => n.Name == name);
                UnitType unitType = new UnitType(unit.UnitTypeId);

                this.UnitType = unitType;
                this.Id = unit.Id;
                this.UnitTypeId = unit.UnitTypeId;
                this.DefaultForType = unit.DefaultForType;
                this.Name = unit.Name;
            }


        }

        public Unit(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {

                Unit unit = context.Unit.Find(id);
                UnitType unitType = context.UnitType.Find(unit.UnitTypeId);

                this.UnitType = unitType;
                this.Id = id;
                this.UnitTypeId = unit.UnitTypeId;
                this.DefaultForType = unit.DefaultForType;
                this.Name = unit.Name;


            }
        }

        public void Add()
        {
            using ApplicationContext context = new ApplicationContext();
            context.Entry(UnitType).State = EntityState.Unchanged;
            context.Unit.Add(this);
            context.SaveChanges();
        }

        public void SaveUpdate()
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                context.Unit.Attach(this);
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void Delete()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Unit.Attach(this);
                context.Unit.Remove(this);
                context.SaveChanges();
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Id: " + Id);
            builder.AppendLine("Name: " + Name);
            builder.AppendLine("Default for type: " + DefaultForType);
            builder.AppendLine("Unit type:" + UnitType.Name);

            return builder.ToString();
        }

        public bool Equals(Unit compare)
        {
            if (this.DefaultForType != compare.DefaultForType) return false;
            if (this.Id != compare.Id) return false;
            if (this.Name != compare.Name) return false;
            if (this.UnitTypeId != compare.UnitTypeId) return false;
            return true;
        }
    }
}
