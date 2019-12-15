using System;
using System.Collections.Generic;
using System.Text;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;
using Transparencia.Domain.Interfaces.TiposDocumento;

namespace Transparencia.Application.Apps
{
	public class ApplicationTipoDocumento : IAppsTipoDocumento
	{

		ITiposDocumento _ITiposDocumento;

		public ApplicationTipoDocumento(ITiposDocumento iTiposDocumento)
		{
			_ITiposDocumento = iTiposDocumento;
		}

		public void Add(TipoDocumento Entity)
		{
			_ITiposDocumento.Add(Entity);
		}

		public void Delete(TipoDocumento Entity)
		{
			_ITiposDocumento.Delete(Entity);
		}

		public TipoDocumento GetEntity(long id)
		{
			return _ITiposDocumento.GetEntity(id);
		}

		public List<TipoDocumento> List()
		{
			return _ITiposDocumento.List();
		}

		public void Update(TipoDocumento Entity)
		{
			_ITiposDocumento.Update(Entity);
		}
	}
}
