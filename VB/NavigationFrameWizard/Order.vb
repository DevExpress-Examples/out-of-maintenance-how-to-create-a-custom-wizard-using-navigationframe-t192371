Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace NavigationFrameWizard
    Public Class Order
        Implements INotifyPropertyChanged

        Protected _Date As Date

        Public Property [Date]() As Date
            Get
                Return Me._Date
            End Get

            Set(ByVal value As Date)
                If Me._Date <> value Then
                    Me._Date = value
                    Me.OnPropertyChanged("Date")
                End If
            End Set
        End Property

        Protected _Description As String

        Public Property Description() As String
            Get
                Return Me._Description
            End Get

            Set(ByVal value As String)
                If Me._Description <> value Then
                    Me._Description = value
                    Me.OnPropertyChanged("Description")
                End If
            End Set
        End Property

        Public Sub OnPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class
End Namespace
