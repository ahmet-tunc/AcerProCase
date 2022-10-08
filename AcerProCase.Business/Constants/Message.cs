﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcerProCase.Business.Constants
{
    public static class Message
    {
        public static string Added = "Yeni kayıt işlemi başarıyla gerçekleştirildi";
        public static string AddedList = "Yeni liste kayıt işlemi başarıyla gerçekleştirildi";
        public static string AddedFailed = "Yeni kayıt işlemi gerçekleştirilemedi";
        public static string AddedListFailed = "Yeni liste kayıt işlemi gerçekleştirilemedi";

        public static string Updated = "Kayıt güncelleme işlemi başarıyla gerçekleştirildi";
        public static string UpdatedList = "Kayıt listesi güncelleme işlemi başarıyla gerçekleştirildi";
        public static string UpdatedFailed = "Kayıt güncelleme işlemi gerçekleştirilemedi";
        public static string UpdatedListFailed = "Kayıt listesi güncelleme işlemi gerçekleştirilemedi";

        public static string Deleted = "Kayıt silme işlemi başarıyla gerçekleştirildi";
        public static string DeletedList = "Kayıt listesi silme işlemi başarıyla gerçekleştirildi";
        public static string DeletedFailed = "Kayıt silme işlemi gerçekleştirilemedi";
        public static string DeletedListFailed = "Kayıt listesi silme işlemi gerçekleştirilemedi";

        public static string Get = "İlgili kayıt başarıyla listelenmiştir";
        public static string GetAll = "İlgili kayıtlar başarıyla listelenmiştir";
        public static string GetFailed = "İlgili kayıt listeleme işlemi başarısız olmuştur";
        public static string GetAllFailed = "İlgili kayıtları listeleme işlemi başarısız olmuştur";

        public static string ExistingRecord = "Veritabanında böyle bir kayıt zaten var";
    }
}
