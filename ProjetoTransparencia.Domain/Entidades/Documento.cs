using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transparencia.Domain.Entidades
{
	[Table("TB_DOCUMENTOS")]
	public class Documento
	{
		[Key]
		[Column("ID_DOCUMENTOS")]
		public long Id { get; set; }

		[Column("ID_TIPO_DOCUMENTOS ")]
		public long IdTipoDocumentos { get; set; }

		[Column("NOME_DOCUMENTO")]
		public string NomeDocumento { get; set; }

		[Column("DT_INCLUSAO")]
		public DateTime DtInclusao { get; set; }

		[Column("DOCUMENTO")]
		public byte[] ImagemDocumento { get; set; }

		[Column("NIVEL_PERMISSAO")]
		public long NivelPermissao { get; set; }

		[Column("NOME_USUARIO")]
		public string NomeUsuario { get; set; }
	}
}
