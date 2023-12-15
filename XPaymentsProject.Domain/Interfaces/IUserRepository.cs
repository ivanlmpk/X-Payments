using XPaymentsProject.Domain.Entities;

namespace XPaymentsProject.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario> BuscaPorLoginSenha(string username, string senha);
    }
}
