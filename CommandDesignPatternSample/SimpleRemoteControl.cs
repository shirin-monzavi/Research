namespace CommandDesignPatternSample
{
    public class SimpleRemoteControl
    {
        ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ButtonWasPressed()
        {
            _command.Execute();
        }

        public void UndoWasPressed()
        {
            _command.Undo();
        }
    }
}
