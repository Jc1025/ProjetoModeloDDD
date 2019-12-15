using System.Collections.Generic;
using Transparencia.Domain.Entidades;

namespace ProjetoTransparencia.Apresentacao.Models
{
	public class MainViewModel
	{
		public List<Documento> ObjDocumentos { get; set; }

		public List<Permissao> ObjPermissoes { get; set; }

		public List<TipoDocumento> ObjTipos { get; set; }

		public Requisicao Requisicao { get; set; }

	}
}
