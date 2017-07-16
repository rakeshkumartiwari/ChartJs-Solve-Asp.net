using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowDataInChart
{
    public class ClientDtoMaper
    {
        public static List<ClientDto> MapAllClientsToDto(List<Client> clients)
        {
            var allClientDto = new List<ClientDto>();
            foreach (var client in clients)
            {
                var clientDto = new ClientDto
                {
                    Id = client.Id,
                    Name = client.Name,
                    JobOrders = client.JobOrders
                };
                allClientDto.Add(clientDto);
            }
            return allClientDto;
        }

        public static ClientDto MapClientToDto(Client client)
        {
            var clientDto = new ClientDto
            {
                Id = client.Id,
                Name = client.Name,
                JobOrders = client.JobOrders
            };
            return clientDto;
        }
    }
}