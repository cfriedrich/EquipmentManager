using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Concrete
{
    public class EFMemberRepository : I_MemberRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Member> Members
        {
            get { return context.Members; }
        }

        public void AddMember(Entities.Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
        }

        public void SaveMember(Member member)
        {
            if (member.MemberID == 0)
            {
                context.Members.Add(member);
            }
            else
            {
                Member dbEntry = context.Members.Find(member.MemberID);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = member.FirstName;
                    dbEntry.LastName = member.LastName;
                    dbEntry.Email = member.Email;
                    dbEntry.CanCheckout = member.CanCheckout;
                }
            }
            context.SaveChanges();
        }

        public Member DeleteMember(int memberID)
        {
            Member dbEntry = context.Members.Find(memberID);
            if (dbEntry != null)
            {
                context.Members.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Member GetMember(int memberID)
        {
            Member member = context.Members.Find(memberID);

            return member;
        }
        
    }
}
