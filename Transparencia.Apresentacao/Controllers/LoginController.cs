using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Transparencia.Domain.Interfaces.Usuarios;
using Transparencia.Domain.Entidades;
using Newtonsoft.Json.Linq;

namespace Transparency.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUsuarios AppUsuarios;

		public LoginController(IUsuarios appUsuarios)
		{
			AppUsuarios = appUsuarios;
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(Usuario ObjUsuario)
		{
			string UserLogin;
			string UserPass;

			UserLogin = ObjUsuario.LoginUsuario;
			UserPass = ObjUsuario.SenhaUsuario;

			var User  = AppUsuarios.FindUserLogin(UserLogin, UserPass);

			if (User != null)
			{
				HttpContext.Session.SetString("idUsuario", User.Id.ToString());
				HttpContext.Session.SetString("Usuario", User.LoginUsuario);
				HttpContext.Session.Set("Imagem", User.ImagemUsuario);

				return RedirectToAction("Main");
			}
			return View(ObjUsuario);
		}

		public IActionResult Main()
		{
			if (HttpContext.Session.GetString("Usuario") != null)
			{
				return RedirectToAction("Main", "Main");
			}
			else
			{
				return RedirectToAction("");
			}
		}

		[HttpPost]
		public string Cadastro()
		{
			string Body;

			using (StreamReader stream = new StreamReader(Request.Body))
			{
				Body = stream.ReadToEndAsync().Result;

			}
			JObject JAcesso = JObject.Parse(Body);

			Usuario Usuario = new Usuario
			{
				LoginUsuario = JAcesso.SelectToken("Login").ToString(),
				EmailUsuario = JAcesso.SelectToken("Email").ToString(),
				SenhaUsuario = JAcesso.SelectToken("Senha").ToString(),
				EmpresaUsuario = JAcesso.SelectToken("Empresa").ToString(),
				DataNascimento = Convert.ToDateTime(JAcesso.SelectToken("DataNascimento").ToString()),
				ImagemUsuario = Convert.FromBase64String(JAcesso.SelectToken("Imagem").ToString().Split(',')[1]),
				IdPermissao = 5

			};

			AppUsuarios.Add(Usuario);

			return "ok";
		}
	}
}