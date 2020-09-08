using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backbutton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject HP;
    public GameObject P1;
    public GameObject P2;
    public void ClosePanel()
  {
    if(Panel != null)
    {
      Panel.SetActive(false);
      P1.SetActive(true);
      P2.SetActive(true);
      HP.SetActive(true);

            Animator animator = Panel.GetComponent<Animator>();
            if (animator != null)
            {

                animator.SetBool("open", false);
            }
            Time.timeScale = Mathf.Approximately(Time.timeScale, 1.0f) ? 1.0f : 1.0f;
    }
  }
}
