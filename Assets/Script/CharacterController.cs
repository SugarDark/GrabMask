using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public RuntimeAnimatorController NormalAniController, MaskAniController;
    private Animator currentAniController;
    public Rigidbody2D chara;


    public bool grounded;

    public bool maskon;

    public bool haveball;

    public float direction;

    public GameObject Mask;

    Vector2 MaskFly;

    GameObject clone;

    public GameObject GetMaskParticle;

    public GameObject Ball;

    public GameObject HPB;

    public GameObject maskUI;
    public GameObject ballUI;




    // Start is called before the first frame update
    void Start()
    {
        print(transform.name);
        grounded = true;
        currentAniController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (maskon)
        {
            maskUI.SetActive(true);
            
        }
        else
        {
            maskUI.SetActive(false);
        }


        if (haveball)
        {
            ballUI.SetActive(true);

        }
        else
        {
            ballUI.SetActive(false);
        }










        if (Input.GetKeyDown(KeyCode.A)) 
        {
            currentAniController.SetBool("Left", true);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            currentAniController.SetBool("Right", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            currentAniController.SetBool("Left", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            currentAniController.SetBool("Right", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //chara.AddForce = new Vector2(-2.0f, 0.0f);
            //chara.AddForce(new Vector2(-10.0f, 0));
            chara.velocity = new Vector2(-10.0f, chara.velocity.y);
            //chara.velocity = new Vector2(-20.0f, chara.velocity.y);
            direction = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //chara.AddForce(new Vector2(10.0f, 0));
            chara.velocity = new Vector2(10.0f, chara.velocity.y);
            direction = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            grounded = false;
            chara.velocity = new Vector2(chara.velocity.x, 15.0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && haveball)
        {
            
            clone = (GameObject)Instantiate(Ball, new Vector3(transform.position.x+direction, transform.position.y, 0), Quaternion.Euler(0, 0, 0));
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(20.0f*direction, 0.0f);
            haveball = false;

        }
        if (Input.GetKeyUp(KeyCode.W) && chara.velocity.y >= 0)
        {
            chara.velocity = new Vector2(chara.velocity.x, chara.velocity.y * 0.5f);
        }

        if (chara.velocity.x > 10)
        {
            chara.velocity = new Vector2(10.0f, chara.velocity.y);
        }
        if(chara.velocity.x < -10)
        {
            chara.velocity = new Vector2(-10.0f, chara.velocity.y);
        }

        

    }







    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.tag == "floor")
        {
            grounded = true;
        }



        if (collidedObject.contacts[0].normal.y == -1)//从上方碰撞
        {
            MaskFly = new Vector2(20.0f, -20.0f);
        }
        else if (collidedObject.contacts[0].normal.y == 1)//从下方碰撞
        {
            MaskFly = new Vector2(-10.0f, 30.0f);
        }
        else if (Mathf.Round(collidedObject.contacts[0].normal.x) == -1)//左边碰撞
        {
            MaskFly = new Vector2(-20.0f, 20.0f);
        }
        else if (Mathf.Round(collidedObject.contacts[0].normal.x) == 1)//右边碰撞
        {

            MaskFly = new Vector2(20.0f, 20.0f);
        }

        Debug.Log(collidedObject.contacts[0].normal.x + "," + collidedObject.contacts[0].normal.y);


        if (collidedObject.gameObject.tag == "mask")
        {
            maskon = true;
            currentAniController.runtimeAnimatorController = MaskAniController;
            Destroy(collidedObject.gameObject);
            Instantiate(GetMaskParticle, transform.position, transform.rotation);
            GetComponent<AudioSource>().clip = GetComponent<CharacterAudio>().audiolist[1];
            GetComponent<AudioSource>().Play();

        }

        if (collidedObject.gameObject.tag == "Player")
        {
            if (maskon == true)
            {
                maskon = false;
                currentAniController.runtimeAnimatorController = NormalAniController;
                clone = (GameObject)Instantiate(Mask, new Vector3(transform.position.x, transform.position.y + 2, 0), Quaternion.Euler(0, 0, 0));
                clone.GetComponent<Rigidbody2D>().velocity = MaskFly;
                GetComponent<AudioSource>().clip = GetComponent<CharacterAudio>().audiolist[2];
                GetComponent<AudioSource>().Play();
            }

            if (collidedObject.contacts[0].normal.y == 1)
            {
                grounded = true;
            }

        }
        if (collidedObject.gameObject.tag == "ball")
        {
            if (maskon==true)
            {
                maskon = false;
                currentAniController.runtimeAnimatorController = NormalAniController;
                clone = (GameObject)Instantiate(Mask, new Vector3(transform.position.x, transform.position.y + 2, 0), Quaternion.Euler(0, 0, 0));
                clone.GetComponent<Rigidbody2D>().velocity = MaskFly;
                GetComponent<AudioSource>().clip = GetComponent<CharacterAudio>().audiolist[4];
                GetComponent<AudioSource>().Play();

            }
            else
            {

                chara.velocity = new Vector3(0.0f, 0.0f, 0.0f);

            }

        }
        if (collidedObject.gameObject.tag == "groundball")
        {
            haveball = true;
            Destroy(collidedObject.gameObject);
            GetComponent<AudioSource>().clip = GetComponent<CharacterAudio>().audiolist[0];
            GetComponent<AudioSource>().Play();
        }
        if (collidedObject.gameObject.tag == "med")
        {
            
            
            Destroy(collidedObject.gameObject);
            HPB.GetComponent<HPBar>().nowHP += 20.0f;
            GetComponent<AudioSource>().clip = GetComponent<CharacterAudio>().audiolist[0];
            GetComponent<AudioSource>().Play();



        }



    }
    void OnCollisionExit2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.tag == "floor")
        {
            grounded = false;
        }

    }
    void OnCollisionStay2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.tag == "floor")
        {
            grounded = true;
        }

    }










}
