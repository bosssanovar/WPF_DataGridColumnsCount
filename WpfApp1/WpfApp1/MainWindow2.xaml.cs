using Reactive.Bindings;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        private const int InitCulumnCount = 200;

        public ObservableCollection<Object> Items { get; private set; } = new ObservableCollection<Object>();

        public MainWindow2()
        {
            InitializeComponent();

            InitData(InitCulumnCount);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            Cursor = Cursors.Wait;

            InitColumns(InitCulumnCount);

            grid.Visibility = Visibility.Visible;

            Dispatcher.InvokeAsync(new Action(() =>
            {
                Cursor = null;
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);

            App.Current.MainWindow = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.ResultView.StartMeasurementTime();


            Cursor = Cursors.Wait;
            grid.Visibility = Visibility.Hidden;

            Dispatcher.InvokeAsync(new Action(() =>
            {
                InitColumns(int.Parse((string)((ComboBoxItem)comboBox.SelectedItem).Content));
                InitData(int.Parse((string)((ComboBoxItem)comboBox.SelectedItem).Content));

                grid.Visibility = Visibility.Visible;
                Dispatcher.InvokeAsync(new Action(() =>
                {
                    App.ResultView.EndMeasurementTimeFast((string)((ComboBoxItem)comboBox.SelectedItem).Content);

                    Cursor = null;
                }), System.Windows.Threading.DispatcherPriority.Background);
            }), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void InitColumns(int count)
        {
            grid.BeginInit();

            for (int i = 0; i < 640; i++)
            {
                grid.Columns[i].Visibility = (i < count) ? Visibility.Visible : Visibility.Collapsed;
            }

            grid.EndInit();
        }

        private void InitData(int count)
        {
            Items.Clear();

            for (int i = 0; i < count; i++)
            {
                Items.Add(new Object());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var next = new MainWindow();
            next.Show();

            App.Current.MainWindow = next;

            this.Close();
        }
    }
}