using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextbutton : MonoBehaviour
{
    public GameObject img;

    public void Openimg()
  {
    if(img != null)
    {
      img.SetActive(true);
    }
  }
}
