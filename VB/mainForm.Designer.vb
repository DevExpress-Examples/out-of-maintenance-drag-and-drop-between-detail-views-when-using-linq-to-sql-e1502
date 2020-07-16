Namespace sampleLinqApp
	Partial Public Class mainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim gridLevelNode1 As New DevExpress.XtraGrid.GridLevelNode()
			Me.gridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colProductID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colProductName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colSupplierID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colCategoryID1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colQuantityPerUnit = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colUnitsInStock = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colUnitsOnOrder = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colReorderLevel = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colDiscontinued = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colCategory = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.categoryGridControl = New DevExpress.XtraGrid.GridControl()
			Me.categoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colCategoryID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colCategoryName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colPicture = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.behaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
			CType(Me.gridView2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.categoryGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.categoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.behaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridView2
			' 
			Me.gridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colProductID, Me.colProductName, Me.colSupplierID, Me.colCategoryID1, Me.colQuantityPerUnit, Me.colUnitPrice, Me.colUnitsInStock, Me.colUnitsOnOrder, Me.colReorderLevel, Me.colDiscontinued, Me.colCategory})
			Me.gridView2.GridControl = Me.categoryGridControl
			Me.gridView2.Name = "gridView2"
			Me.gridView2.OptionsBehavior.Editable = False
			' 
			' colProductID
			' 
			Me.colProductID.FieldName = "ProductID"
			Me.colProductID.Name = "colProductID"
			Me.colProductID.Visible = True
			Me.colProductID.VisibleIndex = 0
			' 
			' colProductName
			' 
			Me.colProductName.FieldName = "ProductName"
			Me.colProductName.Name = "colProductName"
			Me.colProductName.Visible = True
			Me.colProductName.VisibleIndex = 1
			' 
			' colSupplierID
			' 
			Me.colSupplierID.FieldName = "SupplierID"
			Me.colSupplierID.Name = "colSupplierID"
			Me.colSupplierID.Visible = True
			Me.colSupplierID.VisibleIndex = 2
			' 
			' colCategoryID1
			' 
			Me.colCategoryID1.FieldName = "CategoryID"
			Me.colCategoryID1.Name = "colCategoryID1"
			Me.colCategoryID1.Visible = True
			Me.colCategoryID1.VisibleIndex = 3
			' 
			' colQuantityPerUnit
			' 
			Me.colQuantityPerUnit.FieldName = "QuantityPerUnit"
			Me.colQuantityPerUnit.Name = "colQuantityPerUnit"
			Me.colQuantityPerUnit.Visible = True
			Me.colQuantityPerUnit.VisibleIndex = 4
			' 
			' colUnitPrice
			' 
			Me.colUnitPrice.FieldName = "UnitPrice"
			Me.colUnitPrice.Name = "colUnitPrice"
			Me.colUnitPrice.Visible = True
			Me.colUnitPrice.VisibleIndex = 5
			' 
			' colUnitsInStock
			' 
			Me.colUnitsInStock.FieldName = "UnitsInStock"
			Me.colUnitsInStock.Name = "colUnitsInStock"
			Me.colUnitsInStock.Visible = True
			Me.colUnitsInStock.VisibleIndex = 6
			' 
			' colUnitsOnOrder
			' 
			Me.colUnitsOnOrder.FieldName = "UnitsOnOrder"
			Me.colUnitsOnOrder.Name = "colUnitsOnOrder"
			Me.colUnitsOnOrder.Visible = True
			Me.colUnitsOnOrder.VisibleIndex = 7
			' 
			' colReorderLevel
			' 
			Me.colReorderLevel.FieldName = "ReorderLevel"
			Me.colReorderLevel.Name = "colReorderLevel"
			Me.colReorderLevel.Visible = True
			Me.colReorderLevel.VisibleIndex = 8
			' 
			' colDiscontinued
			' 
			Me.colDiscontinued.FieldName = "Discontinued"
			Me.colDiscontinued.Name = "colDiscontinued"
			Me.colDiscontinued.Visible = True
			Me.colDiscontinued.VisibleIndex = 9
			' 
			' colCategory
			' 
			Me.colCategory.FieldName = "Category"
			Me.colCategory.Name = "colCategory"
			Me.colCategory.Visible = True
			Me.colCategory.VisibleIndex = 10
			' 
			' categoryGridControl
			' 
			Me.categoryGridControl.DataSource = Me.categoryBindingSource
			Me.categoryGridControl.Dock = System.Windows.Forms.DockStyle.Fill
			gridLevelNode1.LevelTemplate = Me.gridView2
			gridLevelNode1.RelationName = "Products"
			Me.categoryGridControl.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() { gridLevelNode1})
			Me.categoryGridControl.Location = New System.Drawing.Point(0, 0)
			Me.categoryGridControl.MainView = Me.gridView1
			Me.categoryGridControl.Name = "categoryGridControl"
			Me.categoryGridControl.Size = New System.Drawing.Size(784, 562)
			Me.categoryGridControl.TabIndex = 1
			Me.categoryGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1, Me.gridView2})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.categoryGridControl.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.categoryGridControl_ViewRegistered);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.categoryGridControl.ViewRemoved += new DevExpress.XtraGrid.ViewOperationEventHandler(this.categoryGridControl_ViewRemoved);
			' 
			' categoryBindingSource
			' 
			Me.categoryBindingSource.DataSource = GetType(sampleLinqApp.Category)
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colCategoryID, Me.colCategoryName, Me.colDescription, Me.colPicture})
			Me.gridView1.GridControl = Me.categoryGridControl
			Me.gridView1.Name = "gridView1"
			' 
			' colCategoryID
			' 
			Me.colCategoryID.FieldName = "CategoryID"
			Me.colCategoryID.Name = "colCategoryID"
			Me.colCategoryID.Visible = True
			Me.colCategoryID.VisibleIndex = 0
			' 
			' colCategoryName
			' 
			Me.colCategoryName.FieldName = "CategoryName"
			Me.colCategoryName.Name = "colCategoryName"
			Me.colCategoryName.Visible = True
			Me.colCategoryName.VisibleIndex = 1
			' 
			' colDescription
			' 
			Me.colDescription.FieldName = "Description"
			Me.colDescription.Name = "colDescription"
			Me.colDescription.Visible = True
			Me.colDescription.VisibleIndex = 2
			' 
			' colPicture
			' 
			Me.colPicture.FieldName = "Picture"
			Me.colPicture.Name = "colPicture"
			Me.colPicture.Visible = True
			Me.colPicture.VisibleIndex = 3
			' 
			' mainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(784, 562)
			Me.Controls.Add(Me.categoryGridControl)
			Me.Name = "mainForm"
			Me.Text = "mainForm"
			CType(Me.gridView2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.categoryGridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.categoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.behaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private categoryBindingSource As System.Windows.Forms.BindingSource
		Private WithEvents categoryGridControl As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private colCategoryID As DevExpress.XtraGrid.Columns.GridColumn
		Private colCategoryName As DevExpress.XtraGrid.Columns.GridColumn
		Private colDescription As DevExpress.XtraGrid.Columns.GridColumn
		Private colPicture As DevExpress.XtraGrid.Columns.GridColumn
		Private gridView2 As DevExpress.XtraGrid.Views.Grid.GridView
		Private colProductID As DevExpress.XtraGrid.Columns.GridColumn
		Private colProductName As DevExpress.XtraGrid.Columns.GridColumn
		Private colSupplierID As DevExpress.XtraGrid.Columns.GridColumn
		Private colCategoryID1 As DevExpress.XtraGrid.Columns.GridColumn
		Private colQuantityPerUnit As DevExpress.XtraGrid.Columns.GridColumn
		Private colUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
		Private colUnitsInStock As DevExpress.XtraGrid.Columns.GridColumn
		Private colUnitsOnOrder As DevExpress.XtraGrid.Columns.GridColumn
		Private colReorderLevel As DevExpress.XtraGrid.Columns.GridColumn
		Private colDiscontinued As DevExpress.XtraGrid.Columns.GridColumn
		Private colCategory As DevExpress.XtraGrid.Columns.GridColumn
		Private behaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
	End Class
End Namespace