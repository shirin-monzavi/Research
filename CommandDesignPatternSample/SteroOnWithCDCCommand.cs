using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPatternSample
{
    public class SteroOnWithCDCCommand : ICommand
    {
        Stero stero;
        public SteroOnWithCDCCommand(Stero stero)
        {
            this.stero = stero;
        }

        public void Execute()
        {
            stero.On();
            stero.SetCD();
            stero.SetVolume();
        }

        public void Undo()
        {
           throw new NotImplementedException();
        }
    }
}
