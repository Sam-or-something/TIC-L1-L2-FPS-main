using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrarElementoEnArrat : MonoBehaviour
{
    public GameObject[] array_de_mesas;

    // Start is called before the first frame update
    void Start()
    {
        array_de_mesas = GameObject.FindGameObjectsWithTag("Mesa");
        addMesaScriptAndSetDestructible();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //desactivarMesas();
            destroyDestructible();
        }
    }

    void desactivarMesas()
    {
        for(int i = 0; i < array_de_mesas.Length; i++)
        {
            array_de_mesas[i].SetActive(false);
        }
    }

    void addMesaScriptAndSetDestructible()
    {
        foreach(GameObject mesa in array_de_mesas)
        {
            mesa.AddComponent<Mesa>();
            mesa.GetComponent<Mesa>().destructible = Random.Range(0, 2) == 0;
        }
    }

    void destroyDestructible()
    {
        foreach (GameObject mesa in array_de_mesas)
        {
            if (mesa.GetComponent<Mesa>().destructible)
            {
                Destroy(mesa);
            }
        }
    }
}
