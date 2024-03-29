﻿using Reactive.Bindings;
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
    public partial class MainWindow : Window
    {
        private const int InitCulumnCount = 200;

        public ObservableCollection<Object> Items { get; private set; } = new ObservableCollection<Object>();

        public MainWindow()
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
                    App.ResultView.EndMeasurementTimeSlow((string)((ComboBoxItem)comboBox.SelectedItem).Content);

                    Cursor = null;
                }), System.Windows.Threading.DispatcherPriority.Background);
            }), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void InitColumns(int count)
        {
            grid.Columns.Clear();

            for (int columnIndex = 0; columnIndex < count; ++columnIndex)
            {
                var factory = new FrameworkElementFactory(typeof(Rectangle));
                factory.SetValue(Rectangle.HeightProperty, 10.0);
                factory.SetValue(Rectangle.WidthProperty, 10.0);
                factory.SetValue(Rectangle.FillProperty, Brushes.LightSkyBlue);

                var dataTemplate = new DataTemplate();
                dataTemplate.VisualTree = factory;

                var column = new DataGridTemplateColumn();
                column.CellTemplate = dataTemplate;

                grid.Columns.Add(column);
            }
        }

        private void InitData(int count)
        {
            // バインドを切断
            Binding b = new Binding("Items")
            {
                Source = null
            };
            grid.SetBinding(DataGrid.ItemsSourceProperty, b);

            var list = new List<object>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Object());
            }

            Items = new ObservableCollection<object>(list);

            b = new Binding("Items")
            {
                Source = this
            };
            grid.SetBinding(DataGrid.ItemsSourceProperty, b);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var next = new MainWindow2();
            next.Show();

            App.Current.MainWindow = next;

            this.Close();
        }
    }
}