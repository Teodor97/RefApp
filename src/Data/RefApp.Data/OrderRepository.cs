using Microsoft.EntityFrameworkCore;
using RefApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefApp.Data
{
    public class OrderRepository:IOrderRepository
    { 
        private readonly RefAppContext context;

        public OrderRepository(RefAppContext context)
        {
            this.context = context;
        }

        IQueryable<Order> IOrderRepository.Orders => this.context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
