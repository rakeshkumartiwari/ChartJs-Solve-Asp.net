<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ShowDataInChart.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="portview" content="width=device-width, initial-scale=1.0" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.min.js"></script>
    <title>ChartJs</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:DropDownList ID="ddlClient" runat="server" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div style="height: 500px; width: 500px">
                <canvas id="pie-chart-allClients" height="450" width="800"></canvas>
                <canvas id="pie-chart-Client" height="450" width="800"></canvas>
            </div>
        </div>
        <asp:HiddenField ID="hdnAllClients" runat="server" />
        <asp:HiddenField ID="hdnClient" runat="server" />
    </form>

    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/ClientChart.js"></script>
    <script src="Scripts/pieLabels.js"></script>

</body>
</html>
