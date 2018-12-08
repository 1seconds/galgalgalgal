using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float MoveSpeed = 10f;
    public float MamaximumSpeed = 2.0f;
    public float JumpPower = 30f;
    public float UpSpeed = 5f;

    public bool isKeydownUpDown = false;
    public bool isEnterSideTile = false;
    public bool isEnterLadder = false;
    public bool isJump = false;
    public bool isPlayerDie = false;
    

    public void Update()
    {
        if (isPlayerDie != true)
        {
            //좌우이동
            if (isEnterSideTile == false)
            {
                float h = Input.GetAxisRaw("Horizontal");
                if (h != 0)
                {
                    if (h > 0)
                        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    if (h < 0)
                        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(MoveSpeed * h, 0, 0));
                    //PlayerAnim_Run();
                }
                else if (h == 0)
                {
                    Invoke("HorizontalStop", 0.0f);
                    //PlayerAnim_Idle();
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                //PlayerAnim_Attack();
            }

            //방향키 위아래
            float Verti = Input.GetAxisRaw("Vertical");
            if (Verti != 0)
            {
                isKeydownUpDown = true;
            }
            else
            {
                isKeydownUpDown = false;
            }

            //사다리 타기
            if (isEnterLadder == true)
            {
                if (Verti != 0)
                {
                    //PlayerAnim_Ladder();
                    transform.Translate(0, Verti * UpSpeed * Time.deltaTime, 0);
                }
            }


            //최고속도 제한
            if (gameObject.GetComponent<Rigidbody2D>().velocity.x > MamaximumSpeed)
            {
                Vector3 v = gameObject.GetComponent<Rigidbody2D>().velocity;
                v.x = MamaximumSpeed;
                gameObject.GetComponent<Rigidbody2D>().velocity = v;
            }
            else if (gameObject.GetComponent<Rigidbody2D>().velocity.x < -MamaximumSpeed)
            {
                Vector3 v = gameObject.GetComponent<Rigidbody2D>().velocity;
                v.x = -MamaximumSpeed;
                gameObject.GetComponent<Rigidbody2D>().velocity = v;
            }



            //점프
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
                {
                    if (isEnterLadder == false)
                    {
                        isJump = true;
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, JumpPower, 0));
                    }
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Tile" || col.gameObject.tag=="Wall")
        {
            isJump = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Fire")//불에 닿아 죽음
        {
            isPlayerDie = true;
            //PlayerAnim_Die();
        }
        if(col.gameObject.tag=="Side")
        {
            isEnterSideTile = true;
        }

        if(col.gameObject.tag=="Ladder")
        {
            isEnterLadder = true;
            if (isJump==true)//점프 중일 때
            {
                StartCoroutine(CheckJumpLadder());             
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Side")
        {
            isEnterSideTile = false;
        }

        if (col.gameObject.tag == "Ladder")
        {
            isEnterLadder = false;
            //PlayerAnim_Idle();
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    
    public void HorizontalStop()
    {
        Vector3 v = gameObject.GetComponent<Rigidbody2D>().velocity;
        v.x = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = v;
    }
    public void VerticalStop()
    {
        Vector3 v = gameObject.GetComponent<Rigidbody2D>().velocity;
        v.y = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = v;
    }

    IEnumerator CheckJumpLadder()
    {
        do
        {
            if (isKeydownUpDown == true)
            {
                VerticalStop();
                HorizontalStop();
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            yield return new WaitForSeconds(0.1f);
        } while (isEnterLadder);
    }


    public void PlayerAnim_Idle()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 0);
    }
    public void PlayerAnim_Run()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 1);
    }
    public void PlayerAnim_Attack()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 2);
    }
    public void PlayerAnim_Ladder()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 3);
    }
    public void PlayerAnim_Die()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 4);
    }
}