using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGruppF.Models
{
    public class savedFreelancersM
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string adress { get; set; }
        public int? phonenumber { get; set; }
        public string email { get; set; }

        public List<savedFreelancersM> SavefreeMList()
        {
            ProjektGruppFEntities pg = new ProjektGruppFEntities();
            List<savedFreelancersM> savefreeMList = new List<savedFreelancersM>();

            var savedFreelancersList = (from free in pg.freelancer
                                        select new
                                        {
                                            free.firstname,
                                            free.lastname,
                                            free.adress,
                                            free.phonenumber,
                                            free.email
                                        }).ToList();
            foreach (var item in savedFreelancersList)
            {
                savedFreelancersM objcvm = new savedFreelancersM();
                objcvm.firstname = item.firstname;
                objcvm.lastname = item.lastname;
                objcvm.adress = item.adress;
                objcvm.phonenumber = item.phonenumber;
                objcvm.email = item.email;
                savefreeMList.Add(objcvm);
            }
            return savefreeMList;
        }
    }
}