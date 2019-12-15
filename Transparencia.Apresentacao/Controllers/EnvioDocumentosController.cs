using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoTransparencia.Apresentacao.Models;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;

namespace Transparency.Controllers
{
	public class EnvioDocumentosController : Controller
	{
		
		private readonly IAppsUsuario AppUsuario;
		private readonly IAppsTipoDocumento AppTiposDocumento;
		private readonly IAppsPermissao AppPermissao;
		private readonly IAppsDocumento AppDocumento;

		public EnvioDocumentosController(IAppsUsuario appUsuario, IAppsTipoDocumento appTiposDocumento, IAppsPermissao appPermissao, IAppsDocumento appDocumento)
		{
			AppUsuario = appUsuario;
			AppTiposDocumento = appTiposDocumento;
			AppPermissao = appPermissao;
			AppDocumento = appDocumento;
		}

		public IActionResult EnvioDocumentos()
		{
			long UserId;

			HttpContext.Session.TryGetValue("idUsuario", out byte[] idUsuario);
			HttpContext.Session.TryGetValue("Usuario", out byte[] LoginUsuario);
			HttpContext.Session.TryGetValue("Imagem", out byte[] ImagemUsuario);


			UserId = Convert.ToInt64(Encoding.UTF8.GetString(idUsuario));

			ViewBag.Permissao = AppUsuario.GetEntity(UserId).IdPermissao;
			ViewBag.LoginUsuario = Encoding.UTF8.GetString(LoginUsuario);
			ViewBag.ImagemUsuario = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(ImagemUsuario));

			_ = new List<TipoDocumento>();
			_ = new List<Permissao>();

			List<TipoDocumento> ObjTipo = AppTiposDocumento.List();
			List<Permissao> ObjPermissoes = AppPermissao.List();

			var ViewModel = new DocumentosModel
			{
				TbPermissao = ObjPermissoes,
				TbTipoDocumentos = ObjTipo
			};

			ViewBag.Tipos = new SelectList(ObjTipo, "ID_TIPO_DOCUMENTOS", "TIPO_DOCUMENTO");
			ViewBag.Permissoes = new SelectList(ObjPermissoes, "ID_PERMISSAO", "NIVEL_PERMISSAO");

			return View(ViewModel);
		}

		[HttpPost]
		public IActionResult Gravar(DocumentosModel ObjDocumentoModel)
		{
			HttpContext.Session.TryGetValue("Usuario", out byte[] LoginUsuario);

			byte[] FileBytes = null;

			using (MemoryStream ms = new MemoryStream())

			{
				ObjDocumentoModel.File.OpenReadStream().CopyTo(ms);
				FileBytes = ms.ToArray();
			}

			Documento Documento = new Documento()
			{
				NomeUsuario = Encoding.UTF8.GetString(LoginUsuario),
				NivelPermissao = ObjDocumentoModel.NivelPermissao,
				DtInclusao = DateTime.Now,
				NomeDocumento = ObjDocumentoModel.File.FileName,
				ImagemDocumento = FileBytes,
				IdTipoDocumentos = ObjDocumentoModel.NivelPermissao,
			};

			AppDocumento.Add(Documento);

			return RedirectToAction("EnvioDocumentos");
			
		}
	}
}
