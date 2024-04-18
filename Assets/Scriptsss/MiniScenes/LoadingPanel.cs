using System;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Scenes
{
    public class LoadingPanel : Singleton<LoadingPanel>
    {
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
        public IEnumerator LoadingPopUp(Action _action,float _fakeLoadTime)
        {
            progess = 0;
            currentFakeLoadTime = _fakeLoadTime;
            while (progess <= 1)
            {
                currentFakeLoadTime -= Time.deltaTime;
                progess = 1 - (currentFakeLoadTime / _fakeLoadTime);
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
