<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebCounter1.WebForm1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center;">
        OBLICZANIE CAŁKI
    </div>
    <div style="width:100%;">
        <div style="width:50%; float:left;">
            <asp:Label ID="odLabel" runat="server" style="margin:auto 10px auto 10px" BorderStyle="Ridge" >od(oś OX):</asp:Label>
            <asp:TextBox ID="odX" runat="server" style="margin:10px 10px auto auto;" Height="16px" Width="85px"></asp:TextBox>
        
            <asp:Label ID="Label1" runat="server" style="margin:auto 10px auto 10px" BorderStyle="Ridge" >
                do(oś OX):</asp:Label>
            <asp:TextBox ID="doX" runat="server" style="margin:10px 10px auto auto;" Height="16px" Width="85px"></asp:TextBox>
               
            <br /><br />

            <asp:Label ID="Label2" runat="server" style="margin:auto 10px auto 10px" BorderStyle="Ridge" >od(oś OY):</asp:Label>
            <asp:TextBox ID="odY" runat="server" style="margin:10px 10px auto auto;" Height="16px" Width="85px"></asp:TextBox>
        
            <asp:Label ID="Label3" runat="server" style="margin:auto 10px auto 10px" BorderStyle="Ridge" >do(oś OY):</asp:Label>
            <asp:TextBox ID="doY" runat="server" style="margin:10px 10px auto auto;" Height="16px" Width="85px"></asp:TextBox>
        
        </div>
        <div style="width:50%; float:left;">
            <asp:Label ID="Label4" runat="server" style="margin:auto 10px auto 10px" BorderStyle="Ridge" >dokładność:</asp:Label>            
            <asp:TextBox ID="dokladnoscBox" runat="server" style="margin:10px 10px auto auto;" Height="16px" Width="50px"></asp:TextBox>
        
            <asp:CheckBox ID="checkBoxParallel" runat="server" style="margin-left:10px;" Text="obliczanie równoległe"/>
            
            <br/><br />
            <asp:Label ID="Label5" runat="server" style="margin:auto 10px auto 10px" BorderStyle="Ridge" >metoda:</asp:Label>            
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                 <asp:ListItem Text = "Metoda trapezów" Value="0" />
                 <asp:ListItem Text = "Metoda Monte Carlo I" Value="1" />
                 <asp:ListItem Text = "Metoda Monte Carlo II" Value="2" />
            </asp:DropDownList>

            <asp:Label ID="lprzedzLabel" runat="server" style="margin:auto 10px auto 10px" BorderStyle="Ridge" >liczba przedziałów:</asp:Label>            
            <asp:TextBox ID="lprzedzTextBox" runat="server" style="margin:10px 10px auto auto;" Height="16px" Width="50px"></asp:TextBox>

        </div>

        <br/><br/>
        <br/><br/>


        <div style="margin-top:5%">
            <asp:Button ID="CountButton" runat="server" Text="Oblicz" style="margin:auto; margin-right:auto; display: block; width: 50px;" OnClick="Count_Button"/>
        </div>

        <div style="width: 100%; text-align:center; margin-top:5%">
            <div style="width:33%; float:left;">
                wynik:<asp:Label ID="resultLabel" runat="server" Text="0.0" style="margin: auto 10px"></asp:Label>
            </div>
            <div style="width:33%; float:left;">
                czas:<asp:Label ID="timeLabel" runat="server" Text="0:0" style="margin: auto 10px"></asp:Label>
            </div>
            <div style="width:33%; float:left;">
                error:<asp:Label ID="errorLabel" runat="server" Text="0.0" style="margin: auto 10px"></asp:Label>
            </div>
        </div>

        <div style="margin-left:40.5%; margin-right:auto; display: block; width:24%">
            <asp:Chart ID="SinusChart" runat="server">
            <series>
                <asp:Series Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        </div>

    </div>
        
    </form>
</body>
</html>
