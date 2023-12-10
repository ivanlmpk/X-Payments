using MudBlazor;
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
            var excessoes = new List<Exception>();

            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3 || nome.Length > 50 || nome.All(Char.IsDigit))
                excessoes.Add(new Exception("Nome inválido. Deve ter entre 3-50 caracteres e conter letras."));

            Nome = nome;

            if (string.IsNullOrWhiteSpace(descricao) || descricao.Length < 4 || descricao.Length > 600 || descricao.All(Char.IsDigit))
                excessoes.Add(new Exception("Descrição inválida. Deve ter entre 4-600 caracteres."));

            Descricao = descricao;

            if (garantia < 1)
                excessoes.Add(new Exception("Garantia inválida. Deve ser de no mínimo 1 mês."));

            Garantia = garantia;

            if (string.IsNullOrEmpty(emailSuporte) || !Regex.IsMatch(emailSuporte, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                excessoes.Add(new Exception("E-mail inválido. Use um formato válido."));

            EmailSuporte = emailSuporte;

            if (string.IsNullOrWhiteSpace(foto))
            {
                excessoes.Add(new Exception("Foto obrigatória. Por favor, insira uma foto."));
            }
            else
            {
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
            }

            if (excessoes.Any())
            {
                throw new AggregateException(excessoes);
            }
        }
    }
}
