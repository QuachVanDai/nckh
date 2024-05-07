using QuachDai.NinjaSchool.Animations;
using QuachDai.NinjaSchool.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class RevivalButton : MonoBehaviour
    {
        [SerializeField] RegenerativePanel regenerativePanel;

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
        AnimatorSystem animatorSystem => AnimatorSystem.Instance;
        Player player => Player.Instance;

        private void ListenerMethod()
        {
            if(player.GetXu()<1000)
            {
                TextTemplate.Instance.SetText(TagScript.notMoney);
                return;
            }
            GameManager.Instance.IsPlayGame = true;
            animatorSystem.SetBool(player.GetAnimator(), "IsDeath", false);
            player.SetHp(player.GetMaxHp());
            player.SetMp(player.GetMaxMp());
            player.SetXu(-1000);
            regenerativePanel.SetActive(false);

        }
    }
}
