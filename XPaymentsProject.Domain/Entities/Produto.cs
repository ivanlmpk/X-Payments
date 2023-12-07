using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace XPaymentsProject.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres", MinimumLength = 3)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatório.")]
        [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 600 caracteres")]
        public string? Descricao { get; set; }

        public string? Foto { get; set; }

        [Required(ErrorMessage = "Informe a garantia.")]
        public int Garantia { get; set; }

        [Required(ErrorMessage = "O e-mail do suporte é obrigatório.")]
        public string? EmailSuporte { get; set; }

        public Produto() { }

        public Produto(string nome, string descricao, string foto, int garantia, string emailSuporte)
        {
            SetProduto(nome, descricao, foto, garantia, emailSuporte);
        }

        public void SetProduto(string nome, string descricao, string foto, int garantia, string emailSuporte)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3 || nome.Length > 50 || nome.All(Char.IsDigit))
                throw new Exception("Nome do produto inválido. Por favor, escreva um nome válido.");

            Nome = nome;

            if (string.IsNullOrWhiteSpace(descricao) || descricao.Length <= 2 || descricao.Length > 600 || descricao.All(Char.IsDigit))
                throw new Exception("Descrição inválida. Por favor, escreva uma descrição válida.");

            Descricao = descricao;

            if (string.IsNullOrWhiteSpace(foto))
                throw new Exception("Por favor, insira uma foto.");

            byte[] imagemBytes;
            try
            {
                imagemBytes = Convert.FromBase64String(foto);
            }
            catch (FormatException)
            {
                throw new ArgumentException("A foto não está em um formato base64 válido.");
            }

            // Verifica se o tamanho da foto é maior que 10MB
            if (imagemBytes.Length > 10 * 1024 * 1024)
                throw new ArgumentException("A foto deve ter no máximo 10 MB.");

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
