using AutoMapper;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Input Mapper
            CreateMap<CategoriaInputDTO, Categoria>();
            CreateMap<EnderecoInputDTO, Endereco>();
            CreateMap<EstoqueInputDTO, Estoque>();
            CreateMap<PedidoInputDTO, Pedido>();
            CreateMap<PedidoItemInputDTO, PedidoItem>();
            CreateMap<ProdutoInputDTO, Produto>();
            CreateMap<UsuarioInputDTO, Usuario>();

            //Output Mapper
            CreateMap<Categoria, CategoriaOutputDTO>();
            CreateMap<Endereco, EnderecoOutputDTO>();
            CreateMap<Produto, ProdutoOutputDTO>();
            CreateMap<Usuario, UsuarioOutputDTO>();
            
            //Configurar, retorno personalizado
            CreateMap<Pedido, PedidoOutputDTO>()
                .ForMember(dest => dest.PedidoItemDTO, ppi => ppi.MapFrom(orig => orig.PedidoItem));

            //mapear tipo complexo para tipo primitivo
            CreateMap<Estoque, EstoqueProdutoOutputDTO>()
                .ForMember(dest => dest.IdProduto, ep => ep.MapFrom(orig => orig.Produto.IdProduto))
                .ForMember(dest => dest.ProdutoNome, ep => ep.MapFrom(orig => orig.Produto.Nome))
                .ForMember(dest => dest.Vencimento, ep => ep.MapFrom(orig => orig.Produto.Vencimento))
                .ForMember(dest => dest.Descricao, ep => ep.MapFrom(orig => orig.Produto.Descricao))
                .ForMember(dest => dest.Preco, ep => ep.MapFrom(orig => orig.Produto.Preco));

            //mapear tipo complexo para tipo primitivo
            CreateMap<PedidoItem, PedidoItemOutputDTO>()
                .ForMember(dest => dest.IdProduto, pi => pi.MapFrom(orig => orig.Produto.IdProduto))
                .ForMember(dest => dest.Nome, pi => pi.MapFrom(orig => orig.Produto.Nome))
                .ForMember(dest => dest.Vencimento, pi => pi.MapFrom(orig => orig.Produto.Vencimento))
                .ForMember(dest => dest.Descricao, pi => pi.MapFrom(orig => orig.Produto.Descricao))
                .ForMember(dest => dest.Preco, pi => pi.MapFrom(orig => orig.Produto.Preco));

            //Exemplo fictiocio
            //Como mapear duas propriedades quando os nomes são diferentes usando o AutoMapper? 
            //CreateMap<Estoque,  EstoqueProdutoOutputDTO>().ForMember(x => x.Quantidade, c => c.MapFrom(rr => rr.IdProduto));
        }
    }
}
