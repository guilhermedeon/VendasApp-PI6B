using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository _usuarioRepository)
        {
            this._usuarioRepository = _usuarioRepository;
        }

        public Usuario Create(Usuario usuario)
        {
            return _usuarioRepository.Create(usuario);
        }

        public Usuario Update(Usuario usuario)
        {
            return _usuarioRepository.Update(usuario);
        }

        public void Delete(int id)
        {
            _usuarioRepository.Delete(id);
        }

        public Usuario GetById(int id)
        {
            return _usuarioRepository.GetById(id);
        }

        public Usuario GetByUsername(string name)
        {
            return _usuarioRepository.GetByUsername(name);
        }
    }
}