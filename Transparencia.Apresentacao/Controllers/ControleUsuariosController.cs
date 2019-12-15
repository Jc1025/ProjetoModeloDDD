using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ProjetoTransparencia.Apresentacao.Models;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;

namespace Transparency.Controllers
{
	public class ControleUsuariosController : Controller
	{

		private readonly IAppsUsuario AppUsuario;
		private readonly IAppsPermissao AppPermissao;

		public ControleUsuariosController(IAppsUsuario appUsuario, IAppsPermissao appPermissao)
		{
			AppUsuario = appUsuario;
			AppPermissao = appPermissao;
		}

		public IActionResult ControleUsuarios()
		{
			string LoginUser;
			long IdUser;

			HttpContext.Session.TryGetValue("idUsuario", out byte[] IdUsuario);
			HttpContext.Session.TryGetValue("Usuario", out byte[] LoginUsuario);
			HttpContext.Session.TryGetValue("Imagem", out byte[] ImagemUsuario);

			LoginUser = Encoding.UTF8.GetString(LoginUsuario);
			IdUser = Convert.ToInt64(Encoding.UTF8.GetString(IdUsuario));

			ViewBag.Permissao = AppUsuario.GetEntity(IdUser).IdPermissao;
			ViewBag.LoginUsuario = LoginUser;
			ViewBag.ImagemUsuario = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(ImagemUsuario));

			var viewModel = new ControleUsuariosModel
			{
				Usuarios = AppUsuario.List(),
				Permissao = AppPermissao.List()
			};
			return View(viewModel);
		}


		[HttpPost]
		public IActionResult Editar(ControleUsuariosModel ObjControleUsuariosModel)
		{
			foreach (var Usuario in ObjControleUsuariosModel.Usuarios)
			{
				AppUsuario.Update(Usuario);
			}

			return RedirectToAction("ControleUsuarios");
		}
	}
}