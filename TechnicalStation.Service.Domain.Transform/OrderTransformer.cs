namespace TechnicalStation.Service.Domain.Transform
{
    using TechnicalStation.Core.Domain.Order;
    using TechnicalStation.Service.Domain.Data;
    using TechnicalStation.Service.Domain.Transform.Base;

    public class OrderTransformer : TransformerBase<Order, OrderInfo> 
{
}
}