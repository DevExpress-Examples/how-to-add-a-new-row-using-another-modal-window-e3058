Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Core


Namespace _1008___NewRowViaModalWindow
	Partial Public Class MainPage
		Inherits UserControl
		Private list As ObservableCollection(Of TestData)

		Public Sub New()
			InitializeComponent()

'			#Region "Fill the GridControl with data"
			list = New ObservableCollection(Of TestData)()
			For i As Integer = 0 To 4
				list.Add(New TestData() With {.Text1 = Guid.NewGuid().ToString(), .Text2 = "text2 " & i, .Text3 = "text3 " & i})
			Next i
			grid.DataSource = list
'			#End Region
		End Sub

		Private Sub addNewRowButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			ClearNewRowDialogWindow()
			newRowDialogWindow.ShowDialog()
		End Sub

		Private Sub ClearNewRowDialogWindow()
			text1.Text = ""
			text2.Text = ""
			text3.Text = ""
		End Sub

		Private Sub OKButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim newRow As New TestData() With {.Text1 = text1.Text, .Text2 = text2.Text, .Text3 = text3.Text}
			list.Add(newRow)

			view.MoveFocusedRow(grid.GetRowVisibleIndexByHandle (grid.GetRowHandleByVisibleIndex(list.Count - 1)))

			grid.Focus()

			newRowDialogWindow.Hide()
		End Sub

		Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			newRowDialogWindow.Hide()
		End Sub
	End Class

	#Region "Test data"
	Public Class TestData
		Private privateText1 As String
		Public Property Text1() As String
			Get
				Return privateText1
			End Get
			Set(ByVal value As String)
				privateText1 = value
			End Set
		End Property
		Private privateText2 As String
		Public Property Text2() As String
			Get
				Return privateText2
			End Get
			Set(ByVal value As String)
				privateText2 = value
			End Set
		End Property
		Private privateText3 As String
		Public Property Text3() As String
			Get
				Return privateText3
			End Get
			Set(ByVal value As String)
				privateText3 = value
			End Set
		End Property
	End Class
	#End Region
End Namespace
