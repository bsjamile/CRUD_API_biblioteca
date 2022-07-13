using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.DataBase;

namespace WoMakersCode.Biblioteca.Infra.Respositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Atualizar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Usuario usuario)
        {
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ListarPorId(int id)
        {
            return await Task.FromResult(_context.Find<Usuario>(id));
        }

        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            return await _context
                .Usuarios
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
