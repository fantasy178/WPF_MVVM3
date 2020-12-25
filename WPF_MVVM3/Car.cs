using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM3
{
    class Car
    {
        public string Name { get; set; }
        public int WheelNo { get; set; }

        public override string ToString()
        {
            return $"Element of Cars";
        }
    }
}
