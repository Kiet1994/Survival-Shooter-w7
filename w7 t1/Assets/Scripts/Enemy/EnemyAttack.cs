using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float timeBetweenAttacks = 1f;
    [SerializeField] private int attackDamage = 1;

    Animator anim;
    GameObject player;
    Health playerHealth;
    EnemyHealth enemyHealth;
    bool collidePlayer;
    public float timer;
    //public Transform colorP;



    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <Health> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
        //var cubeRenderer = colorP.GetComponent<Renderer>();
        //cubeRenderer.material.SetColor("Hellephant", Color.red);
    }


    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player)// nếu va chạm và time lớn hơn 1
        {
            Debug.Log("va cham player");
            collidePlayer = true; // xác nhận va chạm
           //bỏ qua va chạm
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == player)// nếu va chạm và time lớn hơn 1
        {
            Debug.Log("vo trong");
            collidePlayer = false; // xác nhận va chạm
                                  //bỏ qua va chạm
        }
    }

    private void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && collidePlayer && enemyHealth.CurrentHealth > 0)
        {
            Attack ();// thực hiện atk           
        }

        if(playerHealth.CurrentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead"); //idle enemy
        }
    }


    void Attack ()
    {
        timer = 0f;//reset thời gian. nếu lớn hơn 1 thì thực hiện tiếp

        if(playerHealth.CurrentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
