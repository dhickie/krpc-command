using KRPC.Client;
using KRPC.Client.Services.UI;
using KrpcCommand.Manoeuvres;

namespace KrpcCommand.UI;

/// <summary>
/// Manages the in-game kRPC UI window. Handles rendering the manoeuvre selection list,
/// configuration forms, and execution log display.
/// </summary>
public class UIManager : IDisposable
{
    private readonly IReadOnlyList<IManoeuvre> _manoeuvres;
    private readonly ManoeuvreContext _context;

    private Panel _window;
    private Text _titleText;
    private UIState _state = UIState.Selection;

    // Selection state UI elements
    private readonly List<Button> _manoeuvreButtons = new();

    // Configuration state UI elements
    private readonly List<(Text Label, InputField Input)> _parameterFields = new();
    private Button? _executeButton;
    private Button? _backButton;
    private IManoeuvre? _selectedManoeuvre;

    // Execution state UI elements
    private Text? _logText;
    private Button? _cancelButton;
    private CancellationTokenSource? _cancellationTokenSource;
    private Task? _executionTask;
    private ManoeuvreLogger? _currentLogger;

    // Layout constants
    private const float WindowWidth = 350f;
    private const float WindowPadding = 10f;
    private const float ElementHeight = 30f;
    private const float ElementSpacing = 5f;

    public UIManager(Connection connection, IReadOnlyList<IManoeuvre> manoeuvres)
    {
        var ui = connection.UI();
        _manoeuvres = manoeuvres;
        _context = new ManoeuvreContext(connection);

        var canvas = ui.StockCanvas;

        // Create main window panel
        _window = canvas.AddPanel();
        var windowRect = _window.RectTransform;
        windowRect.Size = new Tuple<double, double>(WindowWidth, 400);
        windowRect.Position = new Tuple<double, double>(200, 0);

        // Title
        _titleText = _window.AddText("Mission Control");
        _titleText.Size = 16;
        _titleText.Style = FontStyle.Bold;
        _titleText.Color = new Tuple<double, double, double>(1.0, 1.0, 1.0);
        var titleRect = _titleText.RectTransform;
        titleRect.Anchor = new Tuple<double, double>(0.5, 1.0);
        titleRect.Position = new Tuple<double, double>(0, -WindowPadding);
        titleRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);

        ShowSelection();
    }

    /// <summary>
    /// Poll for UI interactions and handle state transitions.
    /// Should be called regularly from the main loop.
    /// </summary>
    public void Update()
    {
        switch (_state)
        {
            case UIState.Selection:
                UpdateSelection();
                break;
            case UIState.Configuration:
                UpdateConfiguration();
                break;
            case UIState.Execution:
                UpdateExecution();
                break;
        }
    }

    #region Selection State

    private void ShowSelection()
    {
        ClearDynamicElements();
        _state = UIState.Selection;
        _titleText.Content = "Mission Control";

        float yOffset = -(WindowPadding + ElementHeight + ElementSpacing);

        for (int i = 0; i < _manoeuvres.Count; i++)
        {
            var manoeuvre = _manoeuvres[i];
            var button = _window.AddButton(manoeuvre.Name);
            button.Text.Size = 14;
            var btnRect = button.RectTransform;
            btnRect.Anchor = new Tuple<double, double>(0.5, 1.0);
            btnRect.Position = new Tuple<double, double>(0, yOffset);
            btnRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);
            _manoeuvreButtons.Add(button);

            yOffset -= (ElementHeight + ElementSpacing);
        }

        ResizeWindow(yOffset);
    }

    private void UpdateSelection()
    {
        for (int i = 0; i < _manoeuvreButtons.Count; i++)
        {
            if (_manoeuvreButtons[i].Clicked)
            {
                _manoeuvreButtons[i].Clicked = false;
                _selectedManoeuvre = _manoeuvres[i];
                ShowConfiguration();
            }
        }
    }

    #endregion

    #region Configuration State

    private void ShowConfiguration()
    {
        ClearDynamicElements();
        _state = UIState.Configuration;
        _titleText.Content = _selectedManoeuvre!.Name;

        float yOffset = -(WindowPadding + ElementHeight + ElementSpacing);

        // Description
        var descText = _window.AddText(_selectedManoeuvre.Description);
        descText.Size = 12;
        descText.Color = new Tuple<double, double, double>(0.8, 0.8, 0.8);
        var descRect = descText.RectTransform;
        descRect.Anchor = new Tuple<double, double>(0.5, 1.0);
        descRect.Position = new Tuple<double, double>(0, yOffset);
        descRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);
        yOffset -= (ElementHeight + ElementSpacing);

        // Parameter fields
        foreach (var param in _selectedManoeuvre.Parameters)
        {
            // Label
            var label = _window.AddText(param.Label);
            label.Size = 12;
            label.Color = new Tuple<double, double, double>(0.9, 0.9, 0.9);
            label.Alignment = TextAnchor.MiddleLeft;
            var labelRect = label.RectTransform;
            labelRect.Anchor = new Tuple<double, double>(0.5, 1.0);
            labelRect.Position = new Tuple<double, double>(0, yOffset);
            labelRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);
            yOffset -= (ElementHeight + ElementSpacing);

            // Input field
            var input = _window.AddInputField();
            input.Value = param.ValueAsString;
            var inputRect = input.RectTransform;
            inputRect.Anchor = new Tuple<double, double>(0.5, 1.0);
            inputRect.Position = new Tuple<double, double>(0, yOffset);
            inputRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);
            yOffset -= (ElementHeight + ElementSpacing);

            _parameterFields.Add((label, input));
        }

        // Execute button
        _executeButton = _window.AddButton("Execute");
        _executeButton.Text.Size = 14;
        _executeButton.Text.Color = new Tuple<double, double, double>(0.2, 1.0, 0.2);
        var execRect = _executeButton.RectTransform;
        execRect.Anchor = new Tuple<double, double>(0.5, 1.0);
        execRect.Position = new Tuple<double, double>(0, yOffset);
        execRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);
        yOffset -= (ElementHeight + ElementSpacing);

        // Back button
        _backButton = _window.AddButton("Back");
        _backButton.Text.Size = 14;
        var backRect = _backButton.RectTransform;
        backRect.Anchor = new Tuple<double, double>(0.5, 1.0);
        backRect.Position = new Tuple<double, double>(0, yOffset);
        backRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);
        yOffset -= (ElementHeight + ElementSpacing);

        ResizeWindow(yOffset);
    }

    private void UpdateConfiguration()
    {
        if (_backButton != null && _backButton.Clicked)
        {
            _backButton.Clicked = false;
            ShowSelection();
            return;
        }

        if (_executeButton != null && _executeButton.Clicked)
        {
            _executeButton.Clicked = false;

            // Copy parameter values from UI inputs
            var parameters = _selectedManoeuvre!.Parameters;
            for (int i = 0; i < parameters.Count; i++)
            {
                parameters[i].SetFromString(_parameterFields[i].Input.Value);
            }

            StartExecution();
        }
    }

    #endregion

    #region Execution State

    private void StartExecution()
    {
        ClearDynamicElements();
        _state = UIState.Execution;
        _titleText.Content = $"Executing: {_selectedManoeuvre!.Name}";

        float yOffset = -(WindowPadding + ElementHeight + ElementSpacing);

        // Log text area
        _logText = _window.AddText("Starting...");
        _logText.Size = 11;
        _logText.Color = new Tuple<double, double, double>(0.9, 0.9, 0.9);
        _logText.Alignment = TextAnchor.UpperLeft;
        var logRect = _logText.RectTransform;
        logRect.Anchor = new Tuple<double, double>(0.5, 1.0);
        logRect.Position = new Tuple<double, double>(0, yOffset);
        logRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, 250);
        yOffset -= (250 + ElementSpacing);

        // Cancel button
        _cancelButton = _window.AddButton("Cancel");
        _cancelButton.Text.Size = 14;
        _cancelButton.Text.Color = new Tuple<double, double, double>(1.0, 0.3, 0.3);
        var cancelRect = _cancelButton.RectTransform;
        cancelRect.Anchor = new Tuple<double, double>(0.5, 1.0);
        cancelRect.Position = new Tuple<double, double>(0, yOffset);
        cancelRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);
        yOffset -= (ElementHeight + ElementSpacing);

        ResizeWindow(yOffset);

        // Start execution
        _cancellationTokenSource = new CancellationTokenSource();
        _currentLogger = new ManoeuvreLogger();
        _currentLogger.OnLog += OnLogMessage;

        _executionTask = Task.Run(async () =>
        {
            try
            {
                _currentLogger.Log("Manoeuvre started.");
                await _selectedManoeuvre!.ExecuteAsync(_context, _currentLogger, _cancellationTokenSource.Token);
                _currentLogger.Log("Manoeuvre completed successfully.");
            }
            catch (OperationCanceledException)
            {
                _currentLogger.Log("Manoeuvre cancelled.");
            }
            catch (Exception ex)
            {
                _currentLogger.Log($"ERROR: {ex.Message}");
            }
        });
    }

    private void OnLogMessage()
    {
        // Update the log text in the UI (will be picked up on next Update call)
        // We keep the last N messages to avoid overflow
        try
        {
            if (_currentLogger != null && _logText != null)
            {
                var messages = _currentLogger.Messages;
                var recent = messages.Count > 15
                    ? messages.Skip(messages.Count - 15).ToList()
                    : messages;
                _logText.Content = string.Join("\n", recent);
            }
        }
        catch
        {
            // UI element may have been disposed
        }
    }

    private void UpdateExecution()
    {
        if (_cancelButton != null && _cancelButton.Clicked)
        {
            _cancelButton.Clicked = false;
            _cancellationTokenSource?.Cancel();
        }

        // Check if execution completed and we need to swap cancel -> back
        if (_executionTask != null && _executionTask.IsCompleted)
        {
            // Replace cancel button with back button
            if (_cancelButton != null)
            {
                _cancelButton.Remove();
                _cancelButton = null;
            }

            _backButton = _window.AddButton("Back");
            _backButton.Text.Size = 14;
            var backRect = _backButton.RectTransform;
            backRect.Anchor = new Tuple<double, double>(0.5, 1.0);

            // Position at the same location as the cancel button was
            float yOffset = -(WindowPadding + ElementHeight + ElementSpacing + 250 + ElementSpacing);
            backRect.Position = new Tuple<double, double>(0, yOffset);
            backRect.Size = new Tuple<double, double>(WindowWidth - 2 * WindowPadding, ElementHeight);

            _executionTask = null;
        }

        // Handle back button after completion
        if (_backButton != null && _backButton.Clicked)
        {
            _backButton.Clicked = false;
            _currentLogger = null;
            ShowSelection();
        }
    }

    #endregion

    #region Helpers

    private void ClearDynamicElements()
    {
        foreach (var button in _manoeuvreButtons)
        {
            try { button.Remove(); } catch { }
        }
        _manoeuvreButtons.Clear();

        foreach (var (label, input) in _parameterFields)
        {
            try { label.Remove(); } catch { }
            try { input.Remove(); } catch { }
        }
        _parameterFields.Clear();

        if (_executeButton != null) { try { _executeButton.Remove(); } catch { } _executeButton = null; }
        if (_backButton != null) { try { _backButton.Remove(); } catch { } _backButton = null; }
        if (_logText != null) { try { _logText.Remove(); } catch { } _logText = null; }
        if (_cancelButton != null) { try { _cancelButton.Remove(); } catch { } _cancelButton = null; }
    }

    private void ResizeWindow(float bottomOffset)
    {
        var height = Math.Abs(bottomOffset) + WindowPadding;
        _window.RectTransform.Size = new Tuple<double, double>(WindowWidth, height);
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        try { _window?.Remove(); } catch { }
    }

    #endregion
}
