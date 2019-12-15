using System.Collections.Generic;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;
using Transparencia.Domain.Interfaces.Usuarios;

namespace Transparencia.Application.Apps
{
	public class ApplicationUsuario : IAppsUsuario
	{
		readonly IUsuarios _IUsuarios;

		public ApplicationUsuario(IUsuarios iUsuarios)
		{
			_IUsuarios = iUsuarios;
		}

		public void Add(Usuario Entity)
		{
			_IUsuarios.Add(Entity);
		}

		public void Delete(Usuario Entity)
		{
			_IUsuarios.Delete(Entity);
		}

		public Usuario FindUserLogin(string Login, string Senha)
		{
			return _IUsuarios.FindUserLogin(Login, Senha);
		}

		public Usuario GetEntity(long id)
		{
			return _IUsuarios.GetEntity(id);
		}

		public List<Usuario> List()
		{
			return _IUsuarios.List();
		}

		public void Update(Usuario Entity)
		{
			_IUsuarios.Update(Entity);
		}
	}
}
