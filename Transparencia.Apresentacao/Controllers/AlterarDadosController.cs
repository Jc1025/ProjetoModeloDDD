using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTransparencia.Apresentacao.Models;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;


namespace Transparency.Controllers
{
	public class AlterarDadosController : Controller
	{

		private readonly IAppsPermissao AppPermissao;
		private readonly IAppsUsuario AppUsuario;

		public AlterarDadosController(IAppsPermissao appPermissao, IAppsUsuario appUsuario)
		{
			AppPermissao = appPermissao;
			AppUsuario = appUsuario;
		}

		public IActionResult AlterarDados()
		{

			string LoginUser;
			long IdUser;

			HttpContext.Session.TryGetValue("idUsuario", out byte[] IdUsuario);
			HttpContext.Session.TryGetValue("Usuario", out byte[] LoginUsuario);
			HttpContext.Session.TryGetValue("Imagem", out byte[] ImagemUsuario);

			IdUser = Convert.ToInt64(Encoding.UTF8.GetString(IdUsuario));
			LoginUser = Encoding.UTF8.GetString(LoginUsuario);

			ViewBag.Permissao = AppUsuario.GetEntity(IdUser).IdPermissao;
			ViewBag.LoginUsuario = LoginUser;
			ViewBag.ImagemUsuario = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(ImagemUsuario));

			var Usuario = AppUsuario.GetEntity(IdUser);
			var Permissoes = AppPermissao.List();

			var viewModel = new UsuarioModel
			{
				Imagem = Convert.ToBase64String(Usuario.ImagemUsuario),
				Usuario = Usuario,
				Permissao = Permissoes
			};
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Editar(UsuarioModel ObjUsuarioModal)
		{
			AppUsuario.Update(ObjUsuarioModal.Usuario);

			var Usuario = AppUsuario.GetEntity(ObjUsuarioModal.Usuario.Id) ;

			HttpContext.Session.Set("Imagem", Usuario.ImagemUsuario);

			return RedirectToAction("AlterarDados");
		}


	}
}