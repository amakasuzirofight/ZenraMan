
namespace Zenra
{
    namespace Inputer
    {
        interface IInputer
        {
            float HoriMoveDir();
            float VertMoveDir();
            bool IsItemButtonDown();
            bool IsGimmickActivateButtonDown();
            bool IsLadderClimbButtonDown();
        }
    }
}
