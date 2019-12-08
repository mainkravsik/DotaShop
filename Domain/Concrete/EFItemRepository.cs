using System.Collections.Generic;
using Domain.Entities;
using Domain.Abstract;

namespace Domain.Concrete
{
    public class EFItemRepository : IItemRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Item> Items
        {
            get { return context.Items; }
        }
        public void SaveItem(Item item)
        {
            if (item.ItemId == 0)
                context.Items.Add(item);
            else
            {
                Item dbEntry = context.Items.Find(item.ItemId);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Description = item.Description;
                    dbEntry.Price = item.Price;
                    dbEntry.Category = item.Category;
                    dbEntry.ImageData = item.ImageData;
                    dbEntry.ImageMimeType = item.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Item DeleteItem(int itemId)
        {
            Item dbEntry = context.Items.Find(itemId);
            if (dbEntry != null)
            {
                context.Items.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}