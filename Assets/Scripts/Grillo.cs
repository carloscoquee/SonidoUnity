using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grillo : MonoBehaviour
{
    public AudioSource _audioSource;
    public float stopDistance;
    private Transform player;
    private float defaultVolume;
    // Start is called before the first frame update
    void Start()
    {
        defaultVolume = _audioSource.volume;
        player = FindObjectOfType<PlayerControler>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > stopDistance)
        {
            _audioSource.volume = defaultVolume;
        }
        else
        {
            _audioSource.volume = 0;
        }
    }
}
