using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPatternSample
{
    public interface ICommand
    {
        public void Execute();

        public void Undo();
    }
}
