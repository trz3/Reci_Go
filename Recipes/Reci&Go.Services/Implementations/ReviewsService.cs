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
	public class ReviewsService : IServiceGeneric<Reviews>
	{

		private readonly IRepositoryGeneric<Reviews> _reviewsRepository = new ReviewsRepository();

		public ReviewsService(IRepositoryGeneric<Reviews> reviewsRepository)
		{
			_reviewsRepository = reviewsRepository;
		}

		public Reviews Create(Reviews review)
		{
			return _reviewsRepository.Create(review);
		}

		public bool Delete(int id)
		{
			_reviewsRepository.Delete(id);
			return true;
		}

		public IEnumerable<Reviews> GetAll()
		{
			return _reviewsRepository.GetAll();
		}

		public Reviews GetById(int id)
		{
			return _reviewsRepository.GetById(id);
		}

		public Reviews Update(Reviews review)
		{
			throw new NotImplementedException();
		}
	}
}
