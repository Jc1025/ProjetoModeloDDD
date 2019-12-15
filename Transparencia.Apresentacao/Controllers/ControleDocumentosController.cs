using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ProjetoTransparencia.Apresentacao.Models;
using Transparencia.Application.Interfaces;

namespace ProjetoTransparencia.Apresentacao.Controllers
{
	public class ControleDocumentosController : Controller
	{
		
		private readonly IAppsDocumento AppDocumento;
		private readonly IAppsUsuario AppUsuario;
		private readonly IAppsPermissao AppPermissao;

		public ControleDocumentosController(IAppsDocumento appDocumento, IAppsUsuario appUsuario, IAppsPermissao appPermissao)
		{
			AppDocumento = appDocumento;
			AppUsuario = appUsuario;
			AppPermissao = appPermissao;
		}

		public IActionResult ControleDocumentos()
		{
			string LoginUser;
			long UserId;

			HttpContext.Session.TryGetValue("idUsuario", out byte[] idUsuario);
			HttpContext.Session.TryGetValue("Usuario", out byte[] LoginUsuario);
			HttpContext.Session.TryGetValue("Imagem", out byte[] ImagemUsuario);

			LoginUser = Encoding.UTF8.GetString(LoginUsuario);

			UserId = Convert.ToInt64(Encoding.UTF8.GetString(idUsuario));

			ViewBag.Permissao = AppUsuario.GetEntity(UserId).IdPermissao;
			ViewBag.LoginUsuario = LoginUser;
			ViewBag.ImagemUsuario = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(ImagemUsuario));

			ControleDocumentosModel viewModel = new ControleDocumentosModel
			{
				ObjDocumentos = AppDocumento.List(),
				Permissao = AppPermissao.List()
			};

			return View(viewModel);
		}


		[HttpPost]
		public IActionResult Editar(ControleDocumentosModel ObjControleDocumentosModel)
		{

			foreach (var Documento in ObjControleDocumentosModel.ObjDocumentos)
			{
				AppDocumento.Update(Documento);
			}
			return RedirectToAction("ControleDocumentos");
		}
	}
}