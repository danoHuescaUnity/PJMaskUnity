using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Image image;

    public void Select()
    {
        image.color = Color.green;   
    }

    public void UnSelect()
    {
        image.color = Color.white;
    }

    public void Catched()
    {
        image.color = Color.red;
        ScoreManager.instance.Scored();
        gameObject.SetActive(false);
    }
}
