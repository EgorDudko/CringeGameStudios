using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Image[] _images;
    private int _i = 1;

   


    public void TutorOnMenu()
    {
        _panel.SetActive(true);
        
    }

    public void Skip()
    {
        
        _i = 0;
                        
        _panel.SetActive(false);
        _images[1].gameObject.SetActive(false);
        _images[2].gameObject.SetActive(false);
        _images[3].gameObject.SetActive(false);
        _images[4].gameObject.SetActive(false);
        _images[5].gameObject.SetActive(false);
        _images[6].gameObject.SetActive(false);
        _images[7].gameObject.SetActive(false);
        _images[8].gameObject.SetActive(false);
        _images[9].gameObject.SetActive(false);
        _images[10].gameObject.SetActive(false);
        _images[11].gameObject.SetActive(false);
        _images[12].gameObject.SetActive(false);
        _images[13].gameObject.SetActive(false);
        _images[14].gameObject.SetActive(false);
        _images[15].gameObject.SetActive(false);
        _images[16].gameObject.SetActive(false);
        _images[17].gameObject.SetActive(false);
        _images[18].gameObject.SetActive(false);

    }

    private void Update()
    {
        Click();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
                Debug.Log(_i);
                if (_i < _images.Length)
                {
                    _images[_i].gameObject.SetActive(true);
                    
                }
                    else if(_images[18].gameObject.activeSelf == true)
                    {
                        _i = 0;
                        
                        _panel.SetActive(false);
                        _images[1].gameObject.SetActive(false);
                        _images[2].gameObject.SetActive(false);
                        _images[3].gameObject.SetActive(false);
                        _images[4].gameObject.SetActive(false);
                        _images[5].gameObject.SetActive(false);
                        _images[6].gameObject.SetActive(false);
                        _images[7].gameObject.SetActive(false);
                        _images[8].gameObject.SetActive(false);
                        _images[9].gameObject.SetActive(false);
                        _images[10].gameObject.SetActive(false);
                        _images[11].gameObject.SetActive(false);
                        _images[12].gameObject.SetActive(false);
                        _images[13].gameObject.SetActive(false);
                        _images[14].gameObject.SetActive(false);
                        _images[15].gameObject.SetActive(false);
                        _images[16].gameObject.SetActive(false);
                        _images[17].gameObject.SetActive(false);
                        _images[18].gameObject.SetActive(false);
                        
                    }
                
                if (_i < _images.Length)
                {
                    _i++;
                    
                }
        }
        
    }
}
