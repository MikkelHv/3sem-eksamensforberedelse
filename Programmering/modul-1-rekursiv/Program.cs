using System;
using System.Collections.Generic;
using System.Linq;



// Test opgave 3
Console.WriteLine("Opgave 3:\t " + Opgave3.Faculty(5)); // Output skal være '120'.
// Test opgave 4.1
        Console.WriteLine("Opgave 4.1:\t " + Opgave4en.Sfd(48, 18)); // Output skal være '6'
// Test opgave 4.2
        Console.WriteLine("opgave 4.2:\t "+ Opgave4to.Potens(5,4)); // Output skal være '625'
//Test opgave 4.3
        Console.WriteLine("Opgave 4.3:\t" + Opgave4tre.Multiplikation(5, 3)); // Output skal være 15);
        Console.WriteLine("Opgave 4.3:\t" + Opgave4tre.Multiplikation(0, 10)); // Output skal være 0
        Console.WriteLine("Opgave 4.3:\t" + Opgave4tre.Multiplikation(7, 1)); // Output skal være 7
// Test Opgave 4.4
        Console.WriteLine("Opgave 4.4:\t" + Opgave4fire.Reverse("EGAKNANAB")); // Output skal være "BANANAKAGE"




// Opgave 1
// Skriv en rekursiv metode der beregner "n!", "n fakultet", 

//Termineringsregel er 0! = 1
// Rekurrensregel n! = n * (n -1)! hvor n > 0
class Opgave3 {
    public static int Faculty(int n) {
    // Basis tilfælde: fakultet af 0 er 1  
       if (n == 0) {
            return 1;
       }
    // Rekursivt tilfælde: n! = n * (n-1)!
       else {
            return n * Faculty(n - 1);
       }
    }
}


class Opgave4en {
    // opgave 4.1
    // termineringsregel: "b" hvis "b <= a", og hvis b går op i af %
    // rekurensregel: 
    // sfd(b,a) hvis a < b
    // eller sfd(b , a % b)
    
    public static int Sfd(int a, int b) {
        // Basis tilfælde: hvis b er 0, så er SFD a
        if (b == 0) {
            return a;
        }
        // Rekursivt tilfælde: SFD(a, b) = SFD(b, a % b)
        else {
            return Sfd(b, a % b);
        }
    }
}

class Opgave4to {
    // opgave 4.2
    // en rekursiv funktion der opløfter et tal i n’te potens. Eksempel: Hvis n er 4, skriver man 5⁴
    // Termineringsregel: n^0 = 1
    // rekurrensregel: n^p = n^(p - 1) * n, hvor p>0
    public static int Potens(int n, int p) {
        if (p == 0) {
            return 1;
        }
        else {
            return n * Potens(n,p - 1);
        }
    }
}


class Opgave4tre {
    // En rekursiv metode der beregner a * b uden at bruge *
    // Termineringsregler:
    // 1 * b = b
    // 0 * b = 0
    // Rekurrensregel: a * b = (a - 1) * b + b hvor a > 1
    public static int Multiplikation(int a, int b) {
        if (a == 0) {
            return 0;
        } else if (a == 1) {
            return b;
        } else {
            return Multiplikation(a - 1, b) + b;
        }
    }
}

class Opgave4fire {
    // Skriv en rekursiv metode der returnerer s med karaktererne i omvendt rækkefølge.
    // For eksempel skal kaldet Reverse(“EGAKNANAB”) = “BANANAKAGE”.
    public static string Reverse(string s) {
        if (s.Length == 0) {
            return "";
        }
        else {
            return s[s.Length - 1] + Reverse(s.Substring(0, s.Length - 1));
        }
    }
}
