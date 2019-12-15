using System.Collections.Generic;
using Transparencia.Domain.Entidades;

namespace ProjetoTransparencia.Apresentacao.Models
{
	public class ControleDocumentosModel
	{
		public List<Documento> ObjDocumentos { get; set; }

		public ICollection<Permissao> Permissao { get; set; }

	}
}
