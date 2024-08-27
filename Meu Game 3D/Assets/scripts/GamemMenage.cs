using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using TMPro;

public class GameMenage : MonoBehaviour
{

    public TextMeshProUGUI hud, menvitoria;
    public int restantes;

    public AudioClip clipmoeda, clipvitoria;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out source);
        restantes = FindObjectsOfType<moeda>().Length;

        hud.text = $"Moedas Restantes: {restantes}";
    }

    public void submoedas(int valor)
    {
        restantes = restantes - valor;
        hud.text = $"Moedas Restantes: {restantes}";
        source.PlayOneShot(clipmoeda);

        if (restantes <= 0)
        {
            //ganhou o jogo
            menvitoria.text = "Você comprou a pinga!!";
            source.PlayOneShot(clipvitoria);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
