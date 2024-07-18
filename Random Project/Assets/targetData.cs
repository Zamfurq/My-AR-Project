using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class targetData : MonoBehaviour
    {

        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
            //add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

                //Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                TextTargetName.GetComponent<Text>().text = name;
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);


                //If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

                if (name == "Mobil")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("mobil"); });
                    TextDescription.GetComponent<Text>().text = "Mobil adalah kendaraan yang menggunakan bahan bakar untuk menghidupkan mesinnya.";
                }



                //If the target name was “unitychan” then add listener to ButtonAction with location of the unitychan sound (locate in Resources/sounds folder) and set text on TextDescription a description of the unitychan / robot

                if (name == "Sepeda")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sepeda"); });
                    TextDescription.GetComponent<Text>().text = "Sepeda adalah kendaraan beroda dua atau tiga yang mempunyai setang, tempat duduk, dan sepasang pengayuh yang digerakkan kaki untuk menjalankannya.";
                }

                if (name == "SepedaMotor")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sepeda motor"); });
                    TextDescription.GetComponent<Text>().text = "Sepeda motor adalah kendaraan beroda dua yang digerakkan oleh sebuah mesin.";
                }
            }
        }

        //function to play sound
        void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }
    }
}
