using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public int lines, columns;

    public Enemy[] enemy;

    private void Awake()
    {
        for (int line = 0; line < this.lines; line++)
        {
            float width = 1.0f * (this.columns - 1);
            float height = 1.0f * (this.lines - 1);
            Vector3 centering = new Vector2(-width / 2, -height / 2);
            Vector3 linePosition = new Vector3(centering.x, centering.y + (line * 1.0f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Enemy invader = Instantiate(this.enemy[line], this.transform);
                Vector3 position = linePosition;
                position.x += col * 1.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        lines = 6;
        columns = 12;
    }


}
