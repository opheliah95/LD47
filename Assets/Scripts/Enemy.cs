using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform target;

    Vector3 playerVector;

    public float moveSpeed = 5f;

    int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, playerVector, step);
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
            knockBack();
            health--;
        }
        else if (other.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    void knockBack()
    {
        UnityEngine.Debug.Log("hello");
        GetComponent<Animator>().SetTrigger("Hit");
        GetComponent<Rigidbody>().AddForce(-transform.forward * 10f, ForceMode.Impulse);
    }
}
