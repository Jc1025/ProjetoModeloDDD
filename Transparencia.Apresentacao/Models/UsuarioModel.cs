using System.Collections.Generic;
using Transparencia.Domain.Entidades;

namespace ProjetoTransparencia.Apresentacao.Models
{
	public class UsuarioModel
	{
		public Usuario Usuario { get; set; }
		public ICollection<Permissao> Permissao { get; set; }
		public string Imagem { get; set; }

	}
}
