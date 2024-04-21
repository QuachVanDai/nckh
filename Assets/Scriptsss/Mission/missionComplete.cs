

using QuachDai.NinjaSchool.Character;
using System.Diagnostics;
using TMPro;
namespace QuachDai.NinjaSchool.Mission
{
    public class MissionComplete : IMissionButton
    {
        public MissionComplete(Mission mission) : base(mission)
        {
            base.mission.missionState = EMissionState.MissionComplete;
        }

        public override bool CompleteMission()
        {
            if (mission.IsCompleteMission == true)
            {
                TextTemplate.Instance.SetText("Đây là phần thưởng");
                mission.GiveTheReward();
                mission.SetChangeMissionButton(new MissionNot(mission));
                return true;
            }
            return false;
        }

        public override bool CancelMission()
        {
            TextTemplate.Instance.SetText("Hủy nhiệm vụ thành công");
            mission.SetChangeMissionButton(new MissionNot(mission));
            return true;
        }
        public override bool AgreeMission()
        {
            if (mission.IsCompleteMission == true)
            {
                TextTemplate.Instance.SetText("Hoàn thành nhiệm vụ để nhận thưởng");
                return true;
            }
            TextTemplate.Instance.SetText("Hãy hoàn thành nhiệm vụ trước đó");
            return false;
        }
    }
}
