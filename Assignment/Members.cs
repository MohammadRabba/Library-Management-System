using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public enum MembershipType
    {
        Student, Faculty,
        Manager

    }
    public class Member
    {
        public static int count = 1;
        public readonly int ID;
        public string Name { get; set; }
        public MembershipType MembershipType { get; set; }
        public readonly int BorrowingLimit;
        public Member(string name, MembershipType membershipType)
        {
            ID = count;
            Name = name;
            MembershipType = membershipType;
            count++;
            if (membershipType == MembershipType.Student)
            {
                BorrowingLimit = 2;
            }
            else if (membershipType == MembershipType.Faculty) { BorrowingLimit = 5; } else { BorrowingLimit = 0; }
        }


    }
}
