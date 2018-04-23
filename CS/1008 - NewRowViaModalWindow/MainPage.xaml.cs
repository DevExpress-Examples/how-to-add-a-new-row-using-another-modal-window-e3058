// Developer Express Code Central Example:
// How to add a new row using another modal window
// 
// The following example demonstrates how to programmatically add a new row to a
// GridControl. To see this approach in action, click the "Add new row..." button,
// fill in three text boxes in the invoked window and click OK.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3058

using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core;


namespace _1008___NewRowViaModalWindow {
    public partial class MainPage : UserControl {
        ObservableCollection<TestData> list;

        public MainPage() {
            InitializeComponent();

            #region Fill the GridControl with data
            list = new ObservableCollection<TestData>();
            for (int i = 0; i < 5; i++) {
                list.Add(new TestData() {
                    Text1 = Guid.NewGuid().ToString(),
                    Text2 = "text2 " + i,
                    Text3 = "text3 " + i
                });
            }
            grid.ItemsSource = list;
            #endregion
        }

        private void addNewRowButton_Click(object sender, RoutedEventArgs e) {
            newRowDialogWindow.DataContext = new TestData();
            newRowDialogWindow.ShowDialog();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) {
            list.Add((TestData)newRowDialogWindow.DataContext);

            view.MoveFocusedRow(grid.GetRowVisibleIndexByHandle
                (grid.GetRowHandleByVisibleIndex(list.Count - 1)));

            grid.Focus();

            newRowDialogWindow.Hide();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            newRowDialogWindow.Hide();
        }
    }

    #region Test data
    public class TestData {
        public string Text1 {
            get;
            set;
        }
        public string Text2 {
            get;
            set;
        }
        public string Text3 {
            get;
            set;
        }
    }
    #endregion
}
