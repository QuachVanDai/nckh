
using UnityEngine;

public class mission 
{
    private ImissionState _State;

    public bool _nhiemvu=false;
    public bool _IsComplete=false;
   // private static mission _instance;
  //  public static mission Instance {  get { return _instance; } }
    public mission()
    {
        setChangeState(new missionNot(this));
    }
   
    public void setChangeState(ImissionState State)
    {
        this._State = State;
    }
    public ImissionState getChangeState()
    {
       return this._State ;
    }
    /* public bool CompleteMission() { _State.CompleteMission(); return true;
     }
     public bool AgreeMission() { _State.AgreeMission(); return true;// can sua
     }
     public bool CancelMission() { _State.CancelMission(); return true;
     }

     public void setImissionState(ImissionState imissionState)
     {
         this._State = imissionState;
     }*/
    /* public ImissionState MissionPerform { get {  return this._missionPerform; } set { this._missionPerform = value;     } }
     public ImissionState MissionComplete { get {  return this._missionComplete; } set { this._missionComplete = value; } }
     public ImissionState MissionNot { get {  return this._missionNot; } set { this._missionNot = value; } }
     public ImissionState MissionState { get {  return this._State; } set {  if (this._State != value) { } } }*/

}
