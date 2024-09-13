namespace TechnicalStation.Core.Dto.Transform
{
    using TechnicalStation.Core.Domain.Order;
    using TechnicalStation.Core.Dto.Data;
    using TechnicalStation.Core.Dto.Transform.Base;

    public class OrderTransformer : TransformerBase<Order, OrderInfo> 
{
}
}