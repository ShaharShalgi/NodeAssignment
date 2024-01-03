namespace NodeAssignment
{
    internal class Program
    {
        //פעולה המקבלת מצביע לחוליה 
        //מחזירה אמת אם החוליות מסודרות בסדר עולה
        //ושקר אחרת
        //אורך הקלט n: מספר החוליות
        //המקרה הגרוע: 
        // 6n + 1
        //הפעולה מתבצעת פעם אחת ובכל סיבוב הלולאה מתבצעות 6 פעולות מכאן שסיבוכיות הפעולה: 
        //O(n)


        public static bool IsAscending(Node<int> lst)
        {
            while (lst.HasNext())
            {
                if (lst.GetValue() > lst.GetNext().GetValue())
                {
                    return false;
                }
                lst = lst.GetNext();
            }
            return true;

        }

        //אורך הקלט n: מספר החוליות
        //המקרה הגרוע:
        //8n + 1
        //הפעולה מבצעת 
        // n 
        //קריאות ובכל קריאה הלולאה מתבצעות 8 פעולות מכאן שסיבוכיות הפעולה: 
        //O(n)

        //כמו קודם רק מימוש רקורסיבי
        public static bool IsAscendingRecursive(Node<int> lst)
        {
            if (!lst.HasNext()) { return true; }
            if (lst.GetValue() > lst.GetNext().GetValue()) { return false; }
            
            return IsAscendingRecursive(lst.GetNext());
        }

        //פעולה גנרית המחזירה אמת אם 
        //x 
        //קיים בשרשרת החוליות 
        //lst
        //ושקר אחחרת
        //שימו לב שבפעולה גנרית אין 
        //לא ניתן להשתמש ב
        //==
        //יש להתשמש בפעולה של
        //object
        //Equals

        //אורך הקלט n: מספר החוליות
        //המקרה הגרוע: 
        //4n + 1
        //הפעולה מתבצעת פעם אחת ובכל סיבוב הלולאה מתבצעות 4 פעולות מכאן שסיבוכיות הפעולה: 
        //O(n)
        public static bool IsExists<T>(Node<T> lst, T x)
        {
            while(lst!=null)
            {
                if(lst.GetValue().Equals(x))
                { 
                    return true; 
                }
                lst= lst.GetNext();
            }
            return false;
        }
        //אורך הקלט n: מספר החוליות
        //המקרה הגרוע:
        //6n + 1
        //הפעולה מבצעת
        //n
        //קריאות ובכל קריאה הלולאה מתבצעות 6 פעולות מכאן שסיבוכיות הפעולה: 
        //O(n)

        public static bool IsExistsRecursive<T>(Node<T> lst, T x)
        {
            if (lst.GetValue().Equals(x)) { return true; }
            if(!lst.HasNext()) { return false; }
            return IsExistsRecursive(lst.GetNext(), x);
        }

        //public static Node<T> Create<T>(int from, int to, int quantity)
        //{
        //    Random rnd = new Random();
        //    int j = rnd.Next(from, to+1);
        //    for(int i = 0; i < quantity; i++)
        //    {
        //        int place = rnd.Next(from, to + 1);
        //        Node<int> node = new Node<int>(j);

        //    }
        //}
        public static Node<T> DeleteValue<T>(Node<T> node, T value)
        {
            Node<T> head = node;
            if (node.GetValue().Equals(value))
            {
                head = node.GetNext();
                node.SetNext(null);
            }
            else
            {
                Node<T> next = node.GetNext();
                while (node.HasNext() && !next.GetValue().Equals(value))
                {
                    node = node.GetNext();
                    next = node.GetNext();
                }
                if (node.HasNext())
                {
                    node.SetNext(node.GetNext().GetNext());
                    node.GetNext().SetNext(null);
                }
            }
            return head;
        }
        public static int Sequence(Node<int> seq, int num)
        {
            Node<int> dummy = new Node<int>(0, seq);
            int counter = 0;
            if(!IsExists(seq, num))
            {
                return 0;
            }
            
            while(seq.HasNext())
            {
                if(seq.GetValue() == num && dummy.GetValue() != num)
                    counter++;
                dummy = seq;
                seq = seq.GetNext();

            }
            return counter;
        }
        public static string OddOrEven(Node<int> seq)
        {
            
            int evencounter = 0;
            int oddcounter = 0;
            

            while (seq.HasNext())
            {
                if (seq.GetValue() %2==0)
                    evencounter++;
                else oddcounter++;
                seq = seq.GetNext();

            }
            if (evencounter == oddcounter)
                return "s";
            else if (oddcounter > evencounter)
                return "e";
            else
                return "z";
        }




        static void Main(string[] args)
        {
            Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(7))));//[4, next]=>[5, next]=>[6, next]=>[7, next]=>null

            Console.WriteLine(IsAscending(lst1));//should print True
            Console.WriteLine(IsAscendingRecursive(lst1));//should print True
            Node<int> lst2 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(2))));//[4, next]=>[5, next]=>[6, next]=>[2, next]=>null
            Console.WriteLine(IsAscending(lst2));//should print False
            Console.WriteLine(IsAscendingRecursive(lst2));//should print False
            Node<int> lst3 = new Node<int>(4, new Node<int>(5, new Node<int>(4, new Node<int>(9))));//[4, next]=>[5, next]=>[4, next]=>[9, next]=>null
            Console.WriteLine(IsAscending(lst3));//should print False
            Console.WriteLine(IsAscendingRecursive(lst3));//should print False

            Node<char> lst4 = new Node<char>('t', new Node<char>('A', new Node<char>('l', new Node<char>('s', new Node<char>('i')))));//['t', next]=>['a', next]=>['l', next]=>['s', next]=>['i', next]=>null
            Console.WriteLine(IsExists(lst1, 5));//should print True
            Console.WriteLine(IsExists(lst4, 'i'));//should print True
            Console.WriteLine(IsExists(lst4, 'I'));//should print False
            Console.WriteLine(IsExistsRecursive(lst1, 5));//should print True
            Console.WriteLine(IsExistsRecursive(lst4, 'i'));//should print True
            Console.WriteLine(IsExistsRecursive(lst4, 'I'));//should print False


        }

    }
}
