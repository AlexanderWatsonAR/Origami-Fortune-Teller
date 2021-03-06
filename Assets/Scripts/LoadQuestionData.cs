using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadQuestionData : MonoBehaviour
{
    public GameObject adjustTextInputField;
    private GameObject questionData;
    private QuestionData data;
    private string question;
    private string write;
    private float writeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<QuestionData>();

        //writeSpeed = 0.05f;

        float size = 5;

        if (data == null)
        {
            questionData = new GameObject();
            questionData.name = "Question_Data_Inside_Load_Question_Data_Script";
            questionData.AddComponent<QuestionData>();
            data = questionData.GetComponent<QuestionData>();

            if (CreateDecisionMaker.currentEntry == -1)
            {
                data.data = new string[5];
                data.data[0] = "Decision Maker (Example)";
                data.data[1] = "Test a";
                data.data[2] = "Test b";
                data.data[3] = "Test c";
                data.data[4] = "Test d";
            }
            else
            {
                size = PlayerPrefs.GetFloat("QuestionDataSize" + CreateDecisionMaker.currentEntry.ToString());
                data.data = new string[(int)size];

                for (int i = 0; i < size; i++)
                {
                    data.data[i] = PlayerPrefs.GetString("QuestionData" + i.ToString() + "Entry" + CreateDecisionMaker.currentEntry.ToString());
                }
            }
        }
        else
        {
            size = PlayerPrefs.GetFloat("QuestionDataSize" + CreateDecisionMaker.currentEntry.ToString());
            data.data = new string[(int)size];

            for (int i = 0; i < size; i++)
            {
                data.data[i] = PlayerPrefs.GetString("QuestionData" + i.ToString() + "Entry" + CreateDecisionMaker.currentEntry.ToString());
            }
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DecisionMaterSetupScene")
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
        TMP_InputField[] textInputFields = AdjustTextInputField.GetAllInputFieldsOrdered(); // including title.
        AdjustTextInputField adjust = adjustTextInputField.GetComponent<AdjustTextInputField>();

        int count = textInputFields.Length;

        for (int i = 0; i < count; i++)
        {
            if (count > size)
            {
                Destroy(textInputFields[count - 1].gameObject);
                count--;
            }
            else
            {
                break;
            }
        }
        
        for (int i = 0; i < size; i++)
        {
            if (count < size)
            {
                adjust.CreateTextInputField();
                count++;
            }
            else
            {
                break;
            }
        }

        textInputFields = AdjustTextInputField.GetAllInputFieldsOrdered();

        for (int i = 0; i < textInputFields.Length; i++)
        {
            string test = PlayerPrefs.GetString("QuestionData" + i.ToString() + "Entry" + CreateDecisionMaker.currentEntry);
            if (test == null)
                return;

            textInputFields[i].text = PlayerPrefs.GetString("QuestionData" + i.ToString() + "Entry" + CreateDecisionMaker.currentEntry);
        }
    }
}
