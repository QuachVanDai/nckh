
using UnityEngine;

public class missionUi : MonoBehaviour
{
    private mission _mission;
    public bool iscom, isNhiemVu;
    // Start is called before the first frame update
    void Start()
    {
        _mission = new mission();
        iscom = _mission._IsComplete;
        isNhiemVu = _mission._nhiemvu;
    }
    public void isComplete()
    {
        _mission._IsComplete = !_mission._IsComplete;
        iscom = _mission._IsComplete;
        if(iscom)
        {
            _mission.setChangeState(new missionComplete(_mission));
        }
    }
    public void isNhiemvu()
    {
        _mission._nhiemvu = !_mission._nhiemvu;
        isNhiemVu = _mission._nhiemvu;
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
