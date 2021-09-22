using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterLimit : MonoBehaviour
{
    public TextMeshProUGUI characterCountText;
    public Image circleAmount;
    private int characterLimit = 110;
    private TMP_InputField textInput;
    private float onePercent;

    void Start()
    {
        textInput = GetComponent<TMP_InputField>();
        textInput.characterLimit = characterLimit;
        onePercent = 0.0091f;
    }

    public void CharacterCount()
    {
        characterCountText.text = (characterLimit - textInput.text.Length).ToString();
        float fillAmount = onePercent * textInput.text.Length;
        
        circleAmount.fillAmount = fillAmount;
    }
}
