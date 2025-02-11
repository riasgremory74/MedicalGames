using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SineWave : MonoBehaviour
{
    public LineRenderer sineWavePrefab;  // Prefab for sine wave LineRenderer
    public LineRenderer flatLinePrefab;  // Prefab for flat line LineRenderer
    public GameObject scoreBallPrefab;   // Prefab for score ball
    public GameObject pngImagePrefab;    // Prefab for PNG image
    public int numberOfWaves = 3;        // The number of sine waves and flat lines you want
    public int numberOfPoints = 1000;    // Number of points in each sine wave
    public float amplitude = 2f;         // Amplitude of the sine wave
    public float frequency = 0.2f;       // Frequency of the sine wave
    public float length = 13.8f;         // Length of each sine wave
    public float speed = 1f;             // Speed of movement for sine waves
    public float flatLineLength = 4f;    // Length of each flat line (5 cm)
    public float scoreSpawnDistance = 2f;   // Distance for spawning score balls
    public List<Vector2> pngOffsets = new List<Vector2>(); // List to store offsets for each PNG
    private int scoreObjectCounter = 0; // Counter to track the number of score objects
    public WaveProperties waveProperties; // Reference to the wave properties
                                          //
    public LineRenderer lineRenderer; // Add the LineRenderer reference
    public int pointsCount = 100; // Number of points in the wave
    public float waveLength = 10f; // Length of one wave cycle
    //public float speed = 1f; // Speed of wave movement
    private float offset = 0f; // Offset to animate the wave
    //
    private List<LineRenderer> sineLineRenderers = new List<LineRenderer>();  // Store all sine wave renderers
    private List<LineRenderer> flatLineRenderers = new List<LineRenderer>();  // Store all flat line renderers
    private List<Vector3[]> sinePositionsList = new List<Vector3[]>();        // Store positions for all sine waves
    private List<GameObject> scoreBalls = new List<GameObject>();             // Store all spawned score balls
    private List<GameObject> pngImages = new List<GameObject>();              // Store all PNG images
    private int score = 0;        // Score variable
    private ScoreManager scoreManager;  // Reference to ScoreManager

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager in the scene

        Vector3 lastFlatLineEndPoint = Vector3.zero; // To track where the next sine wave starts

        for (int i = 0; i < numberOfWaves; i++)
        {
            // Create and setup sine wave LineRenderer
            LineRenderer sineLineRenderer = Instantiate(sineWavePrefab);
            sineLineRenderer.positionCount = numberOfPoints;
            sineLineRenderers.Add(sineLineRenderer);

            // Initialize positions for this sine wave
            Vector3[] sinePositions = new Vector3[numberOfPoints];
            sinePositionsList.Add(sinePositions);

            // Calculate sine wave points
            CalculateSineWavePoints(sinePositions, sineLineRenderer, lastFlatLineEndPoint);

            // Create and setup flat line LineRenderer after the sine wave
            LineRenderer flatLineRenderer = Instantiate(flatLinePrefab);
            flatLineRenderers.Add(flatLineRenderer);
            SetupFlatLine(sineLineRenderer, flatLineRenderer);

            // Store the end point of the current flat line for the next sine wave
            lastFlatLineEndPoint = flatLineRenderer.GetPosition(1);

            // Spawn score balls for sine wave and flat line
            SpawnScoreBallsOnSineWave(sinePositions, scoreSpawnDistance);
            SpawnScoreBallsOnFlatLine(flatLineRenderer, scoreSpawnDistance);

            // Spawn PNG image at intervals after the first flat line
            if (pngOffsets.Count > 0 && i < pngOffsets.Count)
            {
                SpawnPngAtFlatLineEnd(flatLineRenderer, pngOffsets[i]);
            }
            float speed = waveProperties.speed;
            float amplitude = waveProperties.amplitude;
            float frequency = waveProperties.frequency;

        }
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        lineRenderer.positionCount = pointsCount;
    }
    void GenerateSineWave()
    {
        float step = waveLength / pointsCount;

        for (int i = 0; i < pointsCount; i++)
        {
            float x = i * step;
            float y = Mathf.Sin((x * waveProperties.frequency) + offset) * waveProperties.amplitude;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
    public void SetAmplitude(float newAmplitude)
    {
        waveProperties.amplitude = newAmplitude;
    }

    public void SetFrequency(float newFrequency)
    {
        waveProperties.frequency = newFrequency;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    void Update()
    {
        for (int i = 0; i < numberOfWaves; i++)
        {
            if (i < sinePositionsList.Count && i < sineLineRenderers.Count)
            {
                MoveSineWavePoints(sinePositionsList[i], sineLineRenderers[i]);
                UpdateFlatLine(sineLineRenderers[i], flatLineRenderers[i]);
            }
        }

        // Move the score balls and PNG images
        MoveScoreBalls();
        MovePngImages();

        // Check for score collection
        CheckForScoreCollection();
    }

    void CalculateSineWavePoints(Vector3[] positions, LineRenderer lineRenderer, Vector3 startPoint)
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            float x = startPoint.x + i * (length / numberOfPoints); // Calculate x position relative to startPoint
            float y = Mathf.Sin(x * frequency * Mathf.PI * 2) * amplitude; // Calculate sine wave value
            positions[i] = new Vector3(x, y, 0); // Store the position
        }
        lineRenderer.SetPositions(positions); // Set the positions in the LineRenderer
    }


    void SetupFlatLine(LineRenderer sineLineRenderer, LineRenderer flatLineRenderer)
    {
        Vector3 sineWaveEndPoint = sineLineRenderer.GetPosition(numberOfPoints - 1);
        flatLineRenderer.positionCount = 2;
        flatLineRenderer.SetPosition(0, sineWaveEndPoint); // Start of flat line
        flatLineRenderer.SetPosition(1, sineWaveEndPoint + new Vector3(flatLineLength, 0, 0)); // End of flat line
    }

    void MoveSineWavePoints(Vector3[] positions, LineRenderer lineRenderer)
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            positions[i].x -= speed * Time.deltaTime; // Move each point left
        }
        lineRenderer.SetPositions(positions); // Update the LineRenderer positions
    }

    void UpdateFlatLine(LineRenderer sineLineRenderer, LineRenderer flatLineRenderer)
    {
        Vector3 sineWaveEndPoint = sineLineRenderer.GetPosition(numberOfPoints - 1);
        flatLineRenderer.SetPosition(0, sineWaveEndPoint); // Update the flat line to start after sine wave
        flatLineRenderer.SetPosition(1, sineWaveEndPoint + new Vector3(flatLineLength, 0, 0)); // Keep the same length
    }

    void MoveScoreBalls()
    {
        foreach (GameObject scoreBall in scoreBalls)
        {
            if (scoreBall != null)
            {
                scoreBall.transform.position += Vector3.left * speed * Time.deltaTime; // Move score ball in the negative X direction
            }
        }
    }

    void MovePngImages()
    {
        foreach (GameObject pngImage in pngImages)
        {
            if (pngImage != null)
            {
                // Get the current position
                Vector3 position = pngImage.transform.position;

                // Update X position
                position.x -= speed * Time.deltaTime;

                // Apply the new position
                pngImage.transform.position = position;
            }
        }
    }

    void SpawnScoreBallsOnSineWave(Vector3[] sinePositions, float separationDistance)
    {
        for (float x = 0; x < length; x += separationDistance)
        {
            int closestIndex = Mathf.RoundToInt((x / length) * (numberOfPoints - 1));
            if (closestIndex >= 0 && closestIndex < numberOfPoints)
            {
                Vector3 position = sinePositions[closestIndex]; // Get the sine position
                GameObject scoreBall = Instantiate(scoreBallPrefab, position, Quaternion.identity); // Spawn the score ball
                scoreBalls.Add(scoreBall); // Add to the list for movement

                // Increment the score object counter
                scoreObjectCounter++;

                // Check if we need to spawn a PNG image
                if (scoreObjectCounter == 9)
                {
                    SpawnPNGImage(position); // Spawn PNG image after 9 score objects
                    scoreObjectCounter = 0;  // Reset the counter
                }
            }
        }
    }

    void SpawnScoreBallsOnFlatLine(LineRenderer flatLineRenderer, float separationDistance)
    {
        Vector3 start = flatLineRenderer.GetPosition(0);
        Vector3 end = flatLineRenderer.GetPosition(1);
        float distance = Vector3.Distance(start, end);
        int numberOfBalls = Mathf.FloorToInt(distance / separationDistance);

        for (int i = 0; i < numberOfBalls; i++)
        {
            float t = (float)i / (numberOfBalls - 1); // Calculate the interpolation factor
            Vector3 position = Vector3.Lerp(start, end, t); // Calculate position on the flat line
            GameObject scoreBall = Instantiate(scoreBallPrefab, position, Quaternion.identity); // Spawn the score ball
            scoreBalls.Add(scoreBall); // Add to the list for movement

            // Increment the score object counter
            scoreObjectCounter++;

            // Check if we need to spawn a PNG image
            if (scoreObjectCounter == 9)
            {
                SpawnPNGImage(position); // Spawn PNG image after 9 score objects
                scoreObjectCounter = 0;  // Reset the counter
            }
        }
    }
    void SpawnPNGImage(Vector3 spawnPosition)
    {
        // Instantiate the PNG image at the given position
        GameObject pngImage = Instantiate(pngImagePrefab, spawnPosition, Quaternion.identity);
        pngImages.Add(pngImage); // Add to the list for management or movement
    }

    void CheckForScoreCollection()
    {
        GameObject myObject = GameObject.Find("MyObject"); // Find the object you want to detect collision with
        if (myObject != null)
        {
            Vector3 objectPosition = myObject.transform.position;

            // Check if the object collides with any score ball
            foreach (GameObject scoreBall in scoreBalls)
            {
                if (scoreBall != null && Vector3.Distance(objectPosition, scoreBall.transform.position) < 0.5f)
                {
                    score++;
                    scoreManager.UpdateScore(score); // Assuming you have a method in ScoreManager to update the score
                    Destroy(scoreBall); // Destroy the score ball after collection
                }
            }
        }
    }

    void SpawnPngAtFlatLineEnd(LineRenderer flatLineRenderer, Vector2 offset)
    {
        Vector3 flatLineEndPoint = flatLineRenderer.GetPosition(1);
        Vector3 spawnPosition = flatLineEndPoint + new Vector3(offset.x, offset.y, 0);
        GameObject pngImage = Instantiate(pngImagePrefab, spawnPosition, Quaternion.identity);
        pngImages.Add(pngImage);
    }
}