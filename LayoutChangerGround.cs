using UnityEngine;

public class LayoutChangerGround : MonoBehaviour
{

    public Renderer Groundnd;
    public string MatName;

    void Start()
    {
        Groundnd = gameObject.GetComponent<Renderer>();
        Groundnd.material = (Material)Resources.Load(PlayerPrefs.GetString("CurrentGroundMat"), typeof(Material));
    }
    public void ChangePlayerColor(Color value)
    {
        Groundnd.material.color = value;
    }
    public void ChangePlayerMaterial(string value)
    {
        string FullMatName = "Ground\\" + value;
        if (value.Contains("Ground\\"))
        {
            Groundnd.material = (Material)Resources.Load(value, typeof(Material));
        }
        else
            Groundnd.material = (Material)Resources.Load(FullMatName, typeof(Material));
    }
}
