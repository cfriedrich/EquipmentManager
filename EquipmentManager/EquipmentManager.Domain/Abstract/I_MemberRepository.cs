using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Abstract
{
    public interface I_MemberRepository
    {
        IQueryable<Member> Members { get; }
        void SaveMember(Member Member);
        Member DeleteMember(int MemberID);
        Member GetMember(int MemberID);
        //test comment
    }
}
