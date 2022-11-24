using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyAccess.Datatypes
{
    
    partial class dataset
    {
        public List<List<string>> Content = new List<List<string>>();

        public void add(List<string> data)
        {
            Content.Add(data);
        }

        public void removeAt(int index)
        {
            Content.RemoveAt(index);
        }
    }
}
