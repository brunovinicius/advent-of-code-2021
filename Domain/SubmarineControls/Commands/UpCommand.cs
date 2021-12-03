using Domain.Entity;
using Domain.SubmarineControls.States;

namespace Domain.SubmarineControls.Commands
{
    public class UpCommand : ICommand
    {
        public DistanceState State { get; set; }


        public UpCommand(DistanceState distanceState)
        {
            State = distanceState;
        }

        public void Execute(Submarine submarine)
        {
            submarine.Aim -= State.Distance;
        }
    }
}
