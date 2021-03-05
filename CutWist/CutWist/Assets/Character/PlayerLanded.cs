using Platformer.Core;
using Platformer.Mechanics;

//地面についた時のアクション
namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player character lands after being airborne.
    /// </summary>
    /// <typeparam name="PlayerLanded"></typeparam>
    public class PlayerLanded : Simulation.Event<PlayerLanded>
    {
        public Player player;

        public override void Execute()
        {

        }
    }
}