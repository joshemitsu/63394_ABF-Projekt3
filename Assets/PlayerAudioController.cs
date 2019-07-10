using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioClip[] surfaceSounds;

    enum eSurfaces { GRASS, ROAD, WATER };
    private eSurfaces lastSurface = eSurfaces.ROAD;
    private Vector3 lastPos;
    private bool playerMoving = false;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = gameObject.transform.position;
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        checkPlayerMovement();
        if(playerMoving)
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

    private void checkPlayerMovement()
    {
        //return (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D));

        /*
        Vector3 curPos = gameObject.transform.position;
        if(curPos == lastPos)
        {
            return false;
        }
        //Debug.Log((curPos - lastPos).magnitude);
        lastPos = curPos;
        return true;
        */

        Vector3 curPos = gameObject.transform.position;

        if ((curPos - lastPos).magnitude <= 0.02f)
        {
            playerMoving = false;
            return;
        }

        playerMoving = true;
        lastPos = curPos;
    }
}
