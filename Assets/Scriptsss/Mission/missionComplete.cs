

using System.Diagnostics;
using TMPro;

public class MissionComplete : IMissionState
{
    public MissionComplete(Mission mission) : base(mission)
    {
        
    }

    public override bool CompleteMission()
    {
        if(_mission.IsCompleteMission==true) 
        {
            TextTemplate.Instance.SetText("Đây là phần thưởng");
            _mission.setChangeState(new MissionNot(_mission));
            return true;
        }
        return false;
    }

    public override bool CancelMission()
    {
        TextTemplate.Instance.SetText("Hủy nhiệm vụ thành công");
        _mission.setChangeState(new MissionNot(_mission));
        return true;
    }
    public override bool AgreeMission()
    {
        if (_mission.IsCompleteMission == true)
        {
            TextTemplate.Instance.SetText("Hoàn thành nhiệm vụ để nhận thưởng");
            return true;
        }
        TextTemplate.Instance.SetText("Hãy hoàn thành nhiệm vụ trước đó");
        return false;
    }
}
