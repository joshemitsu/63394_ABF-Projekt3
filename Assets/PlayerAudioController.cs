using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioClip[] surfaceSounds;

    enum eSurfaces { GRASS, ROAD, WATER };
    private eSurfaces lastSurface = eSurfaces.ROAD;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(playerIsMoving())
        {
            RaycastHit surfacePlane;
            string surfaceTag = "";

            if (Physics.Raycast(transform.position, Vector3.down, out surfacePlane))
            {
                surfaceTag = surfacePlane.collider.tag;

                //if(surfaceTag != lastSurface)...switchcase

                if (surfaceTag == "grass" && (lastSurface != eSurfaces.GRASS))
                {
                    lastSurface = eSurfaces.GRASS;
                    audiosource.volume = 0.2f;
                    audiosource.clip = surfaceSounds[0];
                    Debug.Log("grass!");
                }
                else if (surfaceTag == "road" && (lastSurface != eSurfaces.ROAD))
                {
                    lastSurface = eSurfaces.ROAD;
                    audiosource.volume = 0.4f;
                    audiosource.clip = surfaceSounds[1];
                    Debug.Log("road!");
                }
                else if (surfaceTag == "water" && (lastSurface != eSurfaces.WATER))
                {
                    lastSurface = eSurfaces.WATER;
                    audiosource.volume = 0.5f;
                    audiosource.clip = surfaceSounds[2];
                    Debug.Log("water!");
                }
            }

            if (!(audiosource.isPlaying))
            {
                audiosource.Play();
            }
        }

        else
        {
            if(audiosource.isPlaying)
            {
                Debug.Log("pause!");
                audiosource.Pause();
            }
        }

    }

    private bool playerIsMoving()
    {
        return (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    }
}
