Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.Xpf.Grid

Namespace Implement_Custom_Sorting
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim months() As String = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }
			grid.DataSource = months
			grid.PopulateColumns()
			grid.SortBy(grid.Columns(0))
		End Sub
		Private Sub checkBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.Columns(0).SortMode = ColumnSortMode.Custom
		End Sub
		Private Sub checkBox_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.Columns(0).SortMode = ColumnSortMode.Default
		End Sub
		Private Sub grid_CustomColumnSort(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
			e.Result = Comparer(Of Integer).Default.Compare(e.ListSourceRowIndex1, e.ListSourceRowIndex2)

			e.Handled = True
		End Sub
	End Class
End Namespace
