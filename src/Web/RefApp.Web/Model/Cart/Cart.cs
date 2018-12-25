using RefApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefApp.Web.Model.Cart
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            var cart = lineCollection.Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (cart == null)
            {
                lineCollection.Add(
                    new CartLine
                    {
                        Product = product,
                        Quantity = quantity
                    });
            }
            else
            {
                cart.Quantity += quantity;
            }
        }

        public virtual void ClearCart()
        {
            this.lineCollection.Clear();
        }

        public virtual decimal ComputeTotalValue()
        {
            decimal totalSum = lineCollection.Sum(x => x.Product.Price * x.Quantity);
            return totalSum;
        }

        public virtual void RemoveLine(Product product)
        {
            this.lineCollection.RemoveAll(p => p.Product.Id == product.Id);
        }

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
}
