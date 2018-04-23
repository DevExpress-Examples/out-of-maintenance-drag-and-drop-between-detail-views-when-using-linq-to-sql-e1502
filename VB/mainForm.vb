Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports System.Data.Linq
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports System.Collections

Namespace sampleLinqApp
	Partial Public Class mainForm
		Inherits DevExpress.XtraEditors.XtraForm
		Private context As New northwindDataContext()
		Private Sub DataBind()
			context.DeferredLoadingEnabled = False

			Dim options As New DataLoadOptions()
			options.LoadWith(Of Category)(Function(c) c.Products)

			context.LoadOptions = options
			categoryBindingSource.DataSource = context.Categories
		End Sub
		Public Sub New()
			InitializeComponent()
			DataBind()
		End Sub

		Private dragRect As New Rectangle(Point.Empty, SystemInformation.DragSize)
		Private dragRowHandle As Integer = GridControl.InvalidRowHandle
		Private masterRowHandle As Integer = GridControl.InvalidRowHandle
		Private timerRowHandle As Integer = GridControl.InvalidRowHandle

		Private Sub OnChildViewMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridView2.MouseMove
			If e.Button <> MouseButtons.Left OrElse dragRect.Location = Point.Empty OrElse dragRect.Contains(e.Location) OrElse dragRowHandle = GridControl.InvalidRowHandle Then
				Return
			End If
			Dim view As GridView = CType(sender, GridView)
			view.GridControl.DoDragDrop(New Integer() { dragRowHandle, view.SourceRowHandle }, DragDropEffects.Move)
			dragRect.Location = Point.Empty
			dragRowHandle = GridControl.InvalidRowHandle
			dragTimer.Start()
		End Sub

		Private Sub OnChildViewMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridView2.MouseDown
			If e.Button <> MouseButtons.Left Then
				Return
			End If
			Dim hInfo As GridHitInfo = (CType(sender, GridView)).CalcHitInfo(e.Location)
			If (Not hInfo.InRowCell) Then
				Return
			End If
			dragRowHandle = hInfo.RowHandle
			dragRect.Location = e.Location
			dragRect.Location.Offset(-CInt(Fix(Math.Round(CDbl(SystemInformation.DragSize.Width \ 2)))), -CInt(Fix(Math.Round(CDbl(SystemInformation.DragSize.Height \ 2)))))
		End Sub

		Private Sub OnChildViewMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridView2.MouseUp
			dragRect.Location = Point.Empty
			dragRowHandle = GridControl.InvalidRowHandle
			masterRowHandle = GridControl.InvalidRowHandle
			timerRowHandle = GridControl.InvalidRowHandle
			dragTimer.Stop()
		End Sub

		Private Sub OnDragTimerTick(ByVal sender As Object, ByVal e As EventArgs) Handles dragTimer.Tick
			If masterRowHandle = GridControl.InvalidRowHandle Then
				timerRowHandle = GridControl.InvalidRowHandle
				Return
			End If
			If masterRowHandle = timerRowHandle Then
				gridView1.SetMasterRowExpanded(masterRowHandle, True)
				timerRowHandle = GridControl.InvalidRowHandle
				masterRowHandle = GridControl.InvalidRowHandle
			Else
				timerRowHandle = masterRowHandle
			End If
		End Sub

		Private Sub OnGridControlDragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles categoryGridControl.DragOver
			Dim grid As GridControl = CType(sender, GridControl)
			Dim mousePosition As Point = grid.PointToClient(Control.MousePosition)
			Dim view As GridView = CType(grid.GetViewAt(mousePosition), GridView)
			If view IsNot Nothing Then
				If view.IsDetailView AndAlso view.CalcHitInfo(mousePosition).InRowCell Then
					e.Effect = DragDropEffects.Move
					If dragTimer.Enabled Then
						dragTimer.Stop()
					End If
				Else
					e.Effect = DragDropEffects.None
					If (Not dragTimer.Enabled) Then
						dragTimer.Start()
					End If
					Dim hInfo As GridHitInfo = view.CalcHitInfo(mousePosition)
					If hInfo.InRowCell Then
						If (Not view.GetMasterRowExpanded(hInfo.RowHandle)) Then
							masterRowHandle = hInfo.RowHandle
						Else
							masterRowHandle = GridControl.InvalidRowHandle
						End If
					Else
						masterRowHandle = GridControl.InvalidRowHandle
					End If
				End If
			End If
		End Sub

		Private Sub OnGridControlDragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles categoryGridControl.DragDrop
			If e.Effect = DragDropEffects.Move Then
				Dim grid As GridControl = CType(sender, GridControl)
				Dim mousePosition As Point = grid.PointToClient(Control.MousePosition)
				Dim view As GridView = CType(grid.GetViewAt(mousePosition), GridView)
				Dim hInfo As GridHitInfo = view.CalcHitInfo(mousePosition)
				Dim data() As Integer = CType(e.Data.GetData(GetType(Integer())), Integer())
				Dim sourceView As GridView = CType((CType(grid.MainView, GridView)).GetDetailView(data(1), 0), GridView)
				Dim dragRow As Product = CType(sourceView.GetRow(data(0)), Product)
				CType(sourceView.DataSource, IList(Of Product)).Remove(dragRow)
				CType(view.DataSource, IList(Of Product)).Add(dragRow)
				Dim sourceRowHandle As Integer = view.SourceRowHandle
			End If
			dragTimer.Stop()
			masterRowHandle = GridControl.InvalidRowHandle
			timerRowHandle = GridControl.InvalidRowHandle
		End Sub
	End Class
End Namespace