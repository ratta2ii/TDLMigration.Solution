using System.Collections.Generic;

namespace TDLMigration.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public ICollection<CategoryItem> CategoriesList { get;}
        
        public Item()
        {
            this.CategoriesList = new HashSet<CategoryItem>();
        }

     
    }
}