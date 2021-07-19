namespace Zenra.Police
{
    public delegate void PoliceShot_delegate(float policePosX);
    interface IPoliceShot
    {
        event PoliceShot_delegate PoliceShotEvent;
    }
}