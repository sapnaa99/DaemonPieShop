using DaemonPieShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonPieShop.Data.Interface
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
