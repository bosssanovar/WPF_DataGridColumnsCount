using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Result.xaml の相互作用ロジック
    /// </summary>
    public partial class Result : Window
    {
        public ReactivePropertySlim<string> Slow10 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Slow20 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Slow30 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Slow100 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Slow200 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Slow400 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Slow640 { get; } = new ReactivePropertySlim<string>("-");


        public ReactivePropertySlim<string> Fast10 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Fast20 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Fast30 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Fast100 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Fast200 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Fast400 { get; } = new ReactivePropertySlim<string>("-");
        public ReactivePropertySlim<string> Fast640 { get; } = new ReactivePropertySlim<string>("-");

        private Stopwatch _stopwatch = new System.Diagnostics.Stopwatch();

        public Result()
        {
            InitializeComponent();
        }

        public void StartMeasurementTime()
        {
            _stopwatch.Restart();
        }

        public void EndMeasurementTimeSlow(string type)
        {
            _stopwatch.Stop();

            switch(type)
            {
                case "10":
                    if (Convert(Slow10.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Slow10.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "20":
                    if (Convert(Slow20.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Slow20.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "30":
                    if (Convert(Slow30.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Slow30.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "100":
                    if (Convert(Slow100.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Slow100.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "200":
                    if (Convert(Slow200.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Slow200.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "400":
                    if (Convert(Slow400.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Slow400.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "640":
                    if (Convert(Slow640.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Slow640.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
            }
        }

        public void EndMeasurementTimeFast(string type)
        {
            _stopwatch.Stop();

            switch (type)
            {
                case "10":
                    if (Convert(Fast10.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Fast10.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "20":
                    if (Convert(Fast20.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Fast20.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "30":
                    if (Convert(Fast30.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Fast30.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "100":
                    if (Convert(Fast100.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Fast100.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "200":
                    if (Convert(Fast200.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Fast200.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "400":
                    if (Convert(Fast400.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Fast400.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
                case "640":
                    if (Convert(Fast640.Value) < _stopwatch.ElapsedMilliseconds) break;
                    Fast640.Value = $"{_stopwatch.ElapsedMilliseconds} ミリ秒";
                    break;
            }
        }

        private int Convert(string str)
        {
            try
            {
                string timeString = str.Replace(" ミリ秒", "");

                return int.Parse(timeString);
            }
            catch
            {
                return int.MaxValue;
            }
        }
    }
}