using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSandbox.Models
{
    public class Сharacteristic
    {
        public string Name { get; set; }
        public List<СharacteristicParam> Params { get; set; }

        public Сharacteristic()
        {
            Params = new List<СharacteristicParam>();
        }
    }

    public class СharacteristicParam
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
