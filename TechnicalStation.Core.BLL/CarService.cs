using Common.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Car;

namespace TechnicalStation.Core.BLL
{
    public class CarService : ServiceBase<Car>, ICarService
    {
        private ICarRepository carRepository;

        public CarService(ICarRepository carRepository) : base(carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task<Car> AddAsync(Car car)
        {
            await this.carRepository.AddAsync(car);
            Car result = await this.carRepository.GetByIdAsync(car.Id);
            car.AddCar(car.Id, car.CustomerId, car.Producer, car.Model, car.Color, car.Number, car.Year);
            await PublishEvents(car.Events);
            
            return result;
        }

        public async Task<Car> UpdateAsync(Car car)
        {
            Car oldValuesCar = await this.carRepository.GetByIdAsync(car.Id);
            //await this.carRepository.UpdateAsync(car);
            //Car newValuesCar = await this.carRepository.GetByIdAsync(car.Id);

            car.UpdateCar(oldValuesCar.CustomerId,oldValuesCar.Producer, car.Producer,
                oldValuesCar.Model, car.Model, oldValuesCar.Color, 
                car.Color,oldValuesCar.Number, car.Number, oldValuesCar.Year, car.Year);
            await PublishEvents(car.Events);
            

            return car;
        }

        public async Task RemoveAsync(int carId)
        {
            Car carToRemove = await this.carRepository.GetByIdAsync(carId);
            carToRemove.DeleteCar();
            await this.carRepository.DeleteAsync(carId);
            await PublishEvents(carToRemove.Events);
        }

        protected async Task PublishEvents(IEnumerable<IDomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                await Dispatcher.Instance.DispatchAsync(domainEvent);
            }
        }
    }
}
