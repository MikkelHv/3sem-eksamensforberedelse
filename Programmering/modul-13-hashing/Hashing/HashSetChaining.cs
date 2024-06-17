using Hashing;

public class HashSetChaining : HashSet
{
    // Array af buckets til at holde linked lists.
    private Node[] buckets;
    // Holder styr p� antallet af elementer i hashtabellen.
    private int currentSize;

    // Indre klasse for noder i linked lists.
    private class Node
    {
        // Konstruktor for Node, initialiserer data og n�ste node.
        public Node(Object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        // Data som noden holder.
        public Object Data { get; set; }
        // Reference til den n�ste node i linked list.
        public Node Next { get; set; }
    }

    // Konstruktor for HashSetChaining, initialiserer buckets array med given st�rrelse.
    public HashSetChaining(int size)
    {
        buckets = new Node[size];
        currentSize = 0;
    }

    // Metode til at tjekke, om et element findes i hashtabellen.
    public bool Contains(Object x)
    {
        // Beregn hash-v�rdien for elementet x.
        int h = HashValue(x);
        // Hent den bucket, hvor elementet formodentlig er placeret.
        Node bucket = buckets[h];
        bool found = false;
        // Iter�r gennem linked list for at finde elementet.
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }
        // Returner true, hvis elementet blev fundet, ellers false.
        return found;
    }

    // Metode til at tilf�je et element til hashtabellen.
    public bool Add(Object x)
    {
        // Rehashing tjek
        if (buckets.Length > 0) // hvis arrayet ikke er 0
        {
            if ((double)currentSize / buckets.Length >= 0.75) //loadfactor, hvis arrayet er 75% fyldt, s� bliver der kaldt ReHash();
            {
                ReHash();
            }
        }


        // Beregn hash-v�rdien for elementet x.
        int h = HashValue(x);

        Node bucket = buckets[h];
        bool found = false;
        // Iter�r gennem linked list for at tjekke, om elementet allerede findes.
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }

        // Hvis elementet ikke findes, tilf�j det til starten af linked list.
        if (!found)
        {
            Node newNode = new Node(x, buckets[h]);
            buckets[h] = newNode;
            currentSize++;
        }

        // Returner true, hvis elementet blev tilf�jet, ellers false.
        return !found;
    }

    // N�dvendig for at kunne lave arrayet st�rre hvis det er ved at blive fyldt.
    private void ReHash()
    {

        Node[] oldbuckets = buckets;
        currentSize = 0;
        buckets = new Node[2 * buckets.Length];

        for (int i = 0; i < oldbuckets.Length; i++)
        {
            Node temp = oldbuckets[i];
            while (temp != null)
            {
                Add(temp.Data);
                temp = temp.Next;
            }
        }
    }



    // Metode til at fjerne et element fra hashtabellen.
    public bool Remove(Object x)
    {
        // Hvis elementet ikke findes i hashtabellen, returner false.
        if (!Contains(x))
        {
            return false;
        }

        // Beregn hash-v�rdien for elementet x.
        int h = HashValue(x);
        Boolean found = false;
        Node before = null!;

        // Hent den bucket (linked list), hvor elementet x skulle v�re placeret.
        Node bucket = buckets[h];

        // Hvis bucket er tom (dvs. ingen elementer med denne hash-v�rdi), returner false.
        if (bucket == null)
        {
            return false;
        }

        // Hvis det f�rste element i bucket matcher elementet x, fjern det.
        if (bucket.Data.Equals(x))
        {
            found = true;
            // Opdater bucket til at pege p� det n�ste element.
            buckets[h] = bucket.Next;
            // Reducer den aktuelle st�rrelse af hashtabellen.
            currentSize--;
            return found;
        }

        // Iter�r gennem linked list (bucket) for at finde elementet x.
        while (!found && bucket != null)
        {
            // Hvis det nuv�rende element matcher x, fjern det.
            if (bucket.Data.Equals(x))
            {
                found = true;
                // Opdater "before" node til at pege p� bucket's n�ste node, s� bucket fjernes.
                before.Next = bucket.Next;
                // Reducer den aktuelle st�rrelse af hashtabellen.
                currentSize--;
            }
            else // Vil altid k�re f�rst grundet if ovenover
            {
                // Flyt f�r-noden til den nuv�rende bucket.
                before = bucket;
                // Flyt bucket til den n�ste node i linked list.
                bucket = bucket.Next;
            }
        }

        // Returner true, hvis elementet blev fundet og fjernet, ellers false.
        return found;
    }

    // Beregn hash-v�rdien for et element x.
    private int HashValue(Object x)
    {
        // F� hash-koden for elementet x.
        int h = x.GetHashCode();
        // S�rg for, at hash-v�rdien er positiv.
        if (h < 0)
        {
            h = -h;
        }
        // Find hash-v�rdien ved at tage modulo med l�ngden af buckets array.
        h = h % buckets.Length;
        return h;
    }

    // Returner antallet af elementer i hashtabellen.
    public int Size()
    {
        return currentSize;
    }

    // Returner en strengrepr�sentation af hashtabellen.
    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < buckets.Length; i++)
        {
            Node temp = buckets[i];
            if (temp != null)
            {
                result += i + "\t";
                while (temp != null)
                {
                    result += temp.Data + " (h:" + HashValue(temp.Data) + ")\t";
                    temp = temp.Next;
                }
                result += "\n";
            }
        }
        return result;
    }
}
