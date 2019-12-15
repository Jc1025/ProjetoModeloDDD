using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transparencia.Domain.Entidades
{
	[Table("TB_USUARIOS")]
	public class Usuario
	{
		[Key]
		[Column("ID_USUARIO")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[Column("LOGIN_USUARIO")]
		public string LoginUsuario { get; set; }

		[Column("EMAIL_USUARIO")]
		public string EmailUsuario { get; set; }

		[Column("SENHA_USUARIO")]
		public string SenhaUsuario { get; set; }

		[Column("EMPRESA_USUARIO")]
		public string EmpresaUsuario { get; set; }

		[Column("DATA_NASCIMENTO")]
		public DateTime DataNascimento  { get; set; }

		[Column("IMAGEM")]
		public byte[] ImagemUsuario  { get; set; }

		[Column("ID_PERMISSAO")]
		public long IdPermissao { get; set; }
	}





}
