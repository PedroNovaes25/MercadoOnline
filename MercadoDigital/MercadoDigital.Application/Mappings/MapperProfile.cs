using AutoMapper;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.Models;
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
            CreateMap<CategoryInputDTO, Categoria>();
            CreateMap<AddressInputDTO, Endereco>();
            CreateMap<StockInputDTO, Estoque>();
            CreateMap<OrderInputDTO, Pedido>();
            CreateMap<OrderItemInputDTO, PedidoItem>();
            CreateMap<ProductInputDTO, Produto>();
            CreateMap<UserInputDTO, Usuario>();
            CreateMap<CategoryProductInputDTO, CategoriaProduto>();

            //Output Mapper
            CreateMap<Categoria, CategoryOutputDTO>();
            CreateMap<Endereco, AddressOutputDTO>();
            CreateMap<Produto, ProductOutputDTO>();
            CreateMap<Usuario, UserOutputDTO>();

            CreateMap<EstoqueEProduto, StockProductOutputDTO>();
            
            
            //Configurar, retorno personalizado
            CreateMap<Pedido, OrderOutputDTO>()
                .ForMember(dest => dest.PedidoItemDTO, ppi => ppi.MapFrom(orig => orig.PedidoItem));

            //mapear tipo complexo para tipo primitivo
            //CreateMap<Estoque, StockProductOutputDTO>()
            //    .ForMember(dest => dest.IdProduto, ep => ep.MapFrom(orig => orig.Produto.IdProduto))
            //    .ForMember(dest => dest.NomeProduto, ep => ep.MapFrom(orig => orig.Produto.Nome))
            //    .ForMember(dest => dest.Vencimento, ep => ep.MapFrom(orig => orig.Produto.Vencimento))
            //    .ForMember(dest => dest.Descricao, ep => ep.MapFrom(orig => orig.Produto.Descricao))
            //    .ForMember(dest => dest.Preco, ep => ep.MapFrom(orig => orig.Produto.Preco));

            //mapear tipo complexo para tipo primitivo
            CreateMap<PedidoItem, OrderItemOutputDTO>()
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
