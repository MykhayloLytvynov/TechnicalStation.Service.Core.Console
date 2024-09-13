namespace TechnicalStation.Service.Domain.Transform
{
    using TechnicalStation.Core.Domain.Customer;
    using TechnicalStation.Service.Domain.Data;
    using TechnicalStation.Service.Domain.Transform.Base;

    public class CustomerTransformer : TransformerBase<Customer, CustomerInfo> 
{
}
}