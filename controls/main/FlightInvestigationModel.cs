using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    partial class FIAModel
    {
        public void closeWindow()
        {
            this.disconnect();
        }
    }
}
