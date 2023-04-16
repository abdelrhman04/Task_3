using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Categories? ParentCategory { get; set; }
        public virtual ICollection<Categories>? ChildCategories { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
