using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIInteractions : MonoBehaviour
{
    [SerializeField]
    private Animator wingsAnimator = null;
    [SerializeField]
    private Animator raysAnimator = null;
    [SerializeField]
    private GameObject guidePanel = null;

    private bool isInitialized = false;

    public void Shoot()
    {
        wingsAnimator.SetTrigger("Shoot");
        raysAnimator.SetTrigger("Shoot");

        if(!isInitialized && guidePanel == null)
        {
            guidePanel = GameObject.Find("UIGuide");
            guidePanel.SetActive(false);
            isInitialized = true;
        }
    }
}
