using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class CamInteractRecommended69 : MonoBehaviour
{



    // Write text partly

    public Text Subtext; // our actual text

    string holder = ""; // holds our sentence

    float texttypetime = 0.025f; // the time to write each character

    public GameObject TalkPanel;


    // Write text partly

    // interact

    bool Caninteract = true;

    public Text InteractionText;

    // interact

    // function

    public AudioSource Source;

    public AudioClip LightOutSound;

    public GameObject Light_GameObject;

    public GameObject Remote_Gameobject;

    public GameObject CubeEvent_gameobject;

    private bool TookRemote = false;
    
    // function



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        CubeEvent_gameobject.SetActive(false);


        
    }

    // Update is called once per frame
    void Update()
    {




        if(Caninteract == true)
        {


            Ray ray1 = new Ray(transform.position, transform.forward);
            RaycastHit hit1;

            if(Physics.Raycast(ray1, out hit1, 10f))
            {

                if (hit1.collider.CompareTag("Remote"))
                {


                    // if we look at remote

                    InteractionText.text = "Take the Remote";

                    if(Input.GetKeyDown(KeyCode.E))
                    {


                        StartCoroutine(TakeRemoteCO());



                    }





                }
                else if (hit1.collider.CompareTag("FuseBox") && TookRemote == true)
                {


                    // if we look at fusebox

                    InteractionText.text = "Fix the Light";


                    if (Input.GetKeyDown(KeyCode.E))
                    {


                        StartCoroutine(FixTheLightCO());



                    }



                }
                else
                {


                    // look at things other than above
                    InteractionText.text = "";

                }




            }
            else
            {

                // if we hit nothing
                InteractionText.text = "";


            }





        }


        
    }






    IEnumerator TakeRemoteCO()
    {


        Caninteract = false;

        InteractionText.text = "";

        Remote_Gameobject.SetActive(false);

        Source.PlayOneShot(LightOutSound);

        yield return new WaitForSeconds(4.5f);

        Light_GameObject.SetActive(false);

        // type text partly 

        TalkPanel.SetActive(true);

        Subtext.text = "";

        holder = "I need to check the Fuse";

        foreach(char c in holder)
        {


            Subtext.text += c;
            yield return new WaitForSeconds(texttypetime);


        }


        // type text partly 

        yield return new WaitForSeconds(2f);

        Subtext.text = "";

        TalkPanel.SetActive(false);

        Caninteract = true;

        TookRemote = true;




    }


    IEnumerator FixTheLightCO()
    {


        CubeEvent_gameobject.SetActive(true);

        Light_GameObject.SetActive(true);

        yield return null;




    }



}
