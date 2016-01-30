using UnityEngine;
using System.Collections;

public class AreaAttackPlayer : MonoBehaviour {

    public Transform pointHomme ;

    public float theta = 45f;
    public float distance = 2f;
    public PolygonCollider2D polygon;

    private Vector2 center, left, right, front; 

    private float rTheta ;

	// Use this for initialization
	void Start () {
        center  = pointHomme.position;
        Vector3 pc = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float x = center.x + (pc.x - center.x) * Mathf.Cos(-rTheta) - (pc.y - center.y) * Mathf.Sin(-rTheta);
        float y = center.y + (pc.y - center.y) * Mathf.Cos(-rTheta) + (pc.x - center.x) * Mathf.Sin(-rTheta);
        left = new Vector2(x, y);

        float x2 = center.x + (pc.x - center.x) * Mathf.Cos(rTheta) - (pc.y - center.y) * Mathf.Sin(rTheta);
        float y2 = center.y + (pc.y - center.y) * Mathf.Cos(rTheta) + (pc.x - center.x) * Mathf.Sin(rTheta);
        right = new Vector2(x2, y2);

        front = new Vector2(distance / norm(pc, center) * (pc.x + center.x), distance / norm(pc, center) * (pc.y + center.y));

        polygon.points = new Vector2[]{ center,left, front, right};
    }
	 
	// Update is called once per frame
	void Update () {
        //angle degree to radian
        rTheta = theta * Mathf.PI / 180;
        //calcul pointeur souris
        Vector3 pc = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //calcul distance pts central
        front = new Vector2( distance/norm(pc, center) *(pc.x + center.x ), distance / norm(pc, center) * (pc.y + center.y));

        //calcul pts gauche
        float x = center.x + (front.x - center.x) * Mathf.Cos(-rTheta) - (front.y - center.y) * Mathf.Sin(-rTheta);
        float y = center.y + (front.y - center.y) * Mathf.Cos(-rTheta) + (front.x - center.x) * Mathf.Sin(-rTheta);
        left.Set(x, y);

        //calcul pts droit
        float x2 = center.x + (front.x - center.x) * Mathf.Cos(rTheta) - (front.y - center.y) * Mathf.Sin(rTheta);
        float y2 = center.y + (front.y - center.y) * Mathf.Cos(rTheta) + (front.x - center.x) * Mathf.Sin(rTheta);
        right.Set(x2, y2);

        //changement polygon
        polygon.points = new Vector2[] { center, left, front, right };
    }

    //Fonction norm
    float norm(Vector2 x1, Vector2 x2)
    {
        float n = Mathf.Sqrt(Mathf.Pow(x2.x - x1.x, 2) + Mathf.Pow(x2.y - x1.y, 2));
        if (n < 1) return 1;
        return n;
    }
}
