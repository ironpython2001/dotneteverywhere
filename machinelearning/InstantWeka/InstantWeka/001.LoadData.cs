using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTU.BigODM.MachineLearning.Weka;
using weka.core;
using static weka.core.converters.ConverterUtils;
using static System.Console;

namespace InstantWeka
{
    public class LoadData
    {
        public static void Run()
        {
            WriteLine("Loading the data");
            var source = new DataSource(@"dataset\titanic.arff");
            var data = source.getDataSet();
            WriteLine(data.numInstances() + " instances loaded.");
            WriteLine(data.toString());
        }
    }
}
