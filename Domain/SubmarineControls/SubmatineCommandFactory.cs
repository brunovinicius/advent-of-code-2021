using Domain.Entity;
using Domain.SubmarineControls.Commands;
using Domain.SubmarineControls.States;

namespace Domain.SubmarineControls
{
    public class SubmatineCommandFactory
    {
        public ICommand CreateFromRawCommand(RawCommand rawCommand)
        {
            return rawCommand.Command switch
            {
                "forward" => (ICommand) new ForwardCommand(new DistanceState() { Distance = rawCommand.Distance }),
                "up" => (ICommand) new UpCommand(new DistanceState() { Distance = rawCommand.Distance }),
                "down" => (ICommand) new DownCommand(new DistanceState() { Distance = rawCommand.Distance }),
                _ => throw new InvalidOperationException($"Unexpected raw command { rawCommand.Command }")
            };
        }
    }
}
