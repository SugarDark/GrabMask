﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howtoplay : MonoBehaviour
{
    public GameObject img;
    public GameObject button;
    public void Openimg()
  {
    if(img != null)
    {
      img.SetActive(true);
    }
  }
  public void destroybutton()
  {
    if(img != null)
    {
      button.SetActive(false);
    }
  }
}
