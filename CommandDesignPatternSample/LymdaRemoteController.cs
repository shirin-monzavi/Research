using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPatternSample
{
    public class LamdaRemoteController
    {
        Action _action;
        public LamdaRemoteController(Action action)
        {
            _action = action;
        }

        public void ButtonWasPressed()
        {
            _action.Invoke();
        }
    }
}
