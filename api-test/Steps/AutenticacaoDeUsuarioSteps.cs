using Api.Controllers;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebSite.Models;

namespace Api.Test.Steps
{
    [Binding]
    public class AutenticacaoDeUsuarioSteps
    {
        private static DbContextOptionsBuilder<AccountStoreContext> contextOptsBuilder;
        private static AccountStoreContext accountDbContext;
        private static ControllerContext controllerContext;
        private static string username;
        private static string password;

        [BeforeTestRun]
        public static void Init()
        {
            contextOptsBuilder = new DbContextOptionsBuilder<AccountStoreContext>();
            contextOptsBuilder.UseInMemoryDatabase("AccountTests");
            accountDbContext = new AccountStoreContext(contextOptsBuilder.Options);
            controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
        }

        [Given(@"os usuários cadastrados")]
        public void DadoOsUsuariosCadastrados(Table table)
        {
            foreach (var row in table.Rows.Where(k => accountDbContext.Accounts.All(a => a.Id != Int32.Parse(k["Id"]))))
            {
                var account = new Account
                {
                    Id = Int32.Parse(row["Id"]),
                    Username = row["Username"],
                    PasswordHash = row["PasswordHash"],
                    Enable = Convert.ToBoolean(row["Enable"].ToString())
                };
                accountDbContext.Accounts.Add(account);
            }
            accountDbContext.SaveChanges();
        }

        [Given(@"que o usuário é ""(.*)""")]
        public void DadoQueOUsuarioE(string p0)
        {
            username = p0;
        }

        [Given(@"que a senha é ""(.*)""")]
        public void DadoQueASenhaE(string p0)
        {
            password = p0;
        }

        [When(@"é solicitada a autenticação")]
        public async Task QuandoESolicitadaAAutenticacao()
        {
            var api = new AuthController
            {
                ControllerContext = controllerContext
            };
            var pwdHasher = new PasswordHasher<Account>();
            var authModel = new AuthModel
            {
                Username = username,
                Password = password
            };
            await api.AutheticateAsync(pwdHasher, accountDbContext, authModel);
        }

        [Then(@"retorna codigo ""(.*)"" e o token com as informações do usuário")]
        public void EntaoRetornaCodigoEOTokenComAsInformacoesDoUsuario(int p0)
        {
            Assert.AreEqual(200, controllerContext.HttpContext.Response.StatusCode);
        }

        [Then(@"retorna codigo ""(.*)"" e mensagem de erro ""(.*)""")]
        public void EntaoRetornaCodigoEMensagemDeErro(int p0, string p1)
        {
            var messages = new Dictionary<int, string>
            {
                { 401, "Senha incorreta;Usuário não autorizado" },
                { 404, "Usuário não cadastrado" },
            };
            Assert.AreEqual(p0, controllerContext.HttpContext.Response.StatusCode);
            Assert.IsTrue(messages[p0].Split(";").Contains(p1));
        }

    }
}
