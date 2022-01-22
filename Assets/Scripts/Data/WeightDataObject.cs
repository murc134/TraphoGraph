using System;
using UnityEngine;

[Serializable]
public struct WeightDataObject
{
    public MyDateTime Day;
    public float Weight;
    public float Fat;
    public float Muscle;
    public float Water;
    public float CaloriesRequire;
    public float CaloriesEat;

    public WeightDataObject(int year, int month, int day, float weight, Vector3 micros, Vector2 calories) : this(new MyDateTime(year, month, day), weight, micros.x, micros.y, micros.z, calories.x, calories.y) { }
    public WeightDataObject(int year, int month, int day, float weight, float fat = -1, float muscle = -1, float water = -1, float caloriesRequire = -1, float caloriesEat = -1) : this(new MyDateTime(year, month, day), weight, fat, muscle, water, caloriesRequire, caloriesEat ) { }
    public WeightDataObject(DateTime date, float weight, float fat = -1, float muscle = -1, float water = -1, float caloriesRequire = -1, float caloriesEat = -1) : this(new MyDateTime(date), weight, fat, muscle, water, caloriesRequire, caloriesEat) { }

    public WeightDataObject(MyDateTime date, float weight, float fat = -1, float muscle = -1, float water=-1, float caloriesRequire=-1, float caloriesEat=-1)
    {
        Day = date;
        Weight = weight;
        Fat = fat;
        Muscle = muscle;
        Water = water;
        CaloriesRequire = caloriesRequire;
        CaloriesEat = caloriesEat;
    }
}