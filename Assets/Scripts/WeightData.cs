using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeightData", menuName = "C4rtwork/WeightData", order = 1)]
public class WeightData : ScriptableObject , IList<WeightDataObject>, IEnumerable<WeightDataObject>
{
    public WeightDataObject this[int i]
    {
        get { return weights[i]; }
        set { weights[i] = value; }
    }
    [SerializeField]
    private List<WeightDataObject> weights = new List<WeightDataObject>();

    public int Count => ((ICollection<WeightDataObject>)weights).Count;

    public bool IsReadOnly => ((ICollection<WeightDataObject>)weights).IsReadOnly;

    WeightDataObject IList<WeightDataObject>.this[int index] { get => ((IList<WeightDataObject>)weights)[index]; set => ((IList<WeightDataObject>)weights)[index] = value; }

    public int IndexOf(WeightDataObject item)
    {
        return ((IList<WeightDataObject>)weights).IndexOf(item);
    }

    public void Insert(int index, WeightDataObject item)
    {
        ((IList<WeightDataObject>)weights).Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        ((IList<WeightDataObject>)weights).RemoveAt(index);
    }

    public void Add(WeightDataObject item)
    {
        ((ICollection<WeightDataObject>)weights).Add(item);
    }

    public void Clear()
    {
        ((ICollection<WeightDataObject>)weights).Clear();
    }

    public bool Contains(WeightDataObject item)
    {
        return ((ICollection<WeightDataObject>)weights).Contains(item);
    }

    public void CopyTo(WeightDataObject[] array, int arrayIndex)
    {
        ((ICollection<WeightDataObject>)weights).CopyTo(array, arrayIndex);
    }

    public bool Remove(WeightDataObject item)
    {
        return ((ICollection<WeightDataObject>)weights).Remove(item);
    }

    public IEnumerator<WeightDataObject> GetEnumerator()
    {
        return ((IEnumerable<WeightDataObject>)weights).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)weights).GetEnumerator();
    }
}
