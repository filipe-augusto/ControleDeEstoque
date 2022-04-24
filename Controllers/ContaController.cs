using ControleDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleDeEstoque.Controllers
{
    public class ContaController : Controller
    {
      
        [AllowAnonymous]
        public ActionResult Login(string returnURl)
        {
            ViewBag.ReturnUrl = returnURl;

            return View();

        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var achou = (login.Usuario == "filipeaugusto" && login.Senha == "123");
            if (achou)
            {
                //GERAR O COOKIE DE AUTENTICAÇÃO

                FormsAuthentication.SetAuthCookie(login.Usuario, login.LembrarMe);
                //DEPOIS REDIRECIONAR PARA URL QUE ELE IA ACESSAR
                //ANTES VALIDAR SE A URL ESTA DENTRO DO DOMINIO
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                   RedirectToAction("Index", "Home");
                }
            }//se o login estiver erraddo
            else
            {
                ModelState.AddModelError("", "login invalido!");
            }


            return View(login);
        }

        [AllowAnonymous]
    [HttpPost]
    public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}