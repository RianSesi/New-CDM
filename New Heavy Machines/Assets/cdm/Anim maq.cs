using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animmaq : MonoBehaviour
{
    public Animator bracoPrincipalAnimator, bracoEixoAnimator, paAnimator;
    string estadoAtualBP, estadoAtualBE, estadoAtualPA;
    public GameObject baseMaquina;
    public float velocidadeRotacao;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * velocidadeRotacao * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.up * velocidadeRotacao * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MudarAnimacaoBracoPrincipal("BracoPrincipalEsticar");
        }
        else
        {
            MudarAnimacaoBracoPrincipal("BracoPrincipalVoltando");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MudarAnimacaoBracoEixo("BracoEixoElevar");
        }
        else
        {
            MudarAnimacaoBracoEixo("BracoEixoVoltando");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MudarAnimacaoPa("PaPegando");
        }
        else
        {
            MudarAnimacaoPa("PaSoltando");
        }

    }

    void MudarAnimacaoBracoPrincipal(string novoEstado)
    {
        if (estadoAtualBP == novoEstado) return;

        bracoPrincipalAnimator.Play(novoEstado);

        estadoAtualBP = novoEstado;

    }
    void MudarAnimacaoBracoEixo(string novoEstado)
    {
        if (estadoAtualBE == novoEstado) return;

        bracoEixoAnimator.Play(novoEstado);

        estadoAtualBE = novoEstado;
    }
    void MudarAnimacaoPa(string novoEstado)
    {
        if (estadoAtualPA == novoEstado) return;

        paAnimator.Play(novoEstado);

        estadoAtualPA = novoEstado;
    }
}
