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
        public mainForm()
        {
            InitializeComponent();
            DataBind();
        }

        private Rectangle dragRect = new Rectangle(Point.Empty, SystemInformation.DragSize);
        private int dragRowHandle = GridControl.InvalidRowHandle;
        private int masterRowHandle = GridControl.InvalidRowHandle;
        private int timerRowHandle = GridControl.InvalidRowHandle;

        private void OnChildViewMouseMove(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left || dragRect.Location == Point.Empty ||
    dragRect.Contains(e.Location) || dragRowHandle == GridControl.InvalidRowHandle) return;
            GridView view = (GridView)sender;
            view.GridControl.DoDragDrop(new int[] { dragRowHandle, view.SourceRowHandle }, DragDropEffects.Move);
            dragRect.Location = Point.Empty;
            dragRowHandle = GridControl.InvalidRowHandle;
            dragTimer.Start();
        }

        private void OnChildViewMouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            GridHitInfo hInfo = ((GridView)sender).CalcHitInfo(e.Location);
            if (!hInfo.InRowCell) return;
            dragRowHandle = hInfo.RowHandle;
            dragRect.Location = e.Location;
            dragRect.Location.Offset(-(int)Math.Round((double)(SystemInformation.DragSize.Width / 2)),
                -(int)Math.Round((double)(SystemInformation.DragSize.Height / 2)));
        }

        private void OnChildViewMouseUp(object sender, MouseEventArgs e) {
            dragRect.Location = Point.Empty;
            dragRowHandle = GridControl.InvalidRowHandle;
            masterRowHandle = GridControl.InvalidRowHandle;
            timerRowHandle = GridControl.InvalidRowHandle;
            dragTimer.Stop();
        }

        private void OnDragTimerTick(object sender, EventArgs e) {
            if (masterRowHandle == GridControl.InvalidRowHandle) {
                timerRowHandle = GridControl.InvalidRowHandle;
                return;
            }
            if (masterRowHandle == timerRowHandle) {
                gridView1.SetMasterRowExpanded(masterRowHandle, true);
                timerRowHandle = GridControl.InvalidRowHandle;
                masterRowHandle = GridControl.InvalidRowHandle;
            } else
                timerRowHandle = masterRowHandle;
        }

        private void OnGridControlDragOver(object sender, DragEventArgs e) {
            GridControl grid = (GridControl)sender;
            Point mousePosition = grid.PointToClient(Control.MousePosition);
            GridView view = (GridView)grid.GetViewAt(mousePosition);
            if (view != null)
                if (view.IsDetailView && view.CalcHitInfo(mousePosition).InRowCell) {
                    e.Effect = DragDropEffects.Move;
                    if (dragTimer.Enabled)
                        dragTimer.Stop();
                } else {
                    e.Effect = DragDropEffects.None;
                    if (!dragTimer.Enabled)
                        dragTimer.Start();
                    GridHitInfo hInfo = view.CalcHitInfo(mousePosition);
                    if (hInfo.InRowCell) {
                        if (!view.GetMasterRowExpanded(hInfo.RowHandle))
                            masterRowHandle = hInfo.RowHandle;
                        else
                            masterRowHandle = GridControl.InvalidRowHandle;
                    } else
                        masterRowHandle = GridControl.InvalidRowHandle;
                }
        }

        private void OnGridControlDragDrop(object sender, DragEventArgs e) {
            if (e.Effect == DragDropEffects.Move) {
                GridControl grid = (GridControl)sender;
                Point mousePosition = grid.PointToClient(Control.MousePosition);
                GridView view = (GridView)grid.GetViewAt(mousePosition);
                GridHitInfo hInfo = view.CalcHitInfo(mousePosition);
                int[] data = (int[])e.Data.GetData(typeof(int[]));
                GridView sourceView = (GridView)((GridView)grid.MainView).GetDetailView(data[1], 0);
                Product dragRow = (Product)sourceView.GetRow(data[0]);
                ((IList<Product>)sourceView.DataSource).Remove(dragRow);
                ((IList<Product>)view.DataSource).Add(dragRow);
                int sourceRowHandle = view.SourceRowHandle;
            }
            dragTimer.Stop();
            masterRowHandle = GridControl.InvalidRowHandle;
            timerRowHandle = GridControl.InvalidRowHandle;
        }
    }
}