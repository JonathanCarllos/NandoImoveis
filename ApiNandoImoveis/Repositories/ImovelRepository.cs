using ApiNandoImoveis.Context;
using ApiNandoImoveis.Models;
using ApiNandoImoveis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNandoImoveis.Repositories
{
    public class ImovelRepository : IImoveis
    {
        private readonly AppDbContext _context;

        public ImovelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Imovel>> GetAll()
        {
            return await _context.Imovels.ToArrayAsync();
        }

        public async Task<IEnumerable<Imovel>> GetImoveisClientes()
        {
            return await _context.Imovels.Include(C => C.Cliente).ToListAsync();
        }

        public async Task<Imovel> GetById(int id)
        {
            return await _context.Imovels.Where(C => C.Id == id).FirstOrDefaultAsync();
        }       

        public async Task<Imovel> Create(Imovel imovel)
        {
            _context.Imovels.Add(imovel);
            await _context.SaveChangesAsync();
            return imovel;
        }
        public async Task<Imovel> Update(Imovel imovel)
        {
            _context.Entry(imovel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return imovel;
        }

        public async Task<Imovel> Delete(int Id)
        {
            var imovel = await GetById(Id);
            _context.Imovels.Remove(imovel);
            await _context.SaveChangesAsync();
            return imovel;
        }

    }
}