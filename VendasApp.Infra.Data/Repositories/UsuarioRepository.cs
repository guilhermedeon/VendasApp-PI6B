using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Domain.Entities;

namespace VendasApp.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VendasAppContext _appContext;

        public UsuarioRepository(VendasAppContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(Usuario usuario)
        {
            _appContext.Usuarios.Add(usuario);
            _appContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _appContext.Usuarios.Remove(GetById(id));
            _appContext.SaveChanges();
        }

        public Usuario GetById(int id)
        {
            return _appContext.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public Usuario GetByUsername(string name)
        {
            return _appContext.Usuarios.Where(x => x.Username == name).FirstOrDefault();
        }

        public void Update(Usuario usuario)
        {
            _appContext.Usuarios.Update(usuario);
            _appContext.SaveChanges();
        }
    }
}