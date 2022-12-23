using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _vida;
    // Start is called before the first frame update
    void Start()
    {
         _vida = GameManager.instance.getVida();
        //_vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (_vida<=0)
        {
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.GetComponent<MutantController>().setVida(5);        
    }
    public void setVida(float vida)
    {
        this._vida+= vida;
        if(this._vida<0)
            this._vida=0;
        GameManager.instance.setVida(this._vida);
    }
}
