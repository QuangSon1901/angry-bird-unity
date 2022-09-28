using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panchitomove : MonoBehaviour
{
    public Transform pivot;
    public float springRange;
    public float maxVel;

    public Texture2D cursorNomal;
    public Texture2D cursorDrag;

    Rigidbody2D rb;

    public AudioClip mGrad;
    public AudioClip mUp;
    private AudioSource mAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        mAudio  = GetComponent<AudioSource>();
        
    }

    bool canDrag = true;
    Vector3 dis;

    void OnMouseDown() {
        if (!canDrag)
            return;
            
        mAudio.clip = mGrad;
        int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        if (musicPlay == 1) {
            mAudio.Play();
        }  
    }

    void OnMouseDrag()
    {
        if (!canDrag)
            return;

        Cursor.SetCursor(cursorDrag,dis, CursorMode.Auto);

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis = pos - pivot.position;
        dis.z = 0;

        if (dis.magnitude > springRange) {
            dis = dis.normalized * springRange;
        }

        transform.position = dis + pivot.position;
    }

    void OnMouseUp() {
        if (!canDrag)
            return;

        mAudio.clip = mUp;
        int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        if (musicPlay == 1) {
            mAudio.Play();
        }  

        Cursor.SetCursor(cursorNomal,dis, CursorMode.Auto);

        if((dis.x < 0.80 && dis.x > -0.80) && (dis.y < 0.80 && dis.y > -0.80)) {
            transform.position = pivot.position;
            return;
        }
            

        canDrag = false;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -dis.normalized * maxVel * dis.magnitude / springRange;
    }
}
