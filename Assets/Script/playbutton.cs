using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbutton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Title;
    public GameObject Rule;


    void Start()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }

    public void OpenPanel()
    {
        if(Panel != null)
        {
          Panel.SetActive(true);
        }
        Title.SetActive(false);
        Rule.SetActive(false);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 1.0f) ? 1.0f : 1.0f;
    }
}
