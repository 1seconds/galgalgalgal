using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float MamaximumSpeed = 2.0f;
    public float JumpPower = 30f;
    public float UpSpeed = 5f;
    public float Verti = 0;

    public bool isAtkActivated = false;
    public bool isKeydownUpDown = false;
    public bool isEnterLadder = false;
    public bool isJump = false;
    static public bool isPlayerDie = false;


    private void OnEnable()
    {
        isPlayerDie = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerDie != true)
        {
            //좌우이동
            if (isAtkActivated != true)
            {

                float h = Input.GetAxisRaw("Horizontal");
                if (h != 0)
                {
                    if (h > 0)
                        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    if (h < 0)
                        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(MoveSpeed * h, 0, 0));

                    //gameObject.transform.GetChild(0).GetComponent<PlayerBody>().PlayerAnim_Run();
                }
                else if (h == 0)
                {
                    Invoke("HorizontalStop", 0.0f);
                    //gameObject.transform.GetChild(0).GetComponent<PlayerBody>().PlayerAnim_Idle();               
                }

                if(gameObject.GetComponent<PlayerSet>().currentPlayerState.Equals(PLAYER.RICHUSER))
                {
                    if (isJump == false && Verti == 0 && h == 0 && isAtkActivated == false)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            //gameObject.transform.GetChild(0).GetComponent<PlayerBody>().PlayerAnim_Attack();
                            isAtkActivated = true;
                        }
                    }
                }


                //방향키 위아래
                Verti = Input.GetAxisRaw("Vertical");
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
                        gameObject.transform.Translate(0, Verti * UpSpeed * Time.deltaTime, 0);
                    }
                    //gameObject.transform.GetChild(0).GetComponent<PlayerBody>().PlayerAnim_Ladder();
                }
                    

                //최고속도 제한
                if (gameObject.transform.GetComponent<Rigidbody2D>().velocity.x > MamaximumSpeed)
                {
                    Vector3 v = gameObject.transform.GetComponent<Rigidbody2D>().velocity;
                    v.x = MamaximumSpeed;
                    gameObject.transform.GetComponent<Rigidbody2D>().velocity = v;
                }
                else if (gameObject.transform.GetComponent<Rigidbody2D>().velocity.x < -MamaximumSpeed)
                {
                    Vector3 v = gameObject.transform.GetComponent<Rigidbody2D>().velocity;
                    v.x = -MamaximumSpeed;
                    gameObject.transform.GetComponent<Rigidbody2D>().velocity = v;
                }
                //점프
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (Mathf.Abs( gameObject.GetComponent<Rigidbody2D>().velocity.y) < 0.1f)
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

}
