using UnityEngine;

public class RaycastMask : MonoBehaviour
{
    public Animator CanvasAnimator;
    public int MaxFoldCount;

    void OnMouseDown()
    {
        OrigamiManager.instance.MaxFoldCount = MaxFoldCount;
        OrigamiManager.instance.PlayAnimation(1);
        OrigamiManager.instance.PlayAnimation(2);
        if(CanvasAnimator != null)
            CanvasAnimator.Play("NewMoveColourTextUpAnimation");
    }
}