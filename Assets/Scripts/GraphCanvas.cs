using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GraphCanvas : MonoBehaviour
{
    public MyDateTime start = new MyDateTime(2021, 12,30);
    public MyDateTime end = new MyDateTime(2022, 4, 1);
    public Vector2 RangeWeight = new Vector2(70, 100);

    public RectTransform Background;

    public Drawer drawerRectX;
    public Drawer drawerRectY;

    public Drawer drawerCircular;
    private Drawer lastDrawer;

    public Vector2 lastPos = Vector2.one * 50;

    public Vector2 FullSize { get { return new Vector2(Screen.width, Screen.height); } }

    public Vector2 DrawSize { get { return new Vector2(Screen.width - 2 * Offset.x, Screen.height - 2 * Offset.y); } }

    public Vector2 Offset = Vector2.one * 25;

    public Vector2 WeightScale = new Vector2(70, 100);

    public float stepSize = 0.2f;

    public bool Gitter = true;

    public WeightData WeightData;

    // Start is called before the first frame update
    void Start()
    {
        DateTime current = start.Date;

        while (current <= end.Date)
        {
            //Debug.Log(current);
            current = current.AddDays(1);
        }
        DrawCoordinateSystem();
    }

    public void DrawCoordinateSystem(float thickness = 1)
    {
        draw(drawerRectX, Offset, new Vector2(thickness, DrawSize.y), Color.black);
        draw(drawerRectX, Offset, new Vector2(DrawSize.x, thickness), Color.black);

        TimeSpan days = end.Date - start.Date;

        float dayDist = 1.0f / (float)days.TotalDays;

        Debug.Log(days.TotalDays);

        DateTime startDay = start.Date;

        for (int day = 0; day <= days.TotalDays; day++)
        {
            DateTime currentDay = startDay.AddDays(day);

            bool drawDateString = currentDay.DayOfWeek.ToString() == "Monday" || day == 0 || currentDay == end.Date;

            Vector2 pos = new Vector2(dayDist * day * DrawSize.x + Offset.x, Offset.y);
            draw(drawerRectX, pos, new Vector2(1, 3), Color.black, drawDateString ? currentDay.DayOfWeek.ToString().Substring(0,2) + "\n" + new MyDateTime(currentDay).ToString(false) : "", false);
        }

        float weightSpan = WeightScale.y - WeightScale.x;
        float weightDist = 1.0f / weightSpan;

        for (float weight = WeightScale.x; weight <= WeightScale.y; weight++)
        {
            float weightCurrent = WeightScale.y - weight;
            Vector2 pos = new Vector2(Offset.x, DrawSize.y + 2 * Offset.y - (Offset.y + weightDist * weightCurrent * DrawSize.y));

            draw(drawerRectY, pos, new Vector2(3, 1), Color.black, weight != WeightScale.x ? weight.ToString() : "", false);
        }
    }

    private void Update()
    {
        //lastPos.x += stepSize;
        //lastDrawer.Text = "";
        //drawPoint(lastPos+ Offset, Color.blue, lastPos.x.ToString());
    }
    private void draw(Drawer drawer, Vector2 pos, Vector2 size, Color color, string text = "", bool anchorRight = true)
    {
        Drawer line = Instantiate<Drawer>(drawer);
        line.RectTransform.SetParent(Background);
        line.Size = size;

        if (anchorRight)
        {
            pos.x += Mathf.Floor(size.x / 2);
            pos.y += Mathf.Floor(size.y / 2);
        }

        line.LocalPos = pos;
        line.Color = color;
        line.Text = text;
    }
    private void drawPoint(Vector2 pos, Color color, string text = "", float radius = 3)
    {
        lastDrawer = Instantiate<Drawer>(drawerCircular);
        lastDrawer.Radius = radius;
        lastDrawer.RectTransform.SetParent(Background);
        lastDrawer.LocalPos = pos;
        lastDrawer.Color = color;
        lastDrawer.Text = text;
    }

}
