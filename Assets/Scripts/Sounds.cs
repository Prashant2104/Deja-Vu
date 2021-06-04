using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds sounds;
    private void Awake()
    {
        if (sounds != null && sounds != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sounds = this;
        DontDestroyOnLoad(this);
    }
}
