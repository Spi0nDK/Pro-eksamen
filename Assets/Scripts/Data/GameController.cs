using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    //variable og funktioner

    /* Det her er her ens highscore bliver gemt p� et gametag. 
       TMP_Text referere til UI text, s� man kan f� den til at s�tte en bestemt text ind.
       */

    public TMP_Text Text;

    private Realm _realm;
    private GameModel _gameModel;

    void OnEnable()
    {
        _realm = Realm.GetInstance(); // Det her henter ting fra vores Realm database. S� n�r man slukker spillet kommer highscoren ind i realm databasen uden er slette den.
        _gameModel = _realm.Find<GameModel>("GamerTag"); // Det her er her ens gamertag bliver kaldt.
        if (_gameModel == null) // Det her tjekker om der er en score under det gamertag man har angivet, og hvis ikke der er det vil den g� videre og lave en.
        {
            _realm.Write(() =>
            {
                _gameModel = _realm.Add(new GameModel("GamerTag", 0)); // Her er det den kalder GamerTaget og dens point, som er 0 til at starte med.
            });
        }
    }

    // Det her gemmer scoren n�r man stopper spillet.
    void OnDisable()
    {
        _realm.Dispose();
    }

    public void SetButtonScore(string fjende, int inc)
    {
        switch (fjende)
        {
            // Den g�r efter gameobject som hedder "Fjende"
            case "Fjende":
                _realm.Write(() =>
                {
                    _gameModel.KillScore++; // Her tilf�jer den til KillScore, hvis man nakker noget med navnet "Fjende"
                });
                break;
            // Den g�r efter gameobject som hedder "Fjende(Clone)" fordi vi laver clones ud fra allerede eksisterende fjender.
            case "Fjende(Clone)":
                _realm.Write(() =>
                {
                    _gameModel.KillScore++; // Her tilf�jer den til KillScore, hvis man nakker noget med navnet "Fjende(Clone)"
                });
                break;
        }
    }

    void Update()
    {
        // Det her laver teksten oppe i venstre hj�rne s� der st�r et tal efterfulgt at "Kills" s� der st�r hvor mange kills man har. 
        Text.text = _gameModel.KillScore + " kills";
    }
}
