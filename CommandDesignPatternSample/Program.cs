using CommandDesignPatternSample;

class Program
{
    public static void Main(string[] args)
    {
        #region Simple
        //invoker
        var simpleRemoteControl = new SimpleRemoteControl();

        //reciever
        Light light = new Light();


        //create command
        LightOnCommand lightOnCommand = new LightOnCommand(light);
        LightOffCommand lightOffCommand = new LightOffCommand(light);

        //set command
        simpleRemoteControl.SetCommand(lightOnCommand);
        simpleRemoteControl.ButtonWasPressed();


        simpleRemoteControl.SetCommand(lightOffCommand);
        simpleRemoteControl.ButtonWasPressed();

        #endregion

        Console.WriteLine("-------------------------");

        #region Lamda
        var lamda = new LamdaRemoteController(() => light.On());

        lamda.ButtonWasPressed();
        #endregion


        Console.WriteLine("-------------------------");

        #region Undo
        //invoker
        var simpleRemoteControl1 = new SimpleRemoteControl();

        //reciever
        Light light1 = new Light();

        //create command
        LightOnCommand lightOnCommand1 = new LightOnCommand(light);

        //set command
        simpleRemoteControl.SetCommand(lightOnCommand);
        simpleRemoteControl.ButtonWasPressed();
        simpleRemoteControl.UndoWasPressed();
        #endregion


    }
}