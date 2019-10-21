Imports Syncfusion.Windows.Controls.Grid

Class MainWindow
    Public Sub New()
        InitializeComponent()

        Dim r As New Random()
        'Specifying row and column count
        gridControl.Model.RowCount = 50
        gridControl.Model.ColumnCount = 10
        gridControl.Model.RowHeights.DefaultLineSize = 30
        gridControl.Model.ColumnWidths.DefaultLineSize = 70
        Dim ci As New GridStyleInfo()
        For row As Integer = 1 To 49
            For col As Integer = 1 To 9
                If r.Next(1, 4) = 2 Then
                    gridControl.Model(row, col).CellValue = r.Next(10, 100)
                ElseIf r.Next(1, 4) = 3 Then
                    gridControl.Model(row, col).CellValue = "Text" & r.Next(10, 100).ToString()
                Else
                    gridControl.Model(row, col).CellValue = (r.Next(1000, 10000) * 0.01)
                End If
            Next col
        Next row

        AddHandler gridControl.QueryCellInfo, AddressOf grid_QueryCellInfo

        'VirtualGrid settings
        virtualGrid.Model.RowCount = 50
        virtualGrid.Model.ColumnCount = 10
        virtualGrid.Model.RowHeights.DefaultLineSize = 30
        virtualGrid.Model.ColumnWidths.DefaultLineSize = 70
        AddHandler virtualGrid.QueryCellInfo, AddressOf virtualGrid_QueryCellInfo
    End Sub

    Dim rand As New Random()
    Private Sub grid_QueryCellInfo(ByVal sender As Object, ByVal e As GridQueryCellInfoEventArgs)
        If e.Style.RowIndex = 0 AndAlso e.Style.ColumnIndex = 0 Then
            Return
        ElseIf e.Style.RowIndex = 0 Then
            e.Style.CellValue = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex)
            e.Style.HorizontalAlignment = HorizontalAlignment.Center
            e.Style.VerticalAlignment = VerticalAlignment.Center
        ElseIf e.Style.ColumnIndex = 0 Then
            e.Style.CellValue = e.Style.RowIndex
            e.Style.HorizontalAlignment = HorizontalAlignment.Center
            e.Style.VerticalAlignment = VerticalAlignment.Center
        End If
    End Sub

    Private Sub virtualGrid_QueryCellInfo(ByVal sender As Object, ByVal e As GridQueryCellInfoEventArgs)
        If e.Style.RowIndex = 0 AndAlso e.Style.ColumnIndex = 0 Then
            Return
            'set value for column headers
        ElseIf e.Style.RowIndex = 0 Then
            e.Style.CellValue = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex)
            'set value for row headers
        ElseIf e.Style.ColumnIndex = 0 Then
            e.Style.CellValue = e.Style.RowIndex
            'set value for cells
        Else
            e.Style.CellValue = rand.Next(10, 100)
        End If
    End Sub
End Class
