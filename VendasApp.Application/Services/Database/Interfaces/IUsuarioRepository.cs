using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario Create(Usuario usuario);

        public Usuario Update(Usuario usuario);

        public void Delete(int id);

        public Usuario GetById(int id);

        public Usuario GetByUsername(string name);
    }
}