using System.Collections.Generic;

namespace Transparencia.Application.Interfaces
{
	public interface IAppsGeneric<T> where T : class
	{
		void Add(T Entity);
		void Update(T Entity);
		void Delete(T Entity);
		T GetEntity(long id);
		List<T> List();
	}
}
