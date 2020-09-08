using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausebutton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject HP;
    public GameObject P1;
    public GameObject P2;
    float timer = 0;
    public void OpenPanel()
  {
    if(Panel != null)
    {
      Panel.SetActive(true);
      HP.SetActive(false);
      P1.SetActive(false);
      P2.SetActive(false);


            timer += Time.deltaTime;
            Animator animator = Panel.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
                StartCoroutine("timer1");
            }
            //Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        }
  }
    IEnumerator timer1()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;

    }
}
