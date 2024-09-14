using ApiNandoImoveis.Context;
using ApiNandoImoveis.Models;
using ApiNandoImoveis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNandoImoveis.Repositories
{
    public class FuncionarioRepository : IFuncionario
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Funcionario> Create(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario> Delete(int id)
        {
            var funcionario = await GetById(id);
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<IEnumerable<Funcionario>> GetAll()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> GetById(int id)
        {
            return await _context.Funcionarios.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Funcionario> Update(Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return funcionario;
        }
    }
}
