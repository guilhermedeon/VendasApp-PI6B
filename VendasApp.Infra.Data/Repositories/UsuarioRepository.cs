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

        public Usuario Create(Usuario usuario)
        {
            var a = _appContext.Usuarios.Add(usuario);
            _appContext.SaveChanges();
            return a.Entity;
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

        public Usuario Update(Usuario usuario)
        {
            var a = _appContext.Usuarios.Update(usuario);
            _appContext.SaveChanges();
            return a.Entity;
        }
    }
}