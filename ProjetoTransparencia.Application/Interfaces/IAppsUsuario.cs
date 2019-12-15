using Transparencia.Domain.Entidades;

namespace Transparencia.Application.Interfaces
{
	public interface IAppsUsuario : IAppsGeneric<Usuario>
	{
		Usuario FindUserLogin(string Login, string Senha);
	}
}
