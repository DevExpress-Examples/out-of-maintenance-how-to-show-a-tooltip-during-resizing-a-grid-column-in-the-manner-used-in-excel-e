using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.ComponentModel;

namespace DXSample
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            var list = new BindingList<Item>();
            for (int i = 0; i < 20; i++)
                list.Add(new Item() { ID = i, Name = "TestName" + i, Description = "TestDescription" + i });
            gridControl1.DataSource = list;
        }
        private void OnGetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gridControl1) return;
            ToolTipControlInfo info = null;
            GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
            if (view == null) return;
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            GridPainter painter = viewInfo.Painter;
            if (view.State == GridState.ColumnSizing)
            {
                GridColumn col = painter.ReSizingObject as GridColumn;
                object o = col.FieldName + e.ControlMousePosition.ToString();
                int width = GetColumnHeaderWidth(viewInfo.ColumnsInfo[col], painter);
                string text = string.Format("Width: {0}", width);
                info = new ToolTipControlInfo(o, text);
            }
            if (info != null)
                e.Info = info;
        }
        protected int GetColumnHeaderWidth(GridColumnInfoArgs args, GridPainter painter)
        {
            if (args != null)
            {
                int width = painter.CurrentSizerPos - args.Bounds.Left;
                if (width < 0) width = args.Bounds.Right - painter.CurrentSizerPos;
                return width;
            }
            return 0;
        }
    }
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
