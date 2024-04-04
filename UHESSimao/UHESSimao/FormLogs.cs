using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHESSimao
{
    public partial class FormLogs : Form
    {
        public FormLogs()
        {
            InitializeComponent();
        }

        public void log(String txt)
        {
            richTextBox1.Invoke(new Action(() => richTextBox1.AppendText(txt + "\r\n")));
        }
    }
}