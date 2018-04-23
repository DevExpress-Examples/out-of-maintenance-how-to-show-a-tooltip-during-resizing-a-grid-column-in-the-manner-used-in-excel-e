using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Drawing;


namespace DXSample {
    public partial class Form1: XtraForm {
        public Form1() {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.nwindDataSet.Products);
        }

        private void OnGetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e) {
            if(e.SelectedControl != gridControl1) return;

            ToolTipControlInfo info = null;
            GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
            if(view == null) return;
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            GridPainter painter = viewInfo.Painter;
            if(view.State == GridState.ColumnSizing) {
                GridColumn col = painter.ReSizingObject as GridColumn;
                object o = col.FieldName + e.ControlMousePosition.ToString();
                int width = GetColumnHeaderWidth(viewInfo.ColumnsInfo[col], painter);
                string text = string.Format("Width: {0}", width);
                info = new ToolTipControlInfo(o, text);
            }
            if(info != null)
                e.Info = info;
        }

        protected int GetColumnHeaderWidth(GridColumnInfoArgs args, GridPainter painter) {
            if(args != null) {
                int width = painter.CurrentSizerPos - args.Bounds.Left;
                if(width < 0) width = args.Bounds.Right - painter.CurrentSizerPos;
                return width;
            }
            return 0;
        }
    }
}
