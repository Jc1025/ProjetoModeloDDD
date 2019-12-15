using System;
using System.Collections.Generic;
using System.Text;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;
using Transparencia.Domain.Interfaces.Permissoes;

namespace Transparencia.Application.Apps
{
	public class ApplicationPermissao : IAppsPermissao
	{
		readonly IPermissoes _IPermissoes;

		public ApplicationPermissao(IPermissoes iPermissoes)
		{
			_IPermissoes = iPermissoes;
		}

		public void Add(Permissao Entity)
		{
			_IPermissoes.Add(Entity);
		}

		public void Delete(Permissao Entity)
		{
			_IPermissoes.Delete(Entity);
		}

		public Permissao GetEntity(long id)
		{
			return _IPermissoes.GetEntity(id);
		}

		public List<Permissao> List()
		{
			return _IPermissoes.List();
		}

		public void Update(Permissao Entity)
		{
			_IPermissoes.Update(Entity);
		}
	}
}
