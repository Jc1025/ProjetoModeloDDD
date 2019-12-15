using System;
using System.Collections.Generic;

namespace Transparencia.Domain.Interfaces.Generic
{
	public interface IInterfaceGeneric<T> where T: class
	{

		void Add(T Entity);
		void Update(T Entity);
		void Delete(T Entity);
		T GetEntity(long id);
		List<T> List();

	}
}
