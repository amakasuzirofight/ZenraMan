
namespace Zenra
{
    namespace Player
    {
        interface IActionClimb
        {
            void shiftPlayerPos(float x);
            void actionClimb(bool isClimb);
            void changeMoveMode(int enumNum);
        }
    }
}
