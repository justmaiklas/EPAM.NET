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
            if (nameInput.Text.Length == 0)
            {
                MessageBox.Show(@"Hi mysterious entity. Your name is missing");
                return;
            }

            NameInputText = nameInput.Text;
            var messageForm = new Message();
            messageForm.ShowDialog();


        }
    }
}