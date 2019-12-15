using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transparencia.Domain.Entidades
{
	[Table("TB_PERMISSOES")]
	public class Permissao
	{
		[Key]
		[Column("ID_PERMISSAO")]
		public long Id  { get; set; }

		[Column("NIVEL_PERMISSAO")]
		public string NivelPermissao { get; set; }

		[Column("FORCA_PERMISSAO")]
		public int ForcaPermissao  { get; set; }

	}
}
