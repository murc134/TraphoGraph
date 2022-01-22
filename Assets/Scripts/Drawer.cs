using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour
{
    public Image Image;
    public Color Color { get { return Image.color; }  set { Image.color = value; } }

    [SerializeField]
    private RectTransform rt;

    [SerializeField]
    private TextMeshProUGUI tmpro;

    public float Radius { get { return RectTransform.sizeDelta.x; } set { rt.sizeDelta = Vector2.one * value; } }

    public Vector2 Size { get { return RectTransform.sizeDelta; } set { rt.sizeDelta = value; } }

    public string Text { get { return tmpro.text;  } set { tmpro.text = value; }  }

    public bool DisplayText { get { return tmpro.gameObject.activeSelf; } set { tmpro.gameObject.SetActive(value); } }

    public RectTransform RectTransform { get { if (rt == null) { rt = GetComponent<RectTransform>(); } return rt; } }

    public Vector2 ScreenSize { get { return new Vector2(Screen.width, Screen.height); } }

    public Vector2 LocalPos { get { return rt.localPosition; } set 
        {
            Vector2 pos = value;
            pos.x -= ScreenSize.x / 2;
            pos.y -= ScreenSize.y / 2;
            RectTransform.localPosition = pos;
        } }
}
