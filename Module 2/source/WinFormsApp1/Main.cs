namespace WinFormsApp1
{
    public partial class Main : Form
    {
        public static string NameInputText = "";
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (nameInput.Text == null)
            {
                //Name textField empty
                MessageBox.Show(@"Name is empty");
                return;
            }

            NameInputText = nameInput.Text;
            var messageForm = new Message();
            messageForm.ShowDialog();


        }
    }
}