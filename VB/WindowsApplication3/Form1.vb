Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.ComponentModel

Namespace DXSample
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            Dim list = New BindingList(Of Item)()
            For i As Integer = 0 To 19
                list.Add(New Item() With { _
                    .ID = i, _
                    .Name = "TestName" & i, _
                    .Description = "TestDescription" & i _
                })
            Next i
            gridControl1.DataSource = list
        End Sub
        Private Sub OnGetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles toolTipController1.GetActiveObjectInfo
            If e.SelectedControl IsNot gridControl1 Then
                Return
            End If
            Dim info As ToolTipControlInfo = Nothing
            Dim view As GridView = TryCast(gridControl1.GetViewAt(e.ControlMousePosition), GridView)
            If view Is Nothing Then
                Return
            End If
            Dim viewInfo As GridViewInfo = TryCast(view.GetViewInfo(), GridViewInfo)
            Dim painter As GridPainter = viewInfo.Painter
            If view.State = GridState.ColumnSizing Then
                Dim col As GridColumn = TryCast(painter.ReSizingObject, GridColumn)
                Dim o As Object = col.FieldName + e.ControlMousePosition.ToString()
                Dim width As Integer = GetColumnHeaderWidth(viewInfo.ColumnsInfo(col), painter)
                Dim text As String = String.Format("Width: {0}", width)
                info = New ToolTipControlInfo(o, text)
            End If
            If info IsNot Nothing Then
                e.Info = info
            End If
        End Sub
        Protected Function GetColumnHeaderWidth(ByVal args As GridColumnInfoArgs, ByVal painter As GridPainter) As Integer
            If args IsNot Nothing Then
                Dim width As Integer = painter.CurrentSizerPos - args.Bounds.Left
                If width < 0 Then
                    width = args.Bounds.Right - painter.CurrentSizerPos
                End If
                Return width
            End If
            Return 0
        End Function
    End Class
    Public Class Item
        Public Property ID() As Integer
        Public Property Name() As String
        Public Property Description() As String
    End Class
End Namespace
