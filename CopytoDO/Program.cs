using CopytoDO.DAL;
using CopytoDO.Data;
using CopytoDO.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Reflection.PortableExecutable;

namespace CopytoDO
{
    internal class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Console.WriteLine("Test");
            ReadProduct();

            try
            {
                Logger.Info("Hello world");
                Console.WriteLine("Now this");
                System.Console.ReadKey();
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Goodbye cruel world");
            }





        }

        static void ReadProduct()
        {
            List<Reasondetail> test = new List<Reasondetail>();
            using (CustomDBContext dbout = new CustomDBContext())
            {

                test = dbout.Reasondetails.FromSqlRaw("EXECUTE spGetLatestData").ToList();

            }

            using (CustomDestDBContext dbin = new CustomDestDBContext())
            {
                //List<OeeDetailsAll> oeedet = test.ConvertAll(new Converter<Reasondetail,OeeDetailsAll>(PointFToPoint));
                ////dbin.AddRange(oeedet);
                ////dbin.SaveChanges();

                dbin.Database.ExecuteSqlRaw("spInsertIntoOeeDetails @StopTimeLocalID, @OeeMachine, @StopReasonStart,@StopReasonEnd,@Stop_MReason,@Stop_SReason",
                new SqlParameter("@StopTimeLocalID", test[0].StopTimeId),
                new SqlParameter("@OeeMachine", 2),
                new SqlParameter("@StopReasonStart", test[0].StopTimeStart),
                new SqlParameter("@StopReasonEnd", test[0].StopTimeEnd),
                new SqlParameter("@Stop_MReason", test[0].StopMreason),
                new SqlParameter("@Stop_SReason", test[0].StopSreason)
                );
            }
            return;
        }

        public static OeeDetailsAll PointFToPoint(Reasondetail pf)
        {
            return new OeeDetailsAll()
            {
                StopTimeLocalId = pf.StopTimeId,
                OeeMachine = 5,
                StopReasonStart = pf.StopTimeStart ?? throw new ArgumentNullException(nameof(pf.StopTimeStart), "DateTime cannot be null"),
                StopReasonEnd = pf.StopTimeEnd ?? throw new ArgumentNullException(nameof(pf.StopTimeStart), "DateTime cannot be null"),
                StopMreason = pf.StopMreason,
                StopSreason = pf.StopSreason

            };
        }

        //testVar1 != null ? testvar1 : testvar2;
       

    }


}