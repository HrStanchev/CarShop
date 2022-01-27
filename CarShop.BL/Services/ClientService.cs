using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;
using CarShop.DL.Interfaces;
using CarShop.BL.Interfaces;

namespace CarShop.BL.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Create(Client client)
        {
            var index = _clientRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            client.Id = (int)(index != null ? index + 1 : 1);
            return _clientRepository.Create(client);
        }

        public Client Delete(int id)
        {
            return _clientRepository.Delete(id);
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public Client Update(Client client)
        {
            return _clientRepository.Update(client);
        }
    }
}
