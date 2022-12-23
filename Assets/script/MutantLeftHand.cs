using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MutantLeftHand : MutantController
{
    [SerializeField]
    private AudioSource _audioAtack;
    // Start is called before the first frame update
    void Start()
    {
        _dano = 5;
        _audioAtack = transform.gameObject.GetComponent<AudioSource>();
        _target = FindObjectOfType<PlayerController>().transform;
        _velocidade = 1.5f;
        _rigid = GetComponent<Rigidbody>(); 
        _vida = 100f;
        _mutantAnimator.SetFloat("vida", _vida);
        _timeDestroy = 10f;
        _minDistance = 1.2f;
        _minDistanceAtack = 1.5f;
        _dano = 1;
        _agentNavimesh.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("usando espada: "+_mutantAnimator.GetBool("usar_espada"));

        if (_mutantAnimator.GetBool("usar_espada"))
        {
            Debug.Log(collision.gameObject.tag + "teste");
            if (collision.gameObject.CompareTag("Player"))
            {

                // collision.gameObject.GetComponent<PlayerController>().setVida(-_dano);
                _audioAtack.Play();
                Debug.Log("Levei uma espadada!");
            }
        }
    }
}
