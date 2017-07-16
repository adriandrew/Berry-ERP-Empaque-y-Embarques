Imports System.Data.SqlClient

Public Module BaseDatos

    Private cadenaConexionConfiguracion As String
    Private cadenaConexionCatalogo As String
    Private cadenaConexionEmpaque As String
    Public conexionConfiguracion As New SqlConnection()
    Public conexionCatalogo As New SqlConnection()
    Public conexionEmpaque As New SqlConnection()

    Public Property ECadenaConexionConfiguracion() As String
        Get
            Return BaseDatos.cadenaConexionConfiguracion
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionConfiguracion = value
        End Set
    End Property
    Public Property ECadenaConexionCatalogo() As String
        Get
            Return BaseDatos.cadenaConexionCatalogo
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionCatalogo = value
        End Set
    End Property
    Public Property ECadenaConexionEmpaque() As String
        Get
            Return BaseDatos.cadenaConexionEmpaque
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionEmpaque = value
        End Set
    End Property

    Public Sub AbrirConexionConfiguracion()

        BaseDatos.ECadenaConexionConfiguracion = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", EYELogicaReporteRecepcion.Directorios.instanciaSql, BaseDatos.ECadenaConexionConfiguracion, EYELogicaReporteRecepcion.Directorios.usuarioSql, EYELogicaReporteRecepcion.Directorios.contrasenaSql)
        conexionConfiguracion.ConnectionString = BaseDatos.ECadenaConexionConfiguracion

    End Sub

    Public Sub AbrirConexionCatalogo()

        BaseDatos.ECadenaConexionCatalogo = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", EYELogicaReporteRecepcion.Directorios.instanciaSql, BaseDatos.ECadenaConexionCatalogo, EYELogicaReporteRecepcion.Directorios.usuarioSql, EYELogicaReporteRecepcion.Directorios.contrasenaSql)
        conexionCatalogo.ConnectionString = BaseDatos.ECadenaConexionCatalogo

    End Sub

    Public Sub AbrirConexionEmpaque()

        BaseDatos.ECadenaConexionEmpaque = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", EYELogicaReporteRecepcion.Directorios.instanciaSql, BaseDatos.ECadenaConexionEmpaque, EYELogicaReporteRecepcion.Directorios.usuarioSql, EYELogicaReporteRecepcion.Directorios.contrasenaSql)
        conexionEmpaque.ConnectionString = BaseDatos.ECadenaConexionEmpaque

    End Sub

End Module
