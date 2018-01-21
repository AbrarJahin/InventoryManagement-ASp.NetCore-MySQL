using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationManagement.DbModel;
using static ApplicationManagement.DbModel.CustomTypes;
using System.Collections.Generic;

namespace ApplicationManagement.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Index()
        {
            _context.JobCirculars.Add(new JobCircular
            {
                NoticeImageFileUrl = "ডেমো ডাটা ডেমো ডাটা ডেমো ডাটা",
                PostName = "ডেমো ডাটা",
                Description = "ডেমো ডাটা",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Application For Applying As A Teacher";

            Random rnd = new Random();
            UInt16 year = (UInt16)rnd.Next(1999, 2017);

            JobCircular jobCircular = _context.JobCirculars
                                        .SingleOrDefault(j => j.Id == 1);

            Address presentAddress = new Address
            {
                HoldingNoOrVillage = "1234",
                RoadBlockSector = "28",
                Thana = "Kotawoli",
                PostOffice = "Rupatoli",
                District = "Barisal"
            };

            Address permanentAddress = new Address
            {
                HoldingNoOrVillage = "86/3",
                RoadBlockSector = "2 No Cross Road",
                Thana = "Daulatpur",
                PostOffice = "Daulatpur",
                District = "Khulna"
            };

            ICollection<Experience> experiences = new List<Experience>();
            for (int i = 0; i < 4; i++)
            {
                Experience experience = new Experience
                {
                    NameOfPost = i.ToString(),
                    NameOfOrganization = i.ToString(),
                    OrganizationType = OrganizationType.Government,
                    SalaryScale = (UInt16)rnd.Next(1999, 2017),
                    TotalSalary = (UInt16)rnd.Next(1999, 2017),
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow
                };
                experiences.Add(experience);
            }

            Person person = new Person {
                ProfileImageFileUrl = "asd asd asd asd asd sadas dasd asd",
                BengaliName = "a sdasd asd asd asd asd",
                EnglishName = "Asasd asd asd asd asd",
                NickName = "Rs dsd fsdaf sdf sdf",
                PhoneNumber = "+8801822804636",
                Email = "abrarja@asd.asd",
                FatherName = "asd asd asd asd",
                DateOfBirth = DateTime.UtcNow,
                PresentAddress = presentAddress,
                PermanentAddress = permanentAddress,
                Nationality = "Bangladeshi",
                MaritalStatus = IsMarried.Unmarried,
                Religion = ReligionName.Islam,
                NId = 1000000009,
                IsInvolvedWithAnyAssociation = Decision.No,
                IsEverSuspended = Decision.No,
                Experiences = experiences
            };

            Payment payment = new Payment {
                BankDraftOrPayOrderNo = "",
                DateOfDraftOrOrder = DateTime.UtcNow,
                AmountOfMoney = 10,
                NameOfBank = "asd asd asd",
                BranchOfBank = "Asdas dasd asd a"
            };

            TeacherApplication teacherApplication = new TeacherApplication {
                JobCircular = jobCircular,
                Person = person,
                AgeAtLastDateOfSubmission = jobCircular.EndDate - person.DateOfBirth,
                HasContactWithAnyOrganization = Decision.No,
                IsGettingPension = Decision.No,
                Payment = payment
            };

            for (int i = 1; i < 4; i++)
            {
                Country country = _context.Countries
                                        .SingleOrDefault(c => c.Id == i);
                CountryPerson countryPerson = new CountryPerson
                {
                    Country = country,
                    Person = person,
                    ReasonOfTour = i.ToString()
                };
                _context.CountryPersons.Add(countryPerson);
            }

            _context.TeacherApplications.Add(teacherApplication);
            await _context.SaveChangesAsync();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please enter data";

            return View();
        }

        [HttpPost]
        public IActionResult ContactPost(ViewModel.TeacherApplication teacherApplication)
        {
            ViewData["Message"] = teacherApplication.BengaliName;

            return View("~/Views/Home/Contact.cshtml");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
