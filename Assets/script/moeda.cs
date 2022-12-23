using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moeda : MonoBehaviour
{
    [SerializeField]
    private AudioSource Audio;
    [SerializeField]
    private Transform transformParent;
    
    // Start is called before the first frame update
    void Start()
    {
        transformParent = transform.parent;
        Audio = transform.GetComponent<AudioSource>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Audio.Play();
            Debug.Log("Colidiu");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            double tempo = 0.2;
            
            Debug.Log("saiu da colisao");
            Destroy(transformParent.transform.gameObject, (float)tempo);
            float moedasPlayer = Random.Range((float)0, (float)20);
            PlayerPrefs.SetFloat("Moedas_Player", PlayerPrefs.GetFloat("Moedas_Player")+moedasPlayer);
            
        }
    }
}
