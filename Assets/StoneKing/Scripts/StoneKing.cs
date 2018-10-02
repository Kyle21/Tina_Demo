using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneKing : MonoBehaviour {

    public Transform g_Camera, g_Target;
    public Transform g_StoneKing;
    SkinnedMeshRenderer g_Weapon;
    Animator g_Ani;

    float g_fX = 0f, g_fY = 0f;
    float g_fDistance = 2f;
    float g_fSpeed = 2f;

    // Use this for initialization
    void Start () {
        if (g_Camera == null || g_Target == null || g_StoneKing == null)
            Debug.LogError("Error");

        Transform Child;
        Child = g_StoneKing.Find("Stone");
        if ((g_Weapon = Child.GetComponent<SkinnedMeshRenderer>()) == null)
            Debug.LogError("Error");

        if ((g_Ani = g_StoneKing.GetComponent<Animator>()) == null)
            Debug.LogError("Error");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            g_fX += Input.GetAxis("Mouse X") * g_fSpeed;
            g_fY -= Input.GetAxis("Mouse Y") * g_fSpeed;
            g_fY = ClampAngle(g_fY, -20, 80);
        }
        g_fDistance += Input.GetAxis("Mouse ScrollWheel");
        if (g_fDistance < 1f)
            g_fDistance = 1f;
        else if (g_fDistance > 2f)
            g_fDistance = 2f;

        Quaternion rotation = Quaternion.Euler(g_fY, g_fX, 0.0f);
        g_Camera.rotation = rotation;

        Vector3 position = rotation * new Vector3(0f, 0f, -g_fDistance) + g_Target.position;
        g_Camera.position = position;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(120f, 0f, 120f, 20f), "Show/Hide Weapon"))
            g_Weapon.enabled = !g_Weapon.enabled;

        if (GUI.Button(new Rect(0f, 0f, 120f, 20f), "Idle"))
            g_Ani.CrossFade("Idle", 0.1f);

        if (GUI.Button(new Rect(0f, 20f, 120f, 20f), "Idle2"))
            g_Ani.CrossFade("Idle2", 0.1f, 0, 0f);

        if (GUI.Button(new Rect(0f, 40f, 120f, 20f), "Walk"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Walk", 0.1f);
        }
        if (GUI.Button(new Rect(0f, 60f, 120f, 20f), "Walk2"))
        {
            g_Weapon.enabled = false;
            g_Ani.CrossFade("Walk2", 0.1f);
        }
        if (GUI.Button(new Rect(0f, 80f, 120f, 20f), "Run"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Run", 0.1f);
        }
        if (GUI.Button(new Rect(0f, 100f, 120f, 20f), "Run2"))
        {
            g_Weapon.enabled = false;
            g_Ani.CrossFade("Run2", 0.1f);
        }
        if (GUI.Button(new Rect(0f, 120f, 120f, 20f), "Jump"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Jump", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 140f, 120f, 20f), "Jump2"))
        {
            g_Weapon.enabled = false;
            g_Ani.CrossFade("Jump2", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 160f, 120f, 20f), "AttackReady"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("AttackReady", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 180f, 120f, 20f), "Attack1"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Attack1", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 200f, 120f, 20f), "Attack2"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Attack2", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 220f, 120f, 20f), "Attack3-1"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Attack3-1", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 240f, 120f, 20f), "Attack3-2"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Attack3-2", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 260f, 120f, 20f), "Attack3-3"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Attack3-3", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 280f, 120f, 20f), "Attack4"))
        {
            g_Weapon.enabled = true;
            g_Ani.CrossFade("Attack4", 0.1f, 0, 0f);
        }
        if (GUI.Button(new Rect(0f, 300f, 120f, 20f), "Wound"))
            g_Ani.CrossFade("Wound", 0f, 0, 0f);

        if (GUI.Button(new Rect(0f, 320f, 120f, 20f), "Stun"))
            g_Ani.CrossFade("Stun", 0.1f);

        if (GUI.Button(new Rect(0f, 340f, 120f, 20f), "HitAway"))
            g_Ani.CrossFade("HitAway", 0f, 0, 0f);

        if (GUI.Button(new Rect(0f, 360f, 120f, 20f), "HitAwayUp"))
            g_Ani.CrossFade("HitAwayUp", 0.1f, 0, 0f);

        if (GUI.Button(new Rect(0f, 380f, 120f, 20f), "Death"))
            g_Ani.CrossFade("Death", 0f, 0, 0f);

        if (GUI.Button(new Rect(0f, 400f, 120f, 20f), "Magic"))
            g_Ani.CrossFade("Magic", 0.1f);

        if (GUI.Button(new Rect(0f, 420f, 120f, 20f), "Fire"))
            g_Ani.CrossFade("Fire", 0.1f, 0, 0f);
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
