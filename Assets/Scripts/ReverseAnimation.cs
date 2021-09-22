using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReverseAnimation : MonoBehaviour
{
    public GameObject ReverseButton;
    public AnimationSpeedController AnimationSpeedController;
    public Slider animationSlider;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI colourText;
    public TextMeshProUGUI numberText;
    public GameObject colourButtons;

    //public static bool isReversing;

    private List<string> origami4Animations = new List<string>();

    public IEnumerator ReverseOrigamiAnimation()
    {
        ReverseButton.GetComponent<MeshCollider>().enabled = false;
        instructionText.text = "";
        colourText.text = "";
        numberText.text = "";
        animationSlider.onValueChanged.RemoveAllListeners();

        Animator org1Anim = OrigamiManager.instance.orgami[0].GetComponent<Animator>();
        Animator org3Anim = OrigamiManager.instance.orgami[3].GetComponent<Animator>();
        Animator org4Anim = OrigamiManager.instance.orgami[4].GetComponent<Animator>();

        int lastIndex = origami4Animations.Count - 1;

        AnimationClip[] allAnimClips = org4Anim.runtimeAnimatorController.animationClips;
        AnimationClip[] reverseClips = new AnimationClip[origami4Animations.Count];

        for(int i = 0; i < allAnimClips.Length; i++)
        {
            for(int j = 0; j < reverseClips.Length; j++)
            {
                if (allAnimClips[i].name == origami4Animations[j])
                {
                    reverseClips[j] = allAnimClips[i];
                }
            }
            
        }

        float waitTime = 0;

        for (int i = 0; i < reverseClips.Length; i++)
        {
            waitTime += (reverseClips[i].length / org4Anim.speed);
        }

        org4Anim.Play(origami4Animations[lastIndex]);

        yield return new WaitForSeconds(waitTime);

        OrigamiManager.instance.orgami[4].SetActive(false);
        OrigamiManager.instance.orgami[3].SetActive(true);

        org3Anim.Play("ReverseNewOpenFortuneAnimation");

        yield return new WaitForSeconds(org3Anim.GetCurrentAnimatorStateInfo(0).length);

        OrigamiManager.instance.orgami[3].SetActive(false);
        OrigamiManager.instance.orgami[0].SetActive(true);

        org1Anim.Play("ToPrimaryView");

        yield return new WaitForSeconds(org1Anim.GetCurrentAnimatorStateInfo(0).length);

        AnimationSpeedController.Init();
        AnimationSpeedController.AdjustAnimationSpeed();
        origami4Animations.Clear();

        instructionText.text = "Select a Colour";
        colourButtons.SetActive(true);
    }

    public void Add(string animationName)
    {
        origami4Animations.Add(animationName);
    }
}
