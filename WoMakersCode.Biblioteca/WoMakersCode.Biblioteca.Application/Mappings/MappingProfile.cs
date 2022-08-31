using AutoMapper;
using WoMakersCode.Biblioteca.Application.Models.AdicionarAutor;
using WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Autor.AtualizarAutor;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AdicionarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AtualizarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.ListarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.ListarAutor;
using WoMakersCode.Biblioteca.Application.Models.ListarLivro;
using WoMakersCode.Biblioteca.Application.Models.Livro.AtualizarLivro;
using WoMakersCode.Biblioteca.Application.Models.Relatorio.DevolucoesEmAtraso;
using WoMakersCode.Biblioteca.Application.Models.Relatorio.LivrosDisponiveis;
using WoMakersCode.Biblioteca.Application.Models.Relatorio.LivrosEmEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Usuario.AtualizarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Usuario.ListarUsuario;
using WoMakersCode.Biblioteca.Core.DTOs;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Autor, ListarAutorResponse>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, fonte => fonte.MapFrom(src => src.Nome));

            CreateMap<AdicionarAutorRequest, Autor>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Nome, fonte => fonte.MapFrom(src => src.Nome));

            CreateMap<AtualizarAutorRequest, Autor>() //source = fonte = de onde está vindo
               .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nome, fonte => fonte.MapFrom(src => src.Nome));

            CreateMap<Livro, ListarLivroResponse>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Titulo, fonte => fonte.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.QuantidadeDisponivel, fonte => fonte.MapFrom(src => src.QuantidadeDisponivel))
                .ForMember(dest => dest.IdAutor, fonte => fonte.MapFrom(src => src.IdAutor));

            CreateMap<AdicionarLivroRequest, Livro>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Titulo, fonte => fonte.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.QuantidadeDisponivel, fonte => fonte.MapFrom(src => src.QuantidadeDisponivel))
                .ForMember(dest => dest.IdAutor, fonte => fonte.MapFrom(src => src.IdAutor));

            CreateMap<AtualizarLivroRequest, Livro>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Titulo, fonte => fonte.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.QuantidadeDisponivel, fonte => fonte.MapFrom(src => src.QuantidadeDisponivel));

            CreateMap<Usuario, ListarUsuarioResponse>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, fonte => fonte.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Endereco, fonte => fonte.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Telefone, fonte => fonte.MapFrom(src => src.Telefone));

            CreateMap<AdicionarUsuarioRequest, Usuario>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Nome, fonte => fonte.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Endereco, fonte => fonte.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Telefone, fonte => fonte.MapFrom(src => src.Telefone));

            CreateMap<AtualizarUsuarioRequest, Usuario>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, fonte => fonte.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Endereco, fonte => fonte.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Telefone, fonte => fonte.MapFrom(src => src.Telefone));

            CreateMap<Emprestimo, ListarEmprestimoResponse>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.DataEmprestimo, fonte => fonte.MapFrom(src => src.DataEmprestimo))
                .ForMember(dest => dest.DataDevolucao, fonte => fonte.MapFrom(src => src.DataDevolucao))
                .ForMember(dest => dest.IdUsuario, fonte => fonte.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.IdLivro, fonte => fonte.MapFrom(src => src.IdLivro));

            CreateMap<AdicionarEmprestimoRequest, Emprestimo>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.DataEmprestimo, fonte => fonte.MapFrom(src => src.DataEmprestimo))
                .ForMember(dest => dest.IdUsuario, fonte => fonte.MapFrom(src => src.IdUsuario));

            CreateMap<AtualizarEmprestimoRequest, Emprestimo>() //source = fonte = de onde está vindo
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id));

            CreateMap<LivrosAtrasadosDTO, DevolucoesEmAtrasoResponse>()
                .ForMember(dest => dest.TituloLivro, fonte => fonte.MapFrom(src => src.TituloLivro))
                .ForMember(dest => dest.NomeAutor, fonte => fonte.MapFrom(src => src.NomeAutor))
                .ForMember(dest => dest.NomeUsuario, fonte => fonte.MapFrom(src => src.NomeUsuario))
                .ForMember(dest => dest.DataEmprestimo, fonte => fonte.MapFrom(src => src.DataEmprestimo))
                .ForMember(dest => dest.DataDevolucao, fonte => fonte.MapFrom(src => src.DataDevolucao))
                .ForMember(dest => dest.DiasEmAtraso, fonte => fonte.MapFrom(src => src.DiasEmAtraso))
                .ForMember(dest => dest.ValorMulta, fonte => fonte.MapFrom(src => src.ValorMulta));

            CreateMap<LivroEmprestadoDTO, LivrosEmEmprestimoResponse>()
                .ForMember(dest => dest.TituloLivro, fonte => fonte.MapFrom(src => src.TituloLivro))
                .ForMember(dest => dest.NomeAutor, fonte => fonte.MapFrom(src => src.NomeAutor))
                .ForMember(dest => dest.NomeUsuario, fonte => fonte.MapFrom(src => src.NomeUsuario))
                .ForMember(dest => dest.DataEmprestimo, fonte => fonte.MapFrom(src => src.DataEmprestimo))
                .ForMember(dest => dest.DataDevolucao, fonte => fonte.MapFrom(src => src.DataDevolucao));

            CreateMap<LivrosDisponiveisDTO, LivrosDisponiveisResponse>()
                .ForMember(dest => dest.TituloLivro, fonte => fonte.MapFrom(src => src.TituloLivro))
                .ForMember(dest => dest.NomeAutor, fonte => fonte.MapFrom(src => src.NomeAutor))
                .ForMember(dest => dest.QtdDisponivel, fonte => fonte.MapFrom(src => src.QtdDisponivel))
                .ForMember(dest => dest.QtdEmp, fonte => fonte.MapFrom(src => src.QtdEmp));
        }
    }
}
