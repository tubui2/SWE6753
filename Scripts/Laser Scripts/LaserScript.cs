using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public float speed = 5f;
    public float timeDeactive = 3f;

    [HideInInspector]
    public bool is_enemyLaser = false;

    public float boundaryX = -11f;

    // Start is called before the first frame update
    void Start() {

        if (is_enemyLaser)
            speed *= -5f;

        Invoke("laserDeactive", timeDeactive);

    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
        if (temp.x < boundaryX)
                gameObject.SetActive(false);
    }

    void laserDeactive() {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "Enemy"|| target.tag == "Laser"||target.tag == "Player") {
            this.gameObject.SetActive(false);
        }

    }

} // class





































