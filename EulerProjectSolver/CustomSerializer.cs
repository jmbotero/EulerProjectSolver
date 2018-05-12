using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class CustomSerializer
    {

        private string Serialize(object o)
        {
            var result = new StringBuilder();
            Type type = o.GetType();

            foreach (var pi in type.GetProperties())
            {
                string name = pi.Name;
                string value = pi.GetValue(o, null).ToString();

                object[] attrs = pi.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var vp = attr as JsonPropertyAttribute;
                    if (vp != null) name = vp.PropertyName;
                }

                result.AppendFormat("\"{0}\" : \"{1}\"", name, value);
            }
            return result.ToString();
        }

        public string SerializeObject(object o)
        {
            //if
            return "";
        }

    }
}
