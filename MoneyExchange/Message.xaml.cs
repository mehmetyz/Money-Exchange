using System.Windows;
namespace MoneyExchange
{
    /// <summary>
    /// MessageBox for my app
    /// </summary>
    public partial class Message : Window
    {
        //Form closing flag by buttons
        public bool Default { get; private set; }

        public Message(string message,bool isInfo)
        {
            InitializeComponent();

            this.messageText.Text = message;
            if (isInfo)
            {
                this.ok.Visibility = Visibility.Hidden;
                this.cancelLBL.Content = "OK";
            }
        }

        //OK event
        private void OKClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Default = true;
            this.Close();
        }


        //CANCEL event
        private void CancelClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Default = false;
            this.Close();
        }
       
    }
}
