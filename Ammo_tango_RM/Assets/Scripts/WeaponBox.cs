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

    private int randomwep;
    private bool hasRandom = false;

    private bool objectIsActive = true;
    [Header("Respawn settings")]
    public float timeBTWRespawns = 10;
    private float startBTWRespawns;

    public GameObject[] weaponHolograms;
    public GameObject HologramScreen;                                                                                                                                                        
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
        }

        randomwep = Random.Range(0, weaponPrefabs.Count);
        hasRandom = true;
        ChangeHologram();
    }

    private void Update()
    {
        

        if (timeBTWRespawns <= 0 && hasRandom == false)
        { 
            // GetComponentInChildren<Material>().SetColor("_color", Color.green);
            randomwep = Random.Range(0, weaponPrefabs.Count);

            Debug.Log(randomwep);
            hasRandom = true;
            ChangeHologram();
        }
        if (hasRandom == true)
        {
            objectIsActive = true;
            
            /*Renderer rend = GetComponentInChildren<Renderer>();
            rend.material.shader = Shader.Find("HDRP/Lit");
            rend.material.SetColor("_BaseColor", Color.green);*/
        }
        else
        {
            /*Renderer rend = GetComponentInChildren<Renderer>();
            rend.material.shader = Shader.Find("HDRP/Lit");
            rend.material.SetColor("_BaseColor", Color.clear);
           // GetComponentInChildren<Material>().SetColor("_color", Color.green);
           */
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
                return weaponPrefabs[weaponIndex];
            }
            else
            {
                return weaponPrefabs[randomwep];
            }  
    }

    public void ResetRespawn()
    {
        objectIsActive = false;
        timeBTWRespawns = startBTWRespawns;
        hasRandom = false;
        DisableHologram();
    }

    public void ChangeHologram()
    {

       if(weaponPrefabs[randomwep].GetComponent<Weapon>().shootmode == Weapon.ShootMode.Single)
       {
            if(weaponPrefabs[randomwep].GetComponent<Weapon>().name != "Shotgun")
            {
                for (int i = 0; i < weaponHolograms.Length; i++)
                {
                    if (weaponHolograms[i].name == "WeaponPickUpSinglePrefab")
                    {
                        weaponHolograms[i].SetActive(true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < weaponHolograms.Length; i++)
                {
                    if (weaponHolograms[i].name == "WeaponPickUpFanPrefab")
                    {
                        weaponHolograms[i].SetActive(true);
                    }
                }
            }
            return;
       }

       if(weaponPrefabs[randomwep].GetComponent<Weapon>().shootmode == Weapon.ShootMode.Burst)
        {
            for (int i = 0; i < weaponHolograms.Length; i++)
            {
                if (weaponHolograms[i].name == "WeaponPickUpBurstPrefab")
                {
                    weaponHolograms[i].SetActive(true);
                }
            }
        }

       if (weaponPrefabs[randomwep].GetComponent<Weapon>().shootmode == Weapon.ShootMode.Rapid)
        {
            for (int i = 0; i < weaponHolograms.Length; i++)
            {
                if (weaponHolograms[i].name == "WeaponPickUpFullAutoPrefab")
                {
                    weaponHolograms[i].SetActive(true);
                }
            }
        }

        HologramScreen.SetActive(true);
    }

    public void DisableHologram()
    {
        for (int i = 0; i < weaponHolograms.Length; i++)
        {
          weaponHolograms[i].SetActive(false);
        }
        HologramScreen.SetActive(false);
    }
}
