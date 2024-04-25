using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence au transform du personnage à suivre
    public Vector3 offset; // Décalage entre la caméra et le personnage

    void Update()
    {
        if (target != null)
        {
            // Déplacer la caméra pour suivre le personnage avec un décalage
            transform.position = target.position + offset;
        }
    }
}
