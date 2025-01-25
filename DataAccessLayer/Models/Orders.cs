using System.ComponentModel.DataAnnotations;

namespace Vashishth_Backened._24.Models
{

    public class Orders
    {
        public Guid Id {get; set;}
        public string deliveryTime {get; set;}
        public string OrderTime {get; set;}
        public OrderStatus status {get; set;}
        public int price {get; set;}
        public string address {get; set;}
        public string userId{get; set;}

    }
}