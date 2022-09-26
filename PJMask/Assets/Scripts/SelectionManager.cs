using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    private GameObject m_marker = null;
    public void IsSelected(GameObject marker)
    {
        m_marker = marker;
        marker.GetComponentInChildren<Image>().color = Color.green;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (m_marker != null)
            {
                Debug.Log("D");
                m_marker.GetComponentInChildren<Image>().color = Color.red;
            }
        }
    }
}
