using System.Collections.Generic;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;
using Transparencia.Domain.Interfaces.Documentos;

namespace Transparencia.Application.Apps
{
	public class ApplicationDocumento : IAppsDocumento
	{
		readonly IDocumentos _IDocumento;
		public ApplicationDocumento(IDocumentos iDocumento)
		{
			_IDocumento = iDocumento;
		}
		public void Add(Documento Entity)
		{
			_IDocumento.Add(Entity);
		}
		public void Delete(Documento Entity)
		{
			_IDocumento.Delete(Entity);
		}
		public Documento GetEntity(long id)
		{
			return _IDocumento.GetEntity(id);
		}
		public List<Documento> List()
		{
			return _IDocumento.List();
		}

		public void Update(Documento Entity)
		{
			_IDocumento.Update(Entity);
		}
	}
}
