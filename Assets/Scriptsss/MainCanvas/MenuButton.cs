using QuachDai.NinjaSchool.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace QuachDai.NinjaSchool.MainCanvas
{
    public class MenuButton : MonoBehaviour
    {
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
        [SerializeField] 
        private void ListenerMethod()
        {
            Player.Instance.SaveDataPlayer();
            SceneManager.LoadScene("GameMenu");
        }
    }
}
