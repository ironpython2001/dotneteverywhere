using java.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weka.core;
using weka.core.converters;

namespace InstantWeka
{
    public class ConvertCSVtoARFF
    {
        public static void Run()
        {
            CSVLoader loader = new CSVLoader();
            loader.setSource(new File(@"dataset\titanic.csv"));
            Instances data = loader.getDataSet();

            // save ARFF
            ArffSaver saver = new ArffSaver();
            saver.setInstances(data);
            saver.setFile(new File(@"titanicconverted.arff"));
            saver.writeBatch();
            
        }
    }
}
