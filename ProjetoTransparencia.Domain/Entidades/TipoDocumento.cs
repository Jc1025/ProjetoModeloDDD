using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transparencia.Domain.Entidades
{
	[Table("TB_TIPO_DOCUMENTOS")]
	public class TipoDocumento
	{
		[Key]
		[Column("ID_TIPO_DOCUMENTOS")]
		public long Id  { get; set; }

		[Column("TIPO_DOCUMENTO")]
		public string Tipo { get; set; }

	}
}
