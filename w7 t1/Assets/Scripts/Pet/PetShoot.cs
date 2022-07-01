using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetShoot : MonoBehaviour
{
    [SerializeField] private float cdAttack;// 0,2
    [SerializeField] private float timeAtk;
    [SerializeField] private int damagePerShot = 1;
    private ParticleSystem gunAnimation;
    public LineRenderer gunLine;
    int coliderMask;//layer muốn phát hiện
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    PlayerRotation playerRotation;
    private void Awake()
    {
        playerRotation = GetComponentInParent<PlayerRotation>();
        coliderMask = LayerMask.GetMask("colider");
        gunLine = GetComponent<LineRenderer>();
        gunAnimation = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        transform.LookAt(playerRotation.point);// lấy vị trí chiếu từ camera tới chuột
        timeAtk += Time.deltaTime;

        if (Input.GetButton("Fire1") & timeAtk >= cdAttack)
        {
            gunLine.enabled = true;
            Shoot();
            timeAtk = 0;
        }
    }
    public void Shoot()
    {
        gunAnimation.Play();
        gunLine.SetPosition(0, transform.position);//0. vi tri ban dau

        shootRay.origin = transform.position;// vị trí bắt đầu tia chiếu
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, 100, coliderMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)//
            {
                Debug.Log("Ban trung");
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);//vị trí bắn vàn
            }
            gunLine.SetPosition(1, shootHit.point);//1. vi tri tia den
        }
        StartCoroutine(TurnOff());
    }
    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(cdAttack - 0.17f);
        gunLine.enabled = false;
    }

}
