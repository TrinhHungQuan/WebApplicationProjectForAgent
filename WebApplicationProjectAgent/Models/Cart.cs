using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProjectAgent.Models
{
    public class CartItem
    {
        public Good order_product { get; set; }
        public int order_quantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items  = new List<CartItem>();
        public IEnumerable<CartItem> Items { 
            get {  return items; } 
        }

        public void Add(Good _pro, int quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.order_product.GoodsID == _pro.GoodsID);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    order_product = _pro,
                    order_quantity= quantity
                }) ;
            }
            else
            {
                item.order_quantity += quantity;
            }
        }

        public void Update_Quantity_Order(string id, int quantity) 
        {
            var item = items.Find(s=>s.order_product.GoodsID == id);
            if (item != null)
            {
                item.order_quantity = quantity;
            }
        }

        public int Total_Money()
        {
            var total = items.Sum(s => s.order_product.Selling_Price * s.order_quantity);
            return (int)total;
        }

        public void Remove_Cart_Item(string id)
        {
            items.RemoveAll(s=>s.order_product.GoodsID==id);
        }

        public void ClearCart()
        {
            items.Clear();
        }
    }
}