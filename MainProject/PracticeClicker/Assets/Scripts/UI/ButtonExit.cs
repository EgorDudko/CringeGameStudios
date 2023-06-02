using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour
{
    //Component for object identification

    private void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            GetComponent<Collider>().enabled = false;
    }
}
