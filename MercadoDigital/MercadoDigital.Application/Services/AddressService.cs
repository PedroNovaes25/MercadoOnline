using AutoMapper;
using Lib.Exceptions;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Application.IServices;
using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {

            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(AddressInputDTO addressDTO)
        {
            try
            {
                var address = _mapper.Map<Endereco>(addressDTO);
                return await _addressRepository.Create(address);
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> Delete(int idAddress)
        {
            try
            {

                var address = await _addressRepository.GetAddressById(idAddress);
                if (address == null)
                    throw new DataNotFoundException($"The address with the ID '{idAddress}' was not found.");

                return await _addressRepository.Delete(address);
                
            }
            catch (Exception) { throw; }
        }

        public async Task<AddressOutputDTO> GetAddressById(int idAddress)
        {
            try
            {
                var address = await _addressRepository.GetAddressById(idAddress);
                if (address == null)
                    throw new DataNotFoundException($"The address with the ID '{idAddress}' was not found.");

                return _mapper.Map<AddressOutputDTO>(address);
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> Update(AddressInputDTO addressDTO, int idAddress)
        {
            try
            {
                var address = await _addressRepository.GetAddressById(idAddress);
                if (address == null)
                    throw new DataNotFoundException($"The address with the ID '{idAddress}' was not found.");

                _mapper.Map(addressDTO, address);
                return await _addressRepository.Update(address);
            }
            catch (Exception) { throw; }
        }
    }
}
