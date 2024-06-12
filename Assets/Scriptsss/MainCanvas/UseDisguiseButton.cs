using QuachDai.NinjaSchool.Character;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class UseDisguiseButton : MonoBehaviour
    {
        [SerializeField] DisguiseSO disguiseSO;
        Player player => Player.Instance;
        PlayerItem playerItem => PlayerItem.Instance;
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
        public void Start()
        {
            ListenerMethod();
        }
        private void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }

        private void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }
        public void ListenerMethod()
        {
            Debug.Log("UseDisguiseButton");
            if (!disguiseSO) return;
            if (player.GetLevel() >= disguiseSO.Level)
            {
                playerItem.SetData(disguiseSO);
                playerItem.SaveData();
                playerItem.SetDisguise();
                playerItem.SetData(null);
            }
            else TextTemplate.Instance.SetText("RequiresLevel: " + disguiseSO.Level);
        }
        public void SetDisguise(DisguiseSO _disguiseSO)
        {
            this.disguiseSO = _disguiseSO;
        }
    }
}
