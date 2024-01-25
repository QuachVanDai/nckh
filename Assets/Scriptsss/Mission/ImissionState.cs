
public abstract class ImissionState 
{
   public mission _mission;

    public ImissionState (mission mission)
    {
        this._mission = mission;
    }
    public virtual bool CompleteMission() { return true; }
    public virtual bool CancelMission() { return true; }
    public virtual bool AgreeMission() { return true; }

}
