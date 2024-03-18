namespace QuachDai.NinjaSchool.Mission
{
    public class MissionPerform : IMissionState
    {

        public MissionPerform(Mission mission) : base(mission)
        {
        }
        public override bool CompleteMission()
        {
            TextTemplate.Instance.SetText("Hãy hoàn thành nhiệm vụ");
            return false;
        }

        public override bool CancelMission()
        {
            TextTemplate.Instance.SetText("Hủy nhiệm vụ thành công");
            _mission.setChangeState(new MissionNot(_mission));
            return false;

        }
        public override bool AgreeMission()
        {
            TextTemplate.Instance.SetText("Hãy hoàn thành nhiệm vụ");
            return true;
        }
    }
}
