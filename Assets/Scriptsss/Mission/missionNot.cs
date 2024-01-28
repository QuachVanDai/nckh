
using UnityEngine;
public class MissionNot : IMissionState
{

    public MissionNot(Mission mission):base(mission)
    {
        _mission.QuantityMonsterDestroy = 0;
        _mission.QuantityMonsterDestroyed = 0;
        _mission.IsHasMission = false;
        _mission.IsCompleteMission = false;
        _mission.MonsterID = -1;
    }
    public override bool CompleteMission()
    {
        TextTemplate.Instance.SetText("Chưa có nhiệm vụ");
        return false;
    }
    public override bool CancelMission()
    {
        TextTemplate.Instance.SetText("Chưa có nhiệm vụ");
        return false;
    }
    public override bool AgreeMission()
    {
        if(_mission.IsHasMission==false)
        {
            TextTemplate.Instance.SetText("Đã nhận nhiệm vụ");
            _mission.SetUpMisson();
            _mission.setChangeState(new MissionPerform(_mission));
            return true;
        }
        else
        {
            TextTemplate.Instance.SetText("Hãy hoàn thành nhiệm vụ trước đó");
            return false;
        }
    }

}
