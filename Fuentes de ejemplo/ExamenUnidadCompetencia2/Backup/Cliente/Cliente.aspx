<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Cliente.Cliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Obtener Areas"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Circulo</asp:ListItem>
            <asp:ListItem>Triangulo</asp:ListItem>
            <asp:ListItem>Cuadrado</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Valor1"></asp:Label>
        <br />
        <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" 
            Text="Valor2(solo se usa en el triangulo)"></asp:Label>
        <br />
        <asp:TextBox ID="txt2" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Resultado:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblResultado" runat="server" Text="aqui saldra el resultado"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
