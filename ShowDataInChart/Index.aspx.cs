using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShowDataInChart
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var clients = GetAllClientFromDb();
            var allClientDto = MapAllClientsToDto(clients);
            var js = new JavaScriptSerializer();
            hdnAllClients.Value = string.Empty;
            hdnAllClients.Value = js.Serialize(allClientDto);
            if(!IsPostBack)
            {
                RefreshDdlClient(allClientDto);
            }
        }

        public List<Client> GetAllClientFromDb()
        {
            var clients = new List<Client>
            {
                new Client
                {
                    Id=1,
                    Name = "Rakesh",
                    JobOrders = 35
                    
                },
                 new Client
                {
                    Id=2,
                    Name = "Ritesh",
                    JobOrders = 50
                    
                },
                 new Client
                {
                    Id=3,
                    Name = "Rupesh",
                    JobOrders = 70
                    
                },
                 new Client
                {
                    Id=4,
                    Name = "Rajnish",
                    JobOrders = 85
                    
                }
               

            };
            return clients;
        }

        public Client GetClientById(int id)
        {
            var clients = GetAllClientFromDb();
            var client = clients.FirstOrDefault(c => c.Id == id);
            return client;

        }

        public List<ClientDto> MapAllClientsToDto(List<Client> clients)
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

        public ClientDto MapClientToDto(Client client)
        {
            var clientDto= new ClientDto
            {
                Id=client.Id,
                Name = client.Name,
                JobOrders = client.JobOrders
            };
            return clientDto;
        }

        public void RefreshDdlClient(List<ClientDto> allClientDto )
        {
            ddlClient.DataValueField = "Id";
            ddlClient.DataTextField = "Name";
            ddlClient.DataSource = allClientDto;
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("Select Client", "0"));
           
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnClient.Value = string.Empty;
            var clientId = Convert.ToInt16(ddlClient.SelectedValue);
            if (clientId < 1)
            {
                return;
            }
            var client = GetClientById(clientId);
            var clientDto = MapClientToDto(client);
            var js = new JavaScriptSerializer();

            hdnClient.Value = js.Serialize(clientDto);
        }

        
    }
}