using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Drawing;


public class playerControl : MonoBehaviour
{
    Rigidbody prota;
    public Vector2 horizontal;
    public bool saltar;
    public bool unSalto;
    public bool dosSaltos;
    RaycastHit2D rayito;
    public const int maxVida = 10;
    public Scrollbar scrollbar;
    public float vidas;
    public float velocidad;
    public float fuerzaSalto;
    public LayerMask layer;
    public GameObject perdiste;
    public GameObject ganaste;
    public Button button;
    public Button boton;
    SpriteRenderer Renderer;



    private void Awake()
    {
        prota = GetComponent<Rigidbody>();
        Renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltar = true;
        }
       
    }
    void Start()
    {
        TiempoDelJuego(1);
    }

    private void FixedUpdate()
    {
        prota.velocity = new Vector3 (horizontal.x * velocidad, prota.velocity.y, horizontal.y * velocidad); 
        CheckRaycast();
        if (saltar == true)
        {
            if (unSalto == true)
            {
                prota.AddForce(new Vector2(0, fuerzaSalto), (ForceMode) ForceMode2D.Impulse);
                saltar = false;
            }
            else if (dosSaltos == true)
            {
                prota.AddForce(new Vector2(0, fuerzaSalto), (ForceMode) ForceMode2D.Impulse);
                dosSaltos = false;
            }
        }
    }

    private void CheckRaycast()
    {
        rayito = Physics2D.Raycast(transform.position, Vector2.down, 1.03f, layer);
        if (rayito.collider != null)
        {
            unSalto = true;
            dosSaltos = true;
        }
        else
        {
            unSalto = false;
        }
    }
    public void ReadDireccion(InputAction.CallbackContext Context)
    {
        horizontal = Context.ReadValue<Vector2>();
    }
    public void TiempoDelJuego(int a)
    {
        Time.timeScale = a;
    }
    public void ReadJump(InputAction.CallbackContext Context)
    {
        if (Context.performed)
        {

            unSalto = true;

        }
    }
}
