namespace LukeUI;

using System;
using Exiled.API.Features;
using LukeUI.EventsHandler;

/// <summary>
/// Main class for LukeUI.
/// </summary>
public class LukeMain : Plugin<LukeConfig>
{
    /// <inheritdoc/>
    public override string Name { get; } = "LukeUI";

    /// <inheritdoc/>
    public override string Author { get; } = "NotZer0Two";

    /// <inheritdoc/>
    public override Version Version { get; } = new Version(1, 0, 0);

    /// <summary>
    /// Gets the internal instance of the plugin.
    /// </summary>
    internal static LukeMain? Instance { get; private set; }

    /// <inheritdoc/>
    public override void OnEnabled()
    {
        Instance = this;
        KillEventsHandler.Register();
        UIEventsHandler.Register();
        base.OnEnabled();
    }

    /// <inheritdoc/>
    public override void OnDisabled()
    {
        Instance = null;
        KillEventsHandler.Unregister();
        UIEventsHandler.Unregister();
        base.OnDisabled();
    }
}
