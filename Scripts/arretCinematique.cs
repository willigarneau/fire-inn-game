using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arretCinematique : MonoBehaviour
{
    Animator animator;
    Transform chat;
    Rigidbody mkay;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GameObject.Find("Low Poly Warrior").GetComponent<Animator>();
      
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

          
            animator.SetBool("walk", false);
           
            StartCoroutine("Wait");
           
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }
}

