using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace MoneyExchange
{
    /// <summary>
    /// Main form of money exchange application
    /// UI designed with Adobe XD
    /// </summary>
    public partial class MainWindow : Window
    {
        //Money type selected
        private Border target;
        private DispatcherTimer timer;
        private Exchange ex;

        public MainWindow()
        {
            InitializeComponent();
        }
        //Event method of window movement with mouse.
        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        /// <summary>
        /// Run all tasks of exchange application.
        /// This contains DispatcherTimer which is Threading-Timer
        /// So it was prograammed by parallel programming.
        /// WARNING! It can make your processes slowly.
        /// </summary>
        private void OnStart()
        {
            //Exchange class
            ex = new Exchange();
            //Task runner
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += Exchange;

            //Start task
            timer.Start();
        }
        private void Exchange(object sender, System.EventArgs e)
        {
            //select money type
            string moneyType = (string)this.target.DataContext;

            //variables to get value from online 
            string vs1Text = "", vs2Text = "", vs3Text = "", vs4Text = "";
            string vs1LText = "", vs2LText = "", vs3LText = "", vs4LText = "";

            //Check which money type
            switch (moneyType)
            {
                case "TRY":
                    //Get USD-TRY rate
                    vs1Text = ex.USD_TO_TRY.ToString("0.000");
                    vs1LText = "USD/TRY";
                    
                    //Get EUR-TRY rate
                    vs2Text = ex.EUR_TO_TRY.ToString("0.000");
                    vs2LText = "EUR/TRY";

                    //Get GBP-TRY rate
                    vs3Text = ex.GBP_TO_TRY.ToString("0.000");
                    vs3LText = "GBP/TRY";

                    //Get JPY-TRY rate
                    vs4Text = ex.JPY_TO_TRY.ToString("0.000");
                    vs4LText = "JPY/TRY";

                    break;
                case "USD":
                    //Get TRY-USD rate
                    vs1Text = ex.TRY_TO_USD.ToString("0.000");
                    vs1LText = "TRY/USD";

                    //Get EUR-USD rate
                    vs2Text = ex.EUR_TO_USD.ToString("0.000");
                    vs2LText = "EUR/USD";

                    //Get GBP-USD rate
                    vs3Text = ex.GBP_TO_USD.ToString("0.000");
                    vs3LText = "GBP/USD";

                    //Get JPY-USD rate
                    vs4Text = ex.JPY_TO_USD.ToString("0.000");
                    vs4LText = "JPY/USD";
                    break;
                case "EUR":
                    //Get TRY-EUR rate
                    vs1Text = ex.TRY_TO_EUR.ToString("0.000");
                    vs1LText = "TRY/EUR";

                    //Get USD-EUR rate
                    vs2Text = ex.USD_TO_EUR.ToString("0.000");
                    vs2LText = "USD/EUR";

                    //Get GBP-EUR rate
                    vs3Text = ex.GBP_TO_EUR.ToString("0.000");
                    vs3LText = "GBP/EUR";

                    //Get JPY-EUR rate
                    vs4Text = ex.JPY_TO_EUR.ToString("0.000");
                    vs4LText = "JPY/EUR";
                    break;
                case "GBP":
                    //Get TRY-GBP rate
                    vs1Text = ex.TRY_TO_GBP.ToString("0.000");
                    vs1LText = "TRY/GBP";

                    //Get USD-GBP rate
                    vs2Text = ex.USD_TO_GBP.ToString("0.000");
                    vs2LText = "USD/GBP";

                    //Get EUR-GBP rate
                    vs3Text = ex.EUR_TO_GBP.ToString("0.000");
                    vs3LText = "EUR/GBP";

                    //Get JPY-GBP rate
                    vs4Text = ex.JPY_TO_GBP.ToString("0.000");
                    vs4LText = "JPY/GBP";
                    break;
                case "JPY":
                    //Get TRY-JPY rate
                    vs1Text = ex.TRY_TO_JPY.ToString("0.000");
                    vs1LText = "TRY/JPY";

                    //Get EUR-HPY rate
                    vs2Text = ex.EUR_TO_JPY.ToString("0.000");
                    vs2LText = "EUR/JPY";

                    //Get GBP-JPY rate
                    vs3Text = ex.GBP_TO_JPY.ToString("0.000");
                    vs3LText = "GBP/JPY";

                    //Get USD-JPY rate
                    vs4Text = ex.USD_TO_JPY.ToString("0.000");
                    vs4LText = "USD/JPY";
                    break;
            }

            //INVOKEREQUIRED for changing first rate LABEL
            this.vs1.Dispatcher.Invoke(() =>
            {
                //set text of first rate dashboards, it will change again and again.
                this.vs1.Content = vs1Text;
                this.vsL1.Content = vs1LText;
            });
            //INVOKEREQUIRED for changing second rate LABEL
            this.vs2.Dispatcher.Invoke(() =>
            {
                //set text of second rate dashboards, it will change again and again.
                this.vs2.Content = vs2Text;
                this.vsL2.Content = vs2LText;
            });
            //INVOKEREQUIRED for changing third rate LABEL
            this.vs3.Dispatcher.Invoke(() =>
            {
                //set text of third rate dashboards, it will change again and again.
                this.vs3.Content = vs3Text;
                this.vsL3.Content = vs3LText;
            });
            //INVOKEREQUIRED for changing fourth rate LABEL
            this.vs4.Dispatcher.Invoke(() =>
            {
                //set text of fourth rate dashboards, it will change again and again.
                this.vs4.Content = vs4Text;
                this.vsL4.Content = vs4LText;
            });
        }
        //ControlBox back color change when mouse entered.
        private void ControlBoxMouseEnter(object sender, MouseEventArgs e)
        {
            Border target = (Border)e.Source;
            target.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#642950"));
        }
        //ControlBox back color change when mouse left.
        private void ControlBoxMouseLeave(object sender, MouseEventArgs e)
        {

            Border target = (Border)e.Source;
            target.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
        }
        
        //Money types mouse entered
        private void MoneyTypeMouseEnter(object sender,MouseEventArgs e)
        {
            Border target = (Border)e.Source;
            if (target.BorderThickness.ToString() != "3")
                target.BorderThickness = new Thickness(2);
        }
        //Money types mouse left.
        private void MoneyTypeMouseLeave(object sender, MouseEventArgs e)
        {
            Border target = (Border)e.Source;
            target.BorderThickness = new Thickness(1);
        }
        //Money types mouse click.
        private void MoneyTypeMouseClick(object sender, MouseEventArgs e)
        {
            //Clear selection of the previous button
            if (this.target != null)
            { 
                this.target.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#642950"));
                this.target.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00A9"));
            }

            //Create new selection.
            var target = e.Source;
            //if target control is not border and go to upper controls until reach a border.
            while (!(target is Border))
                target = target is Control ? ((Control)target).Parent : ((Grid)target).Parent;

            //Change previous money type selected.
            this.target = (Border)target;

            //Select the new money type
            this.target.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#026631"));
            this.target.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#029647"));
            
            //change values of currency by money type
            timer.Stop();
            this.Exchange(null,new EventArgs());
            timer.Start();
        }
        //Kill all process.
        private void ApplicationExit(object sender, MouseButtonEventArgs e)
        {
            Message message = new Message("Want you to exit?",false);
            message.ShowDialog();
            if (message.Default)
            {
                //kill the task runner.
                this.timer.Stop();

                //exit
                Application.Current.Shutdown();

            }

        }
        
        // Minimize the app on taskbar.
        private void AppMinimize(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Get information about this app.
        private void FlagClick(object sender, MouseButtonEventArgs e)
        {
            Message message = new Message("This program developed by Mehmet Yıldız.", true);
            message.ShowDialog();

        }
        //Select TRY button, load all images of buttons and run all tasks
        private void Load(object sender, RoutedEventArgs e)
        {
            //Select TRY button firstly.
            this.target = tryBtn;
            //Load images from image resource directory.
            loadImages();
            //Run the task
            this.OnStart();
        }

        //Initializing all images on buttons.
        private void loadImages()
        {
            //All images stored in local directory (Images directory))
            this.closeImage.Source = (ImageSource) new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Images\\close.png"));
            this.minImage.Source = (ImageSource)new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Images\\min.png"));
            this.flagImage.Source = (ImageSource)new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Images\\flag.png"));

            this.tryImage.Source = (ImageSource)new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Images\\try.png"));
            this.usdImage.Source = (ImageSource)new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Images\\usd.png"));
            this.eurImage.Source = (ImageSource)new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Images\\eur.png"));
            this.gbpImage.Source = (ImageSource)new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Images\\gbp.png"));
            this.jpyImage.Source = (ImageSource)new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Images\\jpy.png"));
        }
    }
}
