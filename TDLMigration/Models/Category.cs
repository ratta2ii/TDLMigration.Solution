using System.Collections.Generic;

namespace TDLMigration.Models
{
  public class Category
    {
        public Category()
        {
            this.ItemsList = new HashSet<CategoryItem>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<CategoryItem> ItemsList { get; set; }
    }
}