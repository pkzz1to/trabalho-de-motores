
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int velocidade = 6;
    Rigidbody rb; 
    public bool nochao;
    public int forcapulo = 2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!nochao && collision.gameObject.tag == "chao")
        {
            nochao = true;
        }
    }

    // Update is called once per frame
    void Update()
    {  //andar
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime,ForceMode.Impulse);
        //fim andar

        if (Input.GetKeyDown(KeyCode.Space) && nochao) //pulo
        {
            rb.AddForce(Vector3.up * forcapulo, ForceMode.Impulse);
            nochao = false;
        }
        
        
        
        
        
        if (transform.position.y <= -10)
        {
            //caiu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

