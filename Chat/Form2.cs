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
    public partial class Form2 : Form
    {
        OurPipes newPipe;

        bool set = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
    }

    class OurPipes
    {
        public NamedPipeServerStream server;
        public NamedPipeClientStream client;

        public StreamWriter writer;
        public StreamReader reader;
        public OurPipes(string choice)
        {
            if (choice == "s")
            {
                createServer();
                initializeStreamsForServer();
            }
            else
            {
                createClient();
                initializeStreamsForClient();
            }
        }
        void createServer()
        {
            server = new NamedPipeServerStream("Pipe");
            server.WaitForConnection();
        }
        void createClient()
        {
            client = new NamedPipeClientStream("Pipe");
            client.Connect();
        }

        public void initializeStreamsForClient()
        {
            reader = new StreamReader(client);
            writer = new StreamWriter(client);
        }
        public void initializeStreamsForServer()
        {
            reader = new StreamReader(server);
            writer = new StreamWriter(server);
        }
    }

}
