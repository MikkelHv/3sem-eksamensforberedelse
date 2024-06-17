using Hashing;

public class HashSetLinearProbing : HashSet {
    private Object[] buckets;
    private int currentSize;
    private enum State { DELETED }

    public HashSetLinearProbing(int bucketsLength) {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        int probe;  // Variabel til at holde den nuv�rende probe position
        int code = HashValue(x);  // Beregn hash-v�rdien for elementet x

        // Tjek om den initiale bucket er tom
        if (buckets[code] == null)
        {
            // Returner false, hvis bucket er tom (og ikke markeret som slettet)
            return false;
        }

        // Tjek om elementet i den initiale bucket matcher x
        else if (buckets[code].Equals(x))
        {
            return true;  // Returner true, hvis elementet matcher
        }

        // Hvis elementet ikke matcher, begynd probing
        else
        {
            // Hvis den initiale bucket er den sidste i arrayet, wrap around til starten
            if (code == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                // Ellers, forts�t til n�ste bucket
                probe = code + 1;
            }
        }

        // Forts�t probing, indtil vi kommer tilbage til den initiale bucket
        while (probe != code)
        {
            // Tjek om den nuv�rende probe position er tom
            if (buckets[probe] == null)
            {
                // Returner false, hvis bucket er tom (og ikke markeret som slettet)
                return false;
            }
            // Tjek om elementet i den nuv�rende probe position matcher x
            else if (buckets[probe].Equals(x))
            {
                return true;  // Returner true, hvis elementet matcher
            }
            // Hvis elementet ikke matcher, forts�t probing
            else
            {
                // Hvis den nuv�rende probe position er den sidste i arrayet, wrap around til starten
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    // Ellers, forts�t til n�ste bucket
                    probe++;
                }
            }
        }

        // Hvis vi har probet hele vejen rundt uden at finde elementet, returner false
        return false;
    }


    public bool Add(Object x)
    {

        // Tjek om elementet allerede findes i hashtabellen
        if (Contains(x))
        {
            return false;  // Returner false, hvis elementet allerede findes
        }

        int probe;  // Variabel til at holde den nuv�rende probe position
        int code = HashValue(x);  // Beregn hash-v�rdien for elementet x

        // Tjek om den initiale bucket er tom eller markeret som slettet
        if ((buckets[code] == null) || buckets[code].Equals(State.DELETED))
        {
            buckets[code] = x;  // Placer elementet i den initiale bucket
            currentSize++;  // �g den aktuelle st�rrelse af hashtabellen
            return true;  // Returner true, da elementet blev tilf�jet
        }

        // Hvis den initiale bucket ikke er tom eller markeret som slettet, begynd probing
        else
        {
            // Hvis den initiale bucket er den sidste i arrayet, wrap around til starten
            if (code == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                // Ellers, forts�t til n�ste bucket
                probe = code + 1;
            }
        }

        // Forts�t probing, indtil vi kommer tilbage til den initiale bucket
        while (probe != code)
        {
            // Tjek om den nuv�rende probe position er tom eller markeret som slettet
            if ((buckets[probe] == null) || buckets[probe].Equals(State.DELETED))
            {
                buckets[probe] = x;  // Placer elementet i den nuv�rende probe position
                currentSize++;  // �g den aktuelle st�rrelse af hashtabellen
                return true;  // Returner true, da elementet blev tilf�jet
            }

            // Dette skulle ikke ske, da vi tjekker med Contains i starten
            else if (buckets[probe].Equals(x))
            {
                return false;  // Returner false, da elementet allerede findes (pga. set)
            }

            // Hvis den nuv�rende probe position ikke er tom eller markeret som slettet, forts�t probing
            else
            {
                // Hvis den nuv�rende probe position er den sidste i arrayet, wrap around til starten
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    // Ellers, forts�t til n�ste bucket
                    probe++;
                }
            }
        }

        // Hvis vi har probet hele vejen rundt uden at finde en tom eller slettet position, returner false
        return false;
    }


    public bool Remove(Object x)
    {

        int probe;  // Variabel til at holde den nuv�rende probe position
        int code = HashValue(x);  // Beregn hash-v�rdien for elementet x

        // Tjek om den initiale bucket er tom
        if (buckets[code] == null)
        {
            return false;  // Returner false, hvis elementet ikke findes i hashtabellen
        }

        // Hvis det f�rste element i bucket matcher elementet x, fjern det
        else if (buckets[code].Equals(x))
        {
            buckets[code] = State.DELETED;  // Marker bucket som slettet
            currentSize--;  // Reducer den aktuelle st�rrelse af hashtabellen
            return true;  // Returner true, da elementet blev fjernet
        }

        // Hvis det f�rste element ikke matcher x, begynd probing
        else
        {
            // Hvis den initiale bucket er den sidste i arrayet, wrap around til starten
            if (code == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                // Ellers, forts�t til n�ste bucket
                probe = code + 1;
            }
        }

        // Forts�t probing, indtil vi kommer tilbage til den initiale bucket
        while (probe != code)
        {
            // Tjek om den nuv�rende probe position er tom
            if (buckets[probe] == null)
            {
                return false;  // Returner false, hvis elementet ikke findes i hashtabellen
            }

            // Hvis det nuv�rende element matcher x, fjern det
            else if (buckets[probe].Equals(x))
            {
                buckets[probe] = State.DELETED;  // Marker bucket som slettet
                currentSize--;  // Reducer den aktuelle st�rrelse af hashtabellen
                return true;  // Returner true, da elementet blev fjernet
            }

            // Hvis den nuv�rende probe position ikke er tom eller matcher x, forts�t probing
            else
            {
                // Hvis den nuv�rende probe position er den sidste i arrayet, wrap around til starten
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    // Ellers, forts�t til n�ste bucket
                    probe++;
                }
            }
        }

        // Hvis vi har probet hele vejen rundt uden at finde elementet, returner false
        return false;
    }


    public int Size() {
        return currentSize;
    }

    private int HashValue(Object x) {
        int h = x.GetHashCode();
        if (h < 0) {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public override String ToString() {
        String result = "";
        for (int i = 0; i < buckets.Length; i++) {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ? 
                    HashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
