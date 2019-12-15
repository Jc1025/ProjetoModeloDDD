using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Transparencia.Data.Config;
using Transparencia.Domain.Interfaces.Generic;

namespace ProjetoTransparencia.Infra.Repository.Generic
{
	public class RepositoryGeneric<T> : IInterfaceGeneric<T>, IDisposable where T : class
	{

		private readonly DbContextOptionsBuilder<ContextBase> _OptionsBuilder;

		public RepositoryGeneric()
		{
			_OptionsBuilder = new DbContextOptionsBuilder<ContextBase>();
		}

		public void Add(T Entity)
		{
			using var banco = new ContextBase(_OptionsBuilder.Options);
			banco.Set<T>().Add(Entity);
			banco.SaveChanges();
		}

		public void Delete(T Entity)
		{
			using var banco = new ContextBase(_OptionsBuilder.Options);
			banco.Set<T>().Remove(Entity);
			banco.SaveChanges();
		}


		public T GetEntity(long id)
		{
			using var banco = new ContextBase(_OptionsBuilder.Options);
			return banco.Set<T>().Find(id);

		}

		public List<T> List()
		{
			using var banco = new ContextBase(_OptionsBuilder.Options);
			return banco.Set<T>().ToList();
		}

		public void Update(T Entity)
		{
			using var banco = new ContextBase(_OptionsBuilder.Options);
			banco.Set<T>().Update(Entity);
			banco.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		private void Dispose(bool isDisposed)
		{

			if (isDisposed)
			{
				return;
			}
		}
		~RepositoryGeneric()
		{
			Dispose(false);
		}

	}
}
