using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPatternSample
{
    public class RemoteControl
    {
        ICommand[] onCommands = new ICommand[7];
        ICommand[] offCommands = new ICommand[7];

        public RemoteControl()
        {
            NoCommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }

        public void setCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }
        public void onButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
        }
        public void offButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
        }


    }
}
