using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPaymentsProject.Domain.Entities;

namespace XPaymentsProject.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Task AddUsuario(string login, string senha, string nome, string email);
        Task UpdateUsuario(int id, Usuario usuario);
        Task DeleteUsuario(int id);
        Task<Usuario> GetUsuarioById(int id);
        Task GetAllUsuarios();
    }
}
