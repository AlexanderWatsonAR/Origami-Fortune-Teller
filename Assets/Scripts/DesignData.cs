using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignData : MonoBehaviour
{
    private static float _TopLeftColourPrimary;
    private static float _TopRightColourPrimary;
    private static float _BottomLeftColourPrimary;
    private static float _BottomRightColourPrimary;

    private static float _TopLeftColourSecondary;
    private static float _TopRightColourSecondary;
    private static float _BottomLeftColourSecondary;
    private static float _BottomRightColourSecondary;

    private static float _TopLeftTexPrimary;
    private static float _TopRightTexPrimary;
    private static float _BottomLeftTexPrimary;
    private static float _BottomRightTexPrimary;

    private static float _TopLeftTexSecondary;
    private static float _TopRightTexSecondary;
    private static float _BottomLeftTexSecondary;
    private static float _BottomRightTexSecondary;

    private static float _TopLeftStickerTex;
    private static float _TopRightStickerTex;
    private static float _BottomLeftStickerTex;
    private static float _BottomRightStickerTex;

    // 0 = empty, 1 = pos1, 2 = pos2, 3 = both
    private static float _TopLeftStickerTexPos;
    private static float _TopRightStickerTexPos;
    private static float _BottomLeftStickerTexPos;
    private static float _BottomRightStickerTexPos;

    // Colour # corresponds to colours in origami manager.
    [HideInInspector]
    public static float TopLeftColourPrimary
    {
        get
        {
            return PlayerPrefs.GetFloat("TopLeftColourPrimary" + CreateDecisionMaker.currentEntry);
            //return _TopLeftColourPrimary;
        }
        set
        {
            PlayerPrefs.SetFloat("TopLeftColourPrimary" + CreateDecisionMaker.currentEntry, value);
            _TopLeftColourPrimary = value;
        }
    }
    [HideInInspector]
    public static float TopRightColourPrimary
    {
        get
        {
            return PlayerPrefs.GetFloat("TopRightColourPrimary" + CreateDecisionMaker.currentEntry);
            //return _TopRightColourPrimary;
        }
        set
        {
            PlayerPrefs.SetFloat("TopRightColourPrimary" + CreateDecisionMaker.currentEntry, value);
            _TopRightColourPrimary = value;
        }
    }
    [HideInInspector]
    public static float BottomLeftColourPrimary
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomLeftColourPrimary" + CreateDecisionMaker.currentEntry);
            //return _BottomLeftColourPrimary;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomLeftColourPrimary" + CreateDecisionMaker.currentEntry, value);
            _BottomLeftColourPrimary = value;
        }
    }
    [HideInInspector]
    public static float BottomRightColourPrimary
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomRightColourPrimary" + CreateDecisionMaker.currentEntry);
            //return _BottomRightColourPrimary;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomRightColourPrimary" + CreateDecisionMaker.currentEntry, value);
            _BottomRightColourPrimary = value;
        }
    }
    [HideInInspector]
    public static float TopLeftColourSecondary
    {
        get
        {
            return PlayerPrefs.GetFloat("TopLeftColourSecondary" + CreateDecisionMaker.currentEntry);
            //return _TopLeftColourSecondary;
        }
        set
        {
            PlayerPrefs.SetFloat("TopLeftColourSecondary" + CreateDecisionMaker.currentEntry, value);
            _TopLeftColourSecondary = value;
        }
    }
    [HideInInspector]
    public static float TopRightColourSecondary
    {
        get
        {
            return PlayerPrefs.GetFloat("TopRightColourSecondary" + CreateDecisionMaker.currentEntry);
            //return _TopRightColourSecondary;
        }
        set
        {
            PlayerPrefs.SetFloat("TopRightColourSecondary" + CreateDecisionMaker.currentEntry, value);
            _TopRightColourSecondary = value;
        }
    }
    [HideInInspector]
    public static float BottomLeftColourSecondary
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomLeftColourSecondary" + CreateDecisionMaker.currentEntry);
            //return _BottomLeftColourSecondary;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomLeftColourSecondary" + CreateDecisionMaker.currentEntry, value);
            _BottomLeftColourSecondary = value;
        }
    }
    [HideInInspector]
    public static float BottomRightColourSecondary
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomRightColourSecondary" + CreateDecisionMaker.currentEntry);
            //return _BottomRightColourSecondary;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomRightColourSecondary" + CreateDecisionMaker.currentEntry, value);
            _BottomRightColourSecondary = value;
        }
    }

    // Texture file extension.
    public static float TopLeftTexPrimary
    {
        get
        {
            return PlayerPrefs.GetFloat("TopLeftTexPrimary" + CreateDecisionMaker.currentEntry);
            //return _TopLeftTexPrimary;
        }
        set
        {
            PlayerPrefs.SetFloat("TopLeftTexPrimary" + CreateDecisionMaker.currentEntry, value);
            _TopLeftTexPrimary = value;
        }
    }
    [HideInInspector]
    public static float TopRightTexPrimary
    {
        get
        {
            return PlayerPrefs.GetFloat("TopRightTexPrimary" + CreateDecisionMaker.currentEntry);
            //return _TopRightTexPrimary;
        }
        set
        {
            PlayerPrefs.SetFloat("TopRightTexPrimary" + CreateDecisionMaker.currentEntry, value);
            _TopRightTexPrimary = value;
        }
    }
    [HideInInspector]
    public static float BottomLeftTexPrimary
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomLeftTexPrimary" + CreateDecisionMaker.currentEntry);
            //return _BottomLeftTexPrimary;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomLeftTexPrimary" + CreateDecisionMaker.currentEntry, value);
            _BottomLeftTexPrimary = value;
        }
    }
    [HideInInspector]
    public static float BottomRightTexPrimary
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomRightTexPrimary" + CreateDecisionMaker.currentEntry);
            //return _BottomRightTexPrimary;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomRightTexPrimary" + CreateDecisionMaker.currentEntry, value);
            _BottomRightTexPrimary = value;
        }
    }
    [HideInInspector]
    public static float TopLeftTexSecondary
    {
        get
        {
            return PlayerPrefs.GetFloat("TopLeftTexSecondary" + CreateDecisionMaker.currentEntry);
            //return _TopLeftTexSecondary;
        }
        set
        {
            PlayerPrefs.SetFloat("TopLeftTexSecondary" + CreateDecisionMaker.currentEntry, value);
            _TopLeftTexSecondary = value;
        }
    }
    [HideInInspector]
    public static float TopRightTexSecondary
    {
        get
        {
            return PlayerPrefs.GetFloat("TopRightTexSecondary" + CreateDecisionMaker.currentEntry);
            //return _TopRightTexSecondary;
        }
        set
        {
            PlayerPrefs.SetFloat("TopRightTexSecondary" + CreateDecisionMaker.currentEntry, value);
            _TopRightTexSecondary = value;
        }
    }
    [HideInInspector]
    public static float BottomLeftTexSecondary
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomLeftTexSecondary" + CreateDecisionMaker.currentEntry);
            //return _BottomLeftTexSecondary;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomLeftTexSecondary" + CreateDecisionMaker.currentEntry, value);
            _BottomLeftTexSecondary = value;
        }
    }
    [HideInInspector]
    public static float BottomRightTexSecondary
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomRightTexSecondary" + CreateDecisionMaker.currentEntry);
            //return _BottomRightTexSecondary;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomRightTexSecondary" + CreateDecisionMaker.currentEntry, value);
            _BottomRightTexSecondary = value;
        }
    }
    [HideInInspector]
    public static float TopLeftStickerTex
    {
        get
        {
            return PlayerPrefs.GetFloat("TopLeftStickerTex" + CreateDecisionMaker.currentEntry);
            //return _TopLeftStickerTex;
        }
        set
        {
            PlayerPrefs.SetFloat("TopLeftStickerTex" + CreateDecisionMaker.currentEntry, value);
            _TopLeftStickerTex = value;
        }
    }
    [HideInInspector]
    public static float TopRightStickerTex
    {
        get
        {
            return PlayerPrefs.GetFloat("TopRightStickerTex" + CreateDecisionMaker.currentEntry);
            //return _TopRightStickerTex;
        }
        set
        {
            PlayerPrefs.SetFloat("TopRightStickerTex" + CreateDecisionMaker.currentEntry, value);
            _TopRightStickerTex = value;
        }
    }
    [HideInInspector]
    public static float BottomLeftStickerTex
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomLeftStickerTex" + CreateDecisionMaker.currentEntry);
            //return _BottomLeftStickerTex;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomLeftStickerTex" + CreateDecisionMaker.currentEntry, value);
            _BottomLeftStickerTex = value;
        }
    }
    [HideInInspector]
    public static float BottomRightStickerTex
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomRightStickerTex" + CreateDecisionMaker.currentEntry);
            //return _BottomRightStickerTex;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomRightStickerTex" + CreateDecisionMaker.currentEntry, value);
            _BottomRightStickerTex = value;
        }
    }

    public static float TopLeftStickerTexPos
    {
        get
        {
            return PlayerPrefs.GetFloat("TopLeftStickerTexPos" + CreateDecisionMaker.currentEntry);
            //return _TopLeftStickerTexPos;
        }
        set
        {
            PlayerPrefs.SetFloat("TopLeftStickerTexPos" + CreateDecisionMaker.currentEntry, value);
            _TopLeftStickerTexPos = value;
        }
    }
    public static float TopRightStickerTexPos
    {
        get
        {
            return PlayerPrefs.GetFloat("TopRightStickerTexPos" + CreateDecisionMaker.currentEntry);
            //return _TopRightStickerTexPos;
        }
        set
        {
            PlayerPrefs.SetFloat("TopRightStickerTexPos" + CreateDecisionMaker.currentEntry, value);
            _TopRightStickerTexPos = value;
        }
    }
    public static float BottomLeftStickerTexPos
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomLeftStickerTexPos" + CreateDecisionMaker.currentEntry);
            //return _BottomLeftStickerTexPos;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomLeftStickerTexPos" + CreateDecisionMaker.currentEntry, value);
            _BottomLeftStickerTexPos = value;
        }
    }
    public static float BottomRightStickerTexPos
    {
        get
        {
            return PlayerPrefs.GetFloat("BottomRightStickerTexPos" + CreateDecisionMaker.currentEntry);
            //return _BottomRightStickerTexPos;
        }
        set
        {
            PlayerPrefs.SetFloat("BottomRightStickerTexPos" + CreateDecisionMaker.currentEntry, value);
            _BottomRightStickerTexPos = value;
        }
    }

    //private void Awake()
    //{
    //    //
    //}

    public static void LoadDefaultValues()
    {
        TopLeftColourPrimary = 7;
        TopRightColourPrimary = 4;
        BottomRightColourPrimary = 2;
        BottomLeftColourPrimary = 10;

        TopLeftColourSecondary = 14;
        TopRightColourSecondary = 14;
        BottomRightColourSecondary = 14;
        BottomLeftColourSecondary = 14;
    }
}
