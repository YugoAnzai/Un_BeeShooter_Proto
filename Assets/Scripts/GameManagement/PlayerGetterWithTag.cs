using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetterWithTag : MonoBehaviour, IPlayerGetter
{

    private GameObject _player;

    public GameObject Player
    {
        get 
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player");
            return _player;
        }
    }

    public GameObject GetPlayer()
    {
        return Player;
    }

}
