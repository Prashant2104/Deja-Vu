using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad sounds;
    public static int Death = 0;
    private void Awake()
    {
        Death = 0;
        if (sounds != null && sounds != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sounds = this;
        DontDestroyOnLoad(this);

        Player.DeathCount = Death;
    }

    public static void ResetDDOL()
    {
        Death = 0;
    }
}
