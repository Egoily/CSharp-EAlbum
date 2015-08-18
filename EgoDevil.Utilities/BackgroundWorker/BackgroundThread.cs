using System.ComponentModel;
using System.Drawing;

namespace EgoDevil.Utilities.BkWorker
{
    public class BackgroundThread
    {
        public delegate void RunFunction();

        public System.ComponentModel.BackgroundWorker Bw;
        public RunFunction thisFunction;
        BackgroundForm frmBackground;

        public BackgroundThread(RunFunction newFunction)
        {
            thisFunction = newFunction;
            Bw = new BackgroundWorker();
            Bw.DoWork += new DoWorkEventHandler(Bw_DoWork);
            Bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
        }


        public void Start()
        {
            Bw.RunWorkerAsync();
            frmBackground = new BackgroundForm();
            frmBackground.ShowDialog();
        }

        public void Start(Size formSize)
        {           
            Bw.RunWorkerAsync();
            frmBackground = new BackgroundForm(formSize);
            frmBackground.ShowDialog();
        }

        void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frmBackground.Dispose();
            //MessageBox.Show("Complete");
        }

        void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (thisFunction != null)
            {             
                thisFunction();             
            }
        }
    }
}
