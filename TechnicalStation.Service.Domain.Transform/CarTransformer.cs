namespace TechnicalStation.Service.Domain.Transform
{
    using TechnicalStation.Core.Domain.Car;
    using TechnicalStation.Service.Domain.Data;
    using TechnicalStation.Service.Domain.Transform.Base;

    public class CarTransformer : TransformerBase<Car, CarInfo> 
{
}
}