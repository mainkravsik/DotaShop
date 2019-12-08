using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Models
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}