using TransitionsPlus;
using UnityEngine;
namespace QuachDai.NinjaSchool.Scenes
{
    public class LoadingScene : MonoBehaviour
    {
        [SerializeField] TransitionAnimator[] transitionAnimator;
        private void Start()
        {
            Invoke("Loading", 0.1f);
        }
        void Loading()
        {
            LoadingPanel.Instance.SetActive(true);
            LoadingPanel.Instance.StartCoroutine(LoadingPanel.Instance.LoadingPopUp(SetActive, 2f));
        }
        public void SetActive()
        {
            foreach (var transition in transitionAnimator)
                transition.gameObject.SetActive(true);
        }
    }
}
