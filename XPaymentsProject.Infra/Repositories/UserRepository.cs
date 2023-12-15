using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPaymentsProject.Domain.Entities;
using XPaymentsProject.Domain.Interfaces;
using XPaymentsProject.Infra.Context;

namespace XPaymentsProject.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> BuscaPorLoginSenha(string username, string senha)
        {
            // Calular hash da senha
            //var passwordHash = CalculaHashSenha(senha);

            var usuario =  await _context.Usuarios.FirstOrDefaultAsync(u => u.Login == username && u.Senha == senha);

            if (usuario == null) {
                throw new Exception("Nenhum usuário encontrado para esse username.");
            }    

            return usuario;
        }

        //private string CalculaHashSenha(string senha)
        //{
        //    // Implemente a lógica de hashing de senha aqui
        //    // Por exemplo, usando o algoritmo SHA256 ou preferencialmente um mais seguro como BCrypt ou Argon2
        //    using (var sha256 = System.Security.Cryptography.SHA256.Create())
        //    {
        //        var bytes = Encoding.UTF8.GetBytes(senha);
        //        var hash = sha256.ComputeHash(bytes);

        //        return Convert.ToBase64String(hash);
        //    }
        //}
    }
}
