using UnityEngine;
using UnityEngine.UI;

public class ScreenBreakSystem : MonoBehaviour
{
    [SerializeField] ScreenBreak sb;
    private int cnt = 0;
    private bool flg = true;

    [SerializeField]
    Image img;

    [SerializeField]
    Camera cam2;

    [SerializeField]
    GameObject stage5Button;

    private void Start()
    {
        stage5Button.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.N) && flg)
        {
            cnt++;

            if (cnt >= 5)
            {
                cam2.targetTexture = null;
                stage5Button.SetActive(true);
                sb.Breaking();
                img.color = new Color(255, 0, 0);
                flg = false;
            }
        }
    }
}
