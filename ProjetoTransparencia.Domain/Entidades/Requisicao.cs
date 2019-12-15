using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transparencia.Domain.Entidades
{
	[Table("TB_REQUISICAO")]
	public class Requisicao
	{
		[Key]
		[Column("ID_REQUISICAO")]
		public long Id { get; set; }

		[Column("ID_DOCUMENTO")]
		public long IdDocumento { get; set; }

		[Column("DOCUMENTO")]
		public string ImagemDocumento { get; set; }

		[Column("MENSAGEM")]
		public string Mensagem { get; set; }

		[Column("USUARIO")]
		public string Usuario { get; set; }
	}
}
