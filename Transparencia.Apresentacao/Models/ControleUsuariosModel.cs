using System.Collections.Generic;
using Transparencia.Domain.Entidades;

namespace ProjetoTransparencia.Apresentacao.Models
{
	public class ControleUsuariosModel
	{
		public List<Usuario> Usuarios { get; set; }
		public ICollection<Permissao> Permissao { get; set; }
	}
}
