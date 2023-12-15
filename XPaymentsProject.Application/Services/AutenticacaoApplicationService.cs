using XPaymentsProject.Application.Interfaces;
using XPaymentsProject.Domain.Entities;
using XPaymentsProject.Domain.Interfaces;

namespace XPaymentsProject.Application.Services
{
    public class AutenticacaoApplicationService : IAutenticacaoApplicationService
    {
        private IUserRepository _userRepository;

        public AutenticacaoApplicationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Usuario> ValidarUsuario(string login, string senha)
        {
            return await _userRepository.BuscaPorLoginSenha(login, senha);
        }
    }
}
