using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform lr;
    [SerializeField] private Transform pointA;
    [SerializeField] private float cdAttack;// 0,2
    [SerializeField] private float timeAtk;
    [SerializeField] public int damagePerShot = 1;
    private ParticleSystem gunAnimation;
    private AudioSource gunAudio;
    public LineRenderer gunLine;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int coliderMask;
    private void Awake()
    {
        coliderMask = LayerMask.GetMask("colider");
        gunAnimation = GetComponent<ParticleSystem>();
        gunAudio = GetComponent<AudioSource>();
        gunLine = GetComponentInChildren<LineRenderer>();//
    }
    public void Shoot()// shoot
    {
        Vector3 points = new Vector3(transform.position.x - pointA.position.x, transform.position.y - pointA.position.y, transform.position.z - pointA.position.z + 100);
        lr.GetComponent<LineRenderer>().SetPosition(0, points);

        gunLine.SetPosition(0, transform.position);//0. vi tri ban dau

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, 100, coliderMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)//
            {
                Debug.Log("Ban trung");
                enemyHealth.TakeDamage(damagePerShot);
            }
            gunLine.SetPosition(1, shootHit.point);//1. vi tri tia den
        }
        else
        {
            gunLine.SetPosition(1, points);
        }
        gunAnimation.Play();
        gunAudio.Play();
        StartCoroutine(TurnOff());          
     }
    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(cdAttack-0.17f);
        gunLine.enabled = false;        
    }

    private void Update()
    {
        timeAtk += Time.deltaTime;

        if (Input.GetButton("Fire1") & timeAtk >= cdAttack)
        {
            gunLine.enabled = true;
            Shoot();
            timeAtk = 0;
        }
    }

}
