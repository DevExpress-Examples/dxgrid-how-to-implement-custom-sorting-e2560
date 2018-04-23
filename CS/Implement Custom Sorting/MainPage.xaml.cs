using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DevExpress.XtraGrid;
using DevExpress.Xpf.Grid;

namespace Implement_Custom_Sorting {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }
        private void OnLoaded(object sender, RoutedEventArgs e) {
            string[] months = new string[] { "January", "February", "March", 
                "April", "May", "June", "July", "August", "September", 
                "October", "November", "December" };
            grid.ItemsSource = months;
            grid.PopulateColumns();
            grid.SortBy(grid.Columns[0]);
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e) {
            grid.Columns[0].SortMode = ColumnSortMode.Custom;
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e) {
            grid.Columns[0].SortMode = ColumnSortMode.Default;
        }
        private void grid_CustomColumnSort(object sender, CustomColumnSortEventArgs e) {
            e.Result = Comparer<int>.Default.Compare(e.ListSourceRowIndex1,
                e.ListSourceRowIndex2);

            e.Handled = true;
        }
    }
}
