<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuGerente.aspx.cs" Inherits="TiendaZapatillas.Gerente.MenuGerente" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
     <script type="text/javascript">
         google.charts.load('current', { 'packages': ['corechart'] });         
         google.charts.setOnLoadCallback(drawPieChart);
         google.charts.load('current', { 'packages': ['bar'] });
         google.charts.setOnLoadCallback(drawColumnChart);
         google.charts.setOnLoadCallback(drawBarChart);



     function drawPieChart() {

         var data = new google.visualization.arrayToDataTable(<%=this.datosPieChartSQL()%>);
         var options = {
             legend: { position: "bottom", textStyle: { color: "black", fontSize: 10 } },
             tooltip: { textStyle: { color: "black", fontSize: 12 }, showColorCode: true },
             is3D: false,
         };
         var chart = new google.visualization.PieChart(document.getElementById('ChartTOP'));

         chart.draw(data, options);
         }


     function drawColumnChart() {

            var data = new google.visualization.arrayToDataTable(<%=this.datosColumnChartSQL()%>);
            var options = {
                width: 800,
                legend: { position: 'none' },
                
                axes: {
                    x: {
                        0: { side: 'bottom,'} // Top x-axis.
                    }
                },
                bar: { groupWidth: "80%" }
            };
            var chart = new google.charts.Bar(document.getElementById('ChartIngresos'));
            chart.draw(data, google.charts.Bar.convertOptions(options));
         }

    function drawBarChart() {

        var data = new google.visualization.arrayToDataTable(<%=this.datosBarChartSQL()%>);
        var options = {
            
            bars: 'horizontal',
            legend: { position: 'none' },
        };

        var chart = new google.charts.Bar(document.getElementById('ChartClientes'));

        chart.draw(data, google.charts.Bar.convertOptions(options));
    }
     </script>
    
     <div class="container">
      <div id="wrapper">
    <div id="content-wrapper" class="d-flex flex-column">
        <div id="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-xl-3 col-md-6 mb-4">
                        <div class="card border-left-primary shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                            Ingresos (Mes Actual)</div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblingmes" runat="server" ForeColor="DarkGreen" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6 mb-4">
                        <div class="card border-left-success shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-uppercase mb-1">
                                            Ingresos (Anual)</div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblinganual" runat="server" ForeColor="DarkGreen" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6 mb-4">
                        <div class="card border-left-success shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-uppercase mb-1">
                                            Ventas (Ultimo Mes)</div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">
                                            <asp:Label ID="lblordmes" runat="server">N°</asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6 mb-4">
                            <div class="card border-left-success shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-uppercase mb-1">
                                                Ventas (Anual)</div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                                <asp:Label ID="lblordanio" runat="server" Text="N° "></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    <%--Graficos   Graficos--%>

                <div class="row">
                    <!-- Chart -->
                    <div class="col-xl-8 col-lg-16">
                        <div class="card shadow mb-4">
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <a href="~/Gerente/Transacciones.aspx" style="text-decoration:none" runat="server">
                                    <h6 class="m-0 font-weight-bold text-primary">Graficos de los ingresos</h6> 
                                    </a>
                            </div>
                            <div class="card-body">
                                <div class="chart-area">
                                    <div id="ChartIngresos" style="width: 100%; height: 350px;"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Pie Chart -->
                    <div class="col-xl-4 col-lg-4">
                        <div class="card shadow mb-4">
                            <!-- Card Header - Dropdown -->
                            <div
                                class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <a href="~/Gerente/EstadisticasAdmin.aspx" style="text-decoration:none" runat="server">
                                    <h6 class="m-0 font-weight-bold text-primary">TOP Productos</h6>
                                </a>
                               
                            </div>
                            <!-- Card Body -->
                            <div class="card-body">
                                <div class="chart-pie">
                                    <div id="ChartTOP" style="width: 100%; height: 350px"></div>
                                </div>
                               
                            </div>
                        </div>
                    </div>
                    <div class="">
                        <div class="card shadow mb-4">
                            <!-- Card Header - Dropdown -->
                            <div
                                class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <a href="~/Gerente/Clientes.aspx" style="text-decoration:none" runat="server">
                                    <h6 class="m-0 font-weight-bold text-primary">TOP Clientes</h6>
                                </a>
           
                            </div>
                            <!-- Card Body -->
                            <div class="card-body">
                                <div class="chart-area">
                                    <div id="ChartClientes" style="width: 100%; height: 350px"></div>
                                </div>
           
                            </div>
                        </div>
                    </div>
                </div>

  
                </div>
            </div>
        </div>
    </div>
</div>
  
         </div>
</asp:Content>
