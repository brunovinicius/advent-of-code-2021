using Domain.Entity;
using Domain.SubmarineControls.States;

namespace Domain.SubmarineControls.Commands
{
    public class DownCommand : ICommand
    {
        public DistanceState State { get; set; }

        public DownCommand(DistanceState distanceState)
        {
            State = distanceState;
        }

        public void Execute(Submarine submarine)
        {
            submarine.Aim += State.Distance;
        }
    }
}
