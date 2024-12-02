using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//zmienia rodzica gracza na tą platformę gdy gracz wejdzie na nią, zapobiega to spadaniu gracza z platformy
public class Platform : MonoBehaviour
{
    [SerializeField] string _playerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            other.transform.SetParent(null);
        }
    }
}
