
using System.Diagnostics;

public class missionPerform : ImissionState
{

    public missionPerform(mission mission):base(mission)
    {
    }
    public override bool CompleteMission()
    {
        if (_mission._IsComplete == false)
        {
            Debug.Write("Nhiệm vụ chưa hoàn thành");
            TextTemplate.Instance.SetText("Nhiệm vụ chưa hoàn thành");
            return false;
        }
        return true;
    }

    public override bool CancelMission()
    {
        _mission._nhiemvu = false;
        TextTemplate.Instance.SetText("Hủy nhiệm vụ MissionPerform");
        _mission.setChangeState(new missionNot(_mission));
        return true;

    }
    public override bool AgreeMission()
    {
        if(_mission._IsComplete)
        {
            TextTemplate.Instance.SetText("Hoàn thành nhiệm vụ để nhận thưởng");
        }
        else
        {
            TextTemplate.Instance.SetText("Hãy đi làm nhiệm vụ");
        }
        return true;
    }
}
