using Grimthole.Core;
using Grimthole.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Grimthole.Controllers
{
	public class ExplorationController : Controller
    {
        public override void Update(Entity entity, GameTime gt)
        {
			int delta = -10;
            if (entity.GetType() == typeof(Player))
            {
                delta = -delta;
            }
            UseControllerInput(entity, delta);
            UseKeyboardInputs(entity, delta);
        }

        void UseControllerInput(Entity entity, int delta)
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            // Get the current state of Controller1
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            if (capabilities.IsConnected && capabilities.HasLeftXThumbStick)
            {
                if (state.ThumbSticks.Left.X < -0.5f)
                {
                    MoveCommand.MoveLeft(entity, delta);
                }

                if (state.ThumbSticks.Left.X > 0.5f)
                {
                    MoveCommand.MoveRight(entity, delta);
                }

                if (state.ThumbSticks.Left.Y > 0.5f)
                {
                    MoveCommand.MoveDown(entity, delta);
                }

                if (state.ThumbSticks.Left.Y < -0.5f)
                {
                    MoveCommand.MoveUp(entity, delta);
                }
            }
        }

        void UseKeyboardInputs(Entity entity, int delta)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveCommand.MoveRight(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveCommand.MoveLeft(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                MoveCommand.MoveUp(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                MoveCommand.MoveDown(entity, delta);
            }
        }
    }
}
