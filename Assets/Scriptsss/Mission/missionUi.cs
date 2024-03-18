
using QuachDai.NinjaSchool.Monsters;
using TMPro;
using UnityEngine;
namespace QuachDai.NinjaSchool.Mission
{
    public class MissionUi : MonoBehaviour
    {
        public Mission _mission;
        public Monster[] Monsters;
        public TextMeshProUGUI textMeshProUGUI;

        // Start is called before the first frame update
        void Start()
        {
            _mission = new Mission();
            _mission.PrefabsMonster = Monsters;
        }
        public void Update()
        {
            if (!_mission.getMonster()) { textMeshProUGUI.text = "Chưa có nhiệm vụ"; return; }

            textMeshProUGUI.text = "Hạ gục " + _mission.QuantityMonsterDestroyed + "/ " + _mission.QuantityMonsterDestroy + " " + _mission.getMonster().nameMonster;
        }
        public void GiaoNhiemVu()
        {
            _mission.ThucHienNhiemVu();
        }
        public void AgreeMission()
        {
            _mission.getChangeState().AgreeMission();
        }
        public void CompleteMission()
        {
            _mission.getChangeState().CompleteMission();
        }
        public void CancelMission()
        {
            _mission.getChangeState().CancelMission();
        }
    }
}
