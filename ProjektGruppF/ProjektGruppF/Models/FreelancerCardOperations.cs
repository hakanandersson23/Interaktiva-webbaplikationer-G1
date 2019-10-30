using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;

namespace ProjektGruppF.Models
{
    public class FreelancerCardOperations
    {
        public List<FreelanceCardVM> fc = new List<FreelanceCardVM>
        {
            new FreelanceCardVM{Name="Erik", Lastname="Oberg"},
            new FreelanceCardVM{Name="Eva", Lastname="Morlind"}
        };

        public List<FreelanceCardVM> fcList = new List<FreelanceCardVM>
                {
                    new FreelanceCardVM{Name="Erik", Lastname="Oberg", Age=40 , Nationality="Swedish", Language="Swedish", Skill="Programming",Expertise="C#",Rank=5},
                    new FreelanceCardVM{Name="Sabrina", Lastname="Thao", Age=21 , Nationality="Swedish", Language="Swedish", Skill="Programming",Expertise="html",Rank=2},
                    new FreelanceCardVM{Name="Eva", Lastname="Evva", Age=42 , Nationality="English", Language="English", Skill="Programming",Expertise="C#",Rank=3},
                    new FreelanceCardVM{Name="Joe", Lastname="Jooe", Age=23 , Nationality="Swedish", Language="Swedish", Skill="Programming",Expertise="C#",Rank=4},
                    new FreelanceCardVM{Name="Ida", Lastname="Idda", Age=34 , Nationality="Finnish", Language="Finnish", Skill="Programming",Expertise="C#",Rank=1},
                    new FreelanceCardVM{Name="Ola", Lastname="Olla", Age=51 , Nationality="Norwegian", Language="Norwegian", Skill="Programming",Expertise="C#",Rank=2}
                };

        public List<FreelanceCardVM> GetCards()
        {
            return fcList;
        }

    }
}