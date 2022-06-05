using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Collections;

namespace Business
{
    public class bsMessage : IComparer<doMessage>
    {
        public List<doMessage> GetAllMessage(int? id, int? to, int? from, bool? isToRead, bool? isToDeleted, bool? isFromDeleted, DateTime? minDate)
        {
            return new daMessage().GetAllMessage(id, to, from, isToRead, isToDeleted, isFromDeleted, minDate);
        }

        public void InsertMessage(int? to, int from, string body)
        {
            if (from <= 0)
            {
                throw new Exception("Böyle bir kullanıcı mesaj gönderemez");
            }
            if (body.IndexOf("sdr") > -1)
            {
                new bsMember().BanUser(new bsMember().GetMember(from));
                throw new Exception("Küfür yok hacı");
            }
            if (string.IsNullOrWhiteSpace(body))
                throw new Exception("Boş mesaj atılamaz");

            new daMessage().InsertMessage(to, from, body);
        }

        public int Compare(doMessage x, doMessage y)
        {
            if (x.Date > y.Date)
                return 1;
            else if (x.Date < y.Date)
                return -1;
            else
                return 0;
        }

        public List<doMessage> GetPrivateMessagesBetween(int who, int whom)
        {
            List<doMessage> benimGonderdigimMesajlar = new bsMessage().GetAllMessage(null, who, whom, false, false, false, DateTime.Now.Subtract(new TimeSpan(0, 5, 0)));
            List<doMessage> banaGonderilenMesajlar = new bsMessage().GetAllMessage(null, whom, who, false, false, false, DateTime.Now.Subtract(new TimeSpan(0, 5, 0)));

            List<doMessage> tumMesajlar = new List<doMessage>();
            tumMesajlar.AddRange(benimGonderdigimMesajlar);
            tumMesajlar.AddRange(banaGonderilenMesajlar);

            bsMessage msj = new bsMessage();
            tumMesajlar.Sort(msj);

            return tumMesajlar;
        }
    }
}
