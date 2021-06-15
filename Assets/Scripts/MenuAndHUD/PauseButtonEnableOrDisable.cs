using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonEnableOrDisable : MonoBehaviour
{
    public void PauseButtonDissabe()
    {
        GetComponent<Canvas>().enabled = false;
    }
    public void PasuseButtonEnable()
    {
        GetComponent<Canvas>().enabled = true;
    }
}
