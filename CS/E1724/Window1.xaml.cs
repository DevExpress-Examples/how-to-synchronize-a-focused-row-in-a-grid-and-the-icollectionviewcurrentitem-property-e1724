using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using DevExpress.Xpf.Grid;

namespace E1724 {
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
            grid.ItemsSource = source.View;
            listBox.ItemsSource = source.View;
        }
    }

    public class TestData {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }
}
