using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed= 1f;
    
    public float min_Y, max_Y;

    [SerializeField]
    private GameObject playerLaser;

    [SerializeField]
    private Transform attack_Point;

    public float attackTimer = 0.01f;
    private float currentAttackTimer;
    private bool canLaser;

    private AudioSource laserAudio;
    public AudioClip destroyClip;

    private Animator anim;
    public GameObject[] energies;
    public int energiesRemaining;
    public bool dead;

    
    public void Start()
    {
         energiesRemaining=energies.Length;
    }

    
    void Update()
    {
        MovePlayer();
        Attack();
        if(dead==true){
            Debug.Log("Game Over");
        }
    }
    void MovePlayer(){
        if(Input.GetAxisRaw("Vertical")>0f){
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            if(temp.y>max_Y)
                temp.y=max_Y;
            transform.position=temp;
            
            }else if(Input.GetAxisRaw("Vertical")<0f){
                Vector3 temp = transform.position;
                temp.y -= speed * Time.deltaTime;
                if(temp.y<min_Y)
                temp.y=min_Y;
                transform.position=temp;
                
            }
        }
    void Attack(){
        attackTimer += Time.deltaTime;
        if(attackTimer>currentAttackTimer)
            canLaser=true;
        if(Input.GetKeyDown(KeyCode.K)){
            if(canLaser){
                canLaser=false;
                attackTimer=5f;
            Instantiate(playerLaser, attack_Point.position, Quaternion.identity);
            }
        }

     

    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "Laser" || target.tag == "Enemy") {

            // prevent the player from attacking
            currentAttackTimer = 10f;
            //laserAudio.clip = destroyClip;
            //laserAudio.Play();
            //anim.Play("Destroy");
             void loseEnegry(){
    if(energiesRemaining>=1){
        energiesRemaining -=1;
        Destroy(energies[energiesRemaining].gameObject);
        if(energiesRemaining<1){
            dead=true;
        }

    }
}
            

        }

    }
    }
    
}//class
