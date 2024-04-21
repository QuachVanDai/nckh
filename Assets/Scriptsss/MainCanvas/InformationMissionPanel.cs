using QuachDai.NinjaSchool.Character;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class InformationMissionPanel : MonoBehaviour
    {
        [SerializeField] Text nameMissionText;
        [SerializeField] Text note;
        [SerializeField] Text status;
        public void SetNameMissionText(string _missionText)
        {
            nameMissionText.text = _missionText;
        }

        public void SetNoteText(string _note)
        {
            note.text = "Note : Go to the " + _note;
        }

        public void SetStatusText(string _status)
        {
            status.text = "Status : " +_status;
        }
    }
}
