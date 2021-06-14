using APIDapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Repository
{
    public interface ICargoRepository
    {
        public IEnumerable<CargoModel> GetCargo();
    }
}
