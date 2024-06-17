namespace LinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class UserLinkedList
    {
        private Node first = null!;

        public void AddFirst(User user) // givet fra start
        {
            Node node = new Node(user, first);
            first = node;
        }
        
        public User RemoveFirst()
        {
            if (first != null)
            {
                Node nodeToRemove = first; //Sætter den første node til nodeToRemove
                first = nodeToRemove.Next; //Sætter .Next node til first . Så nu er første node slettet
                if (first == null)
                {
                    Console.WriteLine("List is now empty"); // dette er blot customer-service
                }

                return nodeToRemove.Data; // fordi vi fjerner en node, så returnere vi den for
            }
            else throw new InvalidOperationException("The list is empty."); // Kastes hvis listen er tom
        }
        
        public void RemoveUser(User user) //givet fra start
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        public User GetFirst() // givet fra start
        {
            return first.Data;
        }

        public User GetLast()
        {
            // Tjek om listen er tom
            if (first == null)
            {
                throw new InvalidOperationException("The list is empty."); // Kastes hvis listen er tom
            }

            // Start fra den første node
            Node currentNode = first;

            // Iterer gennem listen, indtil vi når den sidste node
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            // Returner dataen fra den sidste node
            return currentNode.Data;
        }


        public int CountUsers()
        {
            int count = 0; // Initialiserer tælleren til 0

            // Tjek om listen er tom
            if (first == null)
            {
                throw new InvalidOperationException("The list is empty."); // Kastes hvis listen er tom
            }

            // Starter fra første node
            Node currentNode = first;

            // Itererer gennem listen, indtil vi når den sidste node
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next; // Flytter til næste node
                count++; // Inkrementerer tælleren for hver node vi besøger
            }

            // Returnerer count + 1, fordi vi skal inkludere den sidste node
            return count + 1;
        }


        public override String ToString() // givet fra start
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }


        public bool Contains(User user)
        {
            Node currentNode = first;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(user))
                {
                    throw new InvalidOperationException($"The list already contains user: {user}"); // Kastes hvis brugeren allerede findes i listen
                }
                currentNode = currentNode.Next;
            }
            return false;
        }



        //
        // Sorteret liste
        //

        public void Add(User user)
        {
            Node newNode = new Node(user, first);

            // Hvis listen er tom eller den nye bruger skal være den første
            if (first == null || string.Compare(first.Data.Name, user.Name, StringComparison.Ordinal) > 0)
            {
                newNode.Next = first;
                first = newNode;
                return;
            }

            // Find den korrekte position at indsætte den nye node
            Node currentNode = first;
            while (currentNode.Next != null && string.Compare(currentNode.Next.Data.Name, user.Name, StringComparison.Ordinal) < 0)
            {
                currentNode = currentNode.Next;
            }

            // Indsæt den nye node på den fundne position
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
        }

        // Metode til at udskrive listen for at teste om den er korrekt sorteret
        public void PrintList()
        {
            Node currentNode = first;
            while (currentNode != null)
            {
                Console.WriteLine($"User: {currentNode.Data.Name}");
                currentNode = currentNode.Next;
            }
        }
    }
}