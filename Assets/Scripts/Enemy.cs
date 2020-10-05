using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform target;

    Vector3 playerVector;

    public float moveSpeed = 5f;

    [SerializeField]
    int health = 2;

    [SerializeField]
    bool isKnockedBack;
    [SerializeField]
    float knockBackForce = 30f;

    bool canHurt = true;


    // Update is called once per frame
    void Update()
    {
        if (!isKnockedBack)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            float step = moveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, playerVector, step);
        }
        
    }

    public void setTarget(Transform myTarget)
    {
        this.target = myTarget;
        playerVector = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(target);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            OnCollideWithWeapon();

        }
        else if (other.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("Attack");
            FindObjectOfType<PlayerController>().onHit();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            OnCollideWithWeapon();
        }
    }

    void knockBack()
    {
        if (!isKnockedBack)
        {
            GetComponent<Animator>().SetTrigger("Hit");
            GetComponent<Rigidbody>().AddForce(-transform.forward * knockBackForce, ForceMode.Impulse);
            isKnockedBack = true;
            StartCoroutine("updateStat");
        }
       
    }

    IEnumerator updateStat()
    {
        yield return new WaitForSeconds(0.3f);
        isKnockedBack = false;
        canHurt = true;
    }

    void ReduceHealth()
    {
        if(health < 1)
            Destroy(gameObject);

        if (canHurt)
        {
            health--;
            canHurt = false;
        }
           
    }

    void OnCollideWithWeapon()
    {

        if (GameObject.FindGameObjectWithTag("PlayerPrefab").GetComponent<PlayerController>().isAttacking)
        {
            ReduceHealth();
            knockBack();
            
        }
    }
}
