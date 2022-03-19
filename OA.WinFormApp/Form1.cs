using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OA.WinFormApp
{
    public partial class Form1 : Form
    {
        private Thread thread;

        private bool isSleep = false;

        public Form1()
        {
            thread = new Thread(Progrss);
            InitializeComponent();
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            thread.Start();
        }

        public void Progrss()
        {
            for (int i = 0; i <= 1000; i++)
            {
                progressBar1.Value = i;
                if(isSleep)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(Convert.ToDouble(textBox1.Text)));
                }
                isSleep = false;
                Thread.Sleep(20);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 睡眠
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            isSleep = true;
        }

        /// <summary>
        /// 挂起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            thread.Suspend();
        }

        /// <summary>
        /// 继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            thread.Resume();
        }

        /// <summary>
        /// 终止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }
    }
}