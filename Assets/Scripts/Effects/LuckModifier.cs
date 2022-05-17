using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckModifier
{
    int studentLuckModifier;
    int facultyLuckModifier;

    int engineeringLuckModifier;
    int artsLuckModifier;
    int athleticsLuckModifier;
    int staffLuckModifier;

    public LuckModifier()
    { 
        studentLuckModifier = 0;
        facultyLuckModifier = 0;
        engineeringLuckModifier = 0;
        artsLuckModifier = 0;   
        athleticsLuckModifier = 0;
        staffLuckModifier = 0;
    }

    public int GetStudentLuckModifier() { return studentLuckModifier; }
    public int GetFacultyLuckModifier() { return facultyLuckModifier; }
    public int GetEngineeringLuckModifier() { return engineeringLuckModifier; }
    public int GetArtsLuckModifier() { return artsLuckModifier; }
    public int GetAthleticsLuckModifier() { return athleticsLuckModifier; }
    public int GetStaffLuckModifier() { return staffLuckModifier; }

    public void SetStudentLuckModifier(int val) { studentLuckModifier = val; }
    public void SetFacultyLuckModifier(int val) { facultyLuckModifier = val; }
    public void SetEngineeringLuckModifier(int val) { engineeringLuckModifier = val; }
    public void SetArtsLuckModifier(int val) { artsLuckModifier = val; }
    public void SetAthleticsLuckModifier(int val) { athleticsLuckModifier = val; }
    public void SetStaffLuckModifier(int val) { staffLuckModifier = val; }

    public void ChangeStudentLuckModifier(int val) { studentLuckModifier += val; }
    public void ChangeFacultyLuckModifier(int val) { facultyLuckModifier += val; }
    public void ChangeEngineeringLuckModifier(int val) { engineeringLuckModifier += val; }
    public void ChangeArtsLuckModifier(int val) { artsLuckModifier += val; }
    public void ChangeAthleticsLuckModifier(int val) { athleticsLuckModifier += val; }
    public void ChangeStaffLuckModifier(int val) { staffLuckModifier = val; }

}
