using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour
{
    public Transform player; // 3D‚Ì©‹@ƒLƒƒƒ‰

    void LateUpdate()
    {
        // ˆÊ’u‚¾‚¯’Ç]
        transform.position = player.position + new Vector3(0, 0.2f, 1.0f);
        // ‰ñ“]‚ÍŒÅ’è‚µ‚½‚Ü‚Ü
        // ¦‰½‚à‚µ‚È‚¢¢ŠEÀ•W‚Ì‰ñ“]‚ªˆÛ‚³‚ê‚é
    }
}
