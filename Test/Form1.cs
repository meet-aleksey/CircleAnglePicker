using System;
using System.Windows.Forms;

namespace Test
{

  public partial class Form1 : Form
  {

    public Form1()
    {
      InitializeComponent();
    }

    private void circleAnglePicker9_ValueChanged(object sender, EventArgs e)
    {
      numericUpDown1.Value = (sender as CircleAnglePicker).Value;
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      circleAnglePicker9.Value = Convert.ToInt32((sender as NumericUpDown).Value);
    }

  }

}