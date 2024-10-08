using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Camera")]
    public Transform cameraT; // Transform da câmera
    float verticalLookRotation;
    float horizontalLookRotation;// Rotação vertical da câmera
    float mouseX; // Input de movimento horizontal da câmera
    float mouseY; // Input de movimento vertical da câmera
    public float mouseSensitivityX; // Sensibilidade de movimento horizontal da câmera
    public float mouseSensitivityY; // Sensibilidade de movimento vertical da câmera
    float inputAim; // Input para dar zoom na mira, por enquanto estamos usando para mostrar o cursor
                    // Start is called before the first frame update

    [Header("Coleta")]
    public GameObject[] dejetosBons;
    public GameObject positionDejeto;

    [Header("limpar cidade")]
    public float coletaAtual;
    public float coletaMaxima;
    public Image barraColeta;
    public GameObject ciadadeSuja;
    public GameObject cidadeLimpa;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");


        RotateWithCamera();

        barraColeta.fillAmount = coletaAtual / coletaMaxima;

    }
    public void RotateWithCamera()
    {
        // Rotacionar o jogador com o input da câmera
        // transform.Rotate(Vector3.up, mouseX * mouseSensitivityX);

        horizontalLookRotation += mouseX * mouseSensitivityX;
        horizontalLookRotation = Mathf.Clamp(-90f, horizontalLookRotation, 90f);

        // Limitar a rotação vertical da câmera
        verticalLookRotation += mouseY * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        // Rotacionar a câmera com a rotação vertical
        cameraT.localEulerAngles = new Vector3(-verticalLookRotation, horizontalLookRotation, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lixo"))
        {
            coletaAtual += 100;
            if(coletaAtual >= coletaMaxima)
            {
                ciadadeSuja.SetActive(false);
                cidadeLimpa.SetActive(true);
            }
            Destroy(other.gameObject);
            Instantiate(dejetosBons[Random.Range(0, dejetosBons.Length)],positionDejeto.transform.position, Quaternion.identity);
        }
    }
}
