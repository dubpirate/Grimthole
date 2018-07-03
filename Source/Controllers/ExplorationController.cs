using Grimthole.Core;
using Grimthole.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Grimthole.Controllers
{
	public class ExplorationController : Controller
    {
		public override void Update(Player player, GameTime gt)
        {
			int delta = 10;
            UseControllerInput(player, delta);
            UseKeyboardInputs(player, delta);
        }

        void UseControllerInput(Player player, int delta)
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            // Get the current state of Controller1
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            if (capabilities.IsConnected && capabilities.HasLeftXThumbStick)
            {
                if (state.ThumbSticks.Left.X < -0.5f)
                {
                    MoveCommand.MoveLeft(player, delta);
                }

                if (state.ThumbSticks.Left.X > 0.5f)
                {
                    MoveCommand.MoveRight(player, delta);
                }

                if (state.ThumbSticks.Left.Y > 0.5f)
                {
                    MoveCommand.MoveDown(player, delta);
                }

                if (state.ThumbSticks.Left.Y < -0.5f)
                {
                    MoveCommand.MoveUp(player, delta);
                }
            }
        }

        void UseKeyboardInputs(Player player, int delta)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveCommand.MoveRight(player, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveCommand.MoveLeft(player, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                MoveCommand.MoveUp(player, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                MoveCommand.MoveDown(player, delta);
            }
        }
    }
}
