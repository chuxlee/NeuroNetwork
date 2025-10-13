using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PI_31_2_Tskhe_MyAI.NeuroNet;

namespace PI_31_2_Tskhe_MyAI
{
    public partial class FormMain : Form
    {
        HiddenLayer hiddenLayer; //DELETE IT LATER
        private double[] inputPixels;
        public FormMain()
        {
            InitializeComponent();

            inputPixels = new double[15];
        }

        private void Changing_State_Pixel_Button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.White)
            {
                ((Button)sender).BackColor = Color.Black;
                inputPixels[((Button)sender).TabIndex] = 1d;
            }
            else
            {
                ((Button)sender).BackColor = Color.White;
                inputPixels[((Button)sender).TabIndex] = 0d;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            hiddenLayer = new HiddenLayer(35, 40, NeuronType.Hidden, nameof(HiddenLayer));
            hiddenLayer.WeightInitialize(MemoryMode.INIT, AppDomain.CurrentDomain.BaseDirectory + nameof(HiddenLayer) + "_memory.csv");
        }

        private void SaveTrainSample_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "train.txt";
            string tmpStr = numericUpDown_NecessaryOutput.Value.ToString();

            for (int i = 0; i < inputPixels.Length; i++)
            {
                tmpStr += " " + inputPixels[i].ToString();
            }
            tmpStr += "\n";

            File.AppendAllText(path, tmpStr);
        }
    }
}
