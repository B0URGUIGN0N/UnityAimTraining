using UnityEngine;

public class BeamWeaponController : MonoBehaviour
{
    public Transform beamOrigin; // The point where the beam will originate
    public float beamLength = 10f; // Length of the beam
    public float beamWidth = 0.1f; // Width of the beam
    public Color beamColor = Color.red; // Color of the beam
    public Color hitColor = Color.green; // Color of the beam when it hits an object
    public LayerMask hitLayers; // Layers that the beam can hit

    private LineRenderer lineRenderer;
    private bool isFiring = false;

    void Start()
    {
        // Initialize the LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = beamWidth;
        lineRenderer.endWidth = beamWidth;
        lineRenderer.startColor = beamColor;
        lineRenderer.endColor = beamColor;
        lineRenderer.useWorldSpace = true;
        lineRenderer.enabled = false;
        
    }

    void Update()
    {
        
        // Check if the left mouse button is held down
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
            lineRenderer.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
            lineRenderer.enabled = false;
        }

        if (isFiring)
        {
            ShootBeam();
        }
    }

    void ShootBeam()
    {
        // Set the start position of the beam
        lineRenderer.SetPosition(0, beamOrigin.position);

        // Calculate the end position of the beam
        RaycastHit hit;
        if (Physics.Raycast(beamOrigin.position, beamOrigin.forward, out hit, beamLength, hitLayers))
        {
            lineRenderer.SetPosition(1, hit.point);
            // Change the color of the beam when it hits an object
            lineRenderer.startColor = hitColor;
            lineRenderer.endColor = hitColor;
        }
        else
        {
            lineRenderer.SetPosition(1, beamOrigin.position + beamOrigin.forward * beamLength);
            // Reset the color of the beam when it does not hit an object
            lineRenderer.startColor = beamColor;
            lineRenderer.endColor = beamColor;
        }
    }
}
