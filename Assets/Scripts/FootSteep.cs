using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootSteep : MonoBehaviour
{
    public AudioClip[] footSteps;
    public AudioSource _audioSource;
    public CharacterController controller;
    public float minVelocidadMovimiento;
    public float footStepRate;
    private float lastFootStepTime;

    private void Update()
    {
        //  COMPROBAMOSSI NOS VEMOS A LA MINIMA O MAS VELOCIDAD
        if (controller.velocity.magnitude > footStepRate)
        {
            if (Time.time - lastFootStepTime > footStepRate)
            {
                lastFootStepTime = Time.time;
                _audioSource.PlayOneShot(footSteps[Random.Range(0,footSteps.Length)]);
            }
        }
    }
}
