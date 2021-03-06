﻿using RefApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefApp.Data
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
