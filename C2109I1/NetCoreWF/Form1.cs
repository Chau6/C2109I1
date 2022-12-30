namespace NetCoreWF;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Hi", "Hello World", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            MessageBox.Show("Yes", "DCM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("No", "DCM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
