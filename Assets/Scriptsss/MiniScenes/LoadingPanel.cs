using System;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Scenes
{
    public class LoadingPanel : Singleton<LoadingPanel>
    {
        const float fakeLoadTime = 1;
        float currentFakeLoadTime;
        float progess = 0;
        private void Start()
        {
            SetActive(false);
        }
        public void SetActive(bool values)
        {
            gameObject.SetActive(values);
        }
        public IEnumerator LoadingPopUp(Action _action)
        {
            progess = 0;
            currentFakeLoadTime = fakeLoadTime;
            while (progess <= 1)
            {
                currentFakeLoadTime -= Time.deltaTime;
                progess = 1 - (currentFakeLoadTime / fakeLoadTime);
                LoadingSlider.Instance.SetProgress(progess);
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            _action?.Invoke();
            yield return new WaitForSeconds(0.1f);
            SetActive(false);
        }
    }
}
