using System.Windows;

namespace WpfGlesDemo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            var d = new DemoRenderer();
            d.Texture = First.Dummy;
            First.GlesRenderer = d;
            Second.GlesRenderer = new DemoRenderer();
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            First.Opacity = e.NewValue;
        }

    }
}