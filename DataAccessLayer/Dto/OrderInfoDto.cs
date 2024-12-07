using Vashishth_Backened._24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAL.Data.Dto
{
	public class OrderInfoDto
	{
		public Guid id { get; set; }

	
		public string deliveryTime { get; set; }
		
		public string orderTime { get; set; }
		
		public OrderStatus status { get; set; }
	
		public int price { get; set; }

	
	}
}
