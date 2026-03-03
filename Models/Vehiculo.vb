Namespace Models
    Public Class Vehiculo

        Private _placa As String
        Private _tipo As String
        Private _marca As String
        Private _color As String
        Private _horaEntrada As Date
        Private _horaSalida As Date

        Public Property Estado As String

        Public Property IdEspacio As Integer


        ' Constructores de la clase Vehiculo
        Public Sub New()
        End Sub

        Public Sub New(placa As String, tipo As String, marca As String, color As String)
            Me.Placa = placa
            Me.Tipo = tipo
            Me.Marca = marca
            Me.Color = color
            Me.HoraEntrada = Date.Now
        End Sub

        Public Sub New(placa As String, tipo As String)
            Me.Placa = placa
            Me.Tipo = tipo
        End Sub



        Public Property Placa As String
            Get
                Return _placa
            End Get
            Set(value As String)
                _placa = value
            End Set
        End Property

        Public Property Tipo As String
            Get
                Return _tipo
            End Get
            Set(value As String)
                _tipo = value
            End Set
        End Property

        Public Property Marca As String
            Get
                Return _marca
            End Get
            Set(value As String)
                _marca = value
            End Set
        End Property

        Public Property Color As String
            Get
                Return _color
            End Get
            Set(value As String)
                _color = value
            End Set
        End Property

        Public Property HoraEntrada As Date
            Get
                Return _horaEntrada
            End Get
            Set(value As Date)
                _horaEntrada = value
            End Set
        End Property

        Public Property HoraSalida As Date?
            Get
                Return _horaSalida
            End Get
            Set(value As Date?)
                _horaSalida = value
            End Set
        End Property

    End Class
End Namespace
