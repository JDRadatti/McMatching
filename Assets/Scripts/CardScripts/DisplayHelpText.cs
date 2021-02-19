using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHelpText : MonoBehaviour
{
    public GameObject help;
    private bool displayed;

    private void Start()
    {
        displayed = false;
        help.SetActive(false);
    }
    public void DisplayText()
    {
        if (displayed == false)
        {
            help.SetActive(true);
            displayed = true; 
        }
        else
        {
            help.SetActive(false);
            displayed = false;
        }
        
    }

}
