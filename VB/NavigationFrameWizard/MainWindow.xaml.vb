Imports DevExpress.Mvvm
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace NavigationFrameWizard
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits DevExpress.Xpf.Core.DXWindow

        Public Sub New()
            InitializeComponent()
            Me.DataContext = Me
        End Sub

        Protected _Customers As ObservableCollection(Of Customer)

        Public ReadOnly Property Customers() As ObservableCollection(Of Customer)
            Get
                If Me._Customers Is Nothing Then
                    Me._Customers = New ObservableCollection(Of Customer)()
                    Me._Customers.Add(New Customer() With {.FirstName = "John", .SecondName = "Newman", .Birthday = Date.Today.AddYears(-40)})
                    Me._Customers.Add(New Customer() With {.FirstName = "Mark", .SecondName = "Bisho", .Birthday = Date.Today.AddYears(-35)})
                End If

                Return Me._Customers
            End Get
        End Property

        #Region "AddCommand"

        Protected _AddCommand As DelegateCommand

        Public ReadOnly Property AddCommand() As DelegateCommand
            Get
                If Me._AddCommand Is Nothing Then
                    Me._AddCommand = New DelegateCommand(AddressOf Me.AddCommandExecute, AddressOf Me.AddCommandCanExecute)
                End If

                Return Me._AddCommand
            End Get
        End Property

        Protected Sub AddCommandExecute()
            Dim wnd As New WizardWindow()
            wnd.Owner = Me
            wnd.ShowDialog()
            If CType(wnd.Tag, Boolean?).HasValue AndAlso CType(wnd.Tag, Boolean?).Value Then
                Me.Customers.Add((TryCast(wnd.DataContext, WizardViewModel)).Customer)
            End If
        End Sub

        Protected Function AddCommandCanExecute() As Boolean
            Dim result As Boolean = True
            ' Enter your checking of availability of comand here
            Return result
        End Function

        #End Region ' AddCommand
    End Class
End Namespace
