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
                                        join c in pg.cv on free.cv_id equals c.cv_id
                                        select new
                                        {
                                            free.freelancer_id,
                                            free.firstname,
                                            free.lastname,
                                            free.adress,
                                            free.phonenumber,
                                            free.email,
                                            c.cv_id
                                        }).ToList();
            foreach (var item in savedFreelancersList)
            {
                SavedFreelancersVM objcvm = new SavedFreelancersVM();
                objcvm.Freelancer_id = item.freelancer_id;
                objcvm.Firstname = item.firstname;
                objcvm.Lastname = item.lastname;
                objcvm.Adress = item.adress;
                objcvm.Phonenumber = item.phonenumber;
                objcvm.Email = item.email;
                objcvm.Cv_id = item.cv_id;
                savefreeMList.Add(objcvm);
            }
            return savefreeMList;
        }

        public freelancer GetFreelancer(int id)
        {
            var freelancer = (from free in pg.freelancer
                              where free.freelancer_id == id
                              select new
                              {
                                  free.firstname,
                                  free.lastname,
                                  free.adress,
                                  free.phonenumber,
                                  free.email,

                              }).SingleOrDefault();
            freelancer f = new freelancer()
            {

                firstname = freelancer.firstname,
                lastname = freelancer.lastname,
                adress = freelancer.adress,
                phonenumber = freelancer.phonenumber,
                email = freelancer.email


            };

            return f;



        }

        /*public List<SavedFreelancersVM> AllSkills()
        {
            List<SavedFreelancersVM> allSkills = new List<SavedFreelancersVM>();

            var list = (from s in pg.skill
                                        select new
                                        {
                                            s.name
                                        }).ToList();
            foreach (var item in list)
            {
                SavedFreelancersVM objcvm = new SavedFreelancersVM();
                objcvm.Skillname = item.name;
                allSkills.Add(objcvm);
            }
            return allSkills;
        }

        public List<SavedFreelancersVM> AllExpertises()
        {
            List<SavedFreelancersVM> allExpertises = new List<SavedFreelancersVM>();

            var list = (from e in pg.expertise
                                        select new
                                        {
                                            e.name
                                        }).ToList();
            foreach (var item in list)
            {
                SavedFreelancersVM objcvm = new SavedFreelancersVM();
                objcvm.Expertisename = item.name;
                allExpertises.Add(objcvm);
            }
            return allExpertises;
        }

        public List<SavedFreelancersVM> AllRanks()
        {
            List<SavedFreelancersVM> allRanks = new List<SavedFreelancersVM>();

            var list = (from r in pg.rank_expertise
                        select new
                        {
                            r.rank_expertise_Id
                        }).ToList();
            foreach (var item in list)
            {
                SavedFreelancersVM objcvm = new SavedFreelancersVM();
                objcvm.ExpertiseRank = item.rank_expertise_Id;
                allRanks.Add(objcvm);
            }
            return allRanks;
        }*/
    }
}