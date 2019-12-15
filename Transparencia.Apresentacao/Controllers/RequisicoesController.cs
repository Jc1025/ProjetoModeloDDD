using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Transparencia.Application.Interfaces;

namespace Transparency.Controllers
{
	public class RequisicoesController : Controller
    {

		private readonly IAppsUsuario AppUsuario;
		private readonly IAppsPermissao AppPermissao;
		private readonly IAppsRequisicao AppRequisicao;

		public RequisicoesController(IAppsUsuario appUsuario, IAppsPermissao appPermissao, IAppsRequisicao appRequisicao)
		{
			AppUsuario = appUsuario;
			AppPermissao = appPermissao;
			AppRequisicao = appRequisicao;
		}

		public IActionResult Requisicoes()
        {

			long UserId;


			HttpContext.Session.TryGetValue("idUsuario", out byte[] idUsuario);
			HttpContext.Session.TryGetValue("Usuario", out byte[] LoginUsuario);
			HttpContext.Session.TryGetValue("Imagem", out byte[] ImagemUsuario);

			UserId = Convert.ToInt64(Encoding.UTF8.GetString(idUsuario));

			ViewBag.Permissao = AppUsuario.GetEntity(UserId).IdPermissao;
			ViewBag.LoginUsuario = Encoding.UTF8.GetString(LoginUsuario);
			ViewBag.ImagemUsuario = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(ImagemUsuario));

            return View(AppRequisicao.List());
        }
    }
}