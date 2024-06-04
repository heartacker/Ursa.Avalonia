using Avalonia.Interactivity;

namespace VariableBox.Controls;
public enum ValueChangedReason
{
    None = 0,
    UserInput = 1,
    OnSpinner = 2,
    OnValueModel = 4,
    OnRead = 8,
    OnWrite = 16,
}

public class ValueChangedEventArgs<T> : RoutedEventArgs where T : struct, IComparable<T>
{
    public ValueChangedEventArgs(RoutedEvent routedEvent, T? oldValue, T? newValue,
        ValueChangedReason? reason = ValueChangedReason.None) : base(routedEvent)
    {
        OldValue = oldValue;
        NewValue = newValue;
        Reason = reason;
    }

    public T? OldValue { get; }

    public T? NewValue { get; }

    public ValueChangedReason? Reason { get; }
}
