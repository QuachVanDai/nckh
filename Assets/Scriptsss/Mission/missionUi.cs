using QuachDai.NinjaSchool.Monsters;
using QuachDai.NinjaSchool.Scenes;
using UnityEngine;
namespace QuachDai.NinjaSchool.Mission
{
    public class MissionUi : Singleton<MissionUi>
    {
        public Mission _mission;
        public Monster[] Monsters;

        void Start()
        {
            _mission = new Mission();
            _mission.PrefabsMonster = Monsters;
        }
        public MiniSceneId GetPlaceOfAppearance()
        {
            return _mission.placeOfAppearance;
        }
        public EMissionState GetMissionState()
        {
            return _mission.missionState;
        }
        public Monster GetMonster()
        {
            return _mission.GetMonster();
        }
        public MonsterID GetIDMonster()
        {
            return _mission.GetMonster().ID;
        }
        public void GiveTasks()
        {
            _mission.CarryOutAMission();
        }
        public void AgreeMission()
        {
            _mission.GetChangeMissionButton().AgreeMission();
        }
        public void CompleteMission()
        {
            _mission.GetChangeMissionButton().CompleteMission();

        }
        public void CancelMission()
        {
            _mission.GetChangeMissionButton().CancelMission();
        }
    }
}
