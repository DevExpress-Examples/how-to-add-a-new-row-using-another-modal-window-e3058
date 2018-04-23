' Developer Express Code Central Example:
' How to add a new row using another modal window
' 
' The following example demonstrates how to programmatically add a new row to a
' GridControl. To see this approach in action, click the "Add new row..." button,
' fill in three text boxes in the invoked window and click OK.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3058


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
			grid.ItemsSource = list
'			#End Region
		End Sub

		Private Sub addNewRowButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			newRowDialogWindow.DataContext = New TestData()
			newRowDialogWindow.ShowDialog()
		End Sub

		Private Sub OKButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			list.Add(CType(newRowDialogWindow.DataContext, TestData))

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
		Public Property Text1() As String
		Public Property Text2() As String
		Public Property Text3() As String
	End Class
	#End Region
End Namespace
