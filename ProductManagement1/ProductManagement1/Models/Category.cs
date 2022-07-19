using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public Category(int Id, string CategoryName,int Status)
        {
            this.Id = Id;
            this.CategoryName = CategoryName;
            this.Status = Status;
        }

        public Category()
        {
        }
    }
}
