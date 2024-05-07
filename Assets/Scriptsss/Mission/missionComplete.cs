

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
                mission.GiveTheReward();
                mission.SetChangeMissionButton(new MissionNot(mission));
                return true;
            }
            return false;
        }

        public override bool CancelMission()
        {
            TextTemplate.Instance.SetText("Mission canceled successfully");
            mission.SetChangeMissionButton(new MissionNot(mission));
            return true;
        }
        public override bool AgreeMission()
        {
            if (mission.IsCompleteMission == true)
            {
                TextTemplate.Instance.SetText("Complete tasks to receive rewards");
                return true;
            }
            TextTemplate.Instance.SetText("Please complete the previous mission");
            return false;
        }
    }
}
