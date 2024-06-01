using QuachDai.NinjaSchool.Character;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour
{
    private static Action<string, Action, Action> _instanceCallback;

    public static void Ask(string message, Action yesAction = null, Action noAction = null)
    {
        if (_instanceCallback != null)
        {
            _instanceCallback.Invoke(message, yesAction, noAction);
        }
        else
        {
            yesAction?.Invoke();
        }
    }
    [SerializeField] private Text messageText;

    private Action _yesAction;

    private Action _noAction;

    private void Awake()
    {
        _instanceCallback = AskForConfirmInternal;
    }

    private void AskForConfirmInternal(string message, Action yesAction, Action noAction)
    {
        gameObject.SetActive(true);
        messageText.text = message;
        this._yesAction = yesAction;
        this._noAction = noAction;
        Time.timeScale = 0f;
    }
    public void YesButtonClicked()
    {
        try
        {
            Player.Instance.SaveDataPlayer();
            Application.Quit();
            _yesAction?.Invoke();
        }
        catch
        {
            Application.Quit();
            _yesAction?.Invoke();
        }
    }

    public void NoButtonClicked()
    {
        Cancel();
        _noAction?.Invoke();
    }

    public void Cancel()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
