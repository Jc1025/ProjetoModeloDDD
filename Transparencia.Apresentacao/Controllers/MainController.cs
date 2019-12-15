using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjetoTransparencia.Apresentacao.Models;
using Transparencia.Application.Interfaces;
using Transparencia.Domain.Entidades;

namespace Transparency.Controllers
{
	public class MainController : Controller
	{
		private readonly IAppsUsuario AppUsuario;
		private readonly IAppsPermissao AppPermissao;
		private readonly IAppsDocumento AppDocumento;
		private readonly IAppsTipoDocumento AppTiposDocumento;
		private readonly IAppsRequisicao AppRequisicao;

		public MainController(IAppsUsuario appUsuario, IAppsPermissao appPermissao, IAppsDocumento appDocumento, IAppsTipoDocumento appTiposDocumento, IAppsRequisicao appRequisicao)
		{
			AppUsuario = appUsuario;
			AppPermissao = appPermissao;
			AppDocumento = appDocumento;
			AppTiposDocumento = appTiposDocumento;
			AppRequisicao = appRequisicao;
		}

		public IActionResult Main()
		{

			long UserId;

			HttpContext.Session.TryGetValue("idUsuario", out byte[] idUsuario);
			HttpContext.Session.TryGetValue("Usuario", out byte[] LoginUsuario);
			HttpContext.Session.TryGetValue("Imagem", out byte[] ImagemUsuario);

			UserId = Convert.ToInt64(Encoding.UTF8.GetString(idUsuario));

			ViewBag.Permissao = AppUsuario.GetEntity(UserId).IdPermissao;
			ViewBag.LoginUsuario = Encoding.UTF8.GetString(LoginUsuario);
			ViewBag.ImagemUsuario = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(ImagemUsuario));


			MainViewModel viewModel = new MainViewModel
			{
				ObjDocumentos = AppDocumento.List(),
				ObjPermissoes = AppPermissao.List(),
				ObjTipos = AppTiposDocumento.List(),
				Requisicao = AppRequisicao.GetEntity(1)
				
			};

			return View(viewModel);
		}

		public IActionResult Sair()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login", "Login");
		}



		public IActionResult Excluir(long id)
		{
			AppDocumento.Delete(AppDocumento.GetEntity(id));
			return RedirectToAction("Main");
		}

		[HttpPost]
		public object DowloadFile()
		{
			JObject JIformacao;
			string Body;
			long PermissaoDocumento;
			int ForcaUsuario;
			int ForcaDocumento;


			using (StreamReader stream = new StreamReader(Request.Body))
			{
				Body = stream.ReadToEndAsync().Result;
			}

			JIformacao = JObject.Parse(Body);


			long id = Convert.ToInt32(JIformacao.SelectToken("id"));

			PermissaoDocumento = AppPermissao.GetEntity(id).Id;


			var Usuario = AppUsuario.GetEntity(id);

			ForcaUsuario = AppPermissao.GetEntity(Usuario.IdPermissao).ForcaPermissao;
			ForcaDocumento = AppPermissao.GetEntity(PermissaoDocumento).ForcaPermissao;



			if (ForcaUsuario >= ForcaDocumento)
			{
				var documento = AppDocumento.GetEntity(id);

				string DocumentoInfor = documento.NomeDocumento + "|" + Convert.ToBase64String(documento.ImagemDocumento);
				return DocumentoInfor;
			}

			else
			{
				return id;
			}
		}


		[HttpPost]
		public IActionResult Requisitar(MainViewModel ObjMainViewModel)
		{

			long UserId;
			HttpContext.Session.TryGetValue("idUsuario", out byte[] idUsuario);

			UserId = Convert.ToInt64(Encoding.UTF8.GetString(idUsuario));

						
			Requisicao ObjTbRequisicao = new Requisicao
			{
				IdDocumento = ObjMainViewModel.Requisicao.IdDocumento,
				Mensagem = ObjMainViewModel.Requisicao.Mensagem,
				Usuario = AppUsuario.GetEntity(UserId).LoginUsuario,
				ImagemDocumento = AppDocumento.GetEntity(ObjMainViewModel.Requisicao.IdDocumento).NomeDocumento
				
			};

			AppRequisicao.Add(ObjTbRequisicao);
			return RedirectToAction("Main");
		}

	}
}