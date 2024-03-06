using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.ViewModels
{
    public class ProductVM
    {
        public Product product { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
