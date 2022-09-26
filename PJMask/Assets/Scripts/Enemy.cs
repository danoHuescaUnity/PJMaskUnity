using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private Animator anim = null;
    private BoxCollider boxColl = null;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        boxColl = GetComponentInChildren<BoxCollider>();
    }

    public void Select()
    {
        //image.color = Color.green;   
    }

    public void UnSelect()
    {
        image.color = Color.white;
    }

    public void Catched()
    {
        anim.SetTrigger("Catched");
        ScoreManager.instance.Scored();
        boxColl.enabled = false;
        StartCoroutine(turnGOoff());
    }

    private IEnumerator turnGOoff()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
}
