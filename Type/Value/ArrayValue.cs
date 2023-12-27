namespace Lilith.Type.Value;

public class ArrayValue<T>: IValue {
    private static readonly Action<T, T> EmptyAction = (_, _) => {};

    private readonly string       _name;
    private readonly Action<T, T> _onChange;
    private readonly T[]          _values;
    private          T            _value;

    public ArrayValue(in string name, in T value, params T[] values) {
        _name     = name;
        _value    = value;
        _onChange = EmptyAction;
        _values   = values;
    }

    public ArrayValue(in string name, in T value, in Action<T, T> onChange, params T[] values) {
        _name     = name;
        _value    = value;
        _onChange = onChange;
        _values   = values;
    }

    #region Setters
    public void SetValue(in T value) =>
    _onChange.Invoke(arg1: _value, arg2: _value = value);

    public void SetValueUnchecked(in object value) => SetValue(value: (T) value);
    #endregion

    #region Getters
    public string GetName()   => _name;
    public T      GetValue()  => _value;
    public T[]    GetValues() => _values;
    #endregion
}