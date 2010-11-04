using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace eConcierge.Common
{
    public class ProductInfo
    {

        public static String Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public static String Copyright
        {
            get
            {
                object[] attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (null != attribs)
                {
                    AssemblyCopyrightAttribute cr = attribs[0] as AssemblyCopyrightAttribute;
                    if (null != cr) return cr.Copyright;
                }
                return string.Empty;
            }
        }


    }
}
