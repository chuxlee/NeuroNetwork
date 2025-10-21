using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI_31_2_Tskhe_MyAI.NeuroNet;

namespace PI_31_2_Tskhe_MyAI.NeuroNet
{
    internal class HiddenLayer : Layer
    {
        public HiddenLayer(int non, int nopn, NeuronType nt, string type) : 
            base(non, nopn, nt, type)
        { }

        public override void Recognize(Network net, Layer nextLayer)
        {
            double[] hidden_out = new double[numofneurons];
            for (int i = 0; i < numofneurons; i++)
                hidden_out[i] = neurons[i].Output;
            nextLayer.Data = hidden_out; // передача выходного сигнала на вход следующего слоя 
        }

        public override double[] BackwardPass(double[] gr_sums)
        {
            double[] gr_sum = new double[numofprevneurons];
            // дописать

            return gr_sum;
        }
    }
}
