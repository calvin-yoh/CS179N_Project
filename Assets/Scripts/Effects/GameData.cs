using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public List<BuildingCardDisplay> friendlyBuildings;
    public List<BuildingCardDisplay> enemyBuildings;

    public List<FacultyCardDisplay> friendlyFaculties;
    public List<FacultyCardDisplay> enemyFaculties;

    public List<StudentCardDisplay> friendlyStudents;
    public List<StudentCardDisplay> enemyStudents;

    public DeckLayout friendlyDeck;
    public DeckLayout enemyDeck;

    public HandLayout enemyHand;
    public HandLayout friendlyHand;

    public CardDisplay target;
    public CardDisplay self;

    public GameData(List<BuildingCardDisplay> fbcd, List<BuildingCardDisplay> ebcd,
                    List<FacultyCardDisplay> ff, List<FacultyCardDisplay> ef,
                    List<StudentCardDisplay> fs, List<StudentCardDisplay> es,
                    DeckLayout fd, DeckLayout ed,
                    HandLayout fh, HandLayout eh, 
                    CardDisplay t, CardDisplay s)
    {
        friendlyBuildings = fbcd;
        enemyBuildings = ebcd;
        friendlyFaculties = ff;
        enemyFaculties = ef;
        friendlyStudents = fs;
        enemyStudents = es;
        friendlyDeck = fd;
        enemyDeck = ed;
        friendlyHand = fh;
        enemyHand = eh;
        target = t;
        self = s;
    }
}
