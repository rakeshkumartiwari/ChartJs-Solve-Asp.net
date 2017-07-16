$(function () {

    showAllClients();

    var client = $("#hdnClient").val();

    if (client) {
        showClient();
    }
  
});
function showAllClients() {
    var clients = $("#hdnAllClients").val();

    if (!clients) {
        return;
    }
        
    var jsonClients = JSON.parse(clients);

    var labels = [];
    var jobOrders = [];
    var backgroundColor = [];

    $.each(jsonClients, function (index, data) {
        labels.push(data.Name);//This for show the names.
        jobOrders.push(data.JobOrders);
        backgroundColor.push(getRandomColor());
    });

    var pieOptionsForAllClients = {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [
                {
                    label: jobOrders,
                    backgroundColor: backgroundColor,
                    data: jobOrders,
                }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'All Clients'
            },
            //legend: {
            //    display: false
            //},
            pieceLabel: {
                mode: 'value'
            }
        }


    };
    var allClientsCtx = $("#pie-chart-allClients");
    var clientsChart = new Chart(allClientsCtx, pieOptionsForAllClients);
}
function showClient() {

    var client = $("#hdnClient").val();
    if (!client) {
        return;
    }
    var jsonClient = JSON.parse(client);

    var pieOptionsForClient= {
        type: 'pie',
        data: {
            labels: [jsonClient.Name],
            datasets: [
                {
                    label: [jsonClient.Name],
                    backgroundColor: [getRandomColor()],
                    data: [jsonClient.JobOrders],
                }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'Client'
            },
            //legend: {
            //    display: false
            //},
            pieceLabel: {
                mode: 'value'
            }
        }


    };
    var clientsCtx = $("#pie-chart-Client");
    var clientChart = new Chart(clientsCtx, pieOptionsForClient);
}
function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}