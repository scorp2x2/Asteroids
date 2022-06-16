using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class GlobalParametrs
{
    /// <summary>
    /// Максимальная скорость корабля
    /// </summary>
    public static readonly float MaxSpeedSheep = 500;
    /// <summary>
    /// Шаг увеличения сокрости корабля
    /// </summary>
    public static readonly float StepUpSpeedSheep = 400;
    /// <summary>
    /// Шаг уменьшения скорости корабля
    /// </summary>
    public static readonly float StepDownSpeedSheep = .1f;
    /// <summary>
    /// Шаг поворота корабля в радианах
    /// </summary>
    public static readonly float StepRotationSheep = 3f;

    /// <summary>
    /// Максимальное количество зарядов лазера
    /// </summary>
    public static readonly int MaxCountLaser = 10;
    /// <summary>
    /// Время отката дахера в секундах
    /// </summary>
    public static readonly float TimeReloadLaser = 5;

    /// <summary>
    /// Скорость полёта пули
    /// </summary>
    public static readonly float SpeedGun = 1000;
    /// <summary>
    /// Скорость полёта лазера
    /// </summary>
    public static readonly float SpeedLaser = 3000;

    /// <summary>
    /// Скорость полёта астероида
    /// </summary>
    public static readonly float SpeedAsteroid = 100;
    /// <summary>
    /// Количество очков за астероид
    /// </summary>
    public static readonly int ScoreAsteroid = 1;

    /// <summary>
    /// Скорость полёта тарелки
    /// </summary>
    public static readonly float SpeedSaucer = 130;
    /// <summary>
    /// Количество очков за тарелку
    /// </summary>
    public static readonly int ScoreSaucer = 3;

    /// <summary>
    /// Максимальное количество одновременных противников в игре
    /// </summary>
    public static readonly int MaxCountEnemy = 30;
}

