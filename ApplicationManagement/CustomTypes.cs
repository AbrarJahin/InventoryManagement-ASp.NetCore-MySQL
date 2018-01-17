namespace ApplicationManagement.DbModel
{
    public class CustomTypes
    {
        public enum IsMarried
        {
            Unmarried = 0,
            Married
        }

        public enum ReligionName
        {
            Islam = 0,
            Hinduism,
            Buddhists,
            Christians,
            Animists,
            Atheist
        }

        public enum SelectionStatus
        {
            Pending=0,
            Selected,
            NotSelected
        }

        public enum PaymentStatus
        {
            Pending = 0,
            Done,
            PaymentNotDone
        }

        public enum OrganizationType
        {
            Government = 0,
            SemiGovernment,
            Autonomous,
            NonGovernment
        }

        public enum Decision
        {
            Yes = 0,
            No,
            NoComment
        }

        public enum ApplicationTypes
        {
            Teacher = 0,
            StudentAdmission,
            Officer,
            Stuff
        }
    }
}
