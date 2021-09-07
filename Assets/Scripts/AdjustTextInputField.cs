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

    private float height;

    private void Start()
    {
        height = TextInputField.GetComponent<RectTransform>().sizeDelta.y;
    }

    public void CreateTextInputField()
    {
        TMP_InputField[] textInputs = FindObjectsOfType<TMP_InputField>();
        int count = textInputs.Length;
        GameObject text = Instantiate(TextInputField);
        text.transform.SetParent(VerticalLayout.transform, false);
        text.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Options " + count.ToString() + "...";
        text.GetComponent<TMP_InputField>().text = "";
        VerticalLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(VerticalLayout.GetComponent<RectTransform>().sizeDelta.x,
                                                                               VerticalLayout.GetComponent<RectTransform>().sizeDelta.y + height);
        text.name = "InputField (TMP) + (" + textInputs.Length.ToString() + ")";
        text.GetComponent<TMP_InputField>().onValueChanged.RemoveAllListeners();
        text.GetComponent<TMP_InputField>().onValueChanged.AddListener(delegate { TheQuestionData.GetComponent<QuestionData>().InsertData(count); });
    }

    public void AddTextInput()
    {
        TMP_InputField[] textInputs = GetAllInputFieldsOrdered();
        int count = textInputs.Length;

        int size = count + 1;

        CreateTextInputField();

        QuestionData.DataSize = size;
        TheQuestionData.GetComponent<QuestionData>().data = new string[size];
        
    }

    public void RemoveTextInput()
    {
        if (VerticalLayout.transform.childCount > 1)
        {
            GameObject[] textInputs = TextInputsOrdered();

            int size = textInputs.Length - 1;

            //textInputs[textInputs.Length - 1].transform.SetParent(null, false);
            Destroy(textInputs[textInputs.Length - 1].gameObject);

            TheQuestionData.GetComponent<QuestionData>().data[size+1] = "";
            TheQuestionData.GetComponent<QuestionData>().RemoveData(size+1);
            QuestionData.DataSize = size + 1;

            VerticalLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(VerticalLayout.GetComponent<RectTransform>().sizeDelta.x,
                                                                                 VerticalLayout.GetComponent<RectTransform>().sizeDelta.y - height);
        }
    }

    public static GameObject[] TextInputsOrdered()
    {
        GameObject VerticalLayout = GameObject.FindGameObjectWithTag("Adjust");
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

        for (int i = 0; i < list.Count; i++)
        {
            textInputs.Add(list[i].GetComponent<TMP_InputField>());
        }
        return textInputs.ToArray();
    }
}
