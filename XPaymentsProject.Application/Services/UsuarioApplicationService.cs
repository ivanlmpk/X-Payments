using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPaymentsProject.Application.Interfaces;
using XPaymentsProject.Domain.Entities;
using XPaymentsProject.Domain.Interfaces;

namespace XPaymentsProject.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private IGenericRepository<Usuario> _genericRepository;

        public UsuarioApplicationService(IGenericRepository<Usuario> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task AddUsuario(string login, string senha, string nome, string email)
        {
            var usuario = new Usuario(login, senha, nome, email);

            await _genericRepository.AddAsync(usuario);
        }

        public async Task UpdateUsuario(int id, Usuario usuario)
        {
            var getUsuario = await _genericRepository.GetByIdAsync(id);

            getUsuario.Login = usuario.Login;
            getUsuario.Senha = usuario.Senha;
            getUsuario.Nome = usuario.Nome;
            getUsuario.Email = usuario.Email;

            await _genericRepository.UpdateAsync(getUsuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _genericRepository.DeleteAsync(id);
        }
    }
}
