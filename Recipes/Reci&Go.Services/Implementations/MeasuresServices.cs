using Reci_Go.Models;
using Reci_Go.Repositories.Implementations;
using Reci_Go.Repositories.Interfaces;
using Reci_Go.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Services.Implementations
{
	public class MeasuresServices : IServiceGeneric<Measures>
	{
		private readonly IRepositoryGeneric<Measures> _measuresRepository = new MeasuresRepository();

		public MeasuresServices(IRepositoryGeneric<Measures> measureRepository)
		{
			_measuresRepository = measureRepository;
		}
		public Measures Create(Measures measures)
		{
			return _measuresRepository.Create(measures);	
		}

		public bool Delete(int id)
		{
			_measuresRepository.Delete(id);
			return true;
		}

		public IEnumerable<Measures> GetAll()
		{
			return _measuresRepository.GetAll();
		}

		public Measures GetById(int id)
		{
			return _measuresRepository.GetById(id);
		}

		public Measures Update(Measures measures)
		{
			throw new NotImplementedException();
		}
	}
}
