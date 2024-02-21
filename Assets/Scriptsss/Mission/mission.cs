
using Unity.VisualScripting;
using UnityEngine;

public class Mission 
{
    private IMissionState _State;
   
    public bool IsHasMission=false;
    public bool IsCompleteMission=false;
    public Monster[] PrefabsMonster;
    public int MonsterID=-1;
    public int QuantityMonsterDestroy=0, QuantityMonsterDestroyed=0;

    // private static mission _instance;
    //  public static mission Instance {  get { return _instance; } }

    public Mission()
    {
        setChangeState(new MissionNot(this));
        QuantityMonsterDestroy = 0;
        QuantityMonsterDestroyed = 0;
        IsHasMission = false;
        IsCompleteMission = false;
        MonsterID = -1;
    }
    public int getIndex()
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
    public Monster getMonster()
    {
        if (MonsterID == -1) return null;
        return PrefabsMonster[MonsterID];
    }

    public void ThucHienNhiemVu()
    {
        if (QuantityMonsterDestroyed + 1 > QuantityMonsterDestroy) return;
        QuantityMonsterDestroyed++;
        if (QuantityMonsterDestroy == QuantityMonsterDestroyed)
        {
            IsCompleteMission = true;
            setChangeState(new MissionComplete(this));
        }
    }

    public void GiaoPhanThuong()
    {
        int index = Random.Range(0,3);
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
        getIndex();
        IsHasMission = true;
    }

    public void setChangeState(IMissionState State)
    {
        this._State = State;
    }
    public IMissionState getChangeState()
    {
       return this._State ;
    }
}
