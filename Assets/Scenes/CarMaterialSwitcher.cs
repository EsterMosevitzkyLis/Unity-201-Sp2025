using UnityEngine;

public class CarMaterialSwitcher : MonoBehaviour
{
    public SpriteRenderer centerCarRenderer; // the car in the middle
    public Material[] carMaterials; // assign each material for each car (must match button index)

    // This function gets called by a button with a specific index
    public void SetCarMaterial(int carIndex)
    {
        if (carIndex < 0 || carIndex >= carMaterials.Length)
        {
            Debug.LogWarning("Invalid car index.");
            return;
        }

        centerCarRenderer.material = carMaterials[carIndex];
    }
}
