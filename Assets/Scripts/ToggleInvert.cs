using UnityEngine;

public class ToggleInvert : MonoBehaviour
{
    public GameObject aGameObject;

    public void Switch()
    {
        if (!aGameObject.activeSelf)
            aGameObject.SetActive(true);
        else
            aGameObject.SetActive(false);
    }
}
