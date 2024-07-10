using EFcoreProjectHomeTask.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreProjectHomeTask.Models.Concretes
{
	public  class Product:BaseEntity
	{
        public string Name { get; set; }
        public string Desc { get; set; }    
        public int Category_Id { get; set; }
        public Decimal Price { get; set; }
		public Category Category { get; set; }
	}
}
