using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace test_threed
{
    public partial class threadTester : Form
    {
        // General counter, can be used to measure executing time for each thread.
        public int counter = 0;
        // progress counter for thread one
        public int counter1 = 0;
        // progress counter for thread two
        public int counter2 = 0;
        // progress counter for thread three
        public int counter3 = 0;

        public threadTester()
        {
            InitializeComponent();
            // set timer
            timer1.Interval = 1;
            timer1.Enabled = true;
            timer1.Start();
            // initialize progress bars
            initializeProgressBars();
        }
        /// <summary>
        /// initialize all progress bars
        /// </summary>
        private void initializeProgressBars()
        {
            progressBar1.Step = 1;
            progressBar2.Step = 1;
            progressBar3.Step = 1;
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar1.Maximum = 100;
            progressBar2.Maximum = 100;
            progressBar3.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar2.Minimum = 0;
            progressBar3.Minimum = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create thread1
            ThreadStart newThread1 = new ThreadStart(thread1);
            Thread t1 = new Thread(newThread1);
            t1.Start();
            // create thread2
            ThreadStart newThread2 = new ThreadStart(thread2);
            Thread t2 = new Thread(newThread2);
            t2.Start();
            // create thread3
            ThreadStart newThread3 = new ThreadStart(thread3);
            Thread t3 = new Thread(newThread3);
            t3.Start();
        }

        // progress counter by 1
        private void thread1()
        {
            for (int i = 0; counter1 < 1000000000; i++)
                counter1++;
        }
        // progress counter by 2
        private void thread2()
        {
            for (int i = 0; counter2 < 1000000000; i++)
                counter2 += 2;
        }

        // progress counter by 4
        private void thread3()
        {
            for (int i = 0; counter3 < 1000000000; i++)
                counter3 += 4;
        }

        // show counter for each thread.
        private void timer1_Tick(object sender, EventArgs e)
        {
            double tmp = 0.00;
            counter++;
            textBox4.Text = counter.ToString();
            textBox1.Text = counter1.ToString();
            textBox2.Text = counter2.ToString();
            textBox3.Text = counter3.ToString();
            if (counter1 > 1)
            {
                tmp = ((double)counter1 / 1000000000) * 100;
                progressBar1.Value = (int)tmp;
                tmp = ((double)counter2 / 1000000000) * 100;
                progressBar2.Value = (int)tmp;
                tmp = ((double)counter3 / 1000000000) * 100;
                progressBar3.Value = (int)tmp;
            }
        }
    }
}