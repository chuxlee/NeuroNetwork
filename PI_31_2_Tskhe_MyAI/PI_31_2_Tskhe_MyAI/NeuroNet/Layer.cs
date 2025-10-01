using System;
using System.IO;
using System.Windows.Forms;

namespace PI_31_2_Tskhe_MyAI.NeuroNet
{
    abstract class Layer
    {
        protected string name_Layer;        //protected - имеют доступ потомки 
        string pathDirWeights;              // путь к каталогу, где находится файл синаптических весов
        string pathFileWeights;             // пусть к файлу синаптических весов для нейросети
        protected int numofneurons;         //число нейронов текущего слоя
        protected int numofprevneurons;     //число нейронов предыдущего слоя
        protected const double learningrate = 0.060;    //скорость обучения (будем менять)
        protected const double momentum = 0.050d;       //момент инерции
        protected double[,] lastdeltaweights;           // веса предыдущей итерации обучения
        protected Neuron[] neurons;                     //массив нейронов текущего слоя

        public Neuron[] Neurons { get => neurons; set => neurons = value; }
        public double[] Data    //передача входных данных на нейроны слоя и активация нейронов
        {
            set
            {
                for (int i = 0; i < numofneurons; i++)
                {
                    Neurons[i].Activator(value);
                }
            }
        }
        
        protected Layer(int non, int nopn, NeuronType nt, string nm_Layer)
        {
            numofneurons = non;
            numofprevneurons = nopn;
            Neurons = new Neuron[non];
            name_Layer = nm_Layer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";
            pathFileWeights = pathDirWeights + name_Layer + "_memory.csv";

            lastdeltaweights = new double[non, nopn + 1];
            double[,] Weights;      //временный массив синаптических весов текущего слоя

            if (File.Exists(pathFileWeights))
                Weights = WeightInitialize(MemoryMode.GET, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathFileWeights);
                Weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
            }

            for (int i = 0; i < non; i++) // цикл формирования нейронов слоя и заполнения ими
            {
                double[] tmp_weights = new double[nopn + 1];
                for (int j = 0; j < nopn + 1; j++)
                {
                    tmp_weights[j] = Weights[i, j];
                }
                Neurons[i] = new Neuron(tmp_weights, nt); //заполнение массива нейронами 
            }
        }

        // Метод работы с массивом синаптических весов слоя
        public double[,] WeightInitialize(MemoryMode mm, string path)
        {
            int i, j;          // счетчик циклов
            char[] delim = new char[] { ';', ' ' };     // разделитель слов
            string tmpStr;                              // временная строка для чтения
            string[] tmpStrWeights;                     // временный массив строк
            double[,] weights = new double[numofneurons, numofneurons + 1];

            switch (mm)
            {
                case MemoryMode.GET:
                    tmpStrWeights = File.ReadAllLines(path);
                    string[] memory_element;
                    for (i = 0; i < numofneurons; i++)
                    {
                        memory_element = tmpStrWeights[i].Split(delim); 
                        for (j = 0; j < numofprevneurons; j++)
                        {
                            weights[i, j] = double.Parse(memory_element[j].Replace(',', '.'), 
                                System.Globalization.CultureInfo.InvariantCulture);
                        }

                    }
                    break;
            }
        }
    }
}
