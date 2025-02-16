using UnityEngine;

public class EventCubeRecommended69 : MonoBehaviour
{


    public AudioSource Source;

    public AudioClip KnockingAudio;

    private bool Diditonce = false;



    private void OnTriggerEnter(Collider other)
    {
        
        if(Diditonce == false)
        {


            Diditonce = true;

            Source.PlayOneShot(KnockingAudio);

            


        }


    }




}
