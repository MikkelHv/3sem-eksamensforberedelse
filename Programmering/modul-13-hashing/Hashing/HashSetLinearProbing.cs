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
        int probe;  // Variabel til at holde den nuværende probe position
        int code = HashValue(x);  // Beregn hash-værdien for elementet x

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
                // Ellers, fortsæt til næste bucket
                probe = code + 1;
            }
        }

        // Fortsæt probing, indtil vi kommer tilbage til den initiale bucket
        while (probe != code)
        {
            // Tjek om den nuværende probe position er tom
            if (buckets[probe] == null)
            {
                // Returner false, hvis bucket er tom (og ikke markeret som slettet)
                return false;
            }
            // Tjek om elementet i den nuværende probe position matcher x
            else if (buckets[probe].Equals(x))
            {
                return true;  // Returner true, hvis elementet matcher
            }
            // Hvis elementet ikke matcher, fortsæt probing
            else
            {
                // Hvis den nuværende probe position er den sidste i arrayet, wrap around til starten
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    // Ellers, fortsæt til næste bucket
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

        int probe;  // Variabel til at holde den nuværende probe position
        int code = HashValue(x);  // Beregn hash-værdien for elementet x

        // Tjek om den initiale bucket er tom eller markeret som slettet
        if ((buckets[code] == null) || buckets[code].Equals(State.DELETED))
        {
            buckets[code] = x;  // Placer elementet i den initiale bucket
            currentSize++;  // Øg den aktuelle størrelse af hashtabellen
            return true;  // Returner true, da elementet blev tilføjet
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
                // Ellers, fortsæt til næste bucket
                probe = code + 1;
            }
        }

        // Fortsæt probing, indtil vi kommer tilbage til den initiale bucket
        while (probe != code)
        {
            // Tjek om den nuværende probe position er tom eller markeret som slettet
            if ((buckets[probe] == null) || buckets[probe].Equals(State.DELETED))
            {
                buckets[probe] = x;  // Placer elementet i den nuværende probe position
                currentSize++;  // Øg den aktuelle størrelse af hashtabellen
                return true;  // Returner true, da elementet blev tilføjet
            }

            // Dette skulle ikke ske, da vi tjekker med Contains i starten
            else if (buckets[probe].Equals(x))
            {
                return false;  // Returner false, da elementet allerede findes (pga. set)
            }

            // Hvis den nuværende probe position ikke er tom eller markeret som slettet, fortsæt probing
            else
            {
                // Hvis den nuværende probe position er den sidste i arrayet, wrap around til starten
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    // Ellers, fortsæt til næste bucket
                    probe++;
                }
            }
        }

        // Hvis vi har probet hele vejen rundt uden at finde en tom eller slettet position, returner false
        return false;
    }


    public bool Remove(Object x)
    {

        int probe;  // Variabel til at holde den nuværende probe position
        int code = HashValue(x);  // Beregn hash-værdien for elementet x

        // Tjek om den initiale bucket er tom
        if (buckets[code] == null)
        {
            return false;  // Returner false, hvis elementet ikke findes i hashtabellen
        }

        // Hvis det første element i bucket matcher elementet x, fjern det
        else if (buckets[code].Equals(x))
        {
            buckets[code] = State.DELETED;  // Marker bucket som slettet
            currentSize--;  // Reducer den aktuelle størrelse af hashtabellen
            return true;  // Returner true, da elementet blev fjernet
        }

        // Hvis det første element ikke matcher x, begynd probing
        else
        {
            // Hvis den initiale bucket er den sidste i arrayet, wrap around til starten
            if (code == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                // Ellers, fortsæt til næste bucket
                probe = code + 1;
            }
        }

        // Fortsæt probing, indtil vi kommer tilbage til den initiale bucket
        while (probe != code)
        {
            // Tjek om den nuværende probe position er tom
            if (buckets[probe] == null)
            {
                return false;  // Returner false, hvis elementet ikke findes i hashtabellen
            }

            // Hvis det nuværende element matcher x, fjern det
            else if (buckets[probe].Equals(x))
            {
                buckets[probe] = State.DELETED;  // Marker bucket som slettet
                currentSize--;  // Reducer den aktuelle størrelse af hashtabellen
                return true;  // Returner true, da elementet blev fjernet
            }

            // Hvis den nuværende probe position ikke er tom eller matcher x, fortsæt probing
            else
            {
                // Hvis den nuværende probe position er den sidste i arrayet, wrap around til starten
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    // Ellers, fortsæt til næste bucket
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
