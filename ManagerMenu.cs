using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    abstract class ManagerMenu
    {
        protected abstract void Add();
        protected abstract void Delete();
        protected abstract void Update();
        protected abstract void Display();
    }
}
