using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//klasa magazynu danych
public class StorageContainer
{
    Dictionary<string, object> _storage = new Dictionary<string, object>(); //słownik/magazyn przechowujący dane

    public bool HasValue(string key) //sprawdzanie czy dany klucz występuje w magazynie
    {
        return _storage.ContainsKey(key);
    }

    public T GetValue<T>(string key) //pobieranie wartości danych z podanego klucza
    {
        if (_storage.ContainsKey(key))
        {
            if (_storage[key].GetType() == typeof(T))
            {
                return (T)_storage[key];
            }
            else
            {
                Debug.LogError($"Requested type {typeof(T)} is different from type in storage {_storage[key].GetType()} for key {key}!");
                return default;
            }
        }
        else
        {
            Debug.LogError($"No key {key} in storage!");
            return default;
        }
    }

    public void SetValue<T>(string key, T value) //ustawianie wartości danych w danym kluczu
    {
        if (_storage.ContainsKey(key))
        {
            _storage[key] = value;
        }
        else
        {
            _storage.Add(key, value);
        }
    }

    public void Clear() //czyszczenie magazynu
    {
        _storage.Clear();
    }

    public void ResetValues() //resetowanie wartości wszystkich kluczy w magazynie
    {
        foreach (string key in _storage.Keys)
        {
            _storage[key] = default;
        }
    }
}
