using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaySelector : MonoBehaviour
{
    private GameObject enemySelected = null;

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) )
        {
            if (hit.collider.TryGetComponent(out Enemy enemy) && enemySelected == null)
            {
                enemy.Select();
                enemySelected = enemy.gameObject;
            }

        }
        else
        {
            Dispose();
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);

    }

    public void Catch()
    {
        enemySelected?.GetComponent<Enemy>().Catched();
    }

    private void Dispose()
    {
        enemySelected?.GetComponent<Enemy>().UnSelect();
        enemySelected = null;
    }
  
}
