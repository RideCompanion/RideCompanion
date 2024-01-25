using System.ComponentModel;

namespace Shared.Core.Enums;

/// <summary>
/// Unit type enum
/// </summary>
public enum UnitTypeEnum
{
    /// <summary>
    /// Unit
    /// </summary>
    [Description("Unit")]
    Unit = 1,

    /// <summary>
    /// Kilogram
    /// </summary>
    [Description("Kilogram")]
    Kilogram = 2,

    /// <summary>
    /// Gram
    /// </summary>
    [Description("Gram")]
    Gram = 3,

    /// <summary>
    /// Liter
    /// </summary>
    [Description("Liter")]
    Liter = 4,

    /// <summary>
    /// Milliliter
    /// </summary>
    [Description("Milliliter")]
    Milliliter = 5,

    /// <summary>
    /// Piece
    /// </summary>
    [Description("Piece")]
    Piece = 6,

    /// <summary>
    /// Package
    /// </summary>
    [Description("Package")]
    Package = 7,

    /// <summary>
    /// Box
    /// </summary>
    [Description("Box")]
    Box = 8,

    /// <summary>
    /// Bottle
    /// </summary>
    [Description("Bottle")]
    Bottle = 9,

    /// <summary>
    /// Can
    /// </summary>
    [Description("Can")]
    Can = 10,

    /// <summary>
    /// Bag
    /// </summary>
    [Description("Bag")]
    Bag = 11,

    /// <summary>
    /// Pack
    /// </summary>
    [Description("Pack")]
    Pack = 12,

    /// <summary>
    /// Roll
    /// </summary>
    [Description("Roll")]
    Roll = 13,

    /// <summary>
    /// Set
    /// </summary>
    [Description("Set")]
    Set = 14

}