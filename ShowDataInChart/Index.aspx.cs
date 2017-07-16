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
        public IClientRepository ClientRepository ;
        public Index()
        {
            ClientRepository=new ClientInMemoryRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var clients =ClientRepository.GetAllClientFromDb();
            var allClientDto = ClientDtoMaper.MapAllClientsToDto(clients);
            var js = new JavaScriptSerializer();
            hdnAllClients.Value = string.Empty;
            hdnAllClients.Value = js.Serialize(allClientDto);
            if(!IsPostBack)
            {
                RefreshDdlClient(allClientDto);
            }
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
            var client =ClientRepository.GetClientById(clientId);
            var clientDto = ClientDtoMaper.MapClientToDto(client);
            var js = new JavaScriptSerializer();
            hdnClient.Value = js.Serialize(clientDto);
        }

        
    }
}