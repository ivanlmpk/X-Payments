using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XPaymentsProject.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public Usuario() { }
        public Usuario(string login, string senha, string nome, string email)
        {
            SetUsuario(login, senha, nome, email);
        }

        public void SetUsuario(string login, string senha, string nome, string email)
        {
            if (string.IsNullOrWhiteSpace(login) || login.All(Char.IsDigit) || login.Length <= 3)
                throw new Exception("Login inválido");

            Login = login;

            if (string.IsNullOrWhiteSpace(senha))
                throw new Exception("Senha inválida");

            Senha = senha;

            if (string.IsNullOrWhiteSpace(nome) || nome.All(Char.IsDigit))
                throw new Exception("Nome inválido.");

            Nome = nome;

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                throw new Exception("E-mail inválido.");

            Email = email;
        }
    }
}
