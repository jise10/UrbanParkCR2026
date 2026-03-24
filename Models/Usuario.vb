
Namespace Models
    Public Class Usuario
        Private _idPersona As Integer
        Private _username As String
        Private _passwordHash As String
        Private _rol As String
        Private _activo As Boolean

        Public Sub New()
        End Sub

        Public Property IdPersona As Integer
            Get
                Return _idPersona
            End Get
            Set(value As Integer)
                _idPersona = value
            End Set
        End Property

        Public Property Username As String
            Get
                Return _username
            End Get
            Set(value As String)
                _username = value
            End Set
        End Property

        Public Property PasswordHash As String
            Get
                Return _passwordHash
            End Get
            Set(value As String)
                _passwordHash = value
            End Set
        End Property

        Public Property Rol As String
            Get
                Return _rol
            End Get
            Set(value As String)
                _rol = value
            End Set
        End Property

        Public Property Activo As Boolean
            Get
                Return _activo
            End Get
            Set(value As Boolean)
                _activo = value
            End Set
        End Property
    End Class
End Namespace