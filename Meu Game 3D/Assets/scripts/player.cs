
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    Rigidbody rb; 
    public int forcapulo = 7;
    public bool nochao;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {  //andar
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
        //fim andar

        if (Input.GetKeyDown(KeyCode.Space)) //pulo
        {
            rb.AddForce(Vector3.up * forcapulo, ForceMode.Impulse);
        }
        
        
        
        
        
        if (transform.position.y <= -10)
        {
            //caiu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

