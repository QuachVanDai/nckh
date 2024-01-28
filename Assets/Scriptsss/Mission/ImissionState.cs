
public abstract class IMissionState 
{
   public Mission _mission;

    public IMissionState (Mission mission)
    {
        this._mission = mission;
    }
    public virtual bool CompleteMission() { return true; }
    public virtual bool CancelMission() { return true; }
    public virtual bool AgreeMission() { return true; }

}
