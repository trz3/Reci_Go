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
	public class FavouritesService : IServiceGeneric<Favourites>
	{

		private readonly IRepositoryGeneric<Favourites> _favouritesRepository = new FavouritesRepository();

		public FavouritesService(IRepositoryGeneric<Favourites> favouritesRepository)
		{
			_favouritesRepository = favouritesRepository;
		}

		public Favourites Create(Favourites favourite)
		{
			return _favouritesRepository.Create(favourite);
		}

		public bool Delete(int id)
		{
			_favouritesRepository.Delete(id);
			return true;
		}

		public IEnumerable<Favourites> GetAll()
		{
			return _favouritesRepository.GetAll();
		}

		public Favourites GetById(int id)
		{
			return _favouritesRepository.GetById(id);
		}

		public Favourites Update(Favourites favourite)
		{
			throw new NotImplementedException();
		}
	}
}
