using PI_31_2_Tskhe_MyAI.NeuroNet;

namespace PI_31_2_Tskhe_MyAI.NeuroNet
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nopn, NeuronType nt, string nm_Layer) : 
            base(non, nopn, nt, nm_Layer) { }

        public override void Recognize(Network net, Layer nextLayer)
        {
            double e_sum = 0;
            for (int i = 0; i < neurons.Length; i++)
                e_sum += neurons[i].Output;

            for (int i = 0; i < neurons.Length; i++)
            {
                net.Fact[i] = neurons[i].Output / e_sum;
            }
        }

        public override double[] BackwardPass(double[] errors)
        {
            double[] gr_sum = new double[numofprevneurons + 1];
            // код метода
            return gr_sum;
        }
    }
}
