using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float speed = 5f;
    public float rotate_Speed = 20f;

    public bool laserShoot;
    public bool minionRotate;
    private bool canFly = true;

    public float boundaryX = -11f;

    public Transform attack_Point;
    public GameObject bulletPrefab;

    private Animator anim;
    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Awake() {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    void Start() {
        if(minionRotate) { 
            if(Random.Range(0, 2) > 0) {

                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -15f;

            } else {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
            }
        }

        if (laserShoot)
            Invoke("laserShooting", Random.Range(1f, 2f));

    }

    // Update is called once per frame
    void Update() {
        Move();
        RotateEnemy();
    }

    void Move() { 
        if(canFly) {
           
           Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < boundaryX)
                gameObject.SetActive(false);


        }
    }

    void RotateEnemy() {
        if(minionRotate) {
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed * Time.deltaTime), Space.World);
        }
    }

    void laserShooting() {

        GameObject bullet = Instantiate(bulletPrefab, attack_Point.position, Quaternion.identity);
        bullet.GetComponent<LaserScript>().is_enemyLaser = true;

        if (laserShoot)
            Invoke("laserShooting", Random.Range(1f, 2f));

    }

    void enemyDestroy() {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "Laser"||target.tag == "Player") {

            canFly = false;

            if(laserShoot) {
                laserShoot = false;
                CancelInvoke("laserShooting");
            }

            Invoke("enemyDestroy", 1f);

            // play explosion sound
            explosionSound.Play();
            anim.Play("Destroy");

        }

    }

} // class










































