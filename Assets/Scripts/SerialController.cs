using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialController : MonoBehaviour
{
    // Start is called before the first frame update
    public ArduinoTest Mouvement;
    public Vector2 Vec;
    public string Vector;
    public string First;
    public string Sec;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouvement.dataString != null)
        {
            Vector = Mouvement.dataString;
            int sepa = Vector.IndexOf(",");
            string tmp = Vector;
            string tmp2 = Vector;
            if (sepa > 0)
            {
                First = tmp.Substring(0, sepa);
                Sec = tmp2.Substring(sepa + 1, tmp2.Length - sepa - 1);
                Vec.x = int.Parse(First);
                Vec.y = int.Parse(Sec);
            }

        }

    }
}
