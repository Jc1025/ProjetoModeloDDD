using Microsoft.EntityFrameworkCore;
using System.Linq;
using ProjetoTransparencia.Infra.Repository.Generic;
using Transparencia.Data.Config;
using Transparencia.Domain.Entidades;
using Transparencia.Domain.Interfaces.Usuarios;

namespace ProjetoTransparencia.Infra.Repository.Usuarios
{
	public class RepositorioUsuarios : RepositoryGeneric<Usuario>, IUsuarios
	{

		private readonly DbContextOptionsBuilder<ContextBase> _OptionsBuilder;

		public RepositorioUsuarios()
		{
			_OptionsBuilder = new DbContextOptionsBuilder<ContextBase>();
		}

		public Usuario FindUserLogin(string Login, string Senha)
		{
			using var Usuario = new ContextBase(_OptionsBuilder.Options);
			return Usuario.Set<Usuario>().FirstOrDefault(x => x.LoginUsuario == Login && x.SenhaUsuario == Senha);
		}
	}
}
