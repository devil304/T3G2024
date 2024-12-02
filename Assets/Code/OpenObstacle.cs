using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//zmienia stan Animatora prze wejściu i wyściu gracza z triggera
public class OpenObstacle : MonoBehaviour
{
    [SerializeField] Animator _obstacleAnimator;
    [SerializeField] string _playerTag;
    [SerializeField] string _animatorParameterName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            _obstacleAnimator.SetBool(_animatorParameterName, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            _obstacleAnimator.SetBool(_animatorParameterName, false);
        }
    }
}
