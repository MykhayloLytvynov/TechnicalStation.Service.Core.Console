using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.DAL.Contract
{
    public interface IRepositoryFactory
    {
        T Create<T>();
    }
}
