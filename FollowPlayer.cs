using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    private float delay;
    public float time;

    public void Start()
    {
        delay = time;
    }

    void Update ()
    {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            transform.position = player.position + offset;
        }
	}
}
