using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBody : MonoBehaviour {

    public void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Monster"))
        {
            gameObject.transform.parent.GetComponent<PlayerMove>().isPlayerDie = true;
            PlayerAnim_Die();
            StartCoroutine(DEADCor());
        }
    }

    IEnumerator DEADCor()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("InGame");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeadZone"))
        {
            gameObject.transform.parent.GetComponent<PlayerMove>().isPlayerDie = true;
            PlayerAnim_Die();
            StartCoroutine(DEADCor());
        }
        if (col.gameObject.CompareTag("Fire"))//불에 닿아 죽음
        {
            gameObject.transform.parent.GetComponent<PlayerMove>().isPlayerDie = true;
            PlayerAnim_Die();
            StartCoroutine(DEADCor());
        }
        

        if (col.gameObject.CompareTag("Ladder"))
        {
            gameObject.transform.parent.GetComponent<PlayerMove>().isEnterLadder = true;
            if (gameObject.transform.parent.GetComponent<PlayerMove>().isJump == true)//점프 중일 때
            {
                StartCoroutine(CheckJumpLadder());
            }
            else
            {
                gameObject.transform.parent.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ladder"))
        {
            gameObject.transform.parent.GetComponent<PlayerMove>().isEnterLadder = false;
            PlayerAnim_Idle();
            gameObject.transform.parent.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    IEnumerator CheckJumpLadder()
    {
        do
        {
            if (gameObject.transform.parent.GetComponent<PlayerMove>().isKeydownUpDown == true)
            {
                gameObject.transform.parent.GetComponent<PlayerMove>().VerticalStop();
                gameObject.transform.parent.GetComponent<PlayerMove>().HorizontalStop();
                gameObject.transform.parent.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            yield return new WaitForSeconds(0.1f);
        } while (gameObject.transform.parent.GetComponent<PlayerMove>().isEnterLadder);
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
    public void PlayerAnim_AtkEnd()
    {
        gameObject.transform.parent.GetComponent<PlayerMove>().isAtkActivated = false;
    }
}