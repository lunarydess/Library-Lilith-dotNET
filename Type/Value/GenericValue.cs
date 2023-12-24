namespace Library_Lilith.Type.Value;

public class GenericValue<T>: IValue {
    private static readonly Action<T, T> EmptyAction = (_, _) => {};

    private readonly string       _name;
    private readonly Action<T, T> _onChange;
    private          T            _value;

    public GenericValue(in string name, in T value) {
        _name     = name;
        _value    = value;
        _onChange = EmptyAction;
    }

    public GenericValue(in string name, in T value, in Action<T, T> onChange) {
        _name     = name;
        _value    = value;
        _onChange = onChange;
    }

    #region Setters
    public void SetValue(in T value) =>
    _onChange.Invoke(arg1: _value, arg2: _value = value);

    public void SetValueUnchecked(in object value) => SetValue(value: (T) value);
    #endregion

    #region Getters
    public string GetName()  => _name;
    public T      GetValue() => _value;
    #endregion
}