using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGruppF.Models
{
    public class CvFreelancerOperations
    {

        public void AddCv(cv cv)

        //trycatch

        {
            cv cvModel = new cv();

            using (ProjektGruppFEntities dbModel = new ProjektGruppFEntities())
            {
               
               
                {
                    dbModel.cv.Add(cvModel);  
                    dbModel.SaveChanges();

                }
            }
        }
    }
} 