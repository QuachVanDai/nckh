using QuachDai.NinjaSchool.Scenes;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaitTime : MonoBehaviour
{
    [SerializeField] RobotMove robotMove;
    [SerializeField] Text waitTime;
    [SerializeField] float fakeLoadTime;
    float currentFakeLoadTime;
    float progess = 0;
    private void Start()
    {
        StartCoroutine(LoadingPopUp());

    }
    public void SetActive(bool values)
    {
        gameObject.SetActive(values);
    }

    public IEnumerator LoadingPopUp()
    {
        progess = 0;
        currentFakeLoadTime = 5;
        while (progess <= fakeLoadTime)
        {
            progess += Time.deltaTime;
            waitTime.text = progess.ToString();
            yield return null;
        }
        waitTime.text = "Start";
        yield return new WaitForSeconds(0.2f);
        robotMove.IsMove = true;
        yield return new WaitForSeconds(0.1f);
        SetActive(false);
    }
}
