using Domain.Entity;

namespace Domain.SubmarineControls
{
    public class SubmarineCommandsExecutor
    {
        private readonly Submarine _submarine;

        public SubmarineCommandsExecutor(Submarine submarine)
        {
            _submarine = submarine;
        }

        public void ExecuteCommands(IList<ICommand> commands)
        {
            foreach (var command in commands)
            {
                command.Execute(_submarine);
            }
        }
    }
}
