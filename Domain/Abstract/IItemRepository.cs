using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IItemRepository
    {
        IEnumerable<Item> Items { get; }
        void SaveItem(Item item);
        Item DeleteItem(int itemId);
    }
}
