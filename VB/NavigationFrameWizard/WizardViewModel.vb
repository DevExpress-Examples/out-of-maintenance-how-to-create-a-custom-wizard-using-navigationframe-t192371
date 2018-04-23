Imports DevExpress.Mvvm
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace NavigationFrameWizard
    Public Class WizardViewModel
        Inherits ViewModelBase


        Protected Overridable ReadOnly Property CurrentWindowService() As ICurrentWindowService
            Get
                Return Me.GetService(Of ICurrentWindowService)()
            End Get
        End Property

        Protected _Customer As Customer
        Public Property Customer() As Customer
            Get
                If Me._Customer Is Nothing Then
                    Me._Customer = New Customer()
                End If

                Return Me._Customer
            End Get
            Set(ByVal value As Customer)
                Me.SetProperty(Me._Customer, value, "Customer")
            End Set
        End Property


        Protected _DialogResult? As Boolean
        Public Property DialogResult() As Boolean?
            Get
                Return Me._DialogResult
            End Get
            Set(ByVal value? As Boolean)
                Me.SetProperty(Me._DialogResult, value, "DialogResult")
            End Set
        End Property

        #Region "Done"

        Protected _Done As DelegateCommand

        Public ReadOnly Property Done() As DelegateCommand
            Get
                If Me._Done Is Nothing Then
                    Me._Done = New DelegateCommand(AddressOf Me.DoneExecute)
                End If

                Return Me._Done
            End Get
        End Property

        Protected Sub DoneExecute()
            Me.DialogResult = True
            Me.CurrentWindowService.Close()
        End Sub

        #End Region ' Done

        #Region "Cancel"

        Protected _Cancel As DelegateCommand

        Public ReadOnly Property Cancel() As DelegateCommand
            Get
                If Me._Cancel Is Nothing Then
                    Me._Cancel = New DelegateCommand(AddressOf Me.CancelExecute)
                End If

                Return Me._Cancel
            End Get
        End Property

        Protected Sub CancelExecute()
            Me.DialogResult = False
            Me.CurrentWindowService.Close()
        End Sub

        #End Region ' Cancel
    End Class
End Namespace
