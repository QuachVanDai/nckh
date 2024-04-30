

using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Monsters;
using QuachDai.NinjaSchool.Scenes;
using UnityEngine;
namespace QuachDai.NinjaSchool.Mission
{
    public class Mission
    {
        private IMissionButton missionButton;
        public EMissionState missionState;
        public MiniSceneId placeOfAppearance;
        public bool IsHasMission = false;
        public bool IsCompleteMission = false;
        public Monster[] PrefabsMonster;
        public int MonsterID = -1;
        public int QuantityMonsterDestroy = 0, QuantityMonsterDestroyed = 0;
        public Mission()
        {
            SetChangeMissionButton(new MissionNot(this));
            QuantityMonsterDestroy = 0;
            QuantityMonsterDestroyed = 0;
            IsHasMission = false;
            IsCompleteMission = false;
            MonsterID = -1;
        }


        public void CarryOutAMission() // thuc hien nhiem vu
        {
            if (QuantityMonsterDestroyed + 1 > QuantityMonsterDestroy) return;
            QuantityMonsterDestroyed++;
            Player.Instance.SetMissionText(QuantityMonsterDestroyed.ToString(), QuantityMonsterDestroy.ToString(), GetMonster().nameMonster);

            if (QuantityMonsterDestroy == QuantityMonsterDestroyed)
            {
                IsCompleteMission = true;
                SetChangeMissionButton(new MissionComplete(this));
            }
        }

        public void GiveTheReward() // trao phan thuong
        {
            int index = Random.Range(0, 3);
            switch (index)
            {
                case 0:
                    InventoryUpdate.Instance.UpdateHP(10);
                    break;

                case 1:
                    InventoryUpdate.Instance.UpdateMP(10);
                    break;
                case 2:
                    InventoryUpdate.Instance.UpdateMP(10);
                    break;
                case 3:
                    InventoryUpdate.Instance.UpdateHP(10);
                    break;
            }
        }
        public void SetUpMisson() //initialization
        {
            QuantityMonsterDestroy = Random.Range(5, 10);
            MonsterID = Random.Range(1, PrefabsMonster.Length);
            GetIndex();
            IsHasMission = true;
        }
        public int GetIndex()
        {
            for (int i = 0; i < PrefabsMonster.Length; i++)
            {
                if ((int)PrefabsMonster[i].ID == MonsterID)
                {
                    MonsterID = i;
                    break;
                }
            }
            return MonsterID;
        }
        public Monster GetMonster()
        {
            if (MonsterID == -1)
                return null;
            return PrefabsMonster[MonsterID];
        }

        public void SetChangeMissionButton(IMissionButton _missionButton)
        {
            this.missionButton = _missionButton;
        }
        public IMissionButton GetChangeMissionButton()
        {
            return this.missionButton;
        }
    }
}
public enum EMissionState
{
    None = 0,
    MissionPerform = 1,
    MissionComplete = 2,
}