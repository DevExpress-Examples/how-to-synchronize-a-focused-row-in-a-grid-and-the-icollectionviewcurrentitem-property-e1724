using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using DevExpress.Xpf.Grid;

namespace DXGrid_FocusedRow {
    public partial class Window1 : Window {
        CollectionViewSource source;
        public Window1() {

            InitializeComponent();

            List<TestData> list = new List<TestData>();
            for (int i = 0; i < 100; i++) {
                list.Add(new TestData() {
                    Number1 = i,
                    Number2 = i * 10,
                    Text1 = "row " + i,
                    Text2 = "ROW " + i
                });
            }
            source = new CollectionViewSource() { Source = list };
            source.View.CurrentChanged += new System.EventHandler(CollectionView_CurrentChanged);
            view.FocusedRowChanged += new FocusedRowChangedEventHandler(GridView_FocusedRowChanged);
            grid.ItemsSource = source.View;
            listBox.ItemsSource = source.View;

        }
        void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            source.View.MoveCurrentTo(grid.GetRow(view.FocusedRowHandle));
        }
        void CollectionView_CurrentChanged(object sender, System.EventArgs e) {
            view.FocusedRowHandle = grid.GetRowHandleByListIndex(source.View.CurrentPosition);
        }
    }

    public class TestData {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }
}
