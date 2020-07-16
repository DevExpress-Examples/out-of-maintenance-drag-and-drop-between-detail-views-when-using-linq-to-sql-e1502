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
Imports DevExpress.Utils.DragDrop
Imports DevExpress.Utils.Behaviors

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

			behaviorManager1.Attach(Of DragDropBehavior)(gridView1, Sub(behavior)
				behavior.Properties.AllowDrop = True
				behavior.Properties.InsertIndicatorVisible = True
				behavior.Properties.PreviewVisible = True
			End Sub)
		End Sub
		Private Sub categoryGridControl_ViewRegistered(ByVal sender As Object, ByVal e As ViewOperationEventArgs) Handles categoryGridControl.ViewRegistered
			If e.View.IsDetailView Then
				behaviorManager1.Attach(Of DragDropBehavior)(e.View)
			End If
		End Sub

		Private Sub categoryGridControl_ViewRemoved(ByVal sender As Object, ByVal e As ViewOperationEventArgs) Handles categoryGridControl.ViewRemoved
			If e.View.IsDetailView Then
				behaviorManager1.Detach(Of DragDropBehavior)(e.View)
			End If
		End Sub
	End Class
End Namespace