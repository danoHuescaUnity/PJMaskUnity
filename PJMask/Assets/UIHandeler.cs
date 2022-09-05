using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandeler : MonoBehaviour
{

    private Vector2 startTouchPos;
    private Vector2 currentPos;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    [Header("Managers")]
    [SerializeField]
    private RaySelector raySelector = null;
    [SerializeField]
    private PlayerUIInteractions playerUIInteractions = null;

    [SerializeField]
    private float swipeRange;

    private void Update()
    {
        Swipe();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
#endif
    }

    private void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPos = Input.GetTouch(0).position;
            Vector2 distance = currentPos - startTouchPos;

            if (!stopTouch)
            {
                if (distance.y > swipeRange)
                {
                    //down
                    Shoot();
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;
        }
    }

    private void Shoot()
    {
        playerUIInteractions.Shoot();
        raySelector.Catch();
    }
}
