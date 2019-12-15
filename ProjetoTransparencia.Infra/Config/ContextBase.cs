using Microsoft.EntityFrameworkCore;
using Transparencia.Domain.Entidades;

namespace Transparencia.Data.Config
{
	public partial class ContextBase : DbContext
	{

		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<Documento> Documento { get; set; }
		public DbSet<Permissao> Permissao { get; set; }
		public DbSet<Requisicao> Requisicao { get; set; }
		public DbSet<TipoDocumento> TipoDocumento { get; set; }

		public ContextBase(DbContextOptions<ContextBase> options) : base(options)
		{

		}

				
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(StrConnConfig());
			}

		}

		

		private string StrConnConfig()
		{
			string StrConn = "data source = PCDOJU\\SQLEXPRESS01; initial catalog = Transparencia; persist security info = True; Integrated Security = SSPI;";

			return StrConn;

		}
	}
}




