using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTU.BigODM.MachineLearning.Weka;
using weka.core;
using static weka.core.converters.ConverterUtils;

namespace InstantWeka
{
    public class LoadData
    {
        public static void Run()
        {
            var source = new DataSource(@"dataset\titanic.arff");
            var data = source.getDataSet();
            Console.WriteLine(data.numInstances() + " instances loaded.");
            Console.WriteLine(data.toString());
        }
    }
}
