using QuachDai.NinjaSchool.Scenes;
using System;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class PlayButton : MonoBehaviour
    {
        public NamePlayerText NamePlayerText;
        public GameObject errorPanel;
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
            string namePlayer = NamePlayerText.inputNamePlayer.text;
            int length = NamePlayerText.inputNamePlayer.text.Length;
          
            if (length > 10 || length < 5)
            {
                errorPanel.gameObject.SetActive(true);
                Debug.Log("Độ dài tên: "+length);
                return;
            }
            int asciiValue;
            for (int i = 0; i < length - 1; i++)
            {
                asciiValue = (int)namePlayer[i];
                if (asciiValue >= 97 && asciiValue <= 122
                    || asciiValue >= 48 && asciiValue <= 57)
                {

                }
                else
                {
                    errorPanel.gameObject.SetActive(true);
                    return;
                }

            }
            PlayerPrefs.SetInt(TagScript.firstPlay, 0);
            PlayerPrefs.SetInt(TagScript.level, 1);
            PlayerPrefs.SetFloat(TagScript.percentExp, 0);
            PlayerPrefs.SetString(TagScript.namePlayer, namePlayer);
            PlayerPrefs.SetInt(TagScript.xu, 0);
            PlayerPrefs.SetFloat(TagScript.volumeSound, 1);
            PlayerPrefs.SetFloat(TagScript.volumeMusic, 1);
            PlayerPrefs.SetString(TagScript.sceneCurrent,"SchoolScene");
            foreach (KeyShowOpion option in Enum.GetValues(typeof(KeyShowOpion)))
            {
                PlayerPrefs.SetInt(option.ToString(), 0);
            }
            LoadingScene.Instance.Loading();
        }
    }
}
