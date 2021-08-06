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
        RectTransform content = DecisionMakerTemplate.transform.parent.GetComponent<RectTransform>();
        VerticalLayoutGroup layout = content.gameObject.GetComponent<VerticalLayoutGroup>();

        for (int i = 0; i < PlayerPrefs.GetFloat("numberOfSavedEntries"); i++)
        {
            if(PlayerPrefs.GetInt("Deleted" + i.ToString()) == 1)
            {
                continue;
            }

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

            content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y  + newDecisionMaker.GetComponent<RectTransform>().sizeDelta.y + layout.spacing);
            newDecisionMaker.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;
            newDecisionMaker.transform.GetChild(3).gameObject.GetComponent<Button>().interactable = true;
            newDecisionMaker.transform.GetChild(4).gameObject.GetComponent<Button>().interactable = true;
            int count = i;
            newDecisionMaker.GetComponent<Button>().onClick.AddListener(delegate { LoadEntry(count); });
            for(int j = 0; j < newDecisionMaker.transform.childCount; j++)
            {
                if(newDecisionMaker.transform.GetChild(j).GetComponent<Button>() != null)
                {
                    newDecisionMaker.transform.GetChild(j).GetComponent<Button>().onClick.AddListener(delegate { LoadEntry(count); });
                }
            }

            newDecisionMaker.transform.GetChild(newDecisionMaker.transform.childCount - 1).GetComponent<Button>().onClick.AddListener(delegate { Remove(count); });

            newDecisionMaker.SetActive(true);
        }
    }

    public void Remove(int index)
    {
        RectTransform content = DecisionMakerTemplate.transform.parent.GetComponent<RectTransform>();
        VerticalLayoutGroup layout = content.gameObject.GetComponent<VerticalLayoutGroup>();

        content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y - DecisionMakerTemplate.GetComponent<RectTransform>().sizeDelta.y - layout.spacing);
        string temp = index.ToString();

        // Delete design data.
        PlayerPrefs.DeleteKey("TopLeftColourPrimary" + temp);
        PlayerPrefs.DeleteKey("TopRightColourPrimary" + temp);
        PlayerPrefs.DeleteKey("BottomLeftColourPrimary" + temp);
        PlayerPrefs.DeleteKey("BottomRightColourPrimary" + temp);

        PlayerPrefs.DeleteKey("TopLeftColourSecondary" + temp);
        PlayerPrefs.DeleteKey("TopRightColourSecondary" + temp);
        PlayerPrefs.DeleteKey("BottomLeftColourSecondary" + temp);
        PlayerPrefs.DeleteKey("BottomRightColourSecondary" + temp);

        PlayerPrefs.DeleteKey("TopLeftTexPrimary" + temp);
        PlayerPrefs.DeleteKey("TopRightTexPrimary" + temp);
        PlayerPrefs.DeleteKey("BottomLeftTexPrimary" + temp);
        PlayerPrefs.DeleteKey("BottomRightTexPrimary" + temp);

        PlayerPrefs.DeleteKey("TopLeftTexSecondary" + temp);
        PlayerPrefs.DeleteKey("TopRightTexSecondary" + temp);
        PlayerPrefs.DeleteKey("BottomLeftTexSecondary" + temp);
        PlayerPrefs.DeleteKey("BottomRightTexSecondary" + temp);

        PlayerPrefs.DeleteKey("TopLeftStickerTex" + temp);
        PlayerPrefs.DeleteKey("TopRightStickerTex" + temp);
        PlayerPrefs.DeleteKey("BottomLeftStickerTex" + temp);
        PlayerPrefs.DeleteKey("BottomRightStickerTex" + temp);

        PlayerPrefs.DeleteKey("TopLeftStickerTexPos" + temp);
        PlayerPrefs.DeleteKey("TopRightStickerTexPos" + temp);
        PlayerPrefs.DeleteKey("BottomLeftStickerTexPos" + temp);
        PlayerPrefs.DeleteKey("BottomRightStickerTexPos" + temp);

        // Delete question data.
        float dataSize = PlayerPrefs.GetFloat("QuestionDataSize" + temp);

        for(int i = 0; i < dataSize; i++)
        {
            PlayerPrefs.DeleteKey("QuestionData" + i.ToString() + "Entry" + temp);
        }

        PlayerPrefs.SetInt("Deleted" + temp, 1);

        Destroy(DecisionMakerTemplate.transform.parent.GetChild(index + 1).gameObject);

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
