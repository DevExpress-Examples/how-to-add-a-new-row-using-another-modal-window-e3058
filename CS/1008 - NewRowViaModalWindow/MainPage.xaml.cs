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
            grid.DataSource = list;
            #endregion
        }

        private void addNewRowButton_Click(object sender, RoutedEventArgs e) {
            ClearNewRowDialogWindow();
            newRowDialogWindow.ShowDialog();
        }

        void ClearNewRowDialogWindow() {
            text1.Text = "";
            text2.Text = "";
            text3.Text = "";
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) {
            TestData newRow = new TestData() {
                Text1 = text1.Text,
                Text2 = text2.Text,
                Text3 = text3.Text
            };
            list.Add(newRow);

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
