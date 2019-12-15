using System;
using System.Collections.Generic;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;
using Transparencia.Domain.Interfaces.Requisicoes;

namespace Transparencia.Application.Apps
{
	public class ApplicationRequisicao : IAppsRequisicao
	{
		readonly IRequisicoes _IRequisicao;

		public ApplicationRequisicao(IRequisicoes iRequisicao)
		{
			_IRequisicao = iRequisicao;
		}

		public void Add(Requisicao Entity)
		{
			_IRequisicao.Add(Entity);
		}

		public void Delete(Requisicao Entity)
		{
			_IRequisicao.Delete(Entity);
		}

		public Requisicao GetEntity(long id)
		{
			return _IRequisicao.GetEntity(id);
		}

		public List<Requisicao> List()
		{
			return _IRequisicao.List();
		}

		public void Update(Requisicao Entity)
		{
			_IRequisicao.Update(Entity);
		}
	}
}
