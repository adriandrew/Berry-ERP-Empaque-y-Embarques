Imports System.IO
Imports FarPoint.Win.Spread
Imports System.Reflection
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text

Public Class Correos

    Public nombreEstePrograma As String = String.Empty 
    Public proveedores As New EYEEntidadesEmbarques.ProveedoresCorreo()
    Public configuracion As New EYEEntidadesEmbarques.ConfiguracionCorreo()
    Public correos As New EYEEntidadesEmbarques.Correos()
    Public tieneDatos As Boolean = False
    Public archivoAdjunto As Attachment
    Public correo As New MailMessage()
    Public colorVerde As New Color
    Public colorRojo As New Color
    Public colorTransparente As New Color

#Region "Eventos"

    Private Sub Correos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Centrar()
        CargarNombrePrograma()
        CargarColores()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Correos_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.WaitCursor
        CargarTitulosDirectorio()
        CargarComboProveedores()
        CargarConfiguracion()
        FormatearSpread()
        CargarCorreos()
        FormatearSpreadCorreos()
        txtDireccion.Focus()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Correos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Cursor = Cursors.WaitCursor
        Salir()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub

#End Region

#Region "Métodos"

    Private Sub Salir()

        correo.Dispose()
        Documentos.EliminarArchivosTemporales()
        Principal.pnlContenido.Enabled = True

    End Sub

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Opacity = 0.98
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub CargarNombrePrograma()

        Me.nombreEstePrograma = Me.Text

    End Sub

    Private Sub CargarTitulosDirectorio()

        Me.Text = "Programa:  " & Me.nombreEstePrograma & "              Directorio:  " & EYELogicaEmbarques.Directorios.nombre & "              Usuario:  " & EYELogicaEmbarques.Usuarios.nombre

    End Sub

    Private Sub CargarColores()

        Me.colorRojo = Color.OrangeRed
        Me.colorVerde = Color.LightGreen
        Me.colorTransparente = Color.Transparent

    End Sub
     
    Private Sub FormatearSpread()

        spCorreos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCorreos.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpreadDocumentos, FontStyle.Regular)
        spCorreos.ActiveSheet.GrayAreaBackColor = Color.White
        spCorreos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCorreos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
    End Sub

    Private Sub FormatearSpreadCorreos()
         
        spCorreos.ActiveSheet.ColumnHeader.Rows(0, spCorreos.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spCorreos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spCorreos.ActiveSheet.Columns.Count += 1
        Dim numeracion As Integer = 0
        spCorreos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCorreos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCorreos.ActiveSheet.Columns(numeracion).Tag = "direccion" : numeracion += 1
        spCorreos.ActiveSheet.Columns(numeracion).Tag = "seleccionar" : numeracion += 1
        spCorreos.ActiveSheet.Columns.Count = numeracion
        spCorreos.ActiveSheet.Columns("id").Width = 70
        spCorreos.ActiveSheet.Columns("nombre").Width = 300
        spCorreos.ActiveSheet.Columns("direccion").Width = 300
        spCorreos.ActiveSheet.Columns("seleccionar").Width = 130
        spCorreos.ActiveSheet.Columns("id").CellType = Principal.tipoEntero
        spCorreos.ActiveSheet.Columns("nombre").CellType = Principal.tipoTexto
        spCorreos.ActiveSheet.Columns("direccion").CellType = Principal.tipoTexto
        spCorreos.ActiveSheet.Columns("seleccionar").CellType = Principal.tipoBooleano  
        spCorreos.ActiveSheet.ColumnHeader.Cells(0, spCorreos.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper()
        spCorreos.ActiveSheet.ColumnHeader.Cells(0, spCorreos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper()
        spCorreos.ActiveSheet.ColumnHeader.Cells(0, spCorreos.ActiveSheet.Columns("direccion").Index).Value = "Correo".ToUpper()
        spCorreos.ActiveSheet.ColumnHeader.Cells(0, spCorreos.ActiveSheet.Columns("seleccionar").Index).Value = "Seleccionar".ToUpper()
        spCorreos.Refresh()

    End Sub

    Private Sub CargarComboProveedores()

        Dim datos As New DataTable
        proveedores.EId = 0
        datos = proveedores.ObtenerListado()
        cbProveedores.DataSource = datos
        cbProveedores.ValueMember = "Id"
        cbProveedores.DisplayMember = "Dominio"

    End Sub

    Private Sub CargarCorreos()
         
        spCorreos.ActiveSheet.DataSource = correos.ObtenerListado()
        FormatearSpreadCorreos()

    End Sub

    Private Sub CargarConfiguracion()

        Dim datos As New DataTable
        datos = configuracion.ObtenerListado()
        If (datos.Rows.Count > 0) Then
            txtDireccion.Text = datos.Rows(0).Item("Direccion")
            txtContrasena.Text = datos.Rows(0).Item("Contrasena")
            txtAsunto.Text = datos.Rows(0).Item("Asunto")
            txtMensaje.Text = datos.Rows(0).Item("Mensaje")
            cbProveedores.SelectedValue = datos.Rows(0).Item("IdProveedor")
            Me.tieneDatos = True
        Else
            Me.tieneDatos = False
        End If

    End Sub

    Private Sub GuardarConfiguracion()

        Dim direccion As String = txtDireccion.Text
        Dim contrasena As String = String.Empty
        If (chkRecordar.Checked) Then
            contrasena = txtContrasena.Text
        End If
        Dim asunto As String = txtAsunto.Text
        Dim mensaje As String = txtMensaje.Text
        Dim idProveedor As Integer = cbProveedores.SelectedValue
        If ((Not String.IsNullOrEmpty(direccion)) And (Not String.IsNullOrEmpty(contrasena)) And (idProveedor > 0)) Then
            configuracion.EDireccion = direccion
            configuracion.EContrasena = contrasena
            configuracion.EAsunto = asunto
            configuracion.EMensaje = mensaje
            configuracion.EIdProveedor = idProveedor
            If (Me.tieneDatos) Then
                configuracion.Editar()
            Else
                configuracion.Guardar()
            End If 
            CargarConfiguracion()
        End If

    End Sub

    Private Sub EnviarCorreos()

        Dim direccion As String = EYELogicaEmbarques.Funciones.ValidarLetra(txtDireccion.Text)
        Dim dominio As String = EYELogicaEmbarques.Funciones.ValidarLetra(cbProveedores.Text)
        Dim contrasena As String = EYELogicaEmbarques.Funciones.ValidarLetra(txtContrasena.Text)
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Dim asunto As String = EYELogicaEmbarques.Funciones.ValidarLetra(txtAsunto.Text).Trim
        asunto = IIf(String.IsNullOrEmpty(asunto), "Documentos embarque no. " & idEmbarque, asunto)
        Dim mensaje As String = EYELogicaEmbarques.Funciones.ValidarLetra(txtMensaje.Text)
        Dim emisor As String = direccion & dominio '"aaandrewlopez@gmail.com" 
        Dim mensajePlano As String = String.Empty
        Dim mensajeHtml As String = String.Empty
        Dim idProveedor As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbProveedores.SelectedValue)
        Dim datosProveedores As New DataTable
        proveedores.EId = idProveedor
        datosProveedores = proveedores.ObtenerListado()
        Dim servidorProveedor As String = datosProveedores.Rows(0).Item("Servidor") '"smtp.gmail.com"
        Dim puerto As Integer = datosProveedores.Rows(0).Item("Puerto") '587 
        correo.From = New MailAddress(emisor)
        correo.Priority = MailPriority.High
        For fila As Integer = 0 To spCorreos.ActiveSheet.Rows.Count - 1
            Dim seleccionado As Boolean = spCorreos.ActiveSheet.Cells(fila, spCorreos.ActiveSheet.Columns("seleccionar").Index).Value
            If (seleccionado) Then
                Dim destino As String = spCorreos.ActiveSheet.Cells(fila, spCorreos.ActiveSheet.Columns("direccion").Index).Text
                correo.To.Add(destino)
            End If
        Next
        ' Se crean los mensajes planos y htmls. 
        mensajePlano = mensaje
        mensajeHtml = "<p>" & mensaje & "</p>"
        correo.Subject = asunto
        correo.Body = mensajePlano
        ' Creamos la vista para clientes que sólo pueden acceder a texto plano.
        Dim vistaPlana As AlternateView = AlternateView.CreateAlternateViewFromString(mensajePlano, Encoding.UTF8, MediaTypeNames.Text.Plain)
        ' Ahora creamos la vista para clientes que pueden mostrar contenido HTML.
        Dim vistaHtml As AlternateView = AlternateView.CreateAlternateViewFromString(mensajeHtml, Encoding.UTF8, MediaTypeNames.Text.Html) 
        ' Por último, vinculamos ambas vistas al mensaje.
        correo.AlternateViews.Add(vistaPlana)
        correo.AlternateViews.Add(vistaHtml)
        Dim servidor As New SmtpClient(servidorProveedor)
        servidor.UseDefaultCredentials = False
        servidor.Port = puerto
        servidor.Credentials = New System.Net.NetworkCredential(emisor, contrasena)
        servidor.EnableSsl = True
        Try
            servidor.Send(correo)
            'notificador.BalloonTipText = "Notificaciones enviadas por correo!"
            'notificador.BalloonTipIcon = ToolTipIcon.Info
            'notificador.ShowBalloonTip(5)
            MsgBox("Correos enviados correctamente.", MsgBoxStyle.ApplicationModal, "Finalizado.")
        Catch ex As Exception
            'notificador.BalloonTipText = "Error al enviar notificaciones por correo. " & ex.Message
            'notificador.BalloonTipIcon = ToolTipIcon.Error
            'notificador.ShowBalloonTip(5)
            MsgBox(String.Format("Correos no enviados.{0}{0}{1}", vbNewLine, ex.Message), MsgBoxStyle.ApplicationModal, "Error.")
        End Try

    End Sub

    Private Sub EliminarAdjuntos()

        ' Se borran los archivos adjuntados.
        While correo.Attachments.Count > 0
            correo.Attachments.RemoveAt(0)
        End While 

    End Sub

    Private Sub Adjuntar()

        btnAdjuntar.Enabled = False
        btnEnviar.Enabled = False
        EliminarAdjuntos()
        ' Se carga la ruta.
        Documentos.CargarRutaDocumentos()
        ' Manifiesto.
        If (chkManifiesto.Checked) Then
            Documentos.opcionSeleccionada = Documentos.OpcionDocumento.manifiesto
            Documentos.GenerarManifiesto()
            Documentos.Imprimir(True, False)
            Try
                archivoAdjunto = New Attachment(Documentos.rutaAdjuntar)
                correo.Attachments.Add(archivoAdjunto)
                chkManifiesto.BackColor = Me.colorVerde
            Catch ex As Exception
                archivoAdjunto = Nothing
                chkManifiesto.BackColor = Me.colorRojo
            End Try
        Else
            chkManifiesto.BackColor = Me.colorTransparente
        End If
        ' Remision. 
        If (chkRemision.Checked) Then
            Documentos.opcionSeleccionada = Documentos.OpcionDocumento.remision
            Documentos.GenerarRemision()
            Documentos.Imprimir(True, False)
            Try
                archivoAdjunto = New Attachment(Documentos.rutaAdjuntar)
                correo.Attachments.Add(archivoAdjunto)
                chkRemision.BackColor = Me.colorVerde
            Catch ex As Exception
                archivoAdjunto = Nothing
                chkRemision.BackColor = Me.colorRojo
            End Try
        Else
            chkRemision.BackColor = Me.colorTransparente
        End If
        ' Distribucion. 
        If (chkDistribucion.Checked) Then
            Documentos.opcionSeleccionada = Documentos.OpcionDocumento.distribucion
            Documentos.GenerarDistribucion()
            Documentos.Imprimir(True, False)
            Try
                archivoAdjunto = New Attachment(Documentos.rutaAdjuntar)
                correo.Attachments.Add(archivoAdjunto)
                chkDistribucion.BackColor = Me.colorVerde
            Catch ex As Exception
                archivoAdjunto = Nothing
                chkDistribucion.BackColor = Me.colorRojo
            End Try
        Else
            chkDistribucion.BackColor = Me.colorTransparente
        End If
        ' Responsiva. 
        If (chkResponsiva.Checked) Then
            Documentos.opcionSeleccionada = Documentos.OpcionDocumento.responsiva
            Documentos.GenerarResponsiva()
            Documentos.Imprimir(True, False)
            Try
                archivoAdjunto = New Attachment(Documentos.rutaAdjuntar)
                correo.Attachments.Add(archivoAdjunto)
                chkResponsiva.BackColor = Me.colorVerde
            Catch ex As Exception
                archivoAdjunto = Nothing
                chkResponsiva.BackColor = Me.colorRojo
            End Try
        Else
            chkResponsiva.BackColor = Me.colorTransparente
        End If
        ' Sellos. 
        If (chkSellos.Checked) Then
            Documentos.opcionSeleccionada = Documentos.OpcionDocumento.sellos
            Documentos.GenerarSellos()
            Documentos.Imprimir(True, False)
            Try
                archivoAdjunto = New Attachment(Documentos.rutaAdjuntar)
                correo.Attachments.Add(archivoAdjunto)
                chkSellos.BackColor = Me.colorVerde
            Catch ex As Exception
                archivoAdjunto = Nothing
                chkSellos.BackColor = Me.colorRojo
            End Try
        Else
            chkSellos.BackColor = Me.colorTransparente
        End If
        ' Precos. 
        If (chkPrecos.Checked) Then
            Documentos.opcionSeleccionada = Documentos.OpcionDocumento.precos
            Documentos.GenerarPrecos()
            Documentos.Imprimir(True, False)
            Try
                archivoAdjunto = New Attachment(Documentos.rutaAdjuntar)
                correo.Attachments.Add(archivoAdjunto)
                chkPrecos.BackColor = Me.colorVerde
            Catch ex As Exception
                archivoAdjunto = Nothing
                chkPrecos.BackColor = Me.colorRojo
            End Try
        Else
            chkPrecos.BackColor = Me.colorTransparente
        End If
        btnAdjuntar.Enabled = True
        btnEnviar.Enabled = True
        MsgBox("Archivos adjuntados finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")

    End Sub

#End Region

#Region "Enumeraciones"
     
#End Region

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Me.Cursor = Cursors.WaitCursor
        EnviarCorreos()
        GuardarConfiguracion()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click

        Me.Cursor = Cursors.WaitCursor
        Adjuntar()
        Me.Cursor = Cursors.Default

    End Sub

End Class