using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; // Tableau des armes disponibles
    private int currentWeaponIndex = 0; // Index de l'arme actuelle

    void Start()
    {
        // D�sactiver toutes les armes sauf la premi�re
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }
    }

    void Update()
    {
        // V�rifier l'entr�e de la molette de la souris
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            // Molette vers le haut
            ChangeWeapon(1);
        }
        else if (scroll < 0f)
        {
            // Molette vers le bas
            ChangeWeapon(-1);
        }
    }

    void ChangeWeapon(int direction)
    {
        // D�sactiver l'arme actuelle
        weapons[currentWeaponIndex].SetActive(false);

        // Mettre � jour l'index de l'arme actuelle
        currentWeaponIndex = (currentWeaponIndex + direction + weapons.Length) % weapons.Length;

        // Activer la nouvelle arme
        weapons[currentWeaponIndex].SetActive(true);
    }
}
