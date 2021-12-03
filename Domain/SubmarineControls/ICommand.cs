using Domain.Entity;

namespace Domain.SubmarineControls
{
    public interface ICommand
    { 
        void Execute(Submarine submarine);
    }
}
