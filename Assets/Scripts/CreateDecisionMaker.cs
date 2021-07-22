using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreateDecisionMaker : MonoBehaviour
{
    public GameObject DecisionMakerTemplate;
    public Color[] colours;
    public Sprite[] sprites;

    public static int currentEntry;

    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(this);
        //PlayerPrefs.DeleteAll();

        for (int i = 0; i < PlayerPrefs.GetFloat("numberOfSavedEntries"); i++)
        {
            GameObject newDecisionMaker = Instantiate(DecisionMakerTemplate);
            newDecisionMaker.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("QuestionData0Entry" + i);
            newDecisionMaker.name = newDecisionMaker.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            newDecisionMaker.transform.SetParent(DecisionMakerTemplate.transform.parent);

            Transform origami = newDecisionMaker.transform.GetChild(1);

            origami.GetChild(0).gameObject.GetComponent<Image>().color = colours[(int)PlayerPrefs.GetFloat("TopLeftColourPrimary" + i.ToString())];
            origami.GetChild(1).gameObject.GetComponent<Image>().color = colours[(int)PlayerPrefs.GetFloat("TopRightColourPrimary" + i.ToString())];
            origami.GetChild(2).gameObject.GetComponent<Image>().color = colours[(int)PlayerPrefs.GetFloat("BottomLeftColourPrimary" + i.ToString())];
            origami.GetChild(3).gameObject.GetComponent<Image>().color = colours[(int)PlayerPrefs.GetFloat("BottomRightColourPrimary" + i.ToString())];

            origami.GetChild(0).gameObject.GetComponent<Image>().sprite = sprites[(int)PlayerPrefs.GetFloat("TopLeftTexPrimary" + i.ToString())];
            origami.GetChild(1).gameObject.GetComponent<Image>().sprite = sprites[(int)PlayerPrefs.GetFloat("TopRightTexPrimary" + i.ToString())];
            origami.GetChild(2).gameObject.GetComponent<Image>().sprite = sprites[(int)PlayerPrefs.GetFloat("BottomLeftTexPrimary" + i.ToString())];
            origami.GetChild(3).gameObject.GetComponent<Image>().sprite = sprites[(int)PlayerPrefs.GetFloat("BottomRightTexPrimary" + i.ToString())];

            RectTransform content = newDecisionMaker.transform.parent.GetComponent<RectTransform>();
            VerticalLayoutGroup layout = content.gameObject.GetComponent<VerticalLayoutGroup>();

            content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y  + newDecisionMaker.GetComponent<RectTransform>().sizeDelta.y + layout.spacing);

            int count = i;
            newDecisionMaker.GetComponent<Button>().onClick.AddListener(delegate { LoadEntry(count); });
            for(int j = 0; j < newDecisionMaker.transform.childCount; j++)
            {
                if(newDecisionMaker.transform.GetChild(j).GetComponent<Button>() != null)
                {
                    newDecisionMaker.transform.GetChild(j).GetComponent<Button>().onClick.AddListener(delegate { LoadEntry(count); });
                }
            }
            newDecisionMaker.SetActive(true);
        }
    }

    public void Create()
    {
        ItterateEntry();
        currentEntry = (int) PlayerPrefs.GetFloat("numberOfSavedEntries") - 1;
        DesignData.LoadDefaultValues();
        QuestionData.LoadDefaultValues();
    }

    public void LoadEntry(int index)
    {
        currentEntry = index;
    }

    public static string EntryNumber()
    {
        return (PlayerPrefs.GetFloat("numberOfSavedEntries") - 1f).ToString();
    }

    public static void ItterateEntry()
    {
        float numberOfSavedEntries = PlayerPrefs.GetFloat("numberOfSavedEntries") + 1;
        PlayerPrefs.SetFloat("numberOfSavedEntries", numberOfSavedEntries);
    }
}
