using ApiNandoImoveis.Context;
using ApiNandoImoveis.Models;
using ApiNandoImoveis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNandoImoveis.Repositories
{
    public class ClienteRepository : ICliente
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Delete(int id)
        {
           var cliente = await GetById(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
