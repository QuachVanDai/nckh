

using System.Diagnostics;
using TMPro;

public class missionComplete : ImissionState
{
    public missionComplete(mission mission) : base(mission)
    {
        
    }

    public override bool CompleteMission()
    {
        if(_mission._IsComplete==true) 
        {
            TextTemplate.Instance.SetText("Hoàn thanh nhiem vu");
            return true;
        }
        return false;
    }

    public override bool CancelMission()
    {
        _mission.setChangeState(new missionNot(_mission));
        Debug.Write("Hủy nhiệm vụ MissionComplete");
        return true;
    }
    public override bool AgreeMission()
    {
        return true;
    }
}
