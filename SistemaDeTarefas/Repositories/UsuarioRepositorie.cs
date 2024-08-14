using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;
using System.Data;

namespace SistemaDeTarefas.Repositories
{
    public class UsuarioRepositorie : IUsuarioRepositorie
    {
        private readonly TaskDbContext _dbContext;
        public UsuarioRepositorie(TaskDbContext taskDbContext)
        {
            _dbContext = taskDbContext;
            
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioId = await BuscarUsuarioId(id);
            if(usuarioId == null)
            {
                throw new Exception($" Usuario com o ID {id} NÃO foi encontrado no banco de dados.");
            }

            usuarioId.Nome = usuario.Nome;
            usuarioId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioId);
            _dbContext.SaveChanges();

            return usuarioId;
        }

        public async  Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> BuscarUsuarioId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
