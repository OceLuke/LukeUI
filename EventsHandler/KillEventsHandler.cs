namespace LukeUI.EventsHandler;

using System.Collections.Generic;
using Exiled.Events.EventArgs.Player;

/// <summary>
/// The ui handler.
/// </summary>
internal static class KillEventsHandler
{
    /// <summary>
    /// The kills of all the players in the server.
    /// </summary>
    public static readonly Dictionary<ReferenceHub, int> Kills = [];

    /// <summary>
    /// The kills of all the players in the server.
    /// </summary>
    public static readonly Dictionary<ReferenceHub, int> Deaths = [];

    /// <summary>
    /// Register the Event Handler.
    /// </summary>
    public static void Register()
    {
        Exiled.Events.Handlers.Player.Joined += OnPlayerJoined;
        Exiled.Events.Handlers.Player.Destroying += OnPlayerLeave;
        Exiled.Events.Handlers.Player.Died += OnPlayerDeath;
    }

    /// <summary>
    /// Unregister the Event Handler.
    /// </summary>
    public static void Unregister()
    {
        Exiled.Events.Handlers.Player.Joined -= OnPlayerJoined;
        Exiled.Events.Handlers.Player.Destroying -= OnPlayerLeave;
        Exiled.Events.Handlers.Player.Died -= OnPlayerDeath;
    }

    private static void OnPlayerJoined(JoinedEventArgs ev)
    {
        Kills.Add(ev.Player.ReferenceHub, 0);
        Deaths.Add(ev.Player.ReferenceHub, 0);
    }

    private static void OnPlayerLeave(DestroyingEventArgs ev)
    {
        Kills.Remove(ev.Player.ReferenceHub);
        Deaths.Remove(ev.Player.ReferenceHub);
    }

    private static void OnPlayerDeath(DiedEventArgs ev)
    {
        Deaths[ev.Player.ReferenceHub] += 1;

        if (ev.Attacker == null)
            return;

        Kills[ev.Attacker.ReferenceHub] += 1;
    }
}
