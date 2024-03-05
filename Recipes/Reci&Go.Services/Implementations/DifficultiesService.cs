using Reci_Go.Models;
using Reci_Go.Repositories.Interfaces;
using Reci_Go.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reci_Go.Repositories.Implementations;
using Reci_Go.Repositories.Interfaces;

namespace Reci_Go.Services.Implementations
{
	public class DifficultiesService : IServiceGeneric<Difficulties>
	{

		private readonly IRepositoryGeneric<Difficulties> _difficultiesRepository = new DifficultiesRepository();

		public DifficultiesService(IRepositoryGeneric<Difficulties> difficultiesRepository) 
		{
			_difficultiesRepository = difficultiesRepository;
		}

		public Difficulties Create(Difficulties difficulty)
		{
			return _difficultiesRepository.Create(difficulty);
		}

		public bool Delete(int id)
		{
			_difficultiesRepository.Delete(id);
			return true;
		}

		public IEnumerable<Difficulties> GetAll()
		{
			return _difficultiesRepository.GetAll();
		}

		public Difficulties GetById(int id)
		{
			return _difficultiesRepository.GetById(id);
		}

		public Difficulties Update(Difficulties difficulty)
		{
			throw new NotImplementedException();
		}
	}
}
