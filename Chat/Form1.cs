using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;

namespace Chat
{
    public partial class Form1 : Form
    {
        OurPipes newPipe;

        bool set = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (set == false)
            {
                set = true;
                newPipe = new OurPipes("c");
            }
            MessageBox.Show(newPipe.reader.ReadLine());
            newPipe.writer.Flush();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (set == false)
            {
                set = true;
                newPipe = new OurPipes("s");
            }
            newPipe.writer.WriteLine(textBox1.Text);
            newPipe.writer.Flush();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
       
}
