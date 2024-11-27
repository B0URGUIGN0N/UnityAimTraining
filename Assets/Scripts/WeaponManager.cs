using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; // Tableau des armes disponibles
    private int currentWeaponIndex = 0; // Index de l'arme actuelle

    void Start()
    {
        // Désactiver toutes les armes sauf la première
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }
    }

    void Update()
    {
        // Vérifier l'entrée de la molette de la souris
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
        // Désactiver l'arme actuelle
        weapons[currentWeaponIndex].SetActive(false);

        // Mettre à jour l'index de l'arme actuelle
        currentWeaponIndex = (currentWeaponIndex + direction + weapons.Length) % weapons.Length;

        // Activer la nouvelle arme
        weapons[currentWeaponIndex].SetActive(true);
    }
}
