Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Drawing


Namespace DXSample
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub


		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
			Me.productsTableAdapter.Fill(Me.nwindDataSet.Products)
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
End Namespace
