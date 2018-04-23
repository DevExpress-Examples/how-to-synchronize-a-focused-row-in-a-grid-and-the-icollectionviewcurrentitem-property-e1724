Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Documents
Imports DevExpress.Xpf.Grid

Namespace DXGrid_FocusedRow
	Partial Public Class Window1
		Inherits Window
		Private source As CollectionViewSource
		Public Sub New()

			InitializeComponent()

			Dim list As New List(Of TestData)()
			For i As Integer = 0 To 99
				list.Add(New TestData() With {.Number1 = i, .Number2 = i * 10, .Text1 = "row " & i, .Text2 = "ROW " & i})
			Next i
			Dim columnCount As Integer = grid.Columns.Count

			source = New CollectionViewSource() With {.Source = list}
			AddHandler source.View.CurrentChanged, AddressOf CollectionView_CurrentChanged
			AddHandler view.FocusedRowChanged, AddressOf GridView_FocusedRowChanged
			grid.ItemsSource = list
			listBox.ItemsSource = source.View

		End Sub
		Private Sub GridView_FocusedRowChanged(ByVal sender As Object, ByVal e As FocusedRowChangedEventArgs)
			source.View.MoveCurrentTo(grid.GetRow(view.FocusedRowHandle))
		End Sub
		Private Sub CollectionView_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			view.FocusedRowHandle = grid.GetRowHandleByListIndex(source.View.CurrentPosition)
		End Sub
	End Class

	Public Class TestData
		Private privateNumber1 As Integer
		Public Property Number1() As Integer
			Get
				Return privateNumber1
			End Get
			Set(ByVal value As Integer)
				privateNumber1 = value
			End Set
		End Property
		Private privateNumber2 As Integer
		Public Property Number2() As Integer
			Get
				Return privateNumber2
			End Get
			Set(ByVal value As Integer)
				privateNumber2 = value
			End Set
		End Property
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
	End Class
End Namespace
