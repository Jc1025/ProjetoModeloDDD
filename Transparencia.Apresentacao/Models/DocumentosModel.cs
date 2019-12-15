using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Transparencia.Domain.Entidades;

namespace ProjetoTransparencia.Apresentacao.Models
{
	public class DocumentosModel
	{
		
		public IFormFile File { get; set; }

		public ICollection<Permissao> TbPermissao { get; set; }

		public ICollection<TipoDocumento> TbTipoDocumentos { get; set; }

		public long NivelPermissao { get; set; }
		public long TipoDocumento { get; set; }



	}
}
