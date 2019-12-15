using Transparencia.Domain.Entidades;
using Transparencia.Domain.Interfaces.Generic;

namespace Transparencia.Domain.Interfaces.Usuarios
{
	public interface IUsuarios : IInterfaceGeneric<Usuario>
	{
		Usuario FindUserLogin(string Login, string Senha);

	}
}
