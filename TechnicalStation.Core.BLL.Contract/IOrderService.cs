using System;
using System.Collections.Generic;
using System.Text;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.BLL.Contract
{
    public interface IOrderService : IService<Order>
    {
    }
}
