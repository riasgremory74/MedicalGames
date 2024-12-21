using UnityEngine;
using TMPro;
using System.Drawing;
using static UnityEngine.GraphicsBuffer;

public class Paddle : MonoBehaviour
{
    static readonly int
        emissionColorId = Shader.PropertyToID("_EmissionColor"),
        faceColorId = Shader.PropertyToID("_FaceColor"),
        timeOfLastHitId = Shader.PropertyToID("_TimeOfLastHit");

    [SerializeField]
    TextMeshPro scoreText;

    [SerializeField]
    MeshRenderer goalRenderer;

    [SerializeField, ColorUsage(true, true)]
    UnityEngine.Color goalColor = UnityEngine.Color.white;

    [SerializeField, Min(0f)]
    float
        minExtents = 4f,
        maxExtents = 4f,
        speed = 30f, // Further increased speed for more responsive control
        maxTargetingBias = 0.75f;

    [SerializeField]
    bool isAI;

    int score;
    float extents, targetingBias;

    Material goalMaterial, paddleMaterial, scoreMaterial;

    // Even higher sensitivity for minute input response
    [SerializeField, Range(1f, 200f)]
    float inputSensitivity = 20f; // Increased sensitivity

    void Awake()
    {
        goalMaterial = goalRenderer.material;
        goalMaterial.SetColor(emissionColorId, goalColor);
        paddleMaterial = GetComponent<MeshRenderer>().material;
        scoreMaterial = scoreText.fontMaterial;
        SetScore(0);
    }
    void Update()
    {
        LogJoystickInputs();
    }
    void LogJoystickInputs()
    {
    
    }

    public void StartNewGame()
    {
        SetScore(0);
        ChangeTargetingBias();
    }

    public bool HitBall(float ballX, float ballExtents, out float hitFactor)
    {
        ChangeTargetingBias();
        hitFactor =
            (ballX - transform.localPosition.x) /
            (extents + ballExtents);

        if (-1f <= hitFactor && hitFactor <= 1f)
        {
            paddleMaterial.SetFloat(timeOfLastHitId, Time.time);
            return true;
        }
        return false;
    }

    public bool ScorePoint(int pointsToWin)
    {
        goalMaterial.SetFloat(timeOfLastHitId, Time.time);
        SetScore(score + 1, pointsToWin);
        return score >= pointsToWin;
    }

    public void Move(float target, float arenaExtents)
    {
        Vector3 p = transform.localPosition;
        float initialX = p.x;

        // Log the initial X position
      //  Debug.Log($"Initial X Position: {initialX}");

        float moveInput1 = 0f;

 
        if (isAI)
        {
            p.x = AdjustByAI(p.x, target);
        }
        else
        {
            p.x = AdjustByPlayer(p.x);

        }

        // Calculate the clamping limits
        float limit = arenaExtents - extents;
        p.x = Mathf.Clamp(p.x, -arenaExtents + extents, arenaExtents - extents);

        // Log the clamped position
        Debug.Log($"Clamped X Position: {p.x}");

        transform.localPosition = p;

        // Log the final position after movement
        Debug.Log($"Paddle Position after Move: {p.x}");
    }



    float AdjustByAI(float x, float target)
    {
        target += targetingBias * extents;
        return Mathf.MoveTowards(x, target, speed * Time.deltaTime);
    }

    float AdjustByPlayer(float x)
    {

        float moveInput = Input.GetAxis("Horizontal");  // Get the raw joystick or keyboard input

        Debug.Log($"Joystick Move Input (Horizontal) after multiplying by 2: {x}");

        moveInput *= inputSensitivity;
        return  moveInput ;

    }

    void SetScore(int newScore, float pointsToWin = 1000f)
    {
        score = newScore;
        scoreText.SetText("{0}", newScore);
        scoreMaterial.SetColor(faceColorId, goalColor * (newScore / pointsToWin));
        SetExtents(Mathf.Lerp(maxExtents, minExtents, newScore / (pointsToWin - 1f)));
    }

    void ChangeTargetingBias()
    {
        targetingBias = Random.Range(-maxTargetingBias, maxTargetingBias);
    }

    void SetExtents(float newExtents)
    {
        extents = newExtents;
        Vector3 s = transform.localScale;
        s.x = 2f * newExtents;
        transform.localScale = s;
    }
}
