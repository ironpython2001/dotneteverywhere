using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weka.core;

namespace InstantWeka
{
    public class CreateDataSet
    {
        public static void Run()
        {
            var attributes = new weka.core.FastVector();
            var catVals = new weka.core.FastVector(3);
            catVals.addElement("sports");
            catVals.addElement("finance");
            catVals.addElement("news");
            attributes.addElement(new weka.core.Attribute("category (att1)", catVals));
        }
    }
}
