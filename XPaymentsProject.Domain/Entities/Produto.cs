using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XPaymentsProject.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
        public int Garantia { get; set; }
        public string? EmailSuporte { get; set; }

        public Produto(string nome, string descricao, string foto, int garantia, string emailSuporte)
        {
            SetProduto(nome, descricao, foto, garantia, emailSuporte);
        }

        public void SetProduto(string nome, string descricao, string foto, int garantia, string emailSuporte)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length <= 2 || nome.Length > 50 || nome.All(Char.IsDigit))
                throw new Exception("Nome do produto inválido. Por favor, escreva um nome válido.");

            Nome = nome;

            if (string.IsNullOrWhiteSpace(descricao) || descricao.Length <= 2 || descricao.Length > 600 || descricao.All(Char.IsDigit))
                throw new Exception("Descrição inválida. Por favor, escreva uma descrição válida.");

            Descricao = descricao;

            //if (string.IsNullOrWhiteSpace(foto))
            //    throw new Exception("Por favor, insira uma foto.");

            //byte[] imagemBytes;
            //try
            //{
            //    imagemBytes = Convert.FromBase64String(foto);
            //}
            //catch (FormatException)
            //{
            //    throw new ArgumentException("A foto não está em um formato base64 válido.");
            //}

            //// Verifica se o tamanho da foto é maior que 10MB
            //if (imagemBytes.Length > 10 * 1024 * 1024)
            //    throw new ArgumentException("A foto deve ter no máximo 10 MB.");

            Foto = foto;

            if (garantia < 7)
                throw new Exception("Garantia inválida.");

            Garantia = garantia;

            if (string.IsNullOrEmpty(emailSuporte) || !Regex.IsMatch(emailSuporte, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                throw new Exception("E-mail inválido.");

            EmailSuporte = emailSuporte;
        }
    }
}
