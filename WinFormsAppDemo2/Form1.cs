namespace WinFormsAppDemo2
{
    public partial class Names : Form
    {
        public Names()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !FirstNames.Items.Contains(txtName.Text))
                FirstNames.Items.Add(txtName.Text);
        }
    }
}
