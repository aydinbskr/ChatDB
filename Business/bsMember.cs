using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace Business
{
    public class bsMember
    {
        public doMember Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Kullanıcı adı boş olamaz");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Şifre boş olamaz");

            List<doMember> memberList = new daMember().GetAllMembers(null, username, password, false, false);

            if (memberList.Count > 0)
                MakeMemberOnline(memberList[0]);

            return memberList.FirstOrDefault();
        }

        internal void BanUser(doMember member)
        {
            member.Banned = true;
            new daMember().UpdateMember(member);
        }

        private void MakeMemberOnline(doMember member)
        {
            member.Online = true;
            new daMember().UpdateMember(member);
        }

        public void LogOut(doMember member)
        {
            member.Online = false;
            new daMember().UpdateMember(member);
        }

        public doMember GetMember(int id)
        {
            return new daMember().GetAllMembers(id, null, null, null, null).FirstOrDefault();
        }

        public List<doMember> OnlineKullanicilariGetir()
        {
            return new daMember().GetAllMembers(null, null, null, false, true);
        }
    }
}
