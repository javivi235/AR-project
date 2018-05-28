using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void NuevoProyecto(string nuevaEscena)
    {
        Debug.Log("Accediendo escena: " + nuevaEscena);
        SceneManager.LoadScene(nuevaEscena);
    }
    public void CargarProyecto(string nuevaEscena2)
    {
        Debug.Log("Accediendo escena: " + nuevaEscena2);
        SceneManager.LoadScene(nuevaEscena2);
    }
    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
