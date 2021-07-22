using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadQuestionData : MonoBehaviour
{
    private GameObject questionData;
    private QuestionData data;
    private string question;
    private string write;
    private float writeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //data = FindObjectOfType<QuestionData>();

        //writeSpeed = 0.05f;

        float size = 0;

        if (data == null)
        {
            questionData = new GameObject();
            size = PlayerPrefs.GetFloat("QuestionDataSize" + CreateDecisionMaker.currentEntry.ToString());
            questionData.AddComponent<QuestionData>();
            data = questionData.GetComponent<QuestionData>();
            data.data = new string[(int)size];

            for (int i = 0; i < size; i++)
            {
                data.data[i] = PlayerPrefs.GetString("QuestionData" + i.ToString() + "Entry" + CreateDecisionMaker.currentEntry.ToString());
            }
        }

        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DecisionMaterSetupScene")
        {
            LoadTextInputField(size);
            return;
        }
        
        write = "";
        question = "Your Question: " + data.data[0];
        writeSpeed = 0.0f;
        writeSpeed = 2.0f / (float)question.Length;
        StartCoroutine(WriteQuestion());
        SelectRandomOption();
    }

    IEnumerator WriteQuestion()
    {
        float timeTaken = 0.0f;
        while (question != "")
        {
            yield return new WaitForSeconds(writeSpeed);
            
            write += question.ToCharArray()[0].ToString();
            GetComponent<TMPro.TextMeshProUGUI>().text = write;
            GetComponent<TextBackground>().BreakUpTextObject();
            question = question.Remove(0, 1);
            timeTaken += writeSpeed;
            //Debug.Log(write);
        }
        yield return new WaitForSeconds(writeSpeed);
        GetComponent<TMPro.TextMeshProUGUI>().text = write;
        GetComponent<TextBackground>().BreakUpTextObject();
        timeTaken += writeSpeed;
        Debug.Log(timeTaken);
    }

    private void SelectRandomOption()
    {
        List<string> options = new List<string>();

        for(int i = 1; i < data.data.Length-1; i++)
        {
            if(data.data[i] != "" &&
               data.data[i] != " ")
            {
                options.Add(data.data[i]);
            }
        }

        int random = Random.Range(0, options.Count);

        OrigamiManager.instance.orgami[4].transform.GetChild(12).gameObject.GetComponent<TMPro.TextMeshPro>().text = options[random];
        OrigamiManager.instance.orgami[4].transform.GetChild(13).gameObject.GetComponent<TMPro.TextMeshPro>().text = options[random];
        OrigamiManager.instance.orgami[4].transform.GetChild(14).gameObject.GetComponent<TMPro.TextMeshPro>().text = options[random];
        OrigamiManager.instance.orgami[4].transform.GetChild(15).gameObject.GetComponent<TMPro.TextMeshPro>().text = options[random];

        Debug.Log(options[random]);
       
    }

    private void LoadTextInputField(float size)
    {
        TMP_InputField[] textInputFields = AdjustTextInputField.GetAllInputFieldsOrdered();
        AdjustTextInputField adjust = GameObject.Find("Main Camera").GetComponent<AdjustTextInputField>();

        for (int i = 0; i < textInputFields.Length; i++)
        {
            if (textInputFields.Length > size)
            {
                adjust.RemoveTextInput();
            }
        }

        for (int i = 0; i < size; i++)
        {
            if (textInputFields.Length < size)
            {
                adjust.AddTextInput();
            }
        }

        for (int i = 0; i < size; i++)
        {
            string test = PlayerPrefs.GetString("QuestionData" + i.ToString() + "Entry" + CreateDecisionMaker.EntryNumber());
            if (test == null)
                return;

            textInputFields[i].text = PlayerPrefs.GetString("QuestionData" + i.ToString() + "Entry" + CreateDecisionMaker.EntryNumber());
        }
    }
}
