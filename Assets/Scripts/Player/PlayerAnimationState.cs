namespace Zenra
{
    namespace Player
    {
        public enum PlayerAnimState
        {
            IDLE,
            RUN,
            CLIMBING,
        }

        public enum PlayerAnimStateExecutionMethod
        {
            PLAY_ONE_SHOT,
            UPDATE,
            FIXED_TIME,
            
        }
    }
}