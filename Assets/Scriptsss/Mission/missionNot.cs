

//using System.Diagnostics;
//using UnityEngine;

using System.Diagnostics;

public class missionNot : ImissionState
{

    public missionNot(mission mission):base(mission)
    {
        _mission._nhiemvu = false;
        _mission._IsComplete = false;
    }
    public override bool CompleteMission()
    {
        _mission._IsComplete = false;
        TextTemplate.Instance.SetText("Chưa có nhiệm vụ MissionNot");
        return false;
    }
    public override bool CancelMission()
    {
        _mission._nhiemvu = false;
        TextTemplate.Instance.SetText("Chưa có nhiệm vụ để hủy MissionNot");
        return true;
    }
    public override bool AgreeMission()
    {
        if(_mission._nhiemvu==false)
        {
            Debug.Write("Đã nhiệm vụ MissionNot");
            TextTemplate.Instance.SetText("Đã nhiệm vụ MissionNot");
            _mission.setChangeState(new missionPerform(_mission));
        }
        return true;
    }
}
