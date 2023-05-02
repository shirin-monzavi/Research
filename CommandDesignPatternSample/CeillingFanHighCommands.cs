using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPatternSample
{
    public class CeillingFanHighCommand : ICommand
    {
        CeillingFan ceilling;
        int prevSpeed;
        public CeillingFanHighCommand(CeillingFan ceilling)
        {
            this.ceilling = ceilling;

        }
        public void Execute()
        {
            prevSpeed = ceilling.GetSpeed();
            ceilling.High();
        }

        public void Undo()
        {
            if (prevSpeed == CeillingFan.HIGH)
            {
                ceilling.High();
            }else if(prevSpeed == CeillingFan.LOW)
            {
                ceilling.Low();
            }else if (prevSpeed == CeillingFan.MEDIUM)
            {
                ceilling.Medium();
            }
            else
            {
                ceilling.Off();
            }
        }
    }
}
