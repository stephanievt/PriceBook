using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PriceBook_Data
{
    public class Store
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(10)]
        public string State { get; set; }

        [NotMapped]
        public bool IsAttached { get; internal set; }

        public Store()
        {

        }

        public Store(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Store store = context.Store.FirstOrDefault(i => i.Id == id);
                if (store == null) return;
                CurrentObjectValues(store);
            }
        }

        public Store(string name)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Store store = context.Store.FirstOrDefault(n => n.Name == name);
                CurrentObjectValues(store);
            }
        }

        public void Add()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Store.Add(this);
                context.SaveChanges();
            }
        }

        public void SaveUpdate()
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                context.Store.Attach(this);
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void Delete()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Store.Attach(this);
                context.Store.Remove(this);
                context.SaveChanges();
            }
        }

        public bool Equals(Store store)
        {
            if (this.Id != store.Id) return false;
            if (this.Name != store.Name) return false;
            if (this.Address != store.Address) return false;
            if (this.City != store.City) return false;
            if (this.State != store.State) return false;
            return true;
        }

        public override string ToString() => Name + " " + City + IsAttached;

        private void CurrentObjectValues(Store store)
        {
            this.Id = store.Id;
            this.Name = store.Name;
            this.Address = store.Address;
            this.City = store.City;
            this.State = store.State;
            this.IsAttached = true;
        }

        
    }


    
}
