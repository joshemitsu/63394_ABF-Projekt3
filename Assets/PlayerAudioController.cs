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
            //RaycastHit surfacePlane;
            string surfaceTag = "";

            RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.down);

            foreach(RaycastHit hit in hits)
            {
                surfaceTag = hit.collider.tag;

                if ((surfaceTag != "Untagged") && (surfaceTag != surfaceAsString(lastSurface)))
                {
                    switch (surfaceTag)
                    {
                        case "grass":
                            audiosource.clip = surfaceSounds[0];
                            audiosource.volume = 0.1f;
                            break;

                        case "road":
                            audiosource.clip = surfaceSounds[1];
                            audiosource.volume = 0.4f;
                            break;

                        case "water":
                            audiosource.clip = surfaceSounds[2];
                            audiosource.volume = 0.5f;
                            break;

                        default:
                            audiosource.clip = surfaceSounds[1];
                            audiosource.volume = 0.4f;
                            break;
                    }

                    lastSurface = surfaceAsEnum(surfaceTag);
                    Debug.Log(surfaceTag);
                    break;
                }
            }

            /*
            if (Physics.Raycast(transform.position, Vector3.down, out surfacePlane))
            {
                surfaceTag = surfacePlane.collider.tag;

                //if(surfaceTag != lastSurface)...switchcase
                if(surfaceTag != surfaceAsString(lastSurface) && surfaceTag != "Untagged")
                {
                    switch(surfaceTag)
                    {
                        case "grass":
                            audiosource.clip = surfaceSounds[0];
                            audiosource.volume = 0.1f;
                            break;

                        case "road":
                            audiosource.clip = surfaceSounds[1];
                            audiosource.volume = 0.4f;
                            break;

                        case "water":
                            audiosource.clip = surfaceSounds[2];
                            audiosource.volume = 0.5f;
                            break;

                        default:
                            audiosource.clip = surfaceSounds[1];
                            audiosource.volume = 0.4f;
                            break;
                    }

                    Debug.Log(surfaceTag);
                }
                */

                /*
                if (surfaceTag == "grass" && (lastSurface != eSurfaces.GRASS))
                {
                    lastSurface = eSurfaces.GRASS;
                    audiosource.volume = 0.1f;
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
            */

            if (!(audiosource.isPlaying))
            {
                audiosource.Play();
            }
        }

        else
        {
            if(audiosource.isPlaying)
            {
                //Debug.Log("pause!");
                audiosource.Pause();
            }
        }

    }

    private bool playerIsMoving()
    {
        return (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    }

    private string surfaceAsString(eSurfaces esurface)
    {
        switch(esurface)
        {
            case eSurfaces.ROAD:
                return "road";
            case eSurfaces.GRASS:
                return "grass";
            case eSurfaces.WATER:
                return "water";
            default:
                return "road";
        }
    }

    private eSurfaces surfaceAsEnum(string strsurface)
    {
        switch (strsurface)
        {
            case "road":
                return eSurfaces.ROAD;
            case "grass":
                return eSurfaces.GRASS;
            case "water":
                return eSurfaces.WATER;
            default:
                return eSurfaces.ROAD;
        }
    }
}
