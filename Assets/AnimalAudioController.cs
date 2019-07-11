using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAudioController : MonoBehaviour
{
    private AudioSource audiosource;

    public int delay;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundWithDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlaySoundWithDelay()
    {
        while(true)
        {
            audiosource.PlayOneShot(audiosource.clip);
            yield return new WaitForSeconds(delay);
        }
    }
}
