using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class AdjustTextInputField : MonoBehaviour
{
    public GameObject TextInputField;
    public GameObject VerticalLayout;
    public GameObject HorizontalLayout;
    public GameObject TheQuestionData;

    public void AddTextInput()
    {
        TMP_InputField[] textInputs = FindObjectsOfType<TMP_InputField>();
        int count = textInputs.Length;

        GameObject text = Instantiate(TextInputField);
        text.transform.SetParent(VerticalLayout.transform, false);
        text.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Options " + count.ToString() + "...";
        text.GetComponent<TMP_InputField>().text = "";
        VerticalLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(VerticalLayout.GetComponent<RectTransform>().sizeDelta.x,
                                                                               VerticalLayout.GetComponent<RectTransform>().sizeDelta.y + 30f);
        //VerticalLayout.transform.localPosition -= (Vector3.up * 50);
        QuestionData.DataSize = textInputs.Length;
        TheQuestionData.GetComponent<QuestionData>().data = new string[textInputs.Length];
        text.name = "InputField (TMP) + (" + textInputs.Length.ToString() + ")";
    }

    public void RemoveTextInput()
    {
        if (VerticalLayout.transform.childCount > 1)
        {
            GameObject[] textInputs = TextInputsOrdered();

            textInputs[textInputs.Length - 1].transform.SetParent(null, false);
            Destroy(textInputs[textInputs.Length - 1].gameObject);

            
            TheQuestionData.GetComponent<QuestionData>().data[textInputs.Length] = "";
            TheQuestionData.GetComponent<QuestionData>().RemoveData(textInputs.Length);
            VerticalLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(VerticalLayout.GetComponent<RectTransform>().sizeDelta.x,
                                                                                 VerticalLayout.GetComponent<RectTransform>().sizeDelta.y - 30f);
            //VerticalLayout.transform.localPosition += (Vector3.up * 50);
            QuestionData.DataSize = textInputs.Length + 1;
        }
    }

    public static GameObject[] TextInputsOrdered()
    {
        GameObject VerticalLayout = GameObject.Find("Content");
        List<GameObject> textInputs = new List<GameObject>();

        for (int i = 0; i < VerticalLayout.transform.childCount; i++)
        {
            if (VerticalLayout.transform.GetChild(i).GetComponent<TMP_InputField>() != null)
            {
                textInputs.Add(VerticalLayout.transform.GetChild(i).gameObject);
            }
        }
        return textInputs.ToArray();
    }

    public static TMP_InputField[] GetAllInputFieldsOrdered()
    {
        List<GameObject> list = TextInputsOrdered().ToList();

        list.Insert(0, GameObject.Find("Question InputField (0)"));

        List<TMP_InputField> textInputs = new List<TMP_InputField>();

        for(int i = 0; i < list.Count; i++)
        {
            textInputs.Add(list[i].GetComponent<TMP_InputField>());
        }
        return textInputs.ToArray();
    }
}
