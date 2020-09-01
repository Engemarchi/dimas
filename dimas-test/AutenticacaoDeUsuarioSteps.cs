using Gherkin.Ast;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace dimas_test
{
    [Binding]
    public class AutenticacaoDeUsuarioSteps
    {
        private IWebDriver browser;
        private string baseUrl;
        private string screenshotsPasta;

        [BeforeScenario]
        public void Inicializa()
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
            baseUrl = "https://www.google.com.br";
            screenshotsPasta = @".\evidencias";
        }

        [AfterScenario]
        public void Finaliza()
        {
            browser.Close();
            browser.Dispose();
        }

        [Given(@"que o usuário acessa a tela de autenticação")]
        public void DadoQueOUsuarioAcessaATelaDeAutenticacao()
        {
            browser.Navigate().GoToUrl(baseUrl);
        }

        [Then(@"o campo de usuário existe")]
        public void EntaoOCampoDeUsuarioExiste()
        {
            try
            {
                browser.FindElement(By.ClassName("login-email"));
            }
            catch (NoSuchElementException)
            {

                Assert.Fail();
            }
        }

        [Then(@"o campo de senha existe")]
        public void EntaoOCampoDeSenhaExiste()
        {
            try
            {
                browser.FindElement(By.ClassName("login-senha"));
            }
            catch (NoSuchElementException)
            {

                Assert.Fail();
            }
        }

        [Then(@"o link de esqueci minha senha existe")]
        public void EntaoOLinkDeEsqueciMinhaSenhaExiste()
        {
            try
            {
                browser.FindElement(By.ClassName("login-entrar"));
            }
            catch (NoSuchElementException)
            {

                Assert.Fail();
            }
        }

        [Then(@"o botão de entrar são mostrados existe")]
        public void EntaoOBotaoDeEntrarSaoMostradosExiste()
        {
            try
            {
                browser.FindElement(By.ClassName("login-esqueci-senha"));
            }
            catch (NoSuchElementException)
            {

                Assert.Fail();
            }
        }


        [Given(@"que o usuário informa o seu nome de usuário correto")]
        public void DadoQueOUsuarioInformaOSeuNomeDeUsuarioCorreto()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o usuário informa a sua senha correto")]
        public void DadoQueOUsuarioInformaASuaSenhaCorreto()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o usuário clica em esqueci minha senha")]
        public void DadoQueOUsuarioClicaEmEsqueciMinhaSenha()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o usuário informa a seu email")]
        public void DadoQueOUsuarioInformaASeuEmail()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o email corresponde à um usuário cadastrado")]
        public void DadoQueOEmailCorrespondeAUmUsuarioCadastrado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o usuário informa a sua senha incorreta")]
        public void DadoQueOUsuarioInformaASuaSenhaIncorreta()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o usuário informa o seu nome de usuário incorreto")]
        public void DadoQueOUsuarioInformaOSeuNomeDeUsuarioIncorreto()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o usuário informa a sua senha incorreto")]
        public void DadoQueOUsuarioInformaASuaSenhaIncorreto()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o email não corresponde à um usuário cadastrado")]
        public void DadoQueOEmailNaoCorrespondeAUmUsuarioCadastrado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"os campos de usuário, senha, link de esqueci minha senha e botão de entrar são mostrados")]
        public void EntaoOsCamposDeUsuarioSenhaLinkDeEsqueciMinhaSenhaEBotaoDeEntrarSaoMostrados()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Valida usuário e senha corretos e redireciona para a página inicial")]
        public void EntaoValidaUsuarioESenhaCorretosERedirecionaParaAPaginaInicial()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Envia um email com link para atualização de senha do usuário")]
        public void EntaoEnviaUmEmailComLinkParaAtualizacaoDeSenhaDoUsuario()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Exibe mensagem de senha incorreta")]
        public void EntaoExibeMensagemDeSenhaIncorreta()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Exibe mensagem de usuário não cadastrado")]
        public void EntaoExibeMensagemDeUsuarioNaoCadastrado()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
