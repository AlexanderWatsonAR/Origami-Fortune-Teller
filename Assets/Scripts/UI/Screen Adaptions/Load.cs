using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : ScreenAdapter
{
    public GameObject mainCamera;
    public GameObject BackCanvasMask;

    private Transform mainCameraTransform;

    // Start is called before the first frame update
    void Awake()
    {
        mainCameraTransform = mainCamera.transform;
        ConfigureUI();

    }

    protected override void OnePointThreeThree()
    {
        BackCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 1400.0f);
    }

    protected override void OnePointFourThree()
    {
        BackCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 1400.0f);
    }

    protected override void OnePointSevenSeven()
    {
        mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 0.85f, mainCameraTransform.position.z);
    }

    protected override void TwoPointZeroFive()
    {

    }
}
