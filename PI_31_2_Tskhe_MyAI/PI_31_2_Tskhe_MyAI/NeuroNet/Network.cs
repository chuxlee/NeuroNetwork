namespace PI_31_2_Tskhe_MyAI.NeuroNet
{
    class Network
    {
        // все слои сети
        private InputLayer input_layer = null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(71, 15, NeuronType.Hidden, nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(36, 71, NeuronType.Hidden, nameof(hidden_layer2));
        private OutputLayer output_layer = new OutputLayer(10, 36, NeuronType.Output, nameof(output_layer));

        private double[] fact = new double[10]; // массив фактического выхода сети
        private double[] e_error_avr; // среднее значение энергии ошибки эпохи обучения

        // свойства
        public double[] Fact { get => fact; } // массив фактического выхода сети

        // среднее значение энергии ошибки эпохи обучения
        public double[] E_error_avr { get => e_error_avr; set => e_error_avr = value; }

        // конструктор
        public Network() { }



        // прямой проход сети
        public void ForwardPass(Network net, double[] netInput)
        {
            net.hidden_layer1.Data = netInput;
            net.hidden_layer1.Recognize(null, net.hidden_layer2);
            net.hidden_layer2.Recognize(null, net.output_layer);
            net.output_layer.Recognize(net, null);
        }
    }
}
