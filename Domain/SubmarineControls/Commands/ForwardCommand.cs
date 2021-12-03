using Domain.Entity;
using Domain.SubmarineControls.States;

namespace Domain.SubmarineControls.Commands
{
    public class ForwardCommand : ICommand
    {
        public DistanceState State { get; set; }

        public ForwardCommand(DistanceState distanceState)
        {
            State = distanceState;
        }

        public void Execute(Submarine submarine)
        {
            submarine.Odometer += State.Distance;
            submarine.Depth += submarine.Aim * State.Distance;
        }
    }
}
