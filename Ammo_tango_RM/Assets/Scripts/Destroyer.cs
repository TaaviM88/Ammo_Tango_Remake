using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject destroyedObject;

    [SerializeField]
    private float hp = 1;
    public void TakeDMG( float  dmg)
    {
        float takenDamage = Mathf.Min(dmg - hp, 0);

        if(takenDamage <= 0)
        {
            Instantiate(destroyedObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
