using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektGruppF.ViewModels;
using ProjektGruppF.Models;

namespace ProjektGruppF.Models
{
    public class savedFreelancersOperations
    {
        ProjektGruppFEntities pg = new ProjektGruppFEntities();
        public List<SavedFreelancersVM> AllFreelancers()
        {
            List<SavedFreelancersVM> savefreeMList = new List<SavedFreelancersVM>();

            var savedFreelancersList = (from free in pg.freelancer
                                        select new
                                        {
                                            free.firstname,
                                            free.lastname,
                                            free.adress,
                                            free.phonenumber,
                                            free.email,
                                        }).ToList();
            foreach (var item in savedFreelancersList)
            {
                SavedFreelancersVM objcvm = new SavedFreelancersVM();
                objcvm.Firstname = item.firstname;
                objcvm.Lastname = item.lastname;
                objcvm.Adress = item.adress;
                objcvm.Phonenumber = item.phonenumber;
                objcvm.Email = item.email;
                savefreeMList.Add(objcvm);
            }
            return savefreeMList;
        }

        public List<SavedFreelancersVM> AllSkills()
        {
            List<SavedFreelancersVM> allSkills = new List<SavedFreelancersVM>();

            var savedFreelancersList = (from s in pg.skill
                                        select new
                                        {
                                            s.name
                                        }).ToList();
            foreach (var item in savedFreelancersList)
            {
                SavedFreelancersVM objcvm = new SavedFreelancersVM();
                objcvm.Skillname = item.name;
                allSkills.Add(objcvm);
            }
            return allSkills;
        }
    }
}