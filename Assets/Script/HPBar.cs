using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
  //HP條的Image組件
  public Image hpBar, hpBar1;
  //最大生命值
  public float MaxHp = 100;
  //當前生命值
  public float nowHP, nowHP1;
    public Text Text, Text1;


    public GameObject chara1, chara2;
    public GameObject winimg1, winimg2;
    public GameObject WinPar;
    int winflag;


  void Start () {
    nowHP = MaxHp;
    nowHP1 = MaxHp;
   winflag = 0;

  }
  
  void Update () {
        //每秒扣5 HP 歸0後自動回滿

        if (chara1.GetComponent<CharacterController>().maskon == false && winflag == 0)
        {
            nowHP -= Time.deltaTime *4;
        }
        if (chara2.GetComponent<Player2>().maskon == false && winflag == 0)
        {
            nowHP1 -= Time.deltaTime * 4;
        }

        if (nowHP < 0 && winflag == 0)
        {
            winflag = 1;
            nowHP = 0;

            Instantiate(WinPar, chara2.transform.position, Quaternion.Euler(0, 0, 0));

            Invoke("P2Wins", 3f);
            

        }
        else if (nowHP1 < 0 && winflag == 0)
        {
            winflag = 1;
            nowHP1 = 0;
            Instantiate(WinPar, chara1.transform.position, Quaternion.Euler(0, 0, 0));
            Invoke("P1Wins", 3f);

        }


		//顯示血量
	Text.text = Mathf.Round(((float)nowHP / MaxHp)*100) + "%";
    Text1.text = Mathf.Round(((float)nowHP1 / MaxHp)*100) + "%";


    
    //更新畫面顯示
    updateHPBar();
  }
  void updateHPBar(){
    hpBar.fillAmount = nowHP / MaxHp;
    hpBar1.fillAmount = nowHP1 / MaxHp;
  }


    void P1Wins()
    {
        winimg1.SetActive(true);
    }
    void P2Wins()
    {
        winimg2.SetActive(true);

    }









}
