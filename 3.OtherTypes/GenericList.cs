using System;

[Version(3, 14)]
public class GenericList<T> where T: IComparable<T>
{
    //constants
    const int DefaultCapacity = 16;

    //fields
    private T[] elements;
    private int count = 0;
    private int capacity = DefaultCapacity;

    //constructors
    public GenericList(int capacity = DefaultCapacity)
    {
        elements = new T[capacity];
    }

    //PROPERTIEEEEEEEEEEEEES
    public int Count
    {
        get
        {
            return this.count;
        }
        set
        {
            this.count = value;
        }
    }

    public int Capacity
    {
        get
        {
            return this.capacity;
        }
        set
        {
            this.capacity = value;
        }
    }

    //METHOOOOOOOOOOOOOOOOOOOOOODS
    //adding element to the end of the array
    public void Add(T element)
    {
        this.Count++;

        if (this.Count >= this.elements.Length)
        {
            int stepen = count % elements.Length;
            this.Capacity *= (int)Math.Pow(2, stepen);
            T[] newElements = new T[this.Capacity];
            for (int i = 0; i < count; i++)
            {
                newElements[i] = this.elements[i];
            }
            newElements[this.Count--] = element;
            this.elements = newElements;
        }
        this.elements[this.Count-1] = element;
    }

    //accessing element by index
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            T result = elements[index];
            return result;
        }
    }

    //removing element by index and return it as result
    public void Remove(int index)
    {
        try
        {
            T result = this.elements[index];

            for (int i = index; i < this.Count; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.elements[this.Count] = default(T);
            this.Count--;
        }
        catch (IndexOutOfRangeException ix)
        {
            throw new IndexOutOfRangeException(String.Format("Invaliiid index: {0}.", index));
        }
    }

    //inserting element by index
    public void InsertAt(T element, int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException(String.Format(
                "Invalid index: {0}.", index));
        }
        this.Count++;
        if (this.Count >= elements.Length)
        {
            int stepen = count % elements.Length;
            this.Capacity *= (int)Math.Pow(2, stepen);
            T[] newElements = new T[this.Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }
            this.elements = newElements;
        }
        for (int i = this.Count-1; i > index; i--)
        {
            this.elements[i] = this.elements[i-1];
        }
        this.elements[index] = element;
    }

    //clear the T[] and return it as result
    public void Clear()
    {
        elements = new T[this.count];
        this.Count = 0;
    }

    //find element index by value
    public int IndexOf(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return i;
            }
        }

        return -1;
    }

    //checking if the array T contains a value
    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        if (this.Count>0)
        {
            string result = "[";
            for (int i = 0; i < this.Count; i++)
            {
                result += elements[i].ToString();
                result += ", ";
                if (i == this.Count)
                {
                }
            }
            result = result.Substring(0, result.Length - 2);
            result += "]";
 	        return result;            
        }
        else
        {
            return "[]";
        }
    }

    //generic methods 
    public T Min()
    {
        if (this.count < 1)
            {
                throw new InvalidOperationException("The list is empty");
            }

        T min = this.elements[0];
        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].CompareTo(min) < 0)
            {
                min = this.elements[i];
            }
        }
        return min;
    }
    public T Max()
    {
        if (this.count < 1)
        {
            throw new InvalidOperationException("The list is empty");
        }

        T max = this.elements[0];
        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].CompareTo(max) > 0)
            {
                max = this.elements[i];
            }
        }
        return max;
    }
}

[AttributeUsage(AttributeTargets.Struct | 
                AttributeTargets.Class | 
                AttributeTargets.Interface | 
                AttributeTargets.Enum |
                AttributeTargets.Method, AllowMultiple = true)]
public class VersionAttribute : Attribute
{
    //fields
    private int major;
    private int minor;

    //constructors
    public VersionAttribute(int major, int minor)
    {
        this.major = major;
        this.minor = minor;
    }

    public override string ToString()
    {
        return this.major.ToString() + "." + this.minor.ToString();
    }
}