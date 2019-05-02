using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    [SerializeField]
    private List <GameObject> weaponPrefabs = new List<GameObject>();

    [SerializeField]
    private int weaponIndex = 0;

    [SerializeField]
    private bool random = false;

    private bool objectIsActive = true;
    [Header("Respawn settings")]
    private float timeBTWRespawns = 10;
    private float startBTWRespawns;

    private void Start()
    {
        startBTWRespawns = timeBTWRespawns;
        Renderer rend = GetComponentInChildren<Renderer>();
        rend.material.shader = Shader.Find("HDRP/Lit");
        rend.material.SetColor("_BaseColor", Color.green);
        //GetComponentInChildren<Material>().SetColor("_color", Color.green);

        foreach(GameObject weapon in Resources.LoadAll<GameObject>("Weapons"))
        {
            weaponPrefabs.Add(weapon);
            Debug.Log(weapon.name);
        }
    }

    private void Update()
    {
        if(timeBTWRespawns < 0)
        {
            objectIsActive = true;
            Renderer rend = GetComponentInChildren<Renderer>();
            rend.material.shader = Shader.Find("HDRP/Lit");
            rend.material.SetColor("_BaseColor", Color.green);
           // GetComponentInChildren<Material>().SetColor("_color", Color.green);
        }
        else
        {
            Renderer rend = GetComponentInChildren<Renderer>();
            rend.material.shader = Shader.Find("HDRP/Lit");
            rend.material.SetColor("_BaseColor", Color.clear);
           // GetComponentInChildren<Material>().SetColor("_color", Color.green);
            timeBTWRespawns -= Time.deltaTime;
        }

        if(!objectIsActive)
        {
            GetComponentInChildren<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponentInChildren<BoxCollider>().enabled = true;
        }

    }

    public GameObject ReturnWeapon()
    {
            if (random == false && weaponIndex <= weaponPrefabs.Count)
            {
                objectIsActive = false;
                timeBTWRespawns = startBTWRespawns;
                return weaponPrefabs[weaponIndex];
            }
            else
            {
                objectIsActive = false;
                timeBTWRespawns = startBTWRespawns;
                return weaponPrefabs[Random.Range(0, weaponPrefabs.Count)];
            }  
    }

}
