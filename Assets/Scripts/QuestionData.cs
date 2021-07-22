using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionData : MonoBehaviour
{
    private static float dataSize;

    public static float DataSize
    {
        get
        {
            return dataSize;
        }

        set
        {
            PlayerPrefs.SetFloat("QuestionDataSize" + CreateDecisionMaker.EntryNumber(), value);
            dataSize = value;
        }
    }

    // zero index is the question. One - Eight are the questions.
    public string[] data;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void InsertData(int index)
    {
        TMPro.TMP_InputField[] textInputs = AdjustTextInputField.GetAllInputFieldsOrdered();
        data[index] = textInputs[index].text;

        PlayerPrefs.SetString("QuestionData" + index.ToString() + "Entry" + CreateDecisionMaker.EntryNumber(), data[index]);

    }

    public void RemoveData(int index)
    {
        PlayerPrefs.DeleteKey("QuestionData" + index.ToString() + "Entry" + CreateDecisionMaker.EntryNumber());
    }

    public static void LoadDefaultValues()
    {
        DataSize = 5;
    }
}
