using UnityEngine;

[System.Serializable]
public class PlayerStats 
{
    public Vector3 position = Vector3.zero;

    public int health;

    public PlayerStats(Vector3 _position, int _health)
    {
        position = _position;
        health = _health;   
    }


}
