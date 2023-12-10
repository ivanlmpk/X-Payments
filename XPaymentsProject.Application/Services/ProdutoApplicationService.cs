using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPaymentsProject.Application.Interfaces;
using XPaymentsProject.Domain.Entities;
using XPaymentsProject.Domain.Interfaces;
using XPaymentsProject.Domain.Utilities;

namespace XPaymentsProject.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private IGenericRepository<Produto> _genericRepository;

        public ProdutoApplicationService(IGenericRepository<Produto> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<Result<bool>> AddProduto(string nome, string descricao, string foto, int garantia, string emailSuporte)
        {
            try
            {
                var produto = new Produto(nome, descricao, foto, garantia, emailSuporte);

                await _genericRepository.AddAsync(produto);

                return Result<bool>.Success(true);
            }
            catch (AggregateException ex)
            {
                return Result<bool>.Failure(ex);
            }
            
        }

        public async Task UpdateProduto(int id, Produto produto)
        {
            var getProduto = await _genericRepository.GetByIdAsync(id);

            getProduto.Nome = produto.Nome;
            getProduto.Descricao = produto.Descricao;   
            getProduto.Foto = produto.Foto;
            getProduto.Garantia = produto.Garantia;
            getProduto.EmailSuporte = produto.EmailSuporte;

            await _genericRepository.UpdateAsync(getProduto);
        }

        public async Task DeleteProduto(int id)
        {
            await _genericRepository.DeleteAsync(id);
        }
    }
}

