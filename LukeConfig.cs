namespace LukeUI;

using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using RueI.API.Elements.Enums;

/// <summary>
/// Config class for <see cref="LukeMain"/>.
/// </summary>
public class LukeConfig : IConfig
{
    /// <inheritdoc/>
    public bool IsEnabled { get; set; } = true;

    /// <inheritdoc/>
    public bool Debug { get; set; }

    /// <summary>
    /// Gets or sets how many times a second it gets updated.
    /// </summary>
    [Description("This is used to tell RueI how many times a second we want the plugin to update the UI (higher means slower update time)")]
    public float UpdateInterval { get; set; } = 0.1f;

    /// <summary>
    /// Gets or sets a value indicating whether if it is resolution based.
    /// </summary>
    [Description("Feature from ruei where it allows the user to make it the hint appear based on their resolution (I would say leave it on)")]
    public bool ResolutionBased { get; set; } = true;

    /// <summary>
    /// Gets or sets if it is resolution based.
    /// </summary>
    [Description("Position that it will take vertically which is from 0 to 1000")]
    public float VerticalPosition { get; set; } = 0;

    /// <summary>
    /// Gets or Sets initializes the vertical alignment of the element.
    /// </summary>
    [Description("vertical alignment of the element (Down, Center, Up)")]
    public VerticalAlign VerticalAlign { get; set; } = VerticalAlign.Down;

    /// <summary>
    /// Gets or sets the dead ui for the players.
    /// </summary>
    [Description("Ui shown only to any spectator role.")]
    public string DeadUI { get; set; } = "<size=15><color=#00eaff>Generators: %activeGenerators%/%generators% <color=white>|</color> TPS: %tps% <color=white>|</color> Round: %roundTime% <color=white>|</color> Warhead Status: %warhead% <color=white>|</color> Spectating: %spectating% <color=white>|</color> ID: %id% <color=white>|</color> Role: %role% <color=white>|</color> Kills: %kills% <color=white>|</color> Deaths: %deaths%</size>";

    /// <summary>
    /// Gets or sets the alive ui for the players.
    /// </summary>
    [Description("Ui shown only to alive role.")]
    public string AliveUI { get; set; } = "<size=15><color=%roleColor%>%roleDisplayName% (%id%)</color> <color=white>|</color> Round: %roundTime% <color=white>|</color> TPS: %tps% <color=white>|</color> Kills: %kills% <color=white>|</color> Deaths: %deaths%</size>";

    /// <summary>
    /// Gets or sets the format for player.
    /// </summary>
    [Description("How time gets formatted for Round Time (If you wanna change it search 'C# custom formats strings'.")]
    public string FormatRoundTime { get; set; } = @"mm\:ss";

    /// <summary>
    /// Gets or sets status of the translation for the status of the warhead.
    /// </summary>
    public Dictionary<WarheadStatus, string> WarheadTranslation { get; set; } = new()
    {
        { WarheadStatus.Armed, "Armed" },
        { WarheadStatus.InProgress, "In Progress" },
        { WarheadStatus.Detonated, "Detonated" },
        { WarheadStatus.NotArmed, "Not Armed" },
    };
}
