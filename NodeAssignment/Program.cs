﻿using System.Xml.Linq;

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

        //שאלה שש 
        public static Node<T> NoDoubles<T>(Node<T> node)
        {
            
            Node<T> complete = new Node<T>(default);//ניצור את רשימת החוליות שנחזיר
            Node<T> dummy = new Node<T>(default, complete);//דאמי
            while (node!=null)
            {
                while(complete!=null)
                {
                    if (!complete.GetNext().GetValue().Equals(node.GetValue()))
                    {
                        complete.SetValue(node.GetValue());
                    }
                    complete= complete.GetNext();
                }
                node= node.GetNext();

            }
            return dummy.GetNext();
        }
        //אורך הקלט - מספר החוליות
        //המקרה הגרוע - אין כפילויות או יש כפילות באחרון
        //הפעולה תבצע
        //n^2 - אן בריבוע 
        //O(n^2)

        // שאלה שמונה

        public static bool IsAscending2(Node<int> lst)
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

        //אורך הקטל - מספר החוליות
        //הפעולה תבצע 
        //n
        //המקרה הגרוע - הרשימה ממויינת או שהאחרון לא ממויין
        //O(n)

        //שאלה עשר
        public static Node<int> Series(int beginner, int quantity)
        {
            
            Node<int> node = new Node<int>(beginner);//ניצור את החוליה הראשונה
            
            Node<int> next = node.GetNext();//ניצור מצביע לנקסט של החוליה שיצרנו
            
            for(int i = beginner+1; i< quantity-1; i++) 
            {
                //נשים בהבא בתור את האיי שהוא בעצם כל פעם בגינר םלוס אחד והאיי משתנה
                next.SetValue(i);
                //נקדם את המצביע
                next = next.GetNext();

            }
            return node;
        }

        //אורך הקלט - מספר חוליות
        //מקרה גרוע - הרווח גדול? 
        //O(n)

        //שאלה 12
        public static bool IsBalanced(Node<int> node)
        {
            int count = 0;
            int countLess = 0;
            int total = 0;
            int countMore = 0;
            while (node != null)//נמצא את הטוטאל של הכל וכמות התאים בשביל חישוב הממוצע
            {
                total+= node.GetValue();
                count++;
                node= node.GetNext();
            }
            for (int i = 0; i < count; i++)//כיוון שמצאנו את כמות החוליות נרוץ עליה ונבדוק לגבי כל אחד האם הוא מעל או מתחת לממוצע
            {
                if (node.GetValue() < (double)total / count)
                    countLess++;
                else if (node.GetValue() > (double)total / count)
                    countMore++;
                
                node = node.GetNext();
            }
            if (countLess == countMore)
                return true;
            return false;
        }
        //אורך הקלט - מספר החוליות
        //מקרה גרוע - הערכים שקטנים מהממוצע שווים לערכים שגדולים מהממוצע
        //O(n)

        //שאלה 14
        public static Node<int> DeleteNAll(int n, Node<int> node)
        {
            int biggest = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                while (node != null)
                {
                    if (node.GetValue() > node.GetNext().GetValue())
                    {
                        biggest = node.GetValue();
                    }
                    else
                    {
                        biggest = node.GetNext().GetValue();
                    }

                }
                node = DeleteValue(node,biggest);
                
            }
            return node;
        }
        //אורך קלט - מספר חוליות
        //מקרה גרוע - כשהשרשרת ממויינת מלמטה למעלה
        //סיבוכיות - O(n^2)
        public static int Bigger(Node<int> lis1, Node<int> lis2)
        {
            
            if (Count(lis1) > Count(lis2))
            {
                return 1;
            }
            else if (Count(lis2) > Count(lis1))
                return 2;

            while(lis1 != null || lis2 != null) 
            {
                if (lis1.GetValue() > lis2.GetValue())
                    return 1;
                else if (lis2.GetValue() > lis1.GetValue())
                    return 2;
                lis1 = lis1.GetNext();
                lis2 = lis2.GetNext();
            }
            return 0;

            
        }
        public static int Count(Node<int> node)
        {
            int counter = 0;
            while(node != null)
            {
                counter++;
                node = node.GetNext();
            }
            return counter;
        }

        public static Node<T> DeleteList<T>(Node<T> lis1, Node<T> lis2)
        {
            Node<T> dummy = new Node<T>(default, lis1);
            
            while(lis2 != null)
            {
                lis1 = WhereSequence(lis1, lis2);
                lis1 = DeleteValue(lis1, lis2.GetValue());
                lis1 = lis1.GetNext();
                lis2 = lis2.GetNext();
              
            }
            return dummy.GetNext();
        }
        public static Node<T> WhereSequence<T>(Node<T> lis1, Node<T> lis2)
        {
            Node<T> SequenceHead = null;
            while(lis1 != null && lis2 != null)
            {
                if (lis1.GetValue().Equals(lis2.GetValue()))
                {
                    SequenceHead = lis1;
                    Node<T> Temp1 = lis1;
                    Node<T> Temp2 = lis2;

                    while(lis2 != null)
                    {
                        lis1 = lis1.GetNext();
                        lis2 = lis2.GetNext();
                        if (!lis1.GetValue().Equals(lis2.GetValue()))
                        {
                            SequenceHead = null;
                        }
                      } 

                    lis1 = Temp1;
                    lis2 = Temp2;
                    
                }
                else
                {
                    SequenceHead = null;
                }
                lis1 = lis1.GetNext();
                lis2 = lis2.GetNext();
            }
            return SequenceHead;
        }
        public static Node<T> Merge<T>(Node<T> list1,  Node<T> list2)
        {
            Node<T> Head = new Node<T>(list1.GetValue());
            Node<T> next = Head;
            while (list1 != null && list2 != null)
            {
                
                next.SetNext(new Node<T>(list2.GetValue()));
                next.GetNext().SetNext(new Node<T>(list1.GetValue()));
                next = next.GetNext();
                list1 = list1.GetNext();
                list2 = list2.GetNext();
            }
            
                while(list1 != null)
                {
                    next.SetNext(new Node<T>(list1.GetValue()));
                    list1 = list1.GetNext(); 
                    next = next.GetNext();
                }
            
                while (list2 != null)
                {
                    next.SetNext(new Node<T>(list2.GetValue()));
                    list2 = list2.GetNext();
                    next = next.GetNext();
                }
            
            return Head;
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
