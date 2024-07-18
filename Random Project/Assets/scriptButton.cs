using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptButton : MonoBehaviour
{
    public string namaScene;

    public void gotoScene()
    {
        Application.LoadLevel(namaScene);
    }
}
