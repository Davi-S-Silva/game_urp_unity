using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class caixas : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pecasCaixas;
    [SerializeField]
    private bool quebrado;
    [SerializeField]
    private AudioSource audio;
    private 
    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
        quebrado= false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

            Debug.Log(collision.transform.tag);
            if (quebrado==false) {
                audio.Play(); 
                quebrado= true;
                
            }
            foreach (GameObject peca in pecasCaixas)
            {
                Rigidbody rigid = peca.GetComponent<Rigidbody>();
                rigid.isKinematic = false;
                // rigid.AddForce(Vector3.up, ForceMode.Impulse);

            }
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //audio.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Colidu com o player");
            foreach (GameObject peca in pecasCaixas)
            {
                peca.GetComponent<Rigidbody>().isKinematic=false;
            }
        }
    }
}
