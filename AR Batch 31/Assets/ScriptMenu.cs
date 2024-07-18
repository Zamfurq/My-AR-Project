using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMenu : MonoBehaviour
{
    public string namaScene;

    public void gotoScene()
    {
        Application.LoadLevel(namaScene);
    }
}
