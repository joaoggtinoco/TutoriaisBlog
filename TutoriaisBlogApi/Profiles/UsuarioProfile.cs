using AutoMapper;
using TutoriaisBlogApi.Context.Dtos;
using TutoriaisBlogApi.Context.Dtos.Usuario;
using TutoriaisBlogApi.Models;

namespace TutoriaisBlogApi.Profiles
{
  public class UsuarioProfile : Profile
  {
    public UsuarioProfile()
    {
      CreateMap<CreateUsuarioDto, Usuario>();
      CreateMap<UpdateUsuarioDto, Usuario>();
      CreateMap<Usuario, ReadUsuarioDto>()
        .ForMember(usuario => usuario.Postagens, opts => opts
        .MapFrom(usuario => usuario.Postagens.Select
        (postagem => new {postagem.Id, postagem.Conteudo})));
        
    }
  }
}
