
using CopytoDO.Data;
using CopytoDO.Models;
using CopytoDO.Utilities;
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
        
        static void Main(string[] args)
        {
            
           CallLogger callLogger = new CallLogger();
            callLogger.Content = "Done this";
            callLogger.WriteToFile(callLogger.Content);
            //Console.WriteLine("Test");
           ReadProduct();

            //try
            //{
            //    Logger.Info("Hello world");
            //    Console.WriteLine("Now this");
            //    Console.WriteLine("Now thisone");
            //    System.Console.ReadKey();
                
            //}
            //catch (Exception ex)
            //{
            //    Logger.Error(ex, "Goodbye cruel world");
            //}





        }

        static void ReadProduct()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            List<Reasondetail> test = new List<Reasondetail>();
            using (CustomDBContext dbout = new CustomDBContext(configuration))
            {

                test = dbout.Reasondetails.FromSqlRaw("EXECUTE spGetLatestData").ToList();

            }

            using (CustomDestDBContext dbin = new CustomDestDBContext(configuration))
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
                StopMreason = pf.StopMreason ?? throw new ArgumentNullException(nameof(pf.StopMreason), "Master Stop Reason cannot be null"),
                StopSreason = pf.StopSreason ?? throw new ArgumentNullException(nameof(pf.StopSreason), "Sub Stop Reason cannot be null"),

            };
        }

        //testVar1 != null ? testvar1 : testvar2;
       

    }


}