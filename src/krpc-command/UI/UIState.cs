namespace KrpcCommand.UI;

/// <summary>
/// Represents the current state of the UI.
/// </summary>
public enum UIState
{
    /// <summary>
    /// Showing the manoeuvre selection list.
    /// </summary>
    Selection,

    /// <summary>
    /// Showing configuration parameters for a selected manoeuvre.
    /// </summary>
    Configuration,

    /// <summary>
    /// A manoeuvre is currently executing, showing logs and cancel button.
    /// </summary>
    Execution
}
