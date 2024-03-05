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
	public class RatingsService : IServiceGeneric<Ratings>
	{
		private readonly IRepositoryGeneric<Ratings> _ratingsRepository = new RatingsRepository();

		public RatingsService(IRepositoryGeneric<Ratings> ratingsRepository)
		{
			_ratingsRepository = ratingsRepository;
		}

		public Ratings Create(Ratings rating)
		{
			return _ratingsRepository.Create(rating);
		}

		public bool Delete(int id)
		{
			_ratingsRepository.Delete(id);
			return true;
		}

		public IEnumerable<Ratings> GetAll()
		{
			return _ratingsRepository.GetAll();
		}

		public Ratings GetById(int id)
		{
			return _ratingsRepository.GetById(id);
		}

		public Ratings Update(Ratings rating)
		{
			throw new NotImplementedException();
		}
	}
}
