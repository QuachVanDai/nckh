using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Mission;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class ShowMissionButton : MonoBehaviour
    {
        public InformationMissionPanel informationMissionPanel;
        Player player => Player.Instance;
        MissionUi missionUi=> MissionUi.Instance;
        Button button;
        [SerializeField]
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
        private void ListenerMethod()
        {
            informationMissionPanel.SetNameMissionText(player.GetMissionText());
            informationMissionPanel.SetNoteText(missionUi.GetPlaceOfAppearance().ToString());
            informationMissionPanel.SetStatusText(missionUi.GetMissionState().ToString());
        }
    }
}
