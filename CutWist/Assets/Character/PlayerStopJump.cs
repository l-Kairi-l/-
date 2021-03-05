using Platformer.Core;
using Platformer.Mechanics;

//アクションはEventで管理されていてExecuteで実行される
//クラスを定義してEventを呼び出す

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the Jump Input is deactivated by the user, cancelling the upward velocity of the jump.
    /// </summary>
    /// <typeparam name="PlayerStopJump"></typeparam>
    public class PlayerStopJump : Simulation.Event<PlayerStopJump>
    {
        public Player player;

        public override void Execute()
        {

        }
    }
}

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player performs a Jump.
    /// </summary>
    /// <typeparam name="PlayerJumped"></typeparam>
    public class PlayerJumped : Simulation.Event<PlayerJumped>
    {
        public Player player;

        public override void Execute()
        {
            //if (player.audioSource && player.jumpAudio)
            //    player.audioSource.PlayOneShot(player.jumpAudio);
        }
    }
}