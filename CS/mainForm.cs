using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Collections;
using DevExpress.Utils.DragDrop;
using DevExpress.Utils.Behaviors;

namespace sampleLinqApp
{
    public partial class mainForm : DevExpress.XtraEditors.XtraForm
    {
        northwindDataContext context = new northwindDataContext();
        private void DataBind()
        {
            context.DeferredLoadingEnabled = false;

            DataLoadOptions options = new DataLoadOptions();
            options.LoadWith<Category>(c=>c.Products);

            context.LoadOptions = options;
            categoryBindingSource.DataSource = context.Categories;
        }
        public mainForm() {
            InitializeComponent();
            DataBind();

            behaviorManager1.Attach<DragDropBehavior>(gridView1, behavior => {
                behavior.Properties.AllowDrop = true;
                behavior.Properties.InsertIndicatorVisible = true;
                behavior.Properties.PreviewVisible = true;
            });
        }
        private void categoryGridControl_ViewRegistered(object sender, ViewOperationEventArgs e) {
            if(e.View.IsDetailView) 
                behaviorManager1.Attach<DragDropBehavior>(e.View);
        }

        private void categoryGridControl_ViewRemoved(object sender, ViewOperationEventArgs e) {
            if(e.View.IsDetailView) 
                behaviorManager1.Detach<DragDropBehavior>(e.View);
        }
    }
}