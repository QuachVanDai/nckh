using TransitionsPlus;
using UnityEngine;
namespace QuachDai.NinjaSchool.Scenes
{
    public class LoadingScene : Singleton<LoadingScene>
    {
        [SerializeField] TransitionAnimator[] transitionAnimator;

        public void Loading()
        {
            gameObject.SetActive(true);
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
