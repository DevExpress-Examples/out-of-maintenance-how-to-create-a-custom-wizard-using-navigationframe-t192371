Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace NavigationFrameWizard
    Public Class Customer
        Implements INotifyPropertyChanged


        Protected _FirstName As String

        Public Property FirstName() As String
            Get
                Return Me._FirstName
            End Get

            Set(ByVal value As String)
                If Me._FirstName <> value Then
                    Me._FirstName = value
                    Me.OnPropertyChanged("FirstName")
                End If
            End Set
        End Property


        Protected _SecondName As String

        Public Property SecondName() As String
            Get
                Return Me._SecondName
            End Get

            Set(ByVal value As String)
                If Me._SecondName <> value Then
                    Me._SecondName = value
                    Me.OnPropertyChanged("SecondName")
                End If
            End Set
        End Property


        Protected _Birthday As Date

        Public Property Birthday() As Date
            Get
                Return Me._Birthday
            End Get

            Set(ByVal value As Date)
                If Me._Birthday <> value Then
                    Me._Birthday = value
                    Me.OnPropertyChanged("Birthday")
                End If
            End Set
        End Property

        Protected _Orders As ObservableCollection(Of Order)

        Public ReadOnly Property Orders() As ObservableCollection(Of Order)
            Get
                If Me._Orders Is Nothing Then
                    Me._Orders = New ObservableCollection(Of Order)()
                End If

                Return Me._Orders
            End Get
        End Property

        Public Sub OnPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class
End Namespace
