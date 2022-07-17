
namespace Platformer2D
{
    internal class ProfilePlayer 
    {
        public readonly SubscriptionProperty<GameState> CurrentState;

        public ProfilePlayer(float speedCar, GameState initialState) : this(speedCar)
        {
            CurrentState.Value = initialState;
        }

        public ProfilePlayer(float speed)
        {
            CurrentState = new SubscriptionProperty<GameState>();

        }

      

    }
}
