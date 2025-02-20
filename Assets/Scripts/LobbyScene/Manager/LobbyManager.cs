using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    NoticeUI notice;

    private void Start()
    {
        notice = FindObjectOfType<NoticeUI>(true);

        // πÃ¥œ∞‘¿”¿∏∑Œ Ω◊¿Œ ∞ÒµÂ∏¶ «√∑π¿ÃæÓ ∞ÒµÂø° √ﬂ∞°
        if (GoldManager.instance.MiniGameGold != 0)
        {
            string text = $"πÃ¥œ∞‘¿” ¡ﬂ »πµÊ«— ¡°ºˆ ∏∏≈≠\r\n∞ÒµÂ∏¶ »πµÊ«ﬂΩ¿¥œ¥Ÿ.\r\n\r\n»πµÊ«— ∞ÒµÂ : {GoldManager.instance.MiniGameGold}G\r\n";
            notice.OnNoticeText(text, 2f);

            GoldManager.instance.AddPlayerGold();
            GoldManager.instance.InitializeMiniGameGold();
        }
    }
}
