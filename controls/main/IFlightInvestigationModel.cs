using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model
{
    partial interface IFIAModel : INotifyPropertyChanged
    {
        void closeWindow();
    }
}
