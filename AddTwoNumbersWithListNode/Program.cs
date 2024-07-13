using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbersWithListNode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 9, 9, 9, 9, 9, 9, 9 };
            int[] arr2 = { 9, 9, 9, 9 };
            ListNode l1 = ArrayToListNode(arr);
            ListNode l2 = ArrayToListNode(arr2);
            ListNode l3 = AddTwoNumbers(l1, l2);

        }
        //Method of adding two ListNode objects
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            int count = 0;
            if (l1.val + l2.val >= 10)
            {
                head = new ListNode((l1.val + l2.val) % 10);
                count++;
            }
            else
            {
                head = new ListNode(l1.val + l2.val);
            }
            ListNode current = head;
            while (l1.next != null || l2.next!= null) //Addition is performed until the next value is null in both ListNodes.
            {
                if (l1.next != null)                  //If the next value is not null, it is switched to the other ListNode.
                {
                    l1 = l1.next;
                }
                else                                  //If the next value is null, no transition is made and the value 0 is assigned as value.
                {
                    l1.val = 0;
                }
                if (l2.next != null)
                {
                    l2 = l2.next;
                }
                else
                {
                    l2.val = 0;
                }
                if (l1.val + l2.val + count>=10)      
                {
                    current.next = new ListNode((l1.val + l2.val+count)%10);
                    count = 0;
                    count++;
                }
                else if(count>0)
                {
                    current.next = new ListNode(l1.val + l2.val+count);
                    count = 0;
                }
                else
                {
                    current.next = new ListNode(l1.val + l2.val);
                }
                
                current = current.next;
            }
            if ((l1.next == null && l2.next == null && count > 0)) //When both ListNodes are null, if there is a count value, the next ListNode is assigned the count value.
            {
                current.next = new ListNode(count);
            }
            return head;

        }
        //Method of converting Array to ListNode
        public static ListNode ArrayToListNode(int[] arr)
        {
            ListNode head = new ListNode(arr[0]);
            ListNode current = head;
            for (int i = 0; i < arr.Length; i++)
            {
                current.next = new ListNode(arr[i]);//A new ListNode is assigned to current.next and the new ListNode is defined as current and the assignment process continues.
                current = current.next;
            }

            return head;
        }

    }
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
      {
            this.val = val;
            this.next = next;
      }
    }
}
