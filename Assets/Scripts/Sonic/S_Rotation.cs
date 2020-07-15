using UnityEngine;


//INUTILIZZATO, per ora
[RequireComponent(typeof(Collider))]
public class S_Rotation : MonoBehaviour
{
    [SerializeField]
    Sonic sonic;

    Collider coll;

    void Awake()
    {
        coll = GetComponent<Collider>();
    }
}
