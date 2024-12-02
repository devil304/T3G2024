using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storage //Klasa udostępniająca lokalny i globalny magazyn danych
{
    public static StorageContainer LocalStorage = new StorageContainer();
    public static StorageContainer GlobalStorage = new StorageContainer();
}
