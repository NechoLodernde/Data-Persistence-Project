using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameText : MonoBehaviour
{
    void Start()
    {
        var input = gameObject.GetComponent<TMP_InputField>();
        var se = new InputField.SubmitEvent();
        input.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string arg0)
    {
        MenuManager.Instance.playerName = arg0;
        Debug.Log(arg0);
    }
}
