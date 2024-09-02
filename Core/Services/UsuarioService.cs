using Core.Entitites;
using Core.Interfaces;
using Dapper;
using Infrastructure.Dto;
using Infrastructure.Interface;

namespace Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private Usuario _usuario;
        private UsuarioDto _usuarioDto;

        public UsuarioService(IUsuarioRepository usuarioRepository, Usuario usuario, UsuarioDto usuarioDto)
        {
            _usuarioRepository = usuarioRepository;
            _usuario = usuario;
            _usuarioDto = usuarioDto;
        }

        public async Task<int> Adicionar(Usuario entity)
        {
            _usuarioDto.UsuarioNome = entity.UsuarioNome;
            _usuarioDto.UsuarioEmail = entity.UsuarioEmail;
            _usuarioDto.UsuarioSenha = entity.UsuarioSenha;

            var usuario = await _usuarioRepository.Adicionar(_usuarioDto);

            return usuario;
        }

        public async Task<int> Alterar(Usuario entity)
        {
            _usuarioDto.UsuarioId = entity.UsuarioId;
            _usuarioDto.UsuarioNome = entity.UsuarioNome;
            _usuarioDto.UsuarioEmail = entity.UsuarioEmail;
            _usuarioDto.UsuarioSenha = entity.UsuarioSenha;

            var result = await _usuarioRepository.Alterar(_usuarioDto);
            return result;
        }

        public async Task<int> Apagar(int Id)
        {
            var result = await _usuarioRepository.Apagar(Id);
            return result;
        }

        public async Task<Usuario> LeituraPorId(int Id)
        {
            var listaUsuarios = await _usuarioRepository.LeituraPorId(Id);

            _usuario.UsuarioNome = listaUsuarios.UsuarioNome.ToString();
            _usuario.UsuarioEmail = listaUsuarios.UsuarioEmail.ToString();
            _usuario.UsuarioId = listaUsuarios.UsuarioId;

            return _usuario;
        }

        public async Task<List<Usuario>> ListaTodos()
        {
            var listaUsuarios = await _usuarioRepository.ListaTodos();
            Usuario usuario = null;
            List<Usuario> _listUsuario = new List<Usuario>();
            foreach (var item in listaUsuarios.ToList())
            {
                usuario = new Usuario();
                usuario.UsuarioNome = item.UsuarioNome.ToString();
                usuario.UsuarioEmail = item.UsuarioEmail.ToString();
                usuario.UsuarioId = item.UsuarioId;

                _listUsuario.Add(usuario);
            }

            return _listUsuario;
        }
    }
}
