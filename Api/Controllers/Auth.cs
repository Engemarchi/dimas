using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public async Task AutheticateAsync([FromServices]IPasswordHasher<Account> pwdValidator,[FromServices]AccountStoreContext dataContext, AuthModel authModel)
        {
            try
            {
                var account = await dataContext.Accounts.SingleOrDefaultAsync(account => account.Username == authModel.Username);
                if (account == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("Usuário não cadastrado"));
                }
                else
                {
                    if (account.Enable)
                    {
                        var pwdVerificationResult = pwdValidator.VerifyHashedPassword(account, account.PasswordHash, authModel.Password);
                        Response.StatusCode = (int)(pwdVerificationResult != PasswordVerificationResult.Failed ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
                        switch (pwdVerificationResult)
                        {
                            case PasswordVerificationResult.SuccessRehashNeeded:
                            case PasswordVerificationResult.Success:
                                await Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("JWT"));
                                break;
                            default:
                                await Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("Senha incorreta"));
                                break;
                        }
                    }
                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("Usuário não autorizado"));
                    }
                }

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes(ex.Message));
            }
        }
    }
}
