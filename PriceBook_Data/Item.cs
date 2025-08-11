using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PriceBook_Data
{
    public class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


        [NotMapped]
        public bool Found { get; set; }

        public Item()
        {

        }

        public void LoadCategory()
        {
            Category cat = new Category(this.CategoryId);
            this.Category = cat;
        }

        public Item(int id)
        {
            ApplicationContext context = new ApplicationContext();
            Item item;
            // This is an example of eager loading.
            item = context.Item.Include(c => c.Category).FirstOrDefault(i => i.Id == id);
            
            
            if (item == null) Found = false;
            else
            {
                Found = true;
                this.Id = item.Id;
                this.Name = item.Name;
                this.CategoryId = item.CategoryId;
            }

        }
        
        public void Add()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Item.Add(this);
                context.SaveChanges();
            }
        }

        public void SaveUpdate(bool doLoadCategory = false)
        {

            using (ApplicationContext context = new ApplicationContext())
            { 
                context.Item.Attach(this);
                if (context.Item.Any(i => i.Name == this.Name && i.Id != this.Id))
                    throw new InvalidOperationException("Duplicate item name.");
                context.SaveChanges();
            }
            if (doLoadCategory) LoadCategory();

        }

        public void Delete()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Item.Attach(this);
                context.Item.Remove(this);
                context.SaveChanges();
            }
        }

        
    }
}
