using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutCompetition : MonoBehaviour
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
    private void ListenerMethod()
    {
    }
}
