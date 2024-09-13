namespace TechnicalStation.Core.Dto.Transform
{
    using TechnicalStation.Core.Domain.Car;
    using TechnicalStation.Core.Dto.Data;
    using TechnicalStation.Core.Dto.Transform.Base;

    public class CarTransformer : TransformerBase<Car, CarInfo> 
{
}
}