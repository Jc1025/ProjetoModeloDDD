using ProjetoTransparencia.Infra.Repository.Generic;
using Transparencia.Domain.Entidades;
using Transparencia.Domain.Interfaces.Documentos;

namespace ProjetoTransparencia.Infra.Repositoy.Documentos
{
	public class RepositorioDocumentos : RepositoryGeneric<Documento>, IDocumentos
	{
	}
}
