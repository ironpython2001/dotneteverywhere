using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static weka.core.converters.ConverterUtils;
using static System.Console;
using weka.filters.unsupervised.attribute;


namespace InstantWeka
{
    public class FilteringAttributes
    {
        public static void Run()
        {
            //load the dataset
            WriteLine("Loading the data");
            var source = new DataSource(@"dataset\titanic.arff");
            var data = source.getDataSet();
            WriteLine("no of attributes" + data.numAttributes().ToString());


            //remore second attribute
            String[] opts = new String[] { "-R", "2" };
            Remove remove = new Remove();
            remove.setOptions(opts);
            remove.setInputFormat(data);
            var newData = weka.filters.Filter.useFilter(data, remove);
            WriteLine("no of attributes" + newData.numAttributes().ToString());
        }
    }
}
