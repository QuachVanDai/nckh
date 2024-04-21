
using QuachDai.NinjaSchool.Character;
using UnityEngine;
namespace QuachDai.NinjaSchool.Mission
{
    public class MissionNot : IMissionButton
    {

        public MissionNot(Mission mission) : base(mission)
        {
            base.mission.QuantityMonsterDestroy = 0;
            base.mission.missionState = EMissionState.None;
            base.mission.QuantityMonsterDestroyed = 0;
            base.mission.IsHasMission = false;
            base.mission.IsCompleteMission = false;
            base.mission.MonsterID = -1;
            Player.Instance.SetMissionText("", "", "");
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
            if (mission.IsHasMission == false)
            {
                TextTemplate.Instance.SetText("Đã nhận nhiệm vụ");
                mission.SetUpMisson();
                mission.SetChangeMissionButton(new MissionPerform(mission));
                return true;
            }
            else
            {
                TextTemplate.Instance.SetText("Hãy hoàn thành nhiệm vụ trước đó");
                return false;
            }
        }

    }
}
