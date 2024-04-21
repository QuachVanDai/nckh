namespace QuachDai.NinjaSchool.Mission
{
    public abstract class IMissionButton
    {
        public Mission mission;

        public IMissionButton(Mission _mission)
        {
            this.mission = _mission;
        }
        public virtual bool CompleteMission() { return true; }
        public virtual bool CancelMission()
        {
            return true; 
        }
        public virtual bool AgreeMission() { return true; }
    }
 
}


public enum EMissionButton
{
    None = 0,
    AgreeMission = 1,
    CompleteMission = 2,
    CancelMission = 3,
}