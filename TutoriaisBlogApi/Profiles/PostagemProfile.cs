using AutoMapper;
using TutoriaisBlogApi.Context.Dtos;
using TutoriaisBlogApi.Context.Dtos.Postagem;
using TutoriaisBlogApi.Models;

namespace TutoriaisBlogApi.Profiles
{
  public class PostagemProfile : Profile
  {
    public PostagemProfile()
    {
      //Converte CreatePostagemDto para Postagem.
      CreateMap<CreatePostagemDto, Postagem>();
      CreateMap<Postagem, ReadPostagemDto>();
    }
  }
}
