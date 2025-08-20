# How to create grid control in vb net

This example demonstrates how to create grid control application in vb.net.

### Creating Grid Control in VB.Net
1. Create a new VB.Net WPF application project
2. Install the [Syncfusion.Grid.WPF](https://www.nuget.org/packages/Syncfusion.Grid.WPF)   NuGet package as a reference to your   .NET Framework applications from NuGet.org.
3. Add the following Syncfusion namespace in MainWindow.xaml to make use of the GridControl
4. Add the GridControl inside the `ScrollViewer` control which provides scrollable area to other visible elements that it contains.   

#### XAML

``` xml
<Window x:Class="MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:GridControlDemo"
        mc:Ignorable="d"
        xmlns:Syncfusion="clr-namespace:Syncfusion.Windows.Controls.Grid;assembly=Syncfusion.Grid.WPF" 
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <ScrollViewer HorizontalScrollBarVisibility="Visible">
            <Syncfusion:GridControl x:Name="gridControl"/>
        </ScrollViewer>
    </Grid>
</Window>
```

### Defining Rows and Columns

Users can add the number of rows and columns in grid control by using [RowCount](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html#Syncfusion_Windows_Controls_Grid_GridModel_RowCount) and [ColumnCount](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html#Syncfusion_Windows_Controls_Grid_GridModel_ColumnCount) properties.

``` vb
'Specifying row and column count
gridControl.Model.RowCount = 50
gridControl.Model.ColumnCount = 10
```

### Populating Data

Data can be populated in grid control using one of the following methods.

1. Populate data by looping through the cells in Grid
``` vb
'Specifying row and column count
gridControl.Model.RowCount = 50
gridControl.Model.ColumnCount = 10
 
Dim r As New Random()
 
For row As Integer = 1 To 49
    For col As Integer = 1 To 9
        gridControl.Model(row, col).CellValue = r.Next(10, 100)      
    Next col
Next row
```

2. Populate data by handling the [QueryCellInfo](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html#Syncfusion_Windows_Controls_Grid_GridModel_QueryCellInfo) event of Grid (Virtual Mode). This will load the data in and on-demand basis, ensuring optimized performance.

``` vb
'Specifying row and column count
gridControl.Model.RowCount = 50
gridControl.Model.ColumnCount = 10 
AddHandler gridControl.QueryCellInfo, AddressOf grid_QueryCellInfo
 
Private Sub grid_QueryCellInfo(ByVal sender As Object, ByVal e As GridQueryCellInfoEventArgs)
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
```