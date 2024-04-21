using QuachDai.NinjaSchool.Character;

namespace QuachDai.NinjaSchool.Mission
{
    public class MissionPerform : IMissionButton
    {

        public MissionPerform(Mission mission) : base(mission)
        {
            base.mission.missionState = EMissionState.MissionPerform;
            Player.Instance.SetMissionText(mission.QuantityMonsterDestroyed.ToString(), mission.QuantityMonsterDestroy.ToString(), mission.GetMonster().nameMonster);
        }
        public override bool CompleteMission()
        {
            TextTemplate.Instance.SetText("Hãy hoàn thành nhiệm vụ");
            return false;
        }

        public override bool CancelMission()
        {
            TextTemplate.Instance.SetText("Hủy nhiệm vụ thành công");
            mission.SetChangeMissionButton(new MissionNot(mission));
            return false;

        }
        public override bool AgreeMission()
        {
            TextTemplate.Instance.SetText("Hãy hoàn thành nhiệm vụ");
            return true;
        }
    }
}
