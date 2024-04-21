using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Mission
{
    public class MissionButton : MonoBehaviour
    {
        MissionUi missionUi => MissionUi.Instance; 
        Button button;
        Button ThisButton
        {
            get
            {
                if (button == null)
                    button = GetComponent<Button>();
                return button;
            }
        }
        private void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }

        private void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }
        public EMissionButton state;
        private void ListenerMethod()
        {
            switch (state)
            {
                case EMissionButton.AgreeMission:
                    missionUi.AgreeMission();
                    break;
                case EMissionButton.CompleteMission:
                    missionUi.CompleteMission();
                    break;
                case EMissionButton.CancelMission:
                    missionUi.CancelMission();
                    break;

            }
        }
    }
}

