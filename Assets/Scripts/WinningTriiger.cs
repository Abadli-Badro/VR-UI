using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTriiger : MonoBehaviour
{
    public bool triggerChecked= false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            triggerChecked = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            triggerChecked = false;
        }
    }
    
}
