using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPaymentsProject.Domain.Entities;

namespace XPaymentsProject.Application.Interfaces
{
    public interface IAutenticacaoApplicationService
    {
        Task<Usuario> ValidarUsuario(string login, string senha);
    }
}
